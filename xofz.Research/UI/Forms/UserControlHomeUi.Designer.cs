namespace xofz.Research.UI.Forms
{
    partial class UserControlHomeUi
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(241, 290);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(607, 20);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome to xofz.Research!  Here is where code in xofz.Core will be tested.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "(Please select an item above)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(332, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "(The login password for Level 1 access is 1111)";
            // 
            // logKey
            // 
            this.logKey.AutoSize = true;
            this.logKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.logKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.logKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logKey.Location = new System.Drawing.Point(516, 175);
            this.logKey.Name = "logKey";
            this.logKey.Size = new System.Drawing.Size(57, 36);
            this.logKey.TabIndex = 4;
            this.logKey.Text = "Log";
            this.logKey.UseVisualStyleBackColor = true;
            this.logKey.Click += new System.EventHandler(this.logKey_Click);
            // 
            // UserControlHomeUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.logKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.welcomeLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlHomeUi";
            this.Size = new System.Drawing.Size(1088, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logKey;
    }
}
