namespace MacAttack
{
    partial class MainForm
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
            this.CloseProgramButton = new MetroFramework.Controls.MetroButton();
            this.MinimizeProgramButton = new MetroFramework.Controls.MetroButton();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.macrosTab = new MetroFramework.Controls.MetroTabPage();
            this.loadedMacrosPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.loadMacroButton = new MetroFramework.Controls.MetroButton();
            this.creatorTab = new MetroFramework.Controls.MetroTabPage();
            this.editConfigButton = new MetroFramework.Controls.MetroButton();
            this.setBuilderData = new MetroFramework.Controls.MetroButton();
            this.saveConfigButton = new MetroFramework.Controls.MetroButton();
            this.NameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.SpeedTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.YValueTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.XValueTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.loadedMacroLabel = new MetroFramework.Controls.MetroLabel();
            this.tabControl.SuspendLayout();
            this.macrosTab.SuspendLayout();
            this.creatorTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseProgramButton
            // 
            this.CloseProgramButton.Location = new System.Drawing.Point(329, 13);
            this.CloseProgramButton.Name = "CloseProgramButton";
            this.CloseProgramButton.Size = new System.Drawing.Size(20, 20);
            this.CloseProgramButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CloseProgramButton.TabIndex = 0;
            this.CloseProgramButton.Text = "X";
            this.CloseProgramButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CloseProgramButton.Click += new System.EventHandler(this.CloseProgramButton_Click);
            // 
            // MinimizeProgramButton
            // 
            this.MinimizeProgramButton.Location = new System.Drawing.Point(303, 13);
            this.MinimizeProgramButton.Name = "MinimizeProgramButton";
            this.MinimizeProgramButton.Size = new System.Drawing.Size(20, 20);
            this.MinimizeProgramButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MinimizeProgramButton.TabIndex = 1;
            this.MinimizeProgramButton.Text = "_";
            this.MinimizeProgramButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MinimizeProgramButton.Click += new System.EventHandler(this.MinimizeProgramButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.macrosTab);
            this.tabControl.Controls.Add(this.creatorTab);
            this.tabControl.Location = new System.Drawing.Point(23, 63);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(310, 242);
            this.tabControl.TabIndex = 2;
            this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // macrosTab
            // 
            this.macrosTab.Controls.Add(this.loadedMacrosPanel);
            this.macrosTab.Controls.Add(this.loadMacroButton);
            this.macrosTab.HorizontalScrollbarBarColor = true;
            this.macrosTab.Location = new System.Drawing.Point(4, 35);
            this.macrosTab.Name = "macrosTab";
            this.macrosTab.Size = new System.Drawing.Size(302, 203);
            this.macrosTab.TabIndex = 0;
            this.macrosTab.Text = "Macros";
            this.macrosTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.macrosTab.VerticalScrollbarBarColor = true;
            // 
            // loadedMacrosPanel
            // 
            this.loadedMacrosPanel.AutoScroll = true;
            this.loadedMacrosPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.loadedMacrosPanel.Location = new System.Drawing.Point(0, 3);
            this.loadedMacrosPanel.Name = "loadedMacrosPanel";
            this.loadedMacrosPanel.Size = new System.Drawing.Size(302, 156);
            this.loadedMacrosPanel.TabIndex = 4;
            // 
            // loadMacroButton
            // 
            this.loadMacroButton.Location = new System.Drawing.Point(0, 165);
            this.loadMacroButton.Name = "loadMacroButton";
            this.loadMacroButton.Size = new System.Drawing.Size(302, 35);
            this.loadMacroButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.loadMacroButton.TabIndex = 3;
            this.loadMacroButton.Text = "Load Macro";
            this.loadMacroButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loadMacroButton.Click += new System.EventHandler(this.loadMacroButton_Click);
            // 
            // creatorTab
            // 
            this.creatorTab.Controls.Add(this.editConfigButton);
            this.creatorTab.Controls.Add(this.setBuilderData);
            this.creatorTab.Controls.Add(this.saveConfigButton);
            this.creatorTab.Controls.Add(this.NameTextBox);
            this.creatorTab.Controls.Add(this.metroTile4);
            this.creatorTab.Controls.Add(this.SpeedTextBox);
            this.creatorTab.Controls.Add(this.metroTile3);
            this.creatorTab.Controls.Add(this.YValueTextBox);
            this.creatorTab.Controls.Add(this.metroTile2);
            this.creatorTab.Controls.Add(this.XValueTextBox);
            this.creatorTab.Controls.Add(this.metroTile1);
            this.creatorTab.HorizontalScrollbarBarColor = true;
            this.creatorTab.Location = new System.Drawing.Point(4, 35);
            this.creatorTab.Name = "creatorTab";
            this.creatorTab.Size = new System.Drawing.Size(302, 203);
            this.creatorTab.TabIndex = 1;
            this.creatorTab.Text = "Create Macros";
            this.creatorTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.creatorTab.VerticalScrollbarBarColor = true;
            // 
            // editConfigButton
            // 
            this.editConfigButton.Location = new System.Drawing.Point(206, 119);
            this.editConfigButton.Name = "editConfigButton";
            this.editConfigButton.Size = new System.Drawing.Size(95, 33);
            this.editConfigButton.TabIndex = 12;
            this.editConfigButton.Text = "Edit Config";
            this.editConfigButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.editConfigButton.Click += new System.EventHandler(this.editConfigButton_Click);
            // 
            // setBuilderData
            // 
            this.setBuilderData.Location = new System.Drawing.Point(2, 119);
            this.setBuilderData.Name = "setBuilderData";
            this.setBuilderData.Size = new System.Drawing.Size(88, 33);
            this.setBuilderData.TabIndex = 11;
            this.setBuilderData.Text = "Set Builder";
            this.setBuilderData.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.setBuilderData.Click += new System.EventHandler(this.setBuilderData_Click);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(96, 119);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(104, 33);
            this.saveConfigButton.TabIndex = 10;
            this.saveConfigButton.Text = "Save Config";
            this.saveConfigButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(95, 90);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(206, 23);
            this.NameTextBox.TabIndex = 9;
            this.NameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTile4
            // 
            this.metroTile4.Location = new System.Drawing.Point(2, 90);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(88, 23);
            this.metroTile4.TabIndex = 8;
            this.metroTile4.Text = "Name:";
            this.metroTile4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Location = new System.Drawing.Point(96, 61);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(206, 23);
            this.SpeedTextBox.TabIndex = 7;
            this.SpeedTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTile3
            // 
            this.metroTile3.Location = new System.Drawing.Point(3, 61);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(87, 23);
            this.metroTile3.TabIndex = 6;
            this.metroTile3.Text = "Speed: ";
            this.metroTile3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // YValueTextBox
            // 
            this.YValueTextBox.Location = new System.Drawing.Point(96, 32);
            this.YValueTextBox.Name = "YValueTextBox";
            this.YValueTextBox.Size = new System.Drawing.Size(206, 23);
            this.YValueTextBox.TabIndex = 5;
            this.YValueTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTile2
            // 
            this.metroTile2.Location = new System.Drawing.Point(3, 32);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(87, 23);
            this.metroTile2.TabIndex = 4;
            this.metroTile2.Text = "Y value:";
            this.metroTile2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // XValueTextBox
            // 
            this.XValueTextBox.Location = new System.Drawing.Point(96, 3);
            this.XValueTextBox.Name = "XValueTextBox";
            this.XValueTextBox.Size = new System.Drawing.Size(206, 23);
            this.XValueTextBox.TabIndex = 3;
            this.XValueTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTile1
            // 
            this.metroTile1.Location = new System.Drawing.Point(3, 3);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(87, 23);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "X value:";
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // loadedMacroLabel
            // 
            this.loadedMacroLabel.AutoSize = true;
            this.loadedMacroLabel.Location = new System.Drawing.Point(27, 304);
            this.loadedMacroLabel.Name = "loadedMacroLabel";
            this.loadedMacroLabel.Size = new System.Drawing.Size(134, 19);
            this.loadedMacroLabel.TabIndex = 3;
            this.loadedMacroLabel.Text = "Loaded Macro: None";
            this.loadedMacroLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 328);
            this.ControlBox = false;
            this.Controls.Add(this.loadedMacroLabel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.MinimizeProgramButton);
            this.Controls.Add(this.CloseProgramButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "MacAttack";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.tabControl.ResumeLayout(false);
            this.macrosTab.ResumeLayout(false);
            this.creatorTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton CloseProgramButton;
        private MetroFramework.Controls.MetroButton MinimizeProgramButton;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTabPage macrosTab;
        private MetroFramework.Controls.MetroTabPage creatorTab;
        private MetroFramework.Controls.MetroButton loadMacroButton;
        private MetroFramework.Controls.MetroButton saveConfigButton;
        private MetroFramework.Controls.MetroTextBox NameTextBox;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroTextBox SpeedTextBox;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTextBox YValueTextBox;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTextBox XValueTextBox;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroButton setBuilderData;
        public System.Windows.Forms.FlowLayoutPanel loadedMacrosPanel;
        private MetroFramework.Controls.MetroButton editConfigButton;
        private MetroFramework.Controls.MetroLabel loadedMacroLabel;
    }
}

