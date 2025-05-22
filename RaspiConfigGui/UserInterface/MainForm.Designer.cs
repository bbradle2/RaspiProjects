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
            TextGpioStatus = new TextBox();
            CmbHttpEndPoints = new ComboBox();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.Controls.Add(TextGpioStatus);
            MainPanel.Controls.Add(CmbHttpEndPoints);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(957, 390);
            MainPanel.TabIndex = 0;
            // 
            // TextGpioStatus
            // 
            TextGpioStatus.Location = new Point(12, 37);
            TextGpioStatus.Multiline = true;
            TextGpioStatus.Name = "TextGpioStatus";
            TextGpioStatus.ReadOnly = true;
            TextGpioStatus.ScrollBars = ScrollBars.Vertical;
            TextGpioStatus.Size = new Size(933, 341);
            TextGpioStatus.TabIndex = 4;
            // 
            // CmbHttpEndPoints
            // 
            CmbHttpEndPoints.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbHttpEndPoints.FormattingEnabled = true;
            CmbHttpEndPoints.Location = new Point(10, 10);
            CmbHttpEndPoints.Name = "CmbHttpEndPoints";
            CmbHttpEndPoints.Size = new Size(209, 21);
            CmbHttpEndPoints.TabIndex = 3;
            CmbHttpEndPoints.SelectionChangeCommitted += cmbHttpEndPoints_SelectionChangeCommitted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 390);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += MainForm_FormClosed;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private ComboBox CmbHttpEndPoints;
        private TextBox TextGpioStatus;
    }
}
