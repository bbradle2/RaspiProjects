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
            LabelGpioStatus27 = new Label();
            LabelGpioStatus26 = new Label();
            LabelGpioStatus25 = new Label();
            LabelGpioStatus24 = new Label();
            LabelGpioStatus23 = new Label();
            ComboBoxHttpEndPoints = new ComboBox();
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
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            DataGridViewMemoryInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridViewMemoryInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewMemoryInfo.BackgroundColor = SystemColors.Control;
            DataGridViewMemoryInfo.BorderStyle = BorderStyle.None;
            DataGridViewMemoryInfo.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridViewMemoryInfo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridViewMemoryInfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGridViewMemoryInfo.DefaultCellStyle = dataGridViewCellStyle3;
            DataGridViewMemoryInfo.Location = new Point(6, 25);
            DataGridViewMemoryInfo.MultiSelect = false;
            DataGridViewMemoryInfo.Name = "DataGridViewMemoryInfo";
            DataGridViewMemoryInfo.ReadOnly = true;
            DataGridViewMemoryInfo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            DataGridViewMemoryInfo.Size = new Size(930, 80);
            DataGridViewMemoryInfo.StandardTab = true;
            DataGridViewMemoryInfo.TabIndex = 8;
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
            GroupBoxGpioStatus.Controls.Add(LabelGpioStatus27);
            GroupBoxGpioStatus.Controls.Add(LabelGpioStatus26);
            GroupBoxGpioStatus.Controls.Add(LabelGpioStatus25);
            GroupBoxGpioStatus.Controls.Add(LabelGpioStatus24);
            GroupBoxGpioStatus.Controls.Add(LabelGpioStatus23);
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
            // LabelGpioStatus27
            // 
            LabelGpioStatus27.BackColor = Color.Yellow;
            LabelGpioStatus27.Location = new Point(6, 188);
            LabelGpioStatus27.Margin = new Padding(4);
            LabelGpioStatus27.Name = "LabelGpioStatus27";
            LabelGpioStatus27.Size = new Size(138, 33);
            LabelGpioStatus27.TabIndex = 8;
            LabelGpioStatus27.Tag = "27";
            LabelGpioStatus27.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelGpioStatus26
            // 
            LabelGpioStatus26.BackColor = Color.Yellow;
            LabelGpioStatus26.Location = new Point(6, 148);
            LabelGpioStatus26.Margin = new Padding(4);
            LabelGpioStatus26.Name = "LabelGpioStatus26";
            LabelGpioStatus26.Size = new Size(138, 33);
            LabelGpioStatus26.TabIndex = 7;
            LabelGpioStatus26.Tag = "26";
            LabelGpioStatus26.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelGpioStatus25
            // 
            LabelGpioStatus25.BackColor = Color.Yellow;
            LabelGpioStatus25.Location = new Point(6, 107);
            LabelGpioStatus25.Margin = new Padding(4);
            LabelGpioStatus25.Name = "LabelGpioStatus25";
            LabelGpioStatus25.Size = new Size(138, 33);
            LabelGpioStatus25.TabIndex = 6;
            LabelGpioStatus25.Tag = "25";
            LabelGpioStatus25.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelGpioStatus24
            // 
            LabelGpioStatus24.BackColor = Color.Yellow;
            LabelGpioStatus24.Location = new Point(6, 66);
            LabelGpioStatus24.Margin = new Padding(4);
            LabelGpioStatus24.Name = "LabelGpioStatus24";
            LabelGpioStatus24.Size = new Size(138, 33);
            LabelGpioStatus24.TabIndex = 5;
            LabelGpioStatus24.Tag = "24";
            LabelGpioStatus24.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelGpioStatus23
            // 
            LabelGpioStatus23.BackColor = Color.Yellow;
            LabelGpioStatus23.Location = new Point(6, 26);
            LabelGpioStatus23.Margin = new Padding(4);
            LabelGpioStatus23.Name = "LabelGpioStatus23";
            LabelGpioStatus23.Size = new Size(138, 33);
            LabelGpioStatus23.TabIndex = 4;
            LabelGpioStatus23.Tag = "23";
            LabelGpioStatus23.TextAlign = ContentAlignment.MiddleCenter;
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
        private Label LabelGpioStatus23;
        private GroupBox GroupBoxGpioStatus;
        private Label LabelGpioStatus24;
        private Label LabelGpioStatus25;
        private Label LabelGpioStatus26;
        private Label LabelGpioStatus27;
        private GroupBox GroupBoxTemperatureInfo;
        private Label LabelTemperatureCel;
        private Label LabelTempFarenh;
        private TextBox TextBoxTempFarenh;
        private TextBox TextBoxTempCelcius;
        private DataGridView DataGridViewMemoryInfo;
        private ContextMenuStrip ContextMenuStripDataGrid;
        private ToolStripMenuItem copyToolStripMenuItem;
        private GroupBox GroupBoxMemoryInfo;
        private Label LableGpioActions;
    }
}
