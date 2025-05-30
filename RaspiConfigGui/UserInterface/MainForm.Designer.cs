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
            MainPanel = new Panel();
            LedPanel = new Panel();
            ledStatus27 = new RadioButton();
            ledStatus26 = new RadioButton();
            ledStatus25 = new RadioButton();
            ledStatus24 = new RadioButton();
            ledStatus23 = new RadioButton();
            CmbHttpEndPoints = new ComboBox();
            MainPanel.SuspendLayout();
            LedPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.Controls.Add(LedPanel);
            MainPanel.Controls.Add(CmbHttpEndPoints);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(233, 217);
            MainPanel.TabIndex = 0;
            // 
            // LedPanel
            // 
            LedPanel.Controls.Add(ledStatus27);
            LedPanel.Controls.Add(ledStatus26);
            LedPanel.Controls.Add(ledStatus25);
            LedPanel.Controls.Add(ledStatus24);
            LedPanel.Controls.Add(ledStatus23);
            LedPanel.Location = new Point(10, 37);
            LedPanel.Name = "LedPanel";
            LedPanel.Size = new Size(51, 166);
            LedPanel.TabIndex = 5;
            LedPanel.Tag = "";
            // 
            // ledStatus27
            // 
            ledStatus27.Appearance = Appearance.Button;
            ledStatus27.BackColor = Color.Yellow;
            ledStatus27.CheckAlign = ContentAlignment.MiddleCenter;
            ledStatus27.Location = new Point(3, 135);
            ledStatus27.Name = "ledStatus27";
            ledStatus27.Size = new Size(45, 27);
            ledStatus27.TabIndex = 8;
            ledStatus27.Tag = "27";
            ledStatus27.TextAlign = ContentAlignment.MiddleCenter;
            ledStatus27.UseVisualStyleBackColor = false;
            // 
            // ledStatus26
            // 
            ledStatus26.Appearance = Appearance.Button;
            ledStatus26.BackColor = Color.Yellow;
            ledStatus26.CheckAlign = ContentAlignment.MiddleCenter;
            ledStatus26.Location = new Point(3, 102);
            ledStatus26.Name = "ledStatus26";
            ledStatus26.Size = new Size(45, 27);
            ledStatus26.TabIndex = 7;
            ledStatus26.Tag = "26";
            ledStatus26.TextAlign = ContentAlignment.MiddleCenter;
            ledStatus26.UseVisualStyleBackColor = false;
            // 
            // ledStatus25
            // 
            ledStatus25.Appearance = Appearance.Button;
            ledStatus25.BackColor = Color.Yellow;
            ledStatus25.CheckAlign = ContentAlignment.MiddleCenter;
            ledStatus25.Location = new Point(3, 69);
            ledStatus25.Name = "ledStatus25";
            ledStatus25.Size = new Size(45, 27);
            ledStatus25.TabIndex = 6;
            ledStatus25.Tag = "25";
            ledStatus25.TextAlign = ContentAlignment.MiddleCenter;
            ledStatus25.UseVisualStyleBackColor = false;
            // 
            // ledStatus24
            // 
            ledStatus24.Appearance = Appearance.Button;
            ledStatus24.BackColor = Color.Yellow;
            ledStatus24.CheckAlign = ContentAlignment.MiddleCenter;
            ledStatus24.Location = new Point(3, 36);
            ledStatus24.Name = "ledStatus24";
            ledStatus24.Size = new Size(45, 27);
            ledStatus24.TabIndex = 5;
            ledStatus24.Tag = "24";
            ledStatus24.TextAlign = ContentAlignment.MiddleCenter;
            ledStatus24.UseVisualStyleBackColor = false;
            // 
            // ledStatus23
            // 
            ledStatus23.Appearance = Appearance.Button;
            ledStatus23.BackColor = Color.Yellow;
            ledStatus23.CheckAlign = ContentAlignment.MiddleCenter;
            ledStatus23.Location = new Point(3, 3);
            ledStatus23.Name = "ledStatus23";
            ledStatus23.Size = new Size(45, 27);
            ledStatus23.TabIndex = 4;
            ledStatus23.Tag = "23";
            ledStatus23.TextAlign = ContentAlignment.MiddleCenter;
            ledStatus23.UseVisualStyleBackColor = false;
            // 
            // CmbHttpEndPoints
            // 
            CmbHttpEndPoints.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbHttpEndPoints.FormattingEnabled = true;
            CmbHttpEndPoints.Location = new Point(10, 10);
            CmbHttpEndPoints.Name = "CmbHttpEndPoints";
            CmbHttpEndPoints.Size = new Size(209, 21);
            CmbHttpEndPoints.TabIndex = 3;
            CmbHttpEndPoints.SelectionChangeCommitted += CmbHttpEndPoints_SelectionChangeCommitted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 217);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            MainPanel.ResumeLayout(false);
            LedPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private ComboBox CmbHttpEndPoints;
        private RadioButton ledStatus23;
        private Panel LedPanel;
        private RadioButton ledStatus24;
        private RadioButton ledStatus25;
        private RadioButton ledStatus26;
        private RadioButton ledStatus27;
    }
}
