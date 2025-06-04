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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            MainPanel = new Panel();
            DataGridViewMemoryInfo = new DataGridView();
            ContextMenuStripDataGrid = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            GroupBoxTemperatureInfo = new GroupBox();
            TextBoxTempCelcius = new TextBox();
            TextBoxTempFarenh = new TextBox();
            LabelTempFarenh = new Label();
            LabelTemperatureCel = new Label();
            GroupBoxLed = new GroupBox();
            RadioButtonLedStatus27 = new RadioButton();
            RadioButtonLedStatus26 = new RadioButton();
            RadioButtonLedStatus25 = new RadioButton();
            RadioButtonLedStatus24 = new RadioButton();
            RadioButtonLedStatus23 = new RadioButton();
            ComboBoxHttpEndPoints = new ComboBox();
            TimeUpdateForm = new System.Windows.Forms.Timer(components);
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewMemoryInfo).BeginInit();
            ContextMenuStripDataGrid.SuspendLayout();
            GroupBoxTemperatureInfo.SuspendLayout();
            GroupBoxLed.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.Controls.Add(DataGridViewMemoryInfo);
            MainPanel.Controls.Add(GroupBoxTemperatureInfo);
            MainPanel.Controls.Add(GroupBoxLed);
            MainPanel.Controls.Add(ComboBoxHttpEndPoints);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(4);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1060, 292);
            MainPanel.TabIndex = 0;
            // 
            // DataGridViewMemoryInfo
            // 
            DataGridViewMemoryInfo.AllowUserToAddRows = false;
            DataGridViewMemoryInfo.AllowUserToDeleteRows = false;
            DataGridViewMemoryInfo.AllowUserToResizeColumns = false;
            DataGridViewMemoryInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            DataGridViewMemoryInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridViewMemoryInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DataGridViewMemoryInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewMemoryInfo.BackgroundColor = SystemColors.Control;
            DataGridViewMemoryInfo.BorderStyle = BorderStyle.None;
            DataGridViewMemoryInfo.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridViewMemoryInfo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridViewMemoryInfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGridViewMemoryInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridViewMemoryInfo.ColumnHeadersHeight = 30;
            DataGridViewMemoryInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewMemoryInfo.ContextMenuStrip = ContextMenuStripDataGrid;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGridViewMemoryInfo.DefaultCellStyle = dataGridViewCellStyle3;
            DataGridViewMemoryInfo.Location = new Point(169, 131);
            DataGridViewMemoryInfo.MultiSelect = false;
            DataGridViewMemoryInfo.Name = "DataGridViewMemoryInfo";
            DataGridViewMemoryInfo.ReadOnly = true;
            DataGridViewMemoryInfo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DataGridViewMemoryInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DataGridViewMemoryInfo.RowHeadersVisible = false;
            DataGridViewMemoryInfo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(224, 224, 224);
            DataGridViewMemoryInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            DataGridViewMemoryInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DataGridViewMemoryInfo.ShowEditingIcon = false;
            DataGridViewMemoryInfo.Size = new Size(879, 87);
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
            GroupBoxTemperatureInfo.Location = new Point(169, 47);
            GroupBoxTemperatureInfo.Margin = new Padding(4);
            GroupBoxTemperatureInfo.Name = "GroupBoxTemperatureInfo";
            GroupBoxTemperatureInfo.Size = new Size(214, 77);
            GroupBoxTemperatureInfo.TabIndex = 6;
            GroupBoxTemperatureInfo.TabStop = false;
            GroupBoxTemperatureInfo.Text = "Temperature Information";
            // 
            // TextBoxTempCelcius
            // 
            TextBoxTempCelcius.BorderStyle = BorderStyle.None;
            TextBoxTempCelcius.Location = new Point(115, 50);
            TextBoxTempCelcius.Name = "TextBoxTempCelcius";
            TextBoxTempCelcius.ReadOnly = true;
            TextBoxTempCelcius.ShortcutsEnabled = false;
            TextBoxTempCelcius.Size = new Size(61, 16);
            TextBoxTempCelcius.TabIndex = 3;
            TextBoxTempCelcius.TabStop = false;
            // 
            // TextBoxTempFarenh
            // 
            TextBoxTempFarenh.BorderStyle = BorderStyle.None;
            TextBoxTempFarenh.Location = new Point(115, 28);
            TextBoxTempFarenh.Name = "TextBoxTempFarenh";
            TextBoxTempFarenh.ReadOnly = true;
            TextBoxTempFarenh.ShortcutsEnabled = false;
            TextBoxTempFarenh.Size = new Size(61, 16);
            TextBoxTempFarenh.TabIndex = 2;
            TextBoxTempFarenh.TabStop = false;
            // 
            // LabelTempFarenh
            // 
            LabelTempFarenh.AutoSize = true;
            LabelTempFarenh.Location = new Point(4, 27);
            LabelTempFarenh.Margin = new Padding(4, 0, 4, 0);
            LabelTempFarenh.Name = "LabelTempFarenh";
            LabelTempFarenh.Size = new Size(110, 17);
            LabelTempFarenh.TabIndex = 1;
            LabelTempFarenh.Text = "Temperature F :";
            // 
            // LabelTemperatureCel
            // 
            LabelTemperatureCel.AutoSize = true;
            LabelTemperatureCel.Location = new Point(4, 49);
            LabelTemperatureCel.Margin = new Padding(4, 0, 4, 0);
            LabelTemperatureCel.Name = "LabelTemperatureCel";
            LabelTemperatureCel.Size = new Size(111, 17);
            LabelTemperatureCel.TabIndex = 0;
            LabelTemperatureCel.Text = "Temperature C :";
            // 
            // GroupBoxLed
            // 
            GroupBoxLed.Controls.Add(RadioButtonLedStatus27);
            GroupBoxLed.Controls.Add(RadioButtonLedStatus26);
            GroupBoxLed.Controls.Add(RadioButtonLedStatus25);
            GroupBoxLed.Controls.Add(RadioButtonLedStatus24);
            GroupBoxLed.Controls.Add(RadioButtonLedStatus23);
            GroupBoxLed.Location = new Point(13, 46);
            GroupBoxLed.Margin = new Padding(4);
            GroupBoxLed.Name = "GroupBoxLed";
            GroupBoxLed.Size = new Size(148, 219);
            GroupBoxLed.TabIndex = 5;
            GroupBoxLed.TabStop = false;
            GroupBoxLed.Tag = "";
            GroupBoxLed.Text = "Led Status";
            // 
            // RadioButtonLedStatus27
            // 
            RadioButtonLedStatus27.Appearance = Appearance.Button;
            RadioButtonLedStatus27.BackColor = Color.Yellow;
            RadioButtonLedStatus27.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus27.Location = new Point(4, 179);
            RadioButtonLedStatus27.Margin = new Padding(4);
            RadioButtonLedStatus27.Name = "RadioButtonLedStatus27";
            RadioButtonLedStatus27.Size = new Size(137, 33);
            RadioButtonLedStatus27.TabIndex = 8;
            RadioButtonLedStatus27.Tag = "27";
            RadioButtonLedStatus27.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus27.UseVisualStyleBackColor = false;
            // 
            // RadioButtonLedStatus26
            // 
            RadioButtonLedStatus26.Appearance = Appearance.Button;
            RadioButtonLedStatus26.BackColor = Color.Yellow;
            RadioButtonLedStatus26.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus26.Location = new Point(4, 139);
            RadioButtonLedStatus26.Margin = new Padding(4);
            RadioButtonLedStatus26.Name = "RadioButtonLedStatus26";
            RadioButtonLedStatus26.Size = new Size(137, 33);
            RadioButtonLedStatus26.TabIndex = 7;
            RadioButtonLedStatus26.Tag = "26";
            RadioButtonLedStatus26.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus26.UseVisualStyleBackColor = false;
            // 
            // RadioButtonLedStatus25
            // 
            RadioButtonLedStatus25.Appearance = Appearance.Button;
            RadioButtonLedStatus25.BackColor = Color.Yellow;
            RadioButtonLedStatus25.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus25.Location = new Point(4, 98);
            RadioButtonLedStatus25.Margin = new Padding(4);
            RadioButtonLedStatus25.Name = "RadioButtonLedStatus25";
            RadioButtonLedStatus25.Size = new Size(137, 33);
            RadioButtonLedStatus25.TabIndex = 6;
            RadioButtonLedStatus25.Tag = "25";
            RadioButtonLedStatus25.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus25.UseVisualStyleBackColor = false;
            // 
            // RadioButtonLedStatus24
            // 
            RadioButtonLedStatus24.Appearance = Appearance.Button;
            RadioButtonLedStatus24.BackColor = Color.Yellow;
            RadioButtonLedStatus24.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus24.Location = new Point(4, 57);
            RadioButtonLedStatus24.Margin = new Padding(4);
            RadioButtonLedStatus24.Name = "RadioButtonLedStatus24";
            RadioButtonLedStatus24.Size = new Size(137, 33);
            RadioButtonLedStatus24.TabIndex = 5;
            RadioButtonLedStatus24.Tag = "24";
            RadioButtonLedStatus24.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus24.UseVisualStyleBackColor = false;
            // 
            // RadioButtonLedStatus23
            // 
            RadioButtonLedStatus23.Appearance = Appearance.Button;
            RadioButtonLedStatus23.BackColor = Color.Yellow;
            RadioButtonLedStatus23.CheckAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus23.Location = new Point(4, 17);
            RadioButtonLedStatus23.Margin = new Padding(4);
            RadioButtonLedStatus23.Name = "RadioButtonLedStatus23";
            RadioButtonLedStatus23.Size = new Size(137, 33);
            RadioButtonLedStatus23.TabIndex = 4;
            RadioButtonLedStatus23.Tag = "23";
            RadioButtonLedStatus23.TextAlign = ContentAlignment.MiddleCenter;
            RadioButtonLedStatus23.UseVisualStyleBackColor = false;
            // 
            // ComboBoxHttpEndPoints
            // 
            ComboBoxHttpEndPoints.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxHttpEndPoints.FormattingEnabled = true;
            ComboBoxHttpEndPoints.Location = new Point(13, 12);
            ComboBoxHttpEndPoints.Margin = new Padding(4);
            ComboBoxHttpEndPoints.Name = "ComboBoxHttpEndPoints";
            ComboBoxHttpEndPoints.Size = new Size(277, 24);
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
            ClientSize = new Size(1060, 292);
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
            ((System.ComponentModel.ISupportInitialize)DataGridViewMemoryInfo).EndInit();
            ContextMenuStripDataGrid.ResumeLayout(false);
            GroupBoxTemperatureInfo.ResumeLayout(false);
            GroupBoxTemperatureInfo.PerformLayout();
            GroupBoxLed.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private ComboBox ComboBoxHttpEndPoints;
        private RadioButton RadioButtonLedStatus23;
        private GroupBox GroupBoxLed;
        private RadioButton RadioButtonLedStatus24;
        private RadioButton RadioButtonLedStatus25;
        private RadioButton RadioButtonLedStatus26;
        private RadioButton RadioButtonLedStatus27;
        private GroupBox GroupBoxTemperatureInfo;
        private Label LabelTemperatureCel;
        private Label LabelTempFarenh;
        private TextBox TextBoxTempFarenh;
        private TextBox TextBoxTempCelcius;
        private System.Windows.Forms.Timer TimeUpdateForm;
        private DataGridView DataGridViewMemoryInfo;
        private ContextMenuStrip ContextMenuStripDataGrid;
        private ToolStripMenuItem copyToolStripMenuItem;
    }
}
