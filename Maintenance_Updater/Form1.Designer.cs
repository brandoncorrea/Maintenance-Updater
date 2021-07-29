namespace Maintenance_Updater
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BuildTable = new System.Windows.Forms.TableLayoutPanel();
            this.ItemCodeListBox = new System.Windows.Forms.ListBox();
            this.StoreNumberLabel = new System.Windows.Forms.Label();
            this.StoreNumberTextBox = new System.Windows.Forms.TextBox();
            this.ItemCodeTextBox = new System.Windows.Forms.TextBox();
            this.ItemCodeLabel = new System.Windows.Forms.Label();
            this.BuildButtonTable = new System.Windows.Forms.TableLayoutPanel();
            this.BuildAddButton = new System.Windows.Forms.Button();
            this.BuildRemoveButton = new System.Windows.Forms.Button();
            this.BuildClearButton = new System.Windows.Forms.Button();
            this.BuildSaveButton = new System.Windows.Forms.Button();
            this.BuildOutputLabel = new System.Windows.Forms.Label();
            this.BuildHeaderLabel = new System.Windows.Forms.Label();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SingleBitmapRb = new System.Windows.Forms.RadioButton();
            this.IndividualBitmapsRb = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BuildTab = new System.Windows.Forms.TabPage();
            this.BuildAuthenticationTable = new System.Windows.Forms.TableLayoutPanel();
            this.AuthenticationMessageLb = new System.Windows.Forms.Label();
            this.BuildLoginButton = new System.Windows.Forms.Button();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.SignInHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateListBox = new System.Windows.Forms.ComboBox();
            this.UpdateDataGrid = new System.Windows.Forms.DataGridView();
            this.UpdateOpenButton = new System.Windows.Forms.Button();
            this.UpdateSaveButton = new System.Windows.Forms.Button();
            this.LayerTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.NewFileLb = new System.Windows.Forms.Label();
            this.LayerHeaderLabel = new System.Windows.Forms.Label();
            this.BaseFileBrowseButton = new System.Windows.Forms.Button();
            this.LayerSaveButton = new System.Windows.Forms.Button();
            this.NewFileLabel = new System.Windows.Forms.Label();
            this.BaseFileLb = new System.Windows.Forms.Label();
            this.NewFileBrowseButton = new System.Windows.Forms.Button();
            this.BaseFileLabel = new System.Windows.Forms.Label();
            this.LayerOutputLabel = new System.Windows.Forms.Label();
            this.BarcodesTab = new System.Windows.Forms.TabPage();
            this.BarcodeTable = new System.Windows.Forms.TableLayoutPanel();
            this.BarcodeOutputLabel = new System.Windows.Forms.Label();
            this.BarcodeHeaderLabel = new System.Windows.Forms.Label();
            this.SourceBrowseButton = new System.Windows.Forms.Button();
            this.SourceFileLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SourceFileLb = new System.Windows.Forms.Label();
            this.BarCodeSaveButton = new System.Windows.Forms.Button();
            this.BaterrTab = new System.Windows.Forms.TabPage();
            this.BaterrTable = new System.Windows.Forms.TableLayoutPanel();
            this.BaterrOpenButton = new System.Windows.Forms.Button();
            this.BaterrDataGrid = new System.Windows.Forms.DataGridView();
            this.BaterrDropdown = new System.Windows.Forms.ComboBox();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.BuildTable.SuspendLayout();
            this.BuildButtonTable.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.BuildTab.SuspendLayout();
            this.BuildAuthenticationTable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.UpdateTab.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateDataGrid)).BeginInit();
            this.LayerTab.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.BarcodesTab.SuspendLayout();
            this.BarcodeTable.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.BaterrTab.SuspendLayout();
            this.BaterrTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaterrDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildTable
            // 
            this.BuildTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildTable.ColumnCount = 3;
            this.BuildTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.BuildTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.21019F));
            this.BuildTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.78981F));
            this.BuildTable.Controls.Add(this.ItemCodeListBox, 0, 0);
            this.BuildTable.Controls.Add(this.StoreNumberLabel, 1, 0);
            this.BuildTable.Controls.Add(this.StoreNumberTextBox, 2, 0);
            this.BuildTable.Controls.Add(this.ItemCodeTextBox, 2, 1);
            this.BuildTable.Controls.Add(this.ItemCodeLabel, 1, 1);
            this.BuildTable.Controls.Add(this.BuildButtonTable, 1, 2);
            this.BuildTable.Location = new System.Drawing.Point(0, 35);
            this.BuildTable.Margin = new System.Windows.Forms.Padding(0);
            this.BuildTable.Name = "BuildTable";
            this.BuildTable.RowCount = 6;
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BuildTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BuildTable.Size = new System.Drawing.Size(455, 175);
            this.BuildTable.TabIndex = 22;
            // 
            // ItemCodeListBox
            // 
            this.ItemCodeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemCodeListBox.FormattingEnabled = true;
            this.ItemCodeListBox.ItemHeight = 17;
            this.ItemCodeListBox.Location = new System.Drawing.Point(0, 0);
            this.ItemCodeListBox.Margin = new System.Windows.Forms.Padding(0);
            this.ItemCodeListBox.Name = "ItemCodeListBox";
            this.BuildTable.SetRowSpan(this.ItemCodeListBox, 6);
            this.ItemCodeListBox.Size = new System.Drawing.Size(170, 174);
            this.ItemCodeListBox.TabIndex = 21;
            this.ItemCodeListBox.DoubleClick += new System.EventHandler(this.ItemCodeListBox_DoubleClick);
            // 
            // StoreNumberLabel
            // 
            this.StoreNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StoreNumberLabel.AutoSize = true;
            this.StoreNumberLabel.Location = new System.Drawing.Point(202, 9);
            this.StoreNumberLabel.Name = "StoreNumberLabel";
            this.StoreNumberLabel.Size = new System.Drawing.Size(53, 17);
            this.StoreNumberLabel.TabIndex = 28;
            this.StoreNumberLabel.Text = "Store #";
            // 
            // StoreNumberTextBox
            // 
            this.StoreNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StoreNumberTextBox.Location = new System.Drawing.Point(261, 6);
            this.StoreNumberTextBox.MaxLength = 4;
            this.StoreNumberTextBox.Name = "StoreNumberTextBox";
            this.StoreNumberTextBox.Size = new System.Drawing.Size(191, 23);
            this.StoreNumberTextBox.TabIndex = 22;
            // 
            // ItemCodeTextBox
            // 
            this.ItemCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemCodeTextBox.Location = new System.Drawing.Point(261, 41);
            this.ItemCodeTextBox.MaxLength = 13;
            this.ItemCodeTextBox.Name = "ItemCodeTextBox";
            this.ItemCodeTextBox.Size = new System.Drawing.Size(191, 23);
            this.ItemCodeTextBox.TabIndex = 29;
            this.ItemCodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemCodeTextBox_KeyDown);
            // 
            // ItemCodeLabel
            // 
            this.ItemCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ItemCodeLabel.AutoSize = true;
            this.ItemCodeLabel.Location = new System.Drawing.Point(177, 44);
            this.ItemCodeLabel.Name = "ItemCodeLabel";
            this.ItemCodeLabel.Size = new System.Drawing.Size(78, 17);
            this.ItemCodeLabel.TabIndex = 30;
            this.ItemCodeLabel.Text = "Item Code";
            // 
            // BuildButtonTable
            // 
            this.BuildButtonTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildButtonTable.ColumnCount = 2;
            this.BuildTable.SetColumnSpan(this.BuildButtonTable, 2);
            this.BuildButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BuildButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BuildButtonTable.Controls.Add(this.BuildAddButton, 0, 0);
            this.BuildButtonTable.Controls.Add(this.BuildRemoveButton, 0, 1);
            this.BuildButtonTable.Controls.Add(this.BuildClearButton, 1, 0);
            this.BuildButtonTable.Controls.Add(this.BuildSaveButton, 1, 1);
            this.BuildButtonTable.Controls.Add(this.BuildOutputLabel, 0, 2);
            this.BuildButtonTable.Location = new System.Drawing.Point(170, 70);
            this.BuildButtonTable.Margin = new System.Windows.Forms.Padding(0);
            this.BuildButtonTable.Name = "BuildButtonTable";
            this.BuildButtonTable.RowCount = 3;
            this.BuildTable.SetRowSpan(this.BuildButtonTable, 3);
            this.BuildButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildButtonTable.Size = new System.Drawing.Size(285, 105);
            this.BuildButtonTable.TabIndex = 31;
            // 
            // BuildAddButton
            // 
            this.BuildAddButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BuildAddButton.Location = new System.Drawing.Point(33, 5);
            this.BuildAddButton.Name = "BuildAddButton";
            this.BuildAddButton.Size = new System.Drawing.Size(75, 25);
            this.BuildAddButton.TabIndex = 23;
            this.BuildAddButton.Text = "Add";
            this.BuildAddButton.UseVisualStyleBackColor = true;
            this.BuildAddButton.Click += new System.EventHandler(this.BuildAddButton_Click);
            // 
            // BuildRemoveButton
            // 
            this.BuildRemoveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BuildRemoveButton.Location = new System.Drawing.Point(33, 40);
            this.BuildRemoveButton.Name = "BuildRemoveButton";
            this.BuildRemoveButton.Size = new System.Drawing.Size(75, 25);
            this.BuildRemoveButton.TabIndex = 24;
            this.BuildRemoveButton.Text = "Remove";
            this.BuildRemoveButton.UseVisualStyleBackColor = true;
            this.BuildRemoveButton.Click += new System.EventHandler(this.BuildRemoveButton_Click);
            // 
            // BuildClearButton
            // 
            this.BuildClearButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BuildClearButton.Location = new System.Drawing.Point(176, 5);
            this.BuildClearButton.Name = "BuildClearButton";
            this.BuildClearButton.Size = new System.Drawing.Size(75, 25);
            this.BuildClearButton.TabIndex = 27;
            this.BuildClearButton.Text = "Clear";
            this.BuildClearButton.UseVisualStyleBackColor = true;
            this.BuildClearButton.Click += new System.EventHandler(this.BuildClearButton_Click);
            // 
            // BuildSaveButton
            // 
            this.BuildSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BuildSaveButton.Location = new System.Drawing.Point(176, 40);
            this.BuildSaveButton.Name = "BuildSaveButton";
            this.BuildSaveButton.Size = new System.Drawing.Size(75, 25);
            this.BuildSaveButton.TabIndex = 26;
            this.BuildSaveButton.Text = "Save";
            this.BuildSaveButton.UseVisualStyleBackColor = true;
            this.BuildSaveButton.Click += new System.EventHandler(this.BuildSaveButton_Click);
            // 
            // BuildOutputLabel
            // 
            this.BuildOutputLabel.AutoSize = true;
            this.BuildButtonTable.SetColumnSpan(this.BuildOutputLabel, 2);
            this.BuildOutputLabel.Location = new System.Drawing.Point(10, 80);
            this.BuildOutputLabel.Margin = new System.Windows.Forms.Padding(10);
            this.BuildOutputLabel.Name = "BuildOutputLabel";
            this.BuildOutputLabel.Size = new System.Drawing.Size(119, 15);
            this.BuildOutputLabel.TabIndex = 28;
            this.BuildOutputLabel.Text = "BuildOutputLabel";
            // 
            // BuildHeaderLabel
            // 
            this.BuildHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BuildHeaderLabel.AutoSize = true;
            this.BuildHeaderLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildHeaderLabel.Location = new System.Drawing.Point(3, 8);
            this.BuildHeaderLabel.Name = "BuildHeaderLabel";
            this.BuildHeaderLabel.Size = new System.Drawing.Size(191, 19);
            this.BuildHeaderLabel.TabIndex = 19;
            this.BuildHeaderLabel.Text = "Build Maintenance Files";
            // 
            // OpenDialog
            // 
            this.OpenDialog.InitialDirectory = "Desktop";
            // 
            // SaveDialog
            // 
            this.SaveDialog.InitialDirectory = "Desktop";
            // 
            // SingleBitmapRb
            // 
            this.SingleBitmapRb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SingleBitmapRb.AutoSize = true;
            this.SingleBitmapRb.Checked = true;
            this.SingleBitmapRb.Location = new System.Drawing.Point(29, 7);
            this.SingleBitmapRb.Name = "SingleBitmapRb";
            this.SingleBitmapRb.Size = new System.Drawing.Size(113, 21);
            this.SingleBitmapRb.TabIndex = 18;
            this.SingleBitmapRb.TabStop = true;
            this.SingleBitmapRb.Text = "Single Bitmap";
            this.ToolTip.SetToolTip(this.SingleBitmapRb, "Save all barcodes in a single file.");
            this.SingleBitmapRb.UseVisualStyleBackColor = true;
            // 
            // IndividualBitmapsRb
            // 
            this.IndividualBitmapsRb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IndividualBitmapsRb.AutoSize = true;
            this.IndividualBitmapsRb.Location = new System.Drawing.Point(186, 7);
            this.IndividualBitmapsRb.Name = "IndividualBitmapsRb";
            this.IndividualBitmapsRb.Size = new System.Drawing.Size(144, 21);
            this.IndividualBitmapsRb.TabIndex = 17;
            this.IndividualBitmapsRb.Text = "Individual Bitmaps";
            this.ToolTip.SetToolTip(this.IndividualBitmapsRb, "Save barcodes as individual files named after their item code.");
            this.IndividualBitmapsRb.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.BuildTab);
            this.tabControl1.Controls.Add(this.UpdateTab);
            this.tabControl1.Controls.Add(this.LayerTab);
            this.tabControl1.Controls.Add(this.BarcodesTab);
            this.tabControl1.Controls.Add(this.BaterrTab);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 240);
            this.tabControl1.TabIndex = 1;
            // 
            // BuildTab
            // 
            this.BuildTab.Controls.Add(this.BuildAuthenticationTable);
            this.BuildTab.Controls.Add(this.tableLayoutPanel1);
            this.BuildTab.Location = new System.Drawing.Point(4, 26);
            this.BuildTab.Name = "BuildTab";
            this.BuildTab.Padding = new System.Windows.Forms.Padding(3);
            this.BuildTab.Size = new System.Drawing.Size(455, 210);
            this.BuildTab.TabIndex = 0;
            this.BuildTab.Text = "Build";
            this.BuildTab.UseVisualStyleBackColor = true;
            // 
            // BuildAuthenticationTable
            // 
            this.BuildAuthenticationTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildAuthenticationTable.ColumnCount = 3;
            this.BuildAuthenticationTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.BuildAuthenticationTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.BuildAuthenticationTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BuildAuthenticationTable.Controls.Add(this.AuthenticationMessageLb, 0, 4);
            this.BuildAuthenticationTable.Controls.Add(this.BuildLoginButton, 0, 3);
            this.BuildAuthenticationTable.Controls.Add(this.PasswordTextbox, 1, 2);
            this.BuildAuthenticationTable.Controls.Add(this.PasswordLabel, 0, 2);
            this.BuildAuthenticationTable.Controls.Add(this.UsernameLabel, 0, 1);
            this.BuildAuthenticationTable.Controls.Add(this.UsernameTextbox, 1, 1);
            this.BuildAuthenticationTable.Controls.Add(this.SignInHeader, 0, 0);
            this.BuildAuthenticationTable.Location = new System.Drawing.Point(0, 0);
            this.BuildAuthenticationTable.Margin = new System.Windows.Forms.Padding(0);
            this.BuildAuthenticationTable.Name = "BuildAuthenticationTable";
            this.BuildAuthenticationTable.RowCount = 5;
            this.BuildAuthenticationTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildAuthenticationTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildAuthenticationTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildAuthenticationTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildAuthenticationTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BuildAuthenticationTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BuildAuthenticationTable.Size = new System.Drawing.Size(455, 210);
            this.BuildAuthenticationTable.TabIndex = 23;
            // 
            // AuthenticationMessageLb
            // 
            this.AuthenticationMessageLb.AutoSize = true;
            this.BuildAuthenticationTable.SetColumnSpan(this.AuthenticationMessageLb, 3);
            this.AuthenticationMessageLb.Location = new System.Drawing.Point(10, 150);
            this.AuthenticationMessageLb.Margin = new System.Windows.Forms.Padding(10);
            this.AuthenticationMessageLb.Name = "AuthenticationMessageLb";
            this.AuthenticationMessageLb.Size = new System.Drawing.Size(275, 17);
            this.AuthenticationMessageLb.TabIndex = 5;
            this.AuthenticationMessageLb.Text = "Please sign in using your Retail-Q Account";
            // 
            // BuildLoginButton
            // 
            this.BuildLoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BuildAuthenticationTable.SetColumnSpan(this.BuildLoginButton, 3);
            this.BuildLoginButton.Location = new System.Drawing.Point(195, 110);
            this.BuildLoginButton.Name = "BuildLoginButton";
            this.BuildLoginButton.Size = new System.Drawing.Size(65, 25);
            this.BuildLoginButton.TabIndex = 2;
            this.BuildLoginButton.Text = "Login";
            this.BuildLoginButton.UseVisualStyleBackColor = true;
            this.BuildLoginButton.Click += new System.EventHandler(this.BuildLoginButton_Click);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextbox.Location = new System.Drawing.Point(103, 76);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(162, 23);
            this.PasswordTextbox.TabIndex = 4;
            this.PasswordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginTextbox_KeyDown);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(28, 79);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(69, 17);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(38, 44);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(59, 17);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Retail-Q";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTextbox.Location = new System.Drawing.Point(103, 41);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(162, 23);
            this.UsernameTextbox.TabIndex = 3;
            this.UsernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginTextbox_KeyDown);
            // 
            // SignInHeader
            // 
            this.SignInHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SignInHeader.AutoSize = true;
            this.BuildAuthenticationTable.SetColumnSpan(this.SignInHeader, 3);
            this.SignInHeader.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.SignInHeader.Location = new System.Drawing.Point(3, 8);
            this.SignInHeader.Name = "SignInHeader";
            this.SignInHeader.Size = new System.Drawing.Size(191, 19);
            this.SignInHeader.TabIndex = 6;
            this.SignInHeader.Text = "Build Maintenance Files";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BuildHeaderLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BuildTable, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 210);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // UpdateTab
            // 
            this.UpdateTab.Controls.Add(this.tableLayoutPanel3);
            this.UpdateTab.Location = new System.Drawing.Point(4, 26);
            this.UpdateTab.Name = "UpdateTab";
            this.UpdateTab.Padding = new System.Windows.Forms.Padding(3);
            this.UpdateTab.Size = new System.Drawing.Size(455, 210);
            this.UpdateTab.TabIndex = 4;
            this.UpdateTab.Text = "Update";
            this.UpdateTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.Controls.Add(this.UpdateListBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.UpdateDataGrid, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.UpdateOpenButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.UpdateSaveButton, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(455, 210);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // UpdateListBox
            // 
            this.UpdateListBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UpdateListBox.BackColor = System.Drawing.Color.White;
            this.UpdateListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateListBox.FormattingEnabled = true;
            this.UpdateListBox.Location = new System.Drawing.Point(3, 5);
            this.UpdateListBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.UpdateListBox.Name = "UpdateListBox";
            this.UpdateListBox.Size = new System.Drawing.Size(121, 25);
            this.UpdateListBox.TabIndex = 3;
            this.UpdateListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateListBox_SelectedIndexChanged);
            // 
            // UpdateDataGrid
            // 
            this.UpdateDataGrid.AllowUserToAddRows = false;
            this.UpdateDataGrid.AllowUserToDeleteRows = false;
            this.UpdateDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.UpdateDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel3.SetColumnSpan(this.UpdateDataGrid, 3);
            this.UpdateDataGrid.Location = new System.Drawing.Point(0, 35);
            this.UpdateDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateDataGrid.Name = "UpdateDataGrid";
            this.UpdateDataGrid.Size = new System.Drawing.Size(455, 175);
            this.UpdateDataGrid.TabIndex = 1;
            this.UpdateDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateDataGrid_CellEndEdit);
            // 
            // UpdateOpenButton
            // 
            this.UpdateOpenButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateOpenButton.Location = new System.Drawing.Point(252, 5);
            this.UpdateOpenButton.Name = "UpdateOpenButton";
            this.UpdateOpenButton.Size = new System.Drawing.Size(75, 25);
            this.UpdateOpenButton.TabIndex = 0;
            this.UpdateOpenButton.Text = "Open";
            this.UpdateOpenButton.UseVisualStyleBackColor = true;
            this.UpdateOpenButton.Click += new System.EventHandler(this.UpdateOpenButton_Click);
            // 
            // UpdateSaveButton
            // 
            this.UpdateSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateSaveButton.Location = new System.Drawing.Point(362, 5);
            this.UpdateSaveButton.Name = "UpdateSaveButton";
            this.UpdateSaveButton.Size = new System.Drawing.Size(75, 25);
            this.UpdateSaveButton.TabIndex = 2;
            this.UpdateSaveButton.Text = "Save";
            this.UpdateSaveButton.UseVisualStyleBackColor = true;
            this.UpdateSaveButton.Click += new System.EventHandler(this.UpdateSaveButton_Click);
            // 
            // LayerTab
            // 
            this.LayerTab.Controls.Add(this.tableLayoutPanel4);
            this.LayerTab.Location = new System.Drawing.Point(4, 26);
            this.LayerTab.Name = "LayerTab";
            this.LayerTab.Padding = new System.Windows.Forms.Padding(3);
            this.LayerTab.Size = new System.Drawing.Size(455, 210);
            this.LayerTab.TabIndex = 1;
            this.LayerTab.Text = "Layer";
            this.LayerTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.Controls.Add(this.NewFileLb, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.LayerHeaderLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BaseFileBrowseButton, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.LayerSaveButton, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.NewFileLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.BaseFileLb, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.NewFileBrowseButton, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.BaseFileLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.LayerOutputLabel, 0, 4);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(455, 210);
            this.tableLayoutPanel4.TabIndex = 22;
            // 
            // NewFileLb
            // 
            this.NewFileLb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewFileLb.AutoSize = true;
            this.NewFileLb.Location = new System.Drawing.Point(113, 79);
            this.NewFileLb.Name = "NewFileLb";
            this.NewFileLb.Size = new System.Drawing.Size(73, 17);
            this.NewFileLb.TabIndex = 10;
            this.NewFileLb.Text = "NewFileLb";
            // 
            // LayerHeaderLabel
            // 
            this.LayerHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LayerHeaderLabel.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.LayerHeaderLabel, 2);
            this.LayerHeaderLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayerHeaderLabel.Location = new System.Drawing.Point(3, 8);
            this.LayerHeaderLabel.Name = "LayerHeaderLabel";
            this.LayerHeaderLabel.Size = new System.Drawing.Size(195, 19);
            this.LayerHeaderLabel.TabIndex = 14;
            this.LayerHeaderLabel.Text = "Layer Maintenance Files";
            // 
            // BaseFileBrowseButton
            // 
            this.BaseFileBrowseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BaseFileBrowseButton.Location = new System.Drawing.Point(362, 40);
            this.BaseFileBrowseButton.Name = "BaseFileBrowseButton";
            this.BaseFileBrowseButton.Size = new System.Drawing.Size(75, 25);
            this.BaseFileBrowseButton.TabIndex = 2;
            this.BaseFileBrowseButton.Text = "Browse";
            this.BaseFileBrowseButton.UseVisualStyleBackColor = true;
            this.BaseFileBrowseButton.Click += new System.EventHandler(this.BaseFileBrowseButton_Click);
            // 
            // LayerSaveButton
            // 
            this.LayerSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LayerSaveButton.Location = new System.Drawing.Point(362, 110);
            this.LayerSaveButton.Name = "LayerSaveButton";
            this.LayerSaveButton.Size = new System.Drawing.Size(75, 25);
            this.LayerSaveButton.TabIndex = 6;
            this.LayerSaveButton.Text = "Save";
            this.LayerSaveButton.UseVisualStyleBackColor = true;
            this.LayerSaveButton.Click += new System.EventHandler(this.LayerSaveButton_Click);
            // 
            // NewFileLabel
            // 
            this.NewFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NewFileLabel.AutoSize = true;
            this.NewFileLabel.Location = new System.Drawing.Point(45, 79);
            this.NewFileLabel.Name = "NewFileLabel";
            this.NewFileLabel.Size = new System.Drawing.Size(62, 17);
            this.NewFileLabel.TabIndex = 1;
            this.NewFileLabel.Text = "New File";
            // 
            // BaseFileLb
            // 
            this.BaseFileLb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BaseFileLb.AutoSize = true;
            this.BaseFileLb.Location = new System.Drawing.Point(113, 44);
            this.BaseFileLb.Name = "BaseFileLb";
            this.BaseFileLb.Size = new System.Drawing.Size(72, 17);
            this.BaseFileLb.TabIndex = 9;
            this.BaseFileLb.Text = "BaseFileLb";
            // 
            // NewFileBrowseButton
            // 
            this.NewFileBrowseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewFileBrowseButton.Location = new System.Drawing.Point(362, 75);
            this.NewFileBrowseButton.Name = "NewFileBrowseButton";
            this.NewFileBrowseButton.Size = new System.Drawing.Size(75, 25);
            this.NewFileBrowseButton.TabIndex = 3;
            this.NewFileBrowseButton.Text = "Browse";
            this.NewFileBrowseButton.UseVisualStyleBackColor = true;
            this.NewFileBrowseButton.Click += new System.EventHandler(this.NewFileBrowseButton_Click);
            // 
            // BaseFileLabel
            // 
            this.BaseFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BaseFileLabel.AutoSize = true;
            this.BaseFileLabel.Location = new System.Drawing.Point(46, 44);
            this.BaseFileLabel.Name = "BaseFileLabel";
            this.BaseFileLabel.Size = new System.Drawing.Size(61, 17);
            this.BaseFileLabel.TabIndex = 0;
            this.BaseFileLabel.Text = "Base File";
            // 
            // LayerOutputLabel
            // 
            this.LayerOutputLabel.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.LayerOutputLabel, 3);
            this.LayerOutputLabel.Location = new System.Drawing.Point(10, 150);
            this.LayerOutputLabel.Margin = new System.Windows.Forms.Padding(10);
            this.LayerOutputLabel.Name = "LayerOutputLabel";
            this.LayerOutputLabel.Size = new System.Drawing.Size(122, 17);
            this.LayerOutputLabel.TabIndex = 15;
            this.LayerOutputLabel.Text = "LayerOutputLabel";
            // 
            // BarcodesTab
            // 
            this.BarcodesTab.Controls.Add(this.BarcodeTable);
            this.BarcodesTab.Location = new System.Drawing.Point(4, 26);
            this.BarcodesTab.Name = "BarcodesTab";
            this.BarcodesTab.Padding = new System.Windows.Forms.Padding(3);
            this.BarcodesTab.Size = new System.Drawing.Size(455, 210);
            this.BarcodesTab.TabIndex = 2;
            this.BarcodesTab.Text = "Barcodes";
            this.BarcodesTab.UseVisualStyleBackColor = true;
            // 
            // BarcodeTable
            // 
            this.BarcodeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeTable.ColumnCount = 3;
            this.BarcodeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.BarcodeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BarcodeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.BarcodeTable.Controls.Add(this.BarcodeOutputLabel, 0, 3);
            this.BarcodeTable.Controls.Add(this.BarcodeHeaderLabel, 0, 0);
            this.BarcodeTable.Controls.Add(this.SourceBrowseButton, 2, 1);
            this.BarcodeTable.Controls.Add(this.SourceFileLabel, 0, 1);
            this.BarcodeTable.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.BarcodeTable.Controls.Add(this.SourceFileLb, 1, 1);
            this.BarcodeTable.Controls.Add(this.BarCodeSaveButton, 2, 2);
            this.BarcodeTable.Location = new System.Drawing.Point(0, 0);
            this.BarcodeTable.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeTable.Name = "BarcodeTable";
            this.BarcodeTable.RowCount = 4;
            this.BarcodeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BarcodeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BarcodeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BarcodeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BarcodeTable.Size = new System.Drawing.Size(455, 210);
            this.BarcodeTable.TabIndex = 24;
            // 
            // BarcodeOutputLabel
            // 
            this.BarcodeOutputLabel.AutoSize = true;
            this.BarcodeTable.SetColumnSpan(this.BarcodeOutputLabel, 3);
            this.BarcodeOutputLabel.Location = new System.Drawing.Point(10, 115);
            this.BarcodeOutputLabel.Margin = new System.Windows.Forms.Padding(10);
            this.BarcodeOutputLabel.Name = "BarcodeOutputLabel";
            this.BarcodeOutputLabel.Size = new System.Drawing.Size(143, 17);
            this.BarcodeOutputLabel.TabIndex = 21;
            this.BarcodeOutputLabel.Text = "BarcodeOutputLabel";
            // 
            // BarcodeHeaderLabel
            // 
            this.BarcodeHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BarcodeHeaderLabel.AutoSize = true;
            this.BarcodeTable.SetColumnSpan(this.BarcodeHeaderLabel, 2);
            this.BarcodeHeaderLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarcodeHeaderLabel.Location = new System.Drawing.Point(3, 8);
            this.BarcodeHeaderLabel.Name = "BarcodeHeaderLabel";
            this.BarcodeHeaderLabel.Size = new System.Drawing.Size(158, 19);
            this.BarcodeHeaderLabel.TabIndex = 15;
            this.BarcodeHeaderLabel.Text = "Generate Barcodes";
            // 
            // SourceBrowseButton
            // 
            this.SourceBrowseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SourceBrowseButton.Location = new System.Drawing.Point(362, 40);
            this.SourceBrowseButton.Name = "SourceBrowseButton";
            this.SourceBrowseButton.Size = new System.Drawing.Size(75, 25);
            this.SourceBrowseButton.TabIndex = 11;
            this.SourceBrowseButton.Text = "Browse";
            this.SourceBrowseButton.UseVisualStyleBackColor = true;
            this.SourceBrowseButton.Click += new System.EventHandler(this.SourceBrowseButton_Click);
            // 
            // SourceFileLabel
            // 
            this.SourceFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SourceFileLabel.AutoSize = true;
            this.SourceFileLabel.Location = new System.Drawing.Point(32, 44);
            this.SourceFileLabel.Name = "SourceFileLabel";
            this.SourceFileLabel.Size = new System.Drawing.Size(75, 17);
            this.SourceFileLabel.TabIndex = 12;
            this.SourceFileLabel.Text = "Source File";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.BarcodeTable.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.SingleBitmapRb, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.IndividualBitmapsRb, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(345, 35);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // SourceFileLb
            // 
            this.SourceFileLb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SourceFileLb.AutoSize = true;
            this.SourceFileLb.Location = new System.Drawing.Point(113, 44);
            this.SourceFileLb.Name = "SourceFileLb";
            this.SourceFileLb.Size = new System.Drawing.Size(86, 17);
            this.SourceFileLb.TabIndex = 13;
            this.SourceFileLb.Text = "SourceFileLb";
            // 
            // BarCodeSaveButton
            // 
            this.BarCodeSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BarCodeSaveButton.Location = new System.Drawing.Point(362, 75);
            this.BarCodeSaveButton.Name = "BarCodeSaveButton";
            this.BarCodeSaveButton.Size = new System.Drawing.Size(75, 25);
            this.BarCodeSaveButton.TabIndex = 16;
            this.BarCodeSaveButton.Text = "Save";
            this.BarCodeSaveButton.UseVisualStyleBackColor = true;
            this.BarCodeSaveButton.Click += new System.EventHandler(this.BarCodeSaveButton_Click);
            // 
            // BaterrTab
            // 
            this.BaterrTab.Controls.Add(this.BaterrTable);
            this.BaterrTab.Location = new System.Drawing.Point(4, 26);
            this.BaterrTab.Name = "BaterrTab";
            this.BaterrTab.Padding = new System.Windows.Forms.Padding(3);
            this.BaterrTab.Size = new System.Drawing.Size(455, 210);
            this.BaterrTab.TabIndex = 3;
            this.BaterrTab.Text = "Baterr";
            this.BaterrTab.UseVisualStyleBackColor = true;
            // 
            // BaterrTable
            // 
            this.BaterrTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaterrTable.ColumnCount = 2;
            this.BaterrTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BaterrTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.BaterrTable.Controls.Add(this.BaterrOpenButton, 2, 0);
            this.BaterrTable.Controls.Add(this.BaterrDataGrid, 0, 1);
            this.BaterrTable.Controls.Add(this.BaterrDropdown, 0, 0);
            this.BaterrTable.Location = new System.Drawing.Point(0, 0);
            this.BaterrTable.Margin = new System.Windows.Forms.Padding(0);
            this.BaterrTable.Name = "BaterrTable";
            this.BaterrTable.RowCount = 2;
            this.BaterrTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BaterrTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BaterrTable.Size = new System.Drawing.Size(455, 210);
            this.BaterrTable.TabIndex = 0;
            // 
            // BaterrOpenButton
            // 
            this.BaterrOpenButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BaterrOpenButton.Location = new System.Drawing.Point(362, 5);
            this.BaterrOpenButton.Name = "BaterrOpenButton";
            this.BaterrOpenButton.Size = new System.Drawing.Size(75, 25);
            this.BaterrOpenButton.TabIndex = 0;
            this.BaterrOpenButton.Text = "Open";
            this.BaterrOpenButton.UseVisualStyleBackColor = true;
            this.BaterrOpenButton.Click += new System.EventHandler(this.BaterrOpenButton_Click);
            // 
            // BaterrDataGrid
            // 
            this.BaterrDataGrid.AllowUserToAddRows = false;
            this.BaterrDataGrid.AllowUserToDeleteRows = false;
            this.BaterrDataGrid.AllowUserToOrderColumns = true;
            this.BaterrDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaterrDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.BaterrDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BaterrTable.SetColumnSpan(this.BaterrDataGrid, 2);
            this.BaterrDataGrid.Location = new System.Drawing.Point(0, 35);
            this.BaterrDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.BaterrDataGrid.Name = "BaterrDataGrid";
            this.BaterrDataGrid.ReadOnly = true;
            this.BaterrDataGrid.Size = new System.Drawing.Size(455, 175);
            this.BaterrDataGrid.TabIndex = 1;
            // 
            // BaterrDropdown
            // 
            this.BaterrDropdown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BaterrDropdown.BackColor = System.Drawing.Color.White;
            this.BaterrDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaterrDropdown.FormattingEnabled = true;
            this.BaterrDropdown.Location = new System.Drawing.Point(3, 7);
            this.BaterrDropdown.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BaterrDropdown.Name = "BaterrDropdown";
            this.BaterrDropdown.Size = new System.Drawing.Size(121, 25);
            this.BaterrDropdown.TabIndex = 2;
            this.BaterrDropdown.SelectedIndexChanged += new System.EventHandler(this.BaterrDropdown_SelectedIndexChanged);
            // 
            // FolderDialog
            // 
            this.FolderDialog.Description = "Select the location to save the barcodes.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 241);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(480, 280);
            this.Name = "Form1";
            this.Text = "Maintenance Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.BuildTable.ResumeLayout(false);
            this.BuildTable.PerformLayout();
            this.BuildButtonTable.ResumeLayout(false);
            this.BuildButtonTable.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.BuildTab.ResumeLayout(false);
            this.BuildAuthenticationTable.ResumeLayout(false);
            this.BuildAuthenticationTable.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.UpdateTab.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UpdateDataGrid)).EndInit();
            this.LayerTab.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.BarcodesTab.ResumeLayout(false);
            this.BarcodeTable.ResumeLayout(false);
            this.BarcodeTable.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.BaterrTab.ResumeLayout(false);
            this.BaterrTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BaterrDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label BuildHeaderLabel;
        private System.Windows.Forms.TableLayoutPanel BuildTable;
        private System.Windows.Forms.ListBox ItemCodeListBox;
        private System.Windows.Forms.TextBox StoreNumberTextBox;
        private System.Windows.Forms.Button BuildAddButton;
        private System.Windows.Forms.Button BuildRemoveButton;
        private System.Windows.Forms.Button BuildSaveButton;
        private System.Windows.Forms.Button BuildClearButton;
        private System.Windows.Forms.Label StoreNumberLabel;
        private System.Windows.Forms.TextBox ItemCodeTextBox;
        private System.Windows.Forms.Label ItemCodeLabel;
        private System.Windows.Forms.TableLayoutPanel BuildButtonTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage BuildTab;
        private System.Windows.Forms.TabPage LayerTab;
        private System.Windows.Forms.TabPage BarcodesTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label NewFileLb;
        private System.Windows.Forms.Label LayerHeaderLabel;
        private System.Windows.Forms.Button BaseFileBrowseButton;
        private System.Windows.Forms.Button LayerSaveButton;
        private System.Windows.Forms.Label NewFileLabel;
        private System.Windows.Forms.Label BaseFileLb;
        private System.Windows.Forms.Button NewFileBrowseButton;
        private System.Windows.Forms.Label BaseFileLabel;
        private System.Windows.Forms.TableLayoutPanel BarcodeTable;
        private System.Windows.Forms.Label BarcodeHeaderLabel;
        private System.Windows.Forms.Button SourceBrowseButton;
        private System.Windows.Forms.Label SourceFileLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton SingleBitmapRb;
        private System.Windows.Forms.RadioButton IndividualBitmapsRb;
        private System.Windows.Forms.Label SourceFileLb;
        private System.Windows.Forms.Button BarCodeSaveButton;
        private System.Windows.Forms.TableLayoutPanel BuildAuthenticationTable;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button BuildLoginButton;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label AuthenticationMessageLb;
        private System.Windows.Forms.Label SignInHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label BuildOutputLabel;
        private System.Windows.Forms.Label LayerOutputLabel;
        private System.Windows.Forms.Label BarcodeOutputLabel;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.TabPage BaterrTab;
        private System.Windows.Forms.TableLayoutPanel BaterrTable;
        private System.Windows.Forms.Button BaterrOpenButton;
        private System.Windows.Forms.DataGridView BaterrDataGrid;
        private System.Windows.Forms.ComboBox BaterrDropdown;
        private System.Windows.Forms.TabPage UpdateTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button UpdateOpenButton;
        private System.Windows.Forms.DataGridView UpdateDataGrid;
        private System.Windows.Forms.Button UpdateSaveButton;
        private System.Windows.Forms.ComboBox UpdateListBox;
    }
}

