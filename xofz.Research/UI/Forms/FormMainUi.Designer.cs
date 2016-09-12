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
            this.loginKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginKey
            // 
            this.loginKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.loginKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.loginKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginKey.Location = new System.Drawing.Point(12, 12);
            this.loginKey.Name = "loginKey";
            this.loginKey.Size = new System.Drawing.Size(159, 52);
            this.loginKey.TabIndex = 0;
            this.loginKey.Text = "Log In";
            this.loginKey.UseVisualStyleBackColor = true;
            this.loginKey.Click += new System.EventHandler(this.loginKey_Click);
            // 
            // FormMainUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1088, 651);
            this.Controls.Add(this.loginKey);
            this.Name = "FormMainUi";
            this.Text = "xofz.Research";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loginKey;
    }
}

