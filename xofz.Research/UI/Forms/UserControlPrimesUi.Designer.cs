namespace xofz.Research.UI.Forms
{
    partial class UserControlPrimesUi
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.generateKey = new System.Windows.Forms.Button();
            this.numberToGenerateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentPrimeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPrimeIndexLabel = new System.Windows.Forms.Label();
            this.restartKey = new System.Windows.Forms.Button();
            this.saveKey = new System.Windows.Forms.Button();
            this.stopKey = new System.Windows.Forms.Button();
            this.loadKey = new System.Windows.Forms.Button();
            this.locator = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(283, 37);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Prime Generation";
            // 
            // generateKey
            // 
            this.generateKey.AutoSize = true;
            this.generateKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.generateKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.generateKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.generateKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateKey.Location = new System.Drawing.Point(7, 85);
            this.generateKey.Name = "generateKey";
            this.generateKey.Size = new System.Drawing.Size(97, 32);
            this.generateKey.TabIndex = 1;
            this.generateKey.Text = "Generate";
            this.generateKey.UseVisualStyleBackColor = true;
            this.generateKey.Click += new System.EventHandler(this.generateKey_Click);
            // 
            // numberToGenerateTextBox
            // 
            this.numberToGenerateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberToGenerateTextBox.Location = new System.Drawing.Point(7, 53);
            this.numberToGenerateTextBox.Name = "numberToGenerateTextBox";
            this.numberToGenerateTextBox.Size = new System.Drawing.Size(137, 26);
            this.numberToGenerateTextBox.TabIndex = 0;
            this.numberToGenerateTextBox.Text = "1";
            this.numberToGenerateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of primes to generate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Prime:";
            // 
            // currentPrimeLabel
            // 
            this.currentPrimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentPrimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentPrimeLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPrimeLabel.Location = new System.Drawing.Point(7, 147);
            this.currentPrimeLabel.Name = "currentPrimeLabel";
            this.currentPrimeLabel.Size = new System.Drawing.Size(193, 40);
            this.currentPrimeLabel.TabIndex = 7;
            this.currentPrimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prime Index:";
            // 
            // currentPrimeIndexLabel
            // 
            this.currentPrimeIndexLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentPrimeIndexLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentPrimeIndexLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPrimeIndexLabel.Location = new System.Drawing.Point(7, 214);
            this.currentPrimeIndexLabel.Name = "currentPrimeIndexLabel";
            this.currentPrimeIndexLabel.Size = new System.Drawing.Size(193, 40);
            this.currentPrimeIndexLabel.TabIndex = 9;
            this.currentPrimeIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // restartKey
            // 
            this.restartKey.AutoSize = true;
            this.restartKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.restartKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.restartKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.restartKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartKey.Location = new System.Drawing.Point(7, 257);
            this.restartKey.Name = "restartKey";
            this.restartKey.Size = new System.Drawing.Size(81, 32);
            this.restartKey.TabIndex = 10;
            this.restartKey.Text = "Restart";
            this.restartKey.UseVisualStyleBackColor = true;
            this.restartKey.Click += new System.EventHandler(this.restartKey_Click);
            // 
            // saveKey
            // 
            this.saveKey.AutoSize = true;
            this.saveKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.saveKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveKey.Location = new System.Drawing.Point(7, 337);
            this.saveKey.Name = "saveKey";
            this.saveKey.Size = new System.Drawing.Size(159, 32);
            this.saveKey.TabIndex = 11;
            this.saveKey.Text = "Save Current Set";
            this.saveKey.UseVisualStyleBackColor = true;
            this.saveKey.Click += new System.EventHandler(this.saveKey_Click);
            // 
            // stopKey
            // 
            this.stopKey.AutoSize = true;
            this.stopKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stopKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.stopKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.stopKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopKey.Location = new System.Drawing.Point(186, 85);
            this.stopKey.Name = "stopKey";
            this.stopKey.Size = new System.Drawing.Size(59, 32);
            this.stopKey.TabIndex = 2;
            this.stopKey.Text = "Stop";
            this.stopKey.UseVisualStyleBackColor = true;
            this.stopKey.Visible = false;
            this.stopKey.Click += new System.EventHandler(this.stopKey_Click);
            // 
            // loadKey
            // 
            this.loadKey.AutoSize = true;
            this.loadKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.loadKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.loadKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadKey.Location = new System.Drawing.Point(7, 436);
            this.loadKey.Name = "loadKey";
            this.loadKey.Size = new System.Drawing.Size(94, 32);
            this.loadKey.TabIndex = 13;
            this.loadKey.Text = "Load Set";
            this.loadKey.UseVisualStyleBackColor = true;
            this.loadKey.Click += new System.EventHandler(this.loadKey_Click);
            // 
            // locator
            // 
            this.locator.Filter = "Text files|*.txt|All files|*.*";
            // 
            // UserControlPrimesUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.loadKey);
            this.Controls.Add(this.stopKey);
            this.Controls.Add(this.saveKey);
            this.Controls.Add(this.restartKey);
            this.Controls.Add(this.currentPrimeIndexLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentPrimeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberToGenerateTextBox);
            this.Controls.Add(this.generateKey);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlPrimesUi";
            this.Size = new System.Drawing.Size(1088, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button generateKey;
        private System.Windows.Forms.TextBox numberToGenerateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentPrimeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label currentPrimeIndexLabel;
        private System.Windows.Forms.Button restartKey;
        private System.Windows.Forms.Button saveKey;
        private System.Windows.Forms.Button stopKey;
        private System.Windows.Forms.Button loadKey;
        private System.Windows.Forms.OpenFileDialog locator;
    }
}
