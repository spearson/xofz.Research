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
            this.label2 = new System.Windows.Forms.Label();
            this.logKey = new System.Windows.Forms.Button();
            this.binaryVisualizerKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(3, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(806, 20);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome to xofz.Research!  The source code for this app is for learning the xofz." +
    "Core98 framework.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Passwords: Level1 - 1111   Level2 - 2222";
            // 
            // logKey
            // 
            this.logKey.AutoSize = true;
            this.logKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.logKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.logKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logKey.Location = new System.Drawing.Point(0, 61);
            this.logKey.Name = "logKey";
            this.logKey.Size = new System.Drawing.Size(57, 36);
            this.logKey.TabIndex = 4;
            this.logKey.Text = "Log";
            this.logKey.UseVisualStyleBackColor = true;
            this.logKey.Click += new System.EventHandler(this.logKey_Click);
            // 
            // binaryVisualizerKey
            // 
            this.binaryVisualizerKey.AutoSize = true;
            this.binaryVisualizerKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.binaryVisualizerKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.binaryVisualizerKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.binaryVisualizerKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.binaryVisualizerKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binaryVisualizerKey.Location = new System.Drawing.Point(63, 61);
            this.binaryVisualizerKey.Name = "binaryVisualizerKey";
            this.binaryVisualizerKey.Size = new System.Drawing.Size(177, 36);
            this.binaryVisualizerKey.TabIndex = 5;
            this.binaryVisualizerKey.Text = "Binary Visualizer";
            this.binaryVisualizerKey.UseVisualStyleBackColor = true;
            this.binaryVisualizerKey.Click += new System.EventHandler(this.binaryVisualizerKey_Click);
            // 
            // UserControlHomeUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.binaryVisualizerKey);
            this.Controls.Add(this.logKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.welcomeLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlHomeUi";
            this.Size = new System.Drawing.Size(1088, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logKey;
        private System.Windows.Forms.Button binaryVisualizerKey;
    }
}
