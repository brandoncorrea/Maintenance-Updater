using BarCodeGenerator;
using Maintenance_Updater.Authentication;
using Maintenance_Updater.Baterr;
using Maintenance_Updater.Editor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLogger;
using Maintenance_Updater.MaintParser;

namespace Maintenance_Updater
{
    public partial class Form1 : Form
    {
        private static readonly string DatTxtFilter = "DAT Files|*.dat|Text files|*.txt|All files|*.*";
        private static readonly string BitmapFilter = "BMP files|*.bmp|All files|*.*";
        private static readonly string AllFilesFilter = "All files|*.*";

        private static Dictionary<string, string> Options = new Dictionary<string, string>() {
            { "Layer_Base_File", "" },
            { "Layer_New_File", "" },
            { "Layer_Save_Location", "" },
            { "Barcodes_Source_File", "" },
            { "Barcodes_Save_Location", "" }
        };

        private static User RetailUser = new User("", "", Domain.Retail);
        private static Logger Logger { get; set; }

        // Baterr Variables
        private static List<BatError> ErrorList = new List<BatError>();
        private static readonly string DefaultBaterrOption = "All Lines";
        private static string[] MaintUpdateLines;

        public Form1()
        {
            try
            {
                InitializeLogger();
                Logger.Start();
                Logger.LogAsync("Starting Maintenance_Updater");

                Logger.LogAsync("Initializing UI Components.");
                InitializeComponent();
                InitializeLabels();
                
                Logger.LogAsync("Initializing Baterr Settings.");
                InitializeBaterr();

                Logger.LogAsync("Initializing HOSTDN Settings.");
                InitializeHOSTDN();
            }
            catch (Exception ex)
            {
                try { Logger.LogErrorAsync("Fatal error occurred.", ex); }
                catch { /* Do nothing */ }

                MessageBox.Show($"An error occurred while opening the application.\n\n{ex.Message}");
                Load += (s, e) => Close(); // Close the application
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.LogAsync($"Closing Applicaton. Reason: {e.CloseReason}");
        }

        private void InitializeLabels()
        {
            BaseFileLb.Text = "";
            NewFileLb.Text = "";
            SourceFileLb.Text = "";
            BarcodeOutputLabel.Text = "";
            LayerOutputLabel.Text = "";
            BuildOutputLabel.Text = "";
        }

        private static void InitializeLogger()
        {
            string logName = ConfigurationManager.AppSettings["LogLocation"].TrimEnd('\\', '/') + 
                "\\MaintenanceUpdater_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            bool enabled = bool.Parse(ConfigurationManager.AppSettings["LoggingEnabled"]);
            Logger = new Logger(logName, enabled);
        }

        private static void InitializeBaterr()
        {
            string fileName = ConfigurationManager.AppSettings["BaterrPath"];
            BaterrFormat.Initialize(fileName);
            ApplyError.Initialize(fileName);
        }

        private void InitializeHOSTDN()
        {
            string fileName = ConfigurationManager.AppSettings["HOSTDNPath"];
            HOSTDN.Initialize(fileName);
        }

        /// <summary>
        ///     Build Tab Functionality
        /// </summary>
        private void ItemCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddItemCode();
        }

        private void BuildAddButton_Click(object sender, EventArgs e)
        {
            AddItemCode();
        }

        private void BuildClearButton_Click(object sender, EventArgs e)
        {
            ItemCodeListBox.Items.Clear();
            Logger.LogAsync("Item list has been cleared.");
        }

        private async void BuildSaveButton_Click(object sender, EventArgs e)
        {
            SaveDialog.Filter = DatTxtFilter;
            if (SaveDialog.ShowDialog() == DialogResult.OK && SaveDialog.FileName != "")
            {
                // Disable UI controls
                BuildSaveButton.Enabled = false;
                BuildOutputLabel.Text = "";

                try
                {
                    string saveLocation = SaveDialog.FileName;

                    // Retrieve maintenance lines from the store
                    Logger.LogAsync("Retrieving maintenance lines.");
                    IEnumerable<string> maintLines = await GetMaintLines();

                    // Write maintenance lines to a file
                    Logger.LogAsync($"Writing Maintenance lines to: {saveLocation}");
                    File.WriteAllLines(saveLocation, maintLines);
                    
                    // Return success messages
                    BuildOutputLabel.Text = "File has been written!";
                    Logger.LogAsync("Maintenance file has been created.");
                }
                catch (Exception ex)
                {
                    // Return fail messages
                    Logger.LogErrorAsync("Failed to create new maintenance file.", ex);
                    BuildOutputLabel.Text = "Failed to write file!";
                }

                // Enable UI controls
                BuildSaveButton.Enabled = true;
            }
        }

        private Task<IEnumerable<string>> GetMaintLines() => Task.Run(() =>
        {
            Logger.LogAsync("Preparing maintenance query.");

            // Get Connection String
            string connStr = $"Server=S{StoreNumberTextBox.Text.PadLeft(4, '0')}0001;Trusted_Connection=True";

            // Format Item Codes
            IEnumerable<string> itemCodes = ItemCodeListBox
                .Items
                .Cast<string>()
                .Select(i => i.PadLeft(13, '0'));

            // Get SqlParameters
            SqlParameter[] sqlParams = itemCodes
                .Select(i => new SqlParameter("@item" + i, i))
                .ToArray();

            // Get Query Text
            string queryPath = ConfigurationManager.AppSettings["BuildQueryPath"];
            string query = string.Format(
                File.ReadAllText(queryPath),
                string.Join(",", itemCodes.Select(i => "@item" + i)));
            
            // Log SQL information
            Logger.LogAsync($"Connection String: {connStr}");
            Logger.LogAsync($"Query Location: {queryPath}");
            Logger.LogAsync("Executing Query.");
            
            DataTable outTable = RunQuery(connStr, query, sqlParams);

            Logger.LogAsync("Query execution successful.");

            // Return Results
            return outTable
                .Rows
                .Cast<DataRow>()
                .Select(i => i.ItemArray[i.ItemArray.Length - 1].ToString());
        });

        // Executes a query using the RetailUser credentials
        private static DataTable RunQuery(string connStr, string query, SqlParameter[] sqlParams)
        {
            DataTable outTable = new DataTable();

            // Impersonation must come after SqlConnection, otherwise an exception will be thrown
            using (SqlConnection connection = new SqlConnection(connStr)) {
            using (new Impersonation(RetailUser)) {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddRange(sqlParams);
                connection.Open();
                SqlDataAdapter _adap = new SqlDataAdapter(command);
                _adap.Fill(outTable);
                connection.Close();
            }}
            
            return outTable;
        }

        private void BuildRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems();
        }

        private void ItemCodeListBox_DoubleClick(object sender, EventArgs e)
        {
            RemoveSelectedItems();
        }

        private void RemoveSelectedItems()
        {
            while (ItemCodeListBox.SelectedItems.Count > 0)
            {
                string item = ItemCodeListBox.SelectedItems[0].ToString();
                try
                {
                    ItemCodeListBox.Items.Remove(item);
                    Logger.LogAsync($"Item code removed: {item}");
                }
                catch(Exception ex)
                {
                    Logger.LogErrorAsync($"Failed to remove item code: {item}", ex);
                }
            }
        }

        private void AddItemCode()
        {
            string text = ItemCodeTextBox.Text;

            try
            {
                string itemCode = long.Parse(text).ToString();
                if (itemCode.Length <= 13 && !ItemCodeListBox.Items.Contains(itemCode))
                {
                    ItemCodeListBox.Items.Add(itemCode);
                    ItemCodeTextBox.Text = "";
                    Logger.LogAsync($"Item Code Added: {itemCode}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogErrorAsync($"Failed to add item code: {text}", ex);
            }
        }
        
        private async void BuildLoginButton_Click(object sender, EventArgs e)
        {
            BuildLoginButton.Enabled = false;

            if (await SignInSuccessful())
                BuildAuthenticationTable.Visible = false;
            else
                AuthenticationMessageLb.Text = "User was unable to authenticate.\n\nPlease try again.";

            BuildLoginButton.Enabled = true;
        }

        /// <summary>
        ///     Update Tab Functionality
        /// </summary>
        private void UpdateOpenButton_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = DatTxtFilter;
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = OpenDialog.FileName;
                Logger.LogAsync($"Parsing Maintenance File: {fileName}");

                MaintUpdateLines = File.ReadAllLines(fileName);

                // Get Maint ID list
                var maintIds = MaintUpdateLines
                    .Where(i =>
                        i.Length > 2
                        && i[0] != '#'
                        && !string.IsNullOrWhiteSpace(i))
                    .Select(i => i.Substring(0, 2))
                    .Distinct();

                // Get filters for dropdown list
                string[] dropdownOptions =
                    HOSTDN.Tables.Where(k => maintIds.Contains(k.Value.Identifier))
                    .Select(i => i.Key)
                    .ToArray();

                UpdateListBox.Items.Clear();
                UpdateListBox.Items.AddRange(dropdownOptions);

                if (UpdateListBox.Items.Count > 0)
                    UpdateListBox.SelectedIndex = 0;
            }
        }

        private void UpdateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = UpdateListBox.Text;
            if (HOSTDN.Tables.Keys.Contains(option))
            {
                DataTable data = new DataTable();
                MaintTable table = HOSTDN.Tables[option];

                // Set column Names
                DataColumn lineNo = new DataColumn("Line #");
                lineNo.ReadOnly = true;
                data.Columns.Add(lineNo);
                data.Columns.AddRange(table
                    .Columns
                    .Select(i => new DataColumn()
                    {
                        ColumnName = i.Name,
                        MaxLength = i.Length
                    })
                    .ToArray());
                data.Columns["IDENTIFIER"].ReadOnly = true;

                // Get line numbers with lines
                Dictionary<int, string> displayLines = new Dictionary<int, string>();
                for (int i = 0; i < MaintUpdateLines.Length; i++)
                {
                    string line = MaintUpdateLines[i];
                    if (line.Length >= 2 && line.Substring(0, 2) == table.Identifier)
                        displayLines.Add(i, line);
                }

                // Add each line to the table
                foreach (var line in displayLines)
                {
                    DataRow row = data.NewRow();
                    int index = 0;

                    row.SetField("Line #", line.Key);

                    // Assign each column a value from the line
                    foreach (MaintColumn col in table.Columns)
                    {
                        row.SetField(col.Name, line.Value.Substring(index, col.Length));
                        index += col.Length;
                    }

                    data.Rows.Add(row);
                }

                UpdateDataGrid.DataSource = data;
            }
        }

        // Update line with new text
        private void UpdateDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cells = UpdateDataGrid.Rows[e.RowIndex].Cells;
                int lineIndex = int.Parse(cells["Line #"].Value.ToString());
                Logger.Log($"Updating line index: {lineIndex}");

                // Validate cell length
                HandleCellLength(e);

                // Get Table
                string id = cells["IDENTIFIER"].Value.ToString();
                MaintTable table = HOSTDN
                    .Tables
                    .Where(t => t.Value.Identifier == id)
                    .FirstOrDefault()
                    .Value;

                // Build the new string
                string newString = "";
                foreach (MaintColumn col in table.Columns)
                    newString += cells[col.Name]
                        .Value
                        .ToString()
                        .PadRight(col.Length, ' ');

                Logger.Log($"Old Line: {MaintUpdateLines[lineIndex]}");
                Logger.Log($"New Line: {newString}");
                MaintUpdateLines[lineIndex] = newString;
                Logger.Log("Line has been updated.");
            }
            catch (Exception ex)
            {
                Logger.LogErrorAsync("Could not update line.", ex);
                MessageBox.Show($"An error occurred:\n\n{ex.Message}", "Error");
            }
        }

        private void HandleCellLength(DataGridViewCellEventArgs e)
        {
            // Initialize variables
            var cells = UpdateDataGrid.Rows[e.RowIndex].Cells;
            string cellText = cells[e.ColumnIndex].Value.ToString();
            string colName = cells[e.ColumnIndex].OwningColumn.Name;
            MaintTable table = HOSTDN.GetTable(cells["IDENTIFIER"].Value.ToString());
            int maxLength = table.GetColumn(colName).Length;

            // If length exceeds max, remove the extra characters
            if (cellText.Length > maxLength)
            {
                string newValue = cellText.Substring(0, maxLength);
                Logger.Log("Cell length exceeded.");
                Logger.Log($"Old Value = {cellText}");
                Logger.Log($"New Value = {newValue}");
                cells[e.ColumnIndex].Value = newValue;
            }
        }

        private async void UpdateSaveButton_Click(object sender, EventArgs e)
        {
            SaveDialog.Filter = DatTxtFilter;
            if (SaveDialog.ShowDialog() == DialogResult.OK && SaveDialog.FileName != "")
            {
                string fileName = SaveDialog.FileName;
                UpdateOpenButton.Enabled = false;
                UpdateSaveButton.Enabled = false;
                await Task.Run(() =>
                {
                    File.WriteAllLines(fileName, MaintUpdateLines);
                    return true;
                });
                UpdateOpenButton.Enabled = true;
                UpdateSaveButton.Enabled = true;
            }
        }

        /// <summary>
        ///     Layer Tab Functionality
        /// </summary>
        private void BaseFileBrowseButton_Click(object sender, EventArgs e)
        {
            SetFileNameText(BaseFileLb, "Layer_Base_File");
        }

        private void NewFileBrowseButton_Click(object sender, EventArgs e)
        {
            SetFileNameText(NewFileLb, "Layer_New_File");
        }

        // Displays a file dialog for the user to save to.
        // If the user selects a valid file name, 
        // The selected files are merged and saved to a file location
        private async void LayerSaveButton_Click(object sender, EventArgs e)
        {
            SaveDialog.Filter = DatTxtFilter;
            if (SaveDialog.ShowDialog() == DialogResult.OK && SaveDialog.FileName != "")
            {
                Options["Layer_Save_Location"] = SaveDialog.FileName;
                BaseFileBrowseButton.Enabled = false;
                NewFileBrowseButton.Enabled = false;
                LayerSaveButton.Enabled = false;
                
                if (await PerformUpdates() != null)
                    LayerOutputLabel.Text = "Update Failed!";
                else
                    LayerOutputLabel.Text = "Update Successful!";

                BaseFileBrowseButton.Enabled = true;
                NewFileBrowseButton.Enabled = true;
                LayerSaveButton.Enabled = true;
            }
        }

        // Merges two maintenance files together and saves it to a location
        private Task<Exception> PerformUpdates() => Task.Run(() => {
            try
            {
                Logger.LogAsync("Building new maintenance file.");
                Logger.LogAsync($"Base File: {Options["Layer_Base_File"]}");
                Logger.LogAsync($"New File: {Options["Layer_New_File"]}");
                Logger.LogAsync($"Save Location: {Options["Layer_Save_Location"]}");

                FileUpdater.UpdateFile(
                    Options["Layer_Base_File"], 
                    Options["Layer_New_File"], 
                    Options["Layer_Save_Location"]);

                Logger.LogAsync("File has updated successfully.");
            }
            catch (Exception ex)
            {
                Logger.LogErrorAsync("File has failed to update.", ex);
                return ex;
            }

            return null;
        });

        /// <summary>
        ///     Barcodes Tab Functionality
        /// </summary>
        private void SourceBrowseButton_Click(object sender, EventArgs e)
        {
            SetFileNameText(SourceFileLb, "Barcodes_Source_File");
        }

        // Displays a dialog asking the user where to save the barcodes, then saves the barcodes
        private async void BarCodeSaveButton_Click(object sender, EventArgs e)
        {
            bool resultOk = SetBarcodeSaveLocation();

            if (resultOk)
            {
                BarCodeSaveButton.Enabled = false;
                SourceBrowseButton.Enabled = false;

                if (await SaveBarcodes() != null)
                    BarcodeOutputLabel.Text = "Bar Codes Failed to Save!";
                else
                    BarcodeOutputLabel.Text = "Bar Codes Saved!";

                BarCodeSaveButton.Enabled = true;
                SourceBrowseButton.Enabled = true;
            }
        }

        private bool SetBarcodeSaveLocation()
        {
            bool resultOk = false;

            if (IndividualBitmapsRb.Checked)
            {
                resultOk = FolderDialog.ShowDialog() == DialogResult.OK
                    && FolderDialog.SelectedPath != "";
                Options["Barcodes_Save_Location"] = FolderDialog.SelectedPath;
            }
            else if (SingleBitmapRb.Checked)
            {
                SaveDialog.Filter = BitmapFilter;
                resultOk = SaveDialog.ShowDialog() == DialogResult.OK
                    && SaveDialog.FileName != "";
                Options["Barcodes_Save_Location"] = SaveDialog.FileName;
            }

            return resultOk;
        }

        private Task<Exception> SaveBarcodes() => Task.Run(() =>
        {
            try
            {
                Dictionary<string, string> items = new Dictionary<string, string>();

                // Retrieves all IT lines from a file
                IEnumerable<string> lines = FileUpdater.GetLines(Options["Barcodes_Source_File"], "IT");
                
                Logger.LogAsync($"Creating barcodes from file: {Options["Barcodes_Source_File"]}");

                // Populate items with distinct plus and descriptions
                foreach (string line in lines)
                {
                    string plu = line.Substring(18, 13);
                    if (!items.Keys.Contains(plu))
                    {
                        string description = line.Substring(33, 18);
                        items.Add(plu, description);
                    }
                }

                // Save the barcodes
                if (SingleBitmapRb.Checked)
                {
                    Logger.LogAsync($"Writing barcodes to single file: {Options["Barcodes_Save_Location"]}");
                    BarCode.Save(items, Options["Barcodes_Save_Location"]);
                }
                else if (IndividualBitmapsRb.Checked)
                {
                    Logger.LogAsync($"Writing barcodes to individual files at: {Options["Barcodes_Save_Location"]}");
                    foreach (var item in items)
                        BarCode.Save(item.Key, item.Value, Options["Barcodes_Save_Location"] + "\\" + item.Key.TrimStart('0') + ".BMP");
                }

                Logger.LogAsync($"Barcodes successfully generated.");
            }
            catch(Exception ex)
            {
                Logger.LogErrorAsync($"Failed to write barcodes.", ex);
                return ex;
            }

            return null;
        });

        /// <summary>
        ///     Baterr Tab Functionality
        /// </summary>
        private async void BaterrOpenButton_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = AllFilesFilter;
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = OpenDialog.FileName;
                Logger.LogAsync($"Parsing Baterr File: {fileName}");

                ErrorList = await Task.Run(() => 
                    File
                    .ReadAllLines(fileName)
                    .Select(i => new BatError(i))
                    .ToList());

                // Set dropdown list options
                List<string> options = new List<string>() { DefaultBaterrOption };
                options.AddRange(ErrorList
                    .Select(i => i.Fields["Identifier"])
                    .Distinct()
                    .Where(i => BaterrFormat.LineFormats.Keys.Contains(i)));

                BaterrDropdown.Items.Clear();
                BaterrDropdown.Items.AddRange(options.ToArray());
                if (BaterrDropdown.Items.Count > 0)
                    BaterrDropdown.SelectedIndex = 0;
            }
        }

        private void BaterrDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = BaterrDropdown.Text;
            
            if (selectedText == DefaultBaterrOption)
                DisplayDefaultBaterrLines();
            else
                DisplayFilteredBaterrLines(selectedText);
        }

        private void DisplayFilteredBaterrLines(string selectedText)
        {
            DataTable data = new DataTable();
            try
            {
                Logger.LogAsync($"Displaying lines with Identifier: {selectedText}");
                IEnumerable<BatError> errs = ErrorList
                    .Where(i =>
                    i.Fields.Keys.Contains("Identifier")
                    && i.Fields["Identifier"] == selectedText);
                
                data.Columns.AddRange(
                    BaterrFormat
                    .LineFormats[selectedText]
                    .Fields
                    .Select(i => new DataColumn(i.Key))
                    .ToArray());

                data.Columns.Add(new DataColumn("Error Text"));

                foreach (BatError err in errs)
                {
                    string[] itemArr = err.Fields.Select(i => i.Value).ToArray();
                    itemArr = itemArr.Concat(new string[] { err.ErrorDescription }).ToArray();
                    DataRow row = data.NewRow();

                    foreach (var field in err.Fields.Where(i => i.Key != "Identifier"))
                        row.SetField(field.Key, field.Value);

                    row.SetField("Error Text", err.ErrorDescription);
                    data.Rows.Add(row);
                }

                BaterrDataGrid.Columns.Clear();
                BaterrDataGrid.DataSource = data;
            }
            // Set text to default
            catch (Exception ex)
            {
                Logger.LogErrorAsync($"Could not display lines with Identifier: {selectedText}.", ex);
                if (BaterrDropdown.Items.Contains(DefaultBaterrOption))
                    BaterrDropdown.SelectedIndex = BaterrDropdown.Items.IndexOf(DefaultBaterrOption);
                else if (BaterrDropdown.Items.Count > 0)
                    BaterrDropdown.SelectedIndex = 0;
            }
        }

        private void DisplayDefaultBaterrLines()
        {
            DataTable data = new DataTable();
            data.Columns.Add(new DataColumn("Line"));
            data.Columns.Add(new DataColumn("Error Text"));

            Logger.LogAsync("Displaying all Baterr lines.");

            foreach (BatError err in ErrorList)
                data.Rows.Add(err.Line, err.ErrorDescription);

            BaterrDataGrid.DataSource = data;
        }

        /// <summary>
        ///     General Functions
        /// </summary>
   
        // Sets the Options value and Label text to the Open File Dialog's file name
        private async void SetFileNameText(Label label, string option)
        {
            OpenDialog.Filter = DatTxtFilter;
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                Options[option] = OpenDialog.FileName;
                
                // Await this task to prevent possible delays on the UI
                label.Text = await Task.Run(() => new FileInfo(Options[option]).Name);

                Logger.LogAsync($"Setting File Option - {option} = {Options[option]}");
            }
        }

        // Returns if an exception is thrown when the user attempts to sign in
        // returns false, true otherwise
        private Task<bool> SignInSuccessful() => Task.Run(() =>
        {
            try
            {
                RetailUser.Username = UsernameTextbox.Text;
                RetailUser.Password = PasswordTextbox.Text;
                using (new Impersonation(RetailUser)) { }
                Logger.LogAsync($"User authenticated: {RetailUser.Username}");
            }
            catch (Exception ex)
            {
                Logger.LogErrorAsync($"Failed to authenticate user: {RetailUser.Username}", ex);
                return false;
            }
            return true;
        });

        private void LoginTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuildLoginButton_Click(BuildLoginButton, e);
        }
    }
}
