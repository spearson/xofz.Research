namespace xofz.Research.UI.Forms
{
    partial class UserControlControlHubUi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stopPrimesKey = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stopPrimesKey
            // 
            this.stopPrimesKey.AutoSize = true;
            this.stopPrimesKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stopPrimesKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.stopPrimesKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.stopPrimesKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopPrimesKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopPrimesKey.Location = new System.Drawing.Point(0, 62);
            this.stopPrimesKey.Name = "stopPrimesKey";
            this.stopPrimesKey.Size = new System.Drawing.Size(134, 36);
            this.stopPrimesKey.TabIndex = 0;
            this.stopPrimesKey.Text = "Stop Primes";
            this.stopPrimesKey.UseVisualStyleBackColor = true;
            this.stopPrimesKey.Click += new System.EventHandler(this.stopPrimesKey_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(-7, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(200, 37);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Control Hub";
            // 
            // UserControlControlHubUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.stopPrimesKey);
            this.Name = "UserControlControlHubUi";
            this.Size = new System.Drawing.Size(1088, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopPrimesKey;
        private System.Windows.Forms.Label titleLabel;
    }
}
