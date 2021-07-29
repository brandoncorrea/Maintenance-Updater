using Maintenance_Updater.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maintenance_Updater.Editor
{
    public static class FileUpdater
    {
        private static readonly string[] PrereqIds = new string[] { "SU", "OG", "FA", "CA", "CL" };
        private static readonly string[] ItemIds = new string[] { "SK", "IT", "PK", "IL", "SP" };

        private const long TYPE_2_MIN = 20000000000;
        private const long TYPE_2_MAX = 29999999999;

        // Updates a maintenance file by adding another maintenance file on top of it
        public static Task UpdateFileAsync(string baseFile, string layerFile, string saveLocation) => Task.Run(() => UpdateFile(baseFile, layerFile, saveLocation));
        public static Task UpdateFileAsync(string baseFile, IEnumerable<string> layerFiles, string saveLocation) => Task.Run(() => UpdateFile(baseFile, layerFiles, saveLocation));
        public static void UpdateFile(string baseFile, string layerFile, string saveLocation) => UpdateFile(baseFile, new string[] { layerFile }, saveLocation);
        public static void UpdateFile (string baseFile, IEnumerable<string> layerFiles, string saveLocation)
        {
            // Get a file that does not already exist
            string updatesPath = saveLocation + ".updates.csv";
            for (int i = 0; File.Exists(updatesPath); i++)
                updatesPath = $"{saveLocation}_{i}.updates.csv";
            
            // Update lines
            foreach (string file in layerFiles)
            {
                File.WriteAllLines(saveLocation, GetUpdatedLines(baseFile, file, updatesPath));
                baseFile = saveLocation;
            }   
        }

        public static List<string> GetUpdatedLines(string baseFile, string newFile, string updatesPath) => GetUpdatedLines(File.ReadAllLines(baseFile), File.ReadAllLines(newFile), updatesPath);
        public static List<string> GetUpdatedLines(IEnumerable<string> baseLines, IEnumerable<string> newLines, string updatesPath)
        {
            // Read all required lines needed
            List<string> updatedLines = new List<string>() { GetHDLine() };
            List<string> maintLines = GetPrereqLines(baseLines.Concat(newLines));
            List<string> oldLines = GetItemLines(baseLines).ToList();
            List<string> updLines = GetMaintBlock(newLines);

            // Make necessary updates to prevent overwriting existing items
            SetUniqueSkuCodes(oldLines, updLines, updatesPath);
            SetUniqueItemCodes(oldLines, updLines, updatesPath);
            SetUniquePromotions(oldLines, updLines, updatesPath);

            // Combine all maint lines
            maintLines.AddRange(oldLines);
            maintLines.AddRange(GetBlockHeader(updLines));
            maintLines.AddRange(updLines);

            // Add comments to the start
            updatedLines.Add(new string('#', 30));
            updatedLines.Add(GetMixMatchLines(maintLines));
            updatedLines.Add(new string('#', 30));
            updatedLines.Add("# Prerequisite Maintenance");
            updatedLines.AddRange(maintLines);

            return updatedLines;
        }

        // Returns a new HD Line
        public static string GetHDLine()
        {
            return "HD1" +
                new string(' ', 8) +
                ConfigurationManager.AppSettings["HD_Description"].PadRight(50, ' ') +
                ConfigurationManager.AppSettings["HD_Version"].PadRight(20, ' ') +
                DateTime.Now.ToString("yyyyMMddHHmmssyyyyMMdd0000010");
        }
        
        public static string GetItemCode(string line)
        {
            if (ItemIds.Contains(GetLineId(line)))
                return line.Substring(18, 13);

            return null;
        }

        public static string GetSkuCode(string line)
        {
            if (ItemIds.Contains(GetLineId(line)))
                return line.Substring(5, 13);

            return null;
        }

        public static bool IsComment(string line)
        {
            return line != null && line.Length > 0 && line[0] == '#';
        }

        /// <summary>
        ///     Returns all lines matching the lineId from a file
        /// </summary>
        public static IEnumerable<string> GetLines(string filePath, string lineId) => GetLines(filePath, new string[] { lineId });
        public static IEnumerable<string> GetLines(string filePath, IEnumerable<string> lineIds)
        {
            return GetLines(File.ReadAllLines(filePath), lineIds);
        }

        /// <summary>
        ///     Returns all lines matching the lineId from a list of strings
        /// </summary>
        public static IEnumerable<string> GetLines(IEnumerable<string> lines, string lineId) => GetLines(lines, new string[] { lineId });
        public static IEnumerable<string> GetLines(IEnumerable<string> lines, IEnumerable<string> lineIds)
        {
            return lines.Where(i => lineIds.Contains(GetLineId(i)));
        }

        /// <summary>
        ///     Returns the first two characters of a string,
        ///     or null if the string is less than 2 characters in length
        /// </summary>
        public static string GetLineId(string line)
        {
            return line.Length > 1 ?
                line.Substring(0, 2) : null;
        }

        /// <summary>
        ///     Returns the lines required for maintenance 
        /// </summary>
        public static List<string> GetPrereqLines(string file) => GetPrereqLines(File.ReadAllLines(file));
        public static List<string> GetPrereqLines(IEnumerable<string> lines)
        {
            List<string> prLines = lines
                .Where(i => PrereqIds.Contains(GetLineId(i)))
                .Distinct()
                .ToList();

            // Sort the lines
            return SortLines(prLines, PrereqIds);
        }

        /// <summary>
        ///     Updates the newLines list with new Mix Match Codes 
        ///     that are not contained in the baseLines list
        /// </summary>
        public static void SetUniquePromotions(List<string> baseLines, List<string> newLines, string updatesPath)
        {
            // Get promos from lines
            List<PromotionCode> getPromos(List<string> lines) => 
                GetLines(lines, "IT")
                .Select(i => new PromotionCode(i))
                .Distinct()
                .ToList();
            
            List<PromotionCode> oldPromos = getPromos(baseLines);
            List<PromotionCode> newPromos = getPromos(newLines);

            // Get item lines from new lines
            List<string> newItLines = GetLines(newLines, "IT").ToList();

            for (int i = 0; i < newPromos.Count; i++)
            {
                PromotionCode promo = newPromos[i];
                PromotionCode curPromo = promo.Copy();
                List<PromotionCode> tempPromos = newPromos
                    .Where(j => j != promo)
                    .ToList();
                
                // Get a unique mixMatch code
                if (curPromo.IsPromotion())
                    while (oldPromos.Contains(curPromo) || tempPromos.Contains(curPromo))
                        curPromo.Increment();
                
                // Replace the old mix match code with the new mix match code
                if (curPromo != promo)
                {
                    UpdateMixMatchCode(newLines, promo, curPromo);
                    string lineText = $"Mix Match Code," +
                        $"{promo.PriceMethod} {promo.MixMatchCode.ToString().PadLeft(3, '0')}," +
                        $"{curPromo.PriceMethod} {curPromo.MixMatchCode.ToString().PadLeft(3, '0')}\r\n";
                    File.AppendAllText(updatesPath, lineText);
                    newPromos[i] = curPromo;
                }
            }
        }
        
        /// <summary>
        ///     Updates a list of lines, replacing IT lines that contain 
        ///     the oldPromo promotion with the newPromo's Mix Match Code
        /// </summary>
        public static void UpdateMixMatchCode(List<string> lines, PromotionCode oldPromo, PromotionCode newPromo)
        {
            string line = "";
            for (int i = 0; i < lines.Count; i++)
            {
                line = lines[i];
                if (GetLineId(line) == "IT" && new PromotionCode(line) == oldPromo)
                    lines[i] = newPromo.SetMixMatchCode(line);
            }
        }

        /// <summary>
        ///     Updates the newLines list with new item codes
        ///     that are not contained in the baseLines list
        /// </summary>
        public static void SetUniqueItemCodes(List<string> baseLines, List<string> newLines, string updatesPath)
        {
            List<long> itemIds = GetLines(baseLines, "IT")
                .Select(i => long.Parse(GetItemCode(i)))
                .ToList();

            for (int i = 0; i < newLines.Count; i++)
            {
                string line = newLines[i];
                if (GetLineId(line) == "IT")
                {
                    string oldItemId = GetItemCode(line);
                    long itemId = long.Parse(oldItemId);

                    // Add new itemId to list of skus
                    while (itemIds.Contains(itemId))
                        itemId = IncrementItemId(itemId);
                    
                    itemIds.Add(itemId);

                    // Replace the old itemId with a new itemId
                    string newItemId = itemId.ToString().PadLeft(13, '0');
                    if (newItemId != oldItemId)
                    {
                        UpdateItemCode(newLines, oldItemId, newItemId);
                        File.AppendAllText(updatesPath, $"Item Code,{oldItemId},{newItemId}\r\n");
                    }
                }
            }
        }

        private static long IncrementItemId(long itemId)
        {
            // Handle type 2 itemIds
            if (TYPE_2_MIN <= itemId && itemId <= TYPE_2_MAX)
            {
                if (itemId == TYPE_2_MAX)
                    itemId = TYPE_2_MIN;
                else
                    itemId += 100000;
            }
            else
                itemId++;

            return itemId;
        }

        /// <summary>
        ///     Updates a list of lines, replacing lines that contain 
        ///     the oldItemId with the newItemId
        /// </summary>
        public static void UpdateItemCode(List<string> lines, string oldItemId, string newItemId)
        {
            for (int i = 0; i < lines.Count; i++)
                if (GetItemCode(lines[i]) == oldItemId 
                    && ItemIds.Contains(GetLineId(lines[i])))
                    lines[i] = lines[i].Replace(newItemId, 18);
        }

        /// <summary>
        ///     Updates the newLines list with new sku codes
        ///     that are not contained in the baseLines list
        /// </summary>
        public static void SetUniqueSkuCodes(List<string> baseLines, List<string> newLines, string updatesPath)
        {
            List<long> skus = 
                GetLines(baseLines, "SK")
                .Select(i => long.Parse(GetSkuCode(i)))
                .ToList();

            List<string[]> items = new List<string[]>();
            
            for (int i = 0; i < newLines.Count; i++)
            {
                string line = newLines[i];
                if (GetLineId(line) == "SK")
                {
                    string oldSku = GetSkuCode(line);
                    long sku = long.Parse(oldSku);

                    // Add new sku to list of skus
                    while (skus.Contains(sku)) sku++;
                    skus.Add(sku);

                    // Replace the old sku with a new sku
                    string newSku = sku.ToString().PadLeft(13, '0');
                    if (newSku != oldSku)
                    {
                        UpdateSkuCode(newLines, oldSku, newSku);
                        File.AppendAllText(updatesPath, $"Sku Code,{oldSku},{newSku}\r\n");
                    }
                }
            }
        }

        /// <summary>
        ///     Updates a list of lines, replacing lines that contain 
        ///     the oldSku with the newSku
        /// </summary>
        public static void UpdateSkuCode(List<string> lines, string oldSku, string newSku)
        {
            for (int i = 0; i < lines.Count; i++)
                if (GetSkuCode(lines[i]) == oldSku 
                    && ItemIds.Contains(GetLineId(lines[i])))
                    lines[i] = lines[i].Replace(newSku, 5);
        }

        /// <summary>
        ///     Returns all lines from a file found after 
        ///     the SKU line, including all leading comments 
        /// </summary>
        public static IEnumerable<string> GetItemLines(string filePath) => GetItemLines(File.ReadAllLines(filePath));
        public static IEnumerable<string> GetItemLines(IEnumerable<string> lines)
        {
            string[] lineArr = lines.ToArray();
            int startIndex = -1;
            
            // Get start index
            for (int i = 0; i < lineArr.Length; i++)
            {
                if (GetLineId(lineArr[i]) == "SK")
                {
                    if (startIndex < 0)
                        startIndex = i;
                    i = lineArr.Length;
                }
                else if (IsComment(lineArr[i]))
                {
                    if (startIndex < 0)
                        startIndex = i;
                }
                else
                    startIndex = -1;
            }

            // Return all lines after start index
            return lineArr.Skip(startIndex);
        }

        // Returns a maintenance block, complete with a header comment
        private static List<string> GetMaintBlock(string filePath) => GetMaintBlock(File.ReadAllLines(filePath));
        private static List<string> GetMaintBlock(IEnumerable<string> lines)
        {
            IEnumerable<string> maintLines = lines
                .Where(i => ItemIds.Contains(GetLineId(i)));

            // Format LineBlock
            return SortLines(maintLines, ItemIds);
        }

        // Returns a header comment
        private static string[] GetBlockHeader(IEnumerable<string> lines)
        {
            string commentLine = new string('#', 26);

            return new string[] {
                commentLine,
                $"# (MAINT - {DateTime.Now.ToString("MMdd")}) Layered Maintenance",
                commentLine,
                GetMixMatchLines(lines),
                commentLine,
            };
        }

        // Returns a comment with all the promotions found in the array of lines
        private static string GetMixMatchLines(IEnumerable<string> lines)
        {
            // Get all promos from lines
            IEnumerable<PromotionCode> promos = GetLines(lines, "IT")
                .Select(i => new PromotionCode(i))
                .Distinct()
                .Where(i => i.PriceMethod != '0' && i.PriceMethod != '~');
                        
            // Return mix match lines
            if (promos.Count() > 0)
                return "# Mix Match Codes:\r\n" +
                    string.Join("\r\n",
                    promos
                    .GroupBy(i => i.PriceMethod)
                    .Select(i => $"# {i.Key}: " + string.Join(", ",
                        promos
                        .Where(j => j.PriceMethod == i.Key)
                        .Select(j => j.MixMatchCode.ToString().PadLeft(3, '0'))))
                );
            else
                return "# Mix Match Codes: N/A";
        }

        /// <summary>
        ///     Sorts a list of lines according to the idList passed.
        ///     Sort order is based on the order of the ids in idList
        ///     Lines that do not match the idList are filtered out
        /// </summary>
        private static List<string> SortLines(IEnumerable<string> lines, IEnumerable<string> idList)
        {
            List<string> newLines = new List<string>();

            foreach (string s in idList)
                newLines.AddRange(
                    lines.Where(i => GetLineId(i) == s));

            return newLines;
        }
    }
}
