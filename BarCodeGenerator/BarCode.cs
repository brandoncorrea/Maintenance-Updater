using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace BarCodeGenerator
{
    public static class BarCode
    {
        /// <summary>
        ///     Constants to be used in creating the barcode
        /// </summary>
        private static readonly string[] LEFT_ODD =
        {
            "0001101",
            "0011001",
            "0010011",
            "0111101",
            "0100011",
            "0110001",
            "0101111",
            "0111011",
            "0110111",
            "0001011"
        };

        private static readonly string[] LEFT_EVEN =
        {
            "0100111",
            "0110011",
            "0011011",
            "0100001",
            "0011101",
            "0111001",
            "0000101",
            "0010001",
            "0001001",
            "0010111"
        };

        private static readonly string[] RIGHT_HAND =
        {
            "1110010",
            "1100110",
            "1101100",
            "1000010",
            "1011100",
            "1001110",
            "1010000",
            "1000100",
            "1001000",
            "1110100"
        };

        private static readonly string[] PARITY =
        {
            "000000",
            "001011",
            "001101",
            "001110",
            "010011",
            "011001",
            "011100",
            "010101",
            "010110",
            "011010"
        };

        private static readonly Dictionary<string, string> Settings = GetAppSettings();
        
        private static Dictionary<string, string> GetAppSettings()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            XDocument xml = XDocument.Load("BarCodeGenerator.dll.config");
            XElement appSettings = xml.Root.Element("appSettings");
            
            foreach (XElement el in appSettings.Elements())
                if (el.Name == "add")
                    d.Add(el.Attribute("key").Value, el.Attribute("value").Value);

            return d;
        }

        private const float BAR_WIDTH = 1.0f;
        private const int BAR_SPACING = 1;

        private static readonly Pen ImagePen = new Pen(Color.FromName(Settings["Foreground_Color"]), BAR_WIDTH);
        private static readonly Font ImageFont = new Font(
            Settings["Font_Family"],
            float.Parse(Settings["Font_Size"])
        );

        /// <summary>
        ///     Public method allows the user to create a barcode image
        /// </summary>
        /// <param name="plu">
        ///     The Item Code that the barcode will be drawn for
        /// </param>
        /// <param name="description">
        ///     The text that will display when the item is added to an order
        /// </param>
        /// <returns>
        ///     Image object of a give UPC
        /// </returns>
        public static Image Draw(string plu, string description)
        {
            // Format the plu to 12 digits
            // And add the check digit to the end
            string gtin = plu.TrimStart('0').PadLeft(12, '0')
                + CalcCheckDigit(plu);

            return DrawOnBitmap(gtin, description);
        }

        public static void Save(Dictionary<string, string> items, string fileName)
        {
            Image barcodeSheet = Draw(items);
            File.Delete(fileName);
            barcodeSheet.Save(fileName);
        }

        public static Image Draw(Dictionary<string, string> items)
        {
            List<KeyValuePair<string, string>> barcodes = items.ToList();
            barcodes.Sort((i, j) => i.Key.CompareTo(j.Key));
            
            List<Image> images = barcodes
                .Select(i => Draw(i.Key, i.Value))
                .ToList();

            return Draw(images);
        }

        public static Image Draw(IEnumerable<Image> barcodes)
        {
            // Get configuration values
            int configHeight = int.Parse(Settings["Bitmap_Height"]);
            int configWidth = int.Parse(Settings["Bitmap_Width"]);
            int configSpacing = int.Parse(Settings["BarCode_Spacing"]);

            // Get the number of columns and rows
            int columns = (int)Math.Ceiling(Math.Sqrt(barcodes.Count()));
            int rows = barcodes.Count() / columns;
            if (barcodes.Count() % columns != 0)
                rows++;

            // Set the page bounds
            int pageHeight = rows * (configHeight + configSpacing);
            int pageWidth = rows > 1 ?
                columns * (configWidth + configSpacing)
                : barcodes.Count() * (configWidth + configSpacing);

            pageHeight -= configSpacing;
            pageWidth -= configSpacing;

            // Initialize the image
            Image page = new Bitmap(pageWidth, pageHeight);
            Graphics g = Graphics.FromImage(page);
            g.PageUnit = GraphicsUnit.Pixel;
            Region r = new Region();
            r.GetBounds(g);
            g.FillRegion(Brushes.White, r);

            // Draw the barcodes
            int row = 0;
            int col = 0;
            foreach (Image barcode in barcodes)
            {
                if (col >= columns)
                {
                    col = 0;
                    row++;
                }

                int start_X = col * (configWidth + configSpacing);
                int start_Y = row * (configHeight + configSpacing);
                g.DrawImage(barcode, start_X, start_Y);
                col++;
            }

            return page;
        }
        
        /// <summary>
        ///     Public method allows the user to save a barcode image to a file of their choice
        /// </summary>
        /// <param name="upc">
        ///     The Item Code that the barcode will be drawn for
        /// </param>
        /// <param name="description">
        ///     The text that will display when the item is added to an order
        /// </param>
        /// <param name="fileName">
        ///     The location the barcode image will be saved
        /// </param>
        public static void Save(string upc, string description, string fileName)
        {
            Image barcode = Draw(upc, description);
            File.Delete(fileName);
            barcode.Save(fileName, ImageFormat.Bmp);
            barcode.Dispose();
        }

        /// <summary>
        ///     Returns the check digit of a given item code
        /// </summary>
        /// <param name="plu">
        ///     The item code that a check digit will be calculated from
        /// </param>
        /// <returns>
        ///     The check digit of the item code
        /// </returns>
        private static string CalcCheckDigit(string plu)
        {
            int chkdigit = 0;
            int sum = 0;
            
            for (int i = 0; i < plu.Length; i++)
            {
                // Add the face value of the digits at even indices
                if (i % 2 == 0)
                    sum += Convert.ToInt32(plu[i].ToString());
                // Add the face value of the digits at odd indices, times 3
                else
                    sum += Convert.ToInt32(plu[i].ToString()) * 3;
            }

            // Get the 1s place of the sum
            chkdigit = sum % 10;
            
            // Check digit is either 0 or the complement of 10
            if (chkdigit > 0)
                chkdigit = (10 - chkdigit);
            
            return chkdigit.ToString();
        }

        /// <summary>
        ///     Draws a barcode image containing the gtin and description
        /// </summary>
        /// <param name="gtin">
        ///     The barcode to be drawn
        /// </param>
        /// <param name="description">
        ///     The display description of the item
        /// </param>
        /// <returns>
        ///     An Image of the scannable barcode witht he item code and description
        /// </returns>
        private static Image DrawOnBitmap(string gtin, string description)
        {
            Image bmp = new Bitmap(
                int.Parse(Settings["Bitmap_Width"]),
                int.Parse(Settings["Bitmap_Height"]));
            Graphics g = GetBarCodeGraphic(bmp);

            // Write item information
            g.DrawDescription(description);
            g.DrawBarCode(gtin);
            g.DrawGTIN(gtin);

            return bmp;
        }

        /// <summary>
        ///     Initializes a Graphics object
        /// </summary>
        /// <param name="bmp">The bitmap to be used as a base for the Graphic</param>
        /// <returns>A Graphics Object initialized for drawing a barcode</returns>
        private static Graphics GetBarCodeGraphic(Image bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.PageUnit = GraphicsUnit.Pixel;
            
            Region r = new Region();
            r.GetBounds(g);

            // Color Background White
            g.FillRegion(
                new SolidBrush(Color.FromName(Settings["Background_Color"])), 
                r);

            return g;
        }

        /// <summary>
        ///     Calculates and returns the encoded bits the gtin
        /// </summary>
        /// <param name="gtin">
        ///     The item code, plus the check digit of the item the user wants to encode
        /// </param>
        /// <returns>
        ///     The encoded UPC in bits
        /// </returns>
        private static string EncodeBars(string gtin)
        {
            // Use the first digit of the gtin to select which parity to follow
            string parToFollow = PARITY[Convert.ToInt32(gtin[0].ToString())];

            string strEncoded = "101"; //Start Bars

            for (int i = 0; i < parToFollow.Length; i++)
            {
                if (parToFollow[i].CompareTo('0') == 0) //Odd
                    strEncoded += LEFT_ODD[Convert.ToInt32(gtin[i + 1].ToString())];
                else //Even
                    strEncoded += LEFT_EVEN[Convert.ToInt32(gtin[i + 1].ToString())];
            }

            strEncoded += "01010"; //Center Guard Bars

            for (int i = 7; i < 13; i++)
                strEncoded += RIGHT_HAND[Convert.ToInt32(gtin[i].ToString())];

            strEncoded += 101;

            return strEncoded;
        }

        /// <summary>
        ///     Draws the description of an item using the user defined settings
        /// </summary>
        /// <param name="g">
        ///     The Graphics object being used to draw on
        /// </param>
        /// <param name="description">The text to be drawn</param>
        private static void DrawDescription(this Graphics g, string description)
        {
            int start_Y = int.Parse(Settings["Description_Start_Y"]); // Start Y
            int start_X = int.Parse(Settings["Description_Start_X"]);
            g.DrawString(description, start_X, start_Y);
        }

        /// <summary>
        ///     Draws a bar code on a graph
        /// </summary>
        /// <param name="g">
        ///     The Graphics object being used to draw on
        /// </param>
        /// <param name="description">The text to be drawn</param>
        private static void DrawBarCode(this Graphics g, string upc)
        {
            int start_X = int.Parse(Settings["BarCode_Start_X"]);
            int start_Y = int.Parse(Settings["BarCode_Start_Y"]);

            //Start Bars
            g.DrawBar(start_X, start_Y);
            start_X += 6;
            g.DrawBar(start_X, start_Y);

            //Encode 5 with LeftHand odd Parity
            //0110001    0 = White 1 = Black
            foreach (char c in EncodeBars(upc).ToCharArray())
            {
                if (c == '1')
                    g.DrawBar(start_X, start_Y);
                start_X += BAR_SPACING;
            }
        }

        /// <summary>
        ///     Draws the item code on the Graphics object at a configured locaton
        /// </summary>
        /// <param name="g">The Graphics object to be drawn on</param>
        /// <param name="gtin">The item code to draw</param>
        private static void DrawGTIN(this Graphics g, string gtin)
        {
            int start_Y = int.Parse(Settings["GTIN_Start_Y"]);
            int start_X = int.Parse(Settings["GTIN_Start_X"]);
            g.DrawString(gtin, start_X, start_Y);
        }
        
        /// <summary>
        ///     Draws a vertical line down, Starting at (X, Y) and Ending at (X, Y + BarHeight)
        ///     With BarHeight being the value, Settings["Bar_Height"]
        /// </summary>
        /// <param name="g">The Graphics object to be drawn on</param>
        /// <param name="xPos">The X Position the line will be drawn</param>
        /// <param name="yPos">The Y Position of the top of the line</param>
        private static void DrawBar(this Graphics g, int xPos, int yPos)
        {
            g.DrawLine(ImagePen, xPos, yPos, xPos, yPos + int.Parse(Settings["Bar_Height"]));
        }
        
        /// <summary>
        ///     Draws text onto a Graphics object at a specified starting location
        /// </summary>
        /// <param name="g">The Graphics object to be drawn on</param>
        /// <param name="text">The text to be drawn</param>
        /// <param name="x">The starting X position of the text</param>
        /// <param name="y">The starting Y position of the text</param>
        private static void DrawString(this Graphics g, string text, int x, int y)
        {
            g.DrawString(text, ImageFont, new SolidBrush(Color.FromName(Settings["Foreground_Color"])), x, y, StringFormat.GenericTypographic);
        }
    }
}
