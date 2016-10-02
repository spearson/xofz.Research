namespace xofz.Research.UI.Forms
{
    partial class FormMainUi
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
            this.navUi = new xofz.Research.UI.Forms.UserControlNavUi();
            this.screenPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // navUi
            // 
            this.navUi.Location = new System.Drawing.Point(0, 0);
            this.navUi.Margin = new System.Windows.Forms.Padding(0);
            this.navUi.Name = "navUi";
            this.navUi.Size = new System.Drawing.Size(1088, 50);
            this.navUi.TabIndex = 0;
            // 
            // screenPanel
            // 
            this.screenPanel.Location = new System.Drawing.Point(0, 50);
            this.screenPanel.Margin = new System.Windows.Forms.Padding(0);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(1088, 601);
            this.screenPanel.TabIndex = 1;
            // 
            // FormMainUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1088, 651);
            this.Controls.Add(this.screenPanel);
            this.Controls.Add(this.navUi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMainUi";
            this.Text = "xofz.Research";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlNavUi navUi;
        private System.Windows.Forms.Panel screenPanel;
    }
}

