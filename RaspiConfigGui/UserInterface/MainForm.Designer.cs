namespace UserInterface
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            MainPanel = new Panel();
            LableGpioActions = new Label();
            GroupBoxMemoryInfo = new GroupBox();
            DataGridViewMemoryInfo = new DataGridView();
            ContextMenuStripDataGrid = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            GroupBoxTemperatureInfo = new GroupBox();
            TextBoxTempCelcius = new TextBox();
            TextBoxTempFarenh = new TextBox();
            LabelTempFarenh = new Label();
            LabelTemperatureCel = new Label();
            GroupBoxGpioStatus = new GroupBox();
            RadioButtonGpioStatus27 = new RadioButton();
            RadioButtonGpioStatus26 = new RadioButton();
            RadioButtonGpioStatus25 = new RadioButton();
            RadioButtonGpioStatus24 = new RadioButton();
            RadioButtonGpioStatus23 = new RadioButton();
            ComboBoxHttpEndPoints = new ComboBox();
            TimeUpdateForm = new System.Windows.Forms.Timer(components);
            MainPanel.SuspendLayout();
            GroupBoxMemoryInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewMemoryInfo).BeginInit();
            ContextMenuStripDataGrid.SuspendLayout();
            GroupBoxTemperatureInfo.SuspendLayout();
            GroupBoxGpioStatus.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.Controls.Add(LableGpioActions);
            MainPanel.Controls.Add(GroupBoxMemoryInfo);
            MainPanel.Controls.Add(GroupBoxTemperatureInfo);
            MainPanel.Controls.Add(GroupBoxGpioStatus);
            MainPanel.Controls.Add(ComboBoxHttpEndPoints);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(4);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1130, 310);
            MainPanel.TabIndex = 0;
            // 
            // LableGpioActions
            // 
            LableGpioActions.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LableGpioActions.Location = new Point(21, 14);
            LableGpioActions.Margin = new Padding(4, 0, 4, 0);
            LableGpioActions.Name = "LableGpioActions";
            LableGpioActions.Size = new Size(104, 16);
            LableGpioActions.TabIndex = 10;
            LableGpioActions.Text = "Gpio Actions";
            // 
            // GroupBoxMemoryInfo
            // 
            GroupBoxMemoryInfo.Controls.Add(DataGridViewMemoryInfo);
            GroupBoxMemoryInfo.FlatStyle = FlatStyle.Flat;
            GroupBoxMemoryInfo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GroupBoxMemoryInfo.Location = new Point(175, 147);
            GroupBoxMemoryInfo.Margin = new Padding(4);
            GroupBoxMemoryInfo.Name = "GroupBoxMemoryInfo";
            GroupBoxMemoryInfo.Size = new Size(942, 150);
            GroupBoxMemoryInfo.TabIndex = 9;
            GroupBoxMemoryInfo.TabStop = false;
            GroupBoxMemoryInfo.Text = "Memory Information";
            // 
            // DataGridViewMemoryInfo
            // 
            DataGridViewMemoryInfo.AllowUserToAddRows = false;
            DataGridViewMemoryInfo.AllowUserToDeleteRows = false;
            DataGridViewMemoryInfo.AllowUserToResizeColumns = false;
            DataGridViewMemoryInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            DataGridViewMemoryInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            DataGridViewMemoryInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewMemoryInfo.BackgroundColor = SystemColors.Control;
            DataGridViewMemoryInfo.BorderStyle = BorderStyle.None;
            DataGridViewMemoryInfo.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridViewMemoryInfo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridViewMemoryInfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            DataGridViewMemoryInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            DataGridViewMemoryInfo.ColumnHeadersHeight = 30;
            DataGridViewMemoryInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewMemoryInfo.ContextMenuStrip = ContextMenuStripDataGrid;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            DataGridViewMemoryInfo.DefaultCellStyle = dataGridViewCellStyle8;
            DataGridViewMemoryInfo.Location = new Point(6, 25);
            DataGridViewMemoryInfo.MultiSelect = false;
            DataGridViewMemoryInfo.Name = "DataGridViewMemoryInfo";
            DataGridViewMemoryInfo.ReadOnly = true;
            DataGridViewMemoryInfo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = SystemColors.Window;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            DataGridViewMemoryInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            DataGridViewMemoryInfo.RowHeadersVisible = false;
            DataGridViewMemoryInfo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(224, 224, 224);
            DataGridViewMemoryInfo.RowsDefaultCellStyle = dataGridViewCellStyle10;
            DataGridViewMemoryInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DataGridViewMemoryInfo.ShowEditingIcon = false;
            DataGridViewMemoryInfo.Size = new Size(930, 80);
            DataGridViewMemoryInfo.StandardTab = true;
            DataGridViewMemoryInfo.TabIndex = 8;
            DataGridViewMemoryInfo.VirtualMode = true;
            DataGridViewMemoryInfo.CellMouseDown += DataGridViewMemoryInfo_CellMouseDown;
            DataGridViewMemoryInfo.CellPainting += DataGridViewMemoryInfo_CellPainting;
            DataGridViewMemoryInfo.KeyDown += DataGridViewMemoryInfo_KeyDown;
            // 
            // ContextMenuStripDataGrid
            // 
            ContextMenuStripDataGrid.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem });
            ContextMenuStripDataGrid.Name = "contextMenuStrip1";
            ContextMenuStripDataGrid.Size = new Size(103, 26);
            ContextMenuStripDataGrid.ItemClicked += ContextMenuStripDataGrid_ItemClicked;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(102, 22);
            copyToolStripMenuItem.Text = "Copy";
            // 
            // GroupBoxTemperatureInfo
            // 
            GroupBoxTemperatureInfo.Controls.Add(TextBoxTempCelcius);
            GroupBoxTemperatureInfo.Controls.Add(TextBoxTempFarenh);
            GroupBoxTemperatureInfo.Controls.Add(LabelTempFarenh);
            GroupBoxTemperatureInfo.Controls.Add(LabelTemperatureCel);
            GroupBoxTemperatureInfo.FlatStyle = FlatStyle.Flat;
            GroupBoxTemperatureInfo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GroupBoxTemperatureInfo.Location = new Point(175, 66);
            GroupBoxTemperatureInfo.Margin = new Padding(4);
            GroupBoxTemperatureInfo.Name = "GroupBoxTemperatureInfo";
            GroupBoxTemperatureInfo.Size = new Size(208, 77);
            GroupBoxTemperatureInfo.TabIndex = 6;
            GroupBoxTemperatureInfo.TabStop = false;
            GroupBoxTemperatureInfo.Text = "Temperature Information";
            // 
            // TextBoxTempCelcius
            // 
            TextBoxTempCelcius.BorderStyle = BorderStyle.None;
            TextBoxTempCelcius.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            TextBoxTempCelcius.Location = new Point(127, 50);
            TextBoxTempCelcius.Name = "TextBoxTempCelcius";
            TextBoxTempCelcius.ReadOnly = true;
            TextBoxTempCelcius.ShortcutsEnabled = false;
            TextBoxTempCelcius.Size = new Size(61, 15);
            TextBoxTempCelcius.TabIndex = 3;
            TextBoxTempCelcius.TabStop = false;
            // 
            // TextBoxTempFarenh
            // 
            TextBoxTempFarenh.BorderStyle = BorderStyle.None;
            TextBoxTempFarenh.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            TextBoxTempFarenh.Location = new Point(127, 28);
            TextBoxTempFarenh.Name = "TextBoxTempFarenh";
            TextBoxTempFarenh.ReadOnly = true;
            TextBoxTempFarenh.ShortcutsEnabled = false;
            TextBoxTempFarenh.Size = new Size(61, 15);
            TextBoxTempFarenh.TabIndex = 2;
            TextBoxTempFarenh.TabStop = false;
            // 
            // LabelTempFarenh
            // 
            LabelTempFarenh.AutoSize = true;
            LabelTempFarenh.Location = new Point(4, 27);
            LabelTempFarenh.Margin = new Padding(4, 0, 4, 0);
            LabelTempFarenh.Name = "LabelTempFarenh";
            LabelTempFarenh.Size = new Size(117, 16);
            LabelTempFarenh.TabIndex = 1;
            LabelTempFarenh.Text = "Temperature F :";
            // 
            // LabelTemperatureCel
            // 
            LabelTemperatureCel.AutoSize = true;
            LabelTemperatureCel.Location = new Point(4, 49);
            LabelTemperatureCel.Margin = new Padding(4, 0, 4, 0);
            LabelTemperatureCel.Name = "LabelTemperatureCel";
            LabelTemperatureCel.Size = new Size(118, 16);
            LabelTemperatureCel.TabIndex = 0;
            LabelTemperatureCel.Text = "Temperature C :";
            // 
            // GroupBoxGpioStatus
            // 
            GroupBoxGpioStatus.Controls.Add(RadioButtonGpioStatus27);
            GroupBoxGpioStatus.Controls.Add(RadioButtonGpioStatus26);
            GroupBoxGpioStatus.Controls.Add(RadioButtonGpioStatus25);
            GroupBoxGpioStatus.Controls.Add(RadioButtonGpioStatus24);
            GroupBoxGpioStatus.Controls.Add(RadioButtonGpioStatus23);
            GroupBoxGpioStatus.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GroupBoxGpioStatus.Location = new Point(17, 65);
            GroupBoxGpioStatus.Margin = new Padding(4);
            GroupBoxGpioStatus.Name = "GroupBoxGpioStatus";
            GroupBoxGpioStatus.Size = new Size(150, 232);
            GroupBoxGpioStatus.TabIndex = 5;
            GroupBoxGpioStatus.TabStop = false;
            GroupBoxGpioStatus.Tag = "";
            GroupBoxGpioStatus.Text = "Gpio Status";
            // 
            // RadioButtonGpioStatus27
            // 
            RadioButtonGpioStatus27.Appearance = Appearance.Button;
            RadioButtonGpioStatus27.BackColor = Color.Yellow;
            RadioButtonGpioStatus27.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus27.Location = new Point(5, 188);
            RadioButtonGpioStatus27.Margin = new Padding(4);
            RadioButtonGpioStatus27.Name = "RadioButtonGpioStatus27";
            RadioButtonGpioStatus27.Size = new Size(137, 33);
            RadioButtonGpioStatus27.TabIndex = 8;
            RadioButtonGpioStatus27.Tag = "27";
            RadioButtonGpioStatus27.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus27.UseVisualStyleBackColor = false;
            // 
            // RadioButtonGpioStatus26
            // 
            RadioButtonGpioStatus26.Appearance = Appearance.Button;
            RadioButtonGpioStatus26.BackColor = Color.Yellow;
            RadioButtonGpioStatus26.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus26.Location = new Point(5, 148);
            RadioButtonGpioStatus26.Margin = new Padding(4);
            RadioButtonGpioStatus26.Name = "RadioButtonGpioStatus26";
            RadioButtonGpioStatus26.Size = new Size(137, 33);
            RadioButtonGpioStatus26.TabIndex = 7;
            RadioButtonGpioStatus26.Tag = "26";
            RadioButtonGpioStatus26.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus26.UseVisualStyleBackColor = false;
            // 
            // RadioButtonGpioStatus25
            // 
            RadioButtonGpioStatus25.Appearance = Appearance.Button;
            RadioButtonGpioStatus25.BackColor = Color.Yellow;
            RadioButtonGpioStatus25.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus25.Location = new Point(5, 107);
            RadioButtonGpioStatus25.Margin = new Padding(4);
            RadioButtonGpioStatus25.Name = "RadioButtonGpioStatus25";
            RadioButtonGpioStatus25.Size = new Size(137, 33);
            RadioButtonGpioStatus25.TabIndex = 6;
            RadioButtonGpioStatus25.Tag = "25";
            RadioButtonGpioStatus25.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus25.UseVisualStyleBackColor = false;
            // 
            // RadioButtonGpioStatus24
            // 
            RadioButtonGpioStatus24.Appearance = Appearance.Button;
            RadioButtonGpioStatus24.BackColor = Color.Yellow;
            RadioButtonGpioStatus24.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus24.Location = new Point(5, 66);
            RadioButtonGpioStatus24.Margin = new Padding(4);
            RadioButtonGpioStatus24.Name = "RadioButtonGpioStatus24";
            RadioButtonGpioStatus24.Size = new Size(137, 33);
            RadioButtonGpioStatus24.TabIndex = 5;
            RadioButtonGpioStatus24.Tag = "24";
            RadioButtonGpioStatus24.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus24.UseVisualStyleBackColor = false;
            // 
            // RadioButtonGpioStatus23
            // 
            RadioButtonGpioStatus23.Appearance = Appearance.Button;
            RadioButtonGpioStatus23.BackColor = Color.Yellow;
            RadioButtonGpioStatus23.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus23.Location = new Point(5, 26);
            RadioButtonGpioStatus23.Margin = new Padding(4);
            RadioButtonGpioStatus23.Name = "RadioButtonGpioStatus23";
            RadioButtonGpioStatus23.Size = new Size(137, 33);
            RadioButtonGpioStatus23.TabIndex = 4;
            RadioButtonGpioStatus23.Tag = "23";
            RadioButtonGpioStatus23.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonGpioStatus23.UseVisualStyleBackColor = false;
            // 
            // ComboBoxHttpEndPoints
            // 
            ComboBoxHttpEndPoints.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxHttpEndPoints.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ComboBoxHttpEndPoints.FormattingEnabled = true;
            ComboBoxHttpEndPoints.Location = new Point(17, 34);
            ComboBoxHttpEndPoints.Margin = new Padding(4);
            ComboBoxHttpEndPoints.Name = "ComboBoxHttpEndPoints";
            ComboBoxHttpEndPoints.Size = new Size(366, 24);
            ComboBoxHttpEndPoints.TabIndex = 3;
            ComboBoxHttpEndPoints.SelectionChangeCommitted += CmbHttpEndPoints_SelectionChangeCommitted;
            // 
            // TimeUpdateForm
            // 
            TimeUpdateForm.Enabled = true;
            TimeUpdateForm.Interval = 5000;
            TimeUpdateForm.Tick += TimerTemperature_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 310);
            Controls.Add(MainPanel);
            Font = new Font("Microsoft Sans Serif", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            MainPanel.ResumeLayout(false);
            GroupBoxMemoryInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridViewMemoryInfo).EndInit();
            ContextMenuStripDataGrid.ResumeLayout(false);
            GroupBoxTemperatureInfo.ResumeLayout(false);
            GroupBoxTemperatureInfo.PerformLayout();
            GroupBoxGpioStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private ComboBox ComboBoxHttpEndPoints;
        private RadioButton RadioButtonGpioStatus23;
        private GroupBox GroupBoxGpioStatus;
        private RadioButton RadioButtonGpioStatus24;
        private RadioButton RadioButtonGpioStatus25;
        private RadioButton RadioButtonGpioStatus26;
        private RadioButton RadioButtonGpioStatus27;
        private GroupBox GroupBoxTemperatureInfo;
        private Label LabelTemperatureCel;
        private Label LabelTempFarenh;
        private TextBox TextBoxTempFarenh;
        private TextBox TextBoxTempCelcius;
        private System.Windows.Forms.Timer TimeUpdateForm;
        private DataGridView DataGridViewMemoryInfo;
        private ContextMenuStrip ContextMenuStripDataGrid;
        private ToolStripMenuItem copyToolStripMenuItem;
        private GroupBox GroupBoxMemoryInfo;
        private Label LableGpioActions;
    }
}
