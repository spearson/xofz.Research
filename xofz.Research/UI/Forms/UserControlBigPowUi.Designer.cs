namespace xofz.Research.UI.Forms
{
    partial class UserControlBigPowUi
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
            this.saveKey = new System.Windows.Forms.Button();
            this.durationLabel = new System.Windows.Forms.Label();
            this.computeKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.powerTextBox = new System.Windows.Forms.TextBox();
            this.numberInputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.exponentInputTextBox = new System.Windows.Forms.TextBox();
            this.displayKey = new System.Windows.Forms.Button();
            this.multiPowKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveKey
            // 
            this.saveKey.AutoSize = true;
            this.saveKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.saveKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveKey.Location = new System.Drawing.Point(352, 78);
            this.saveKey.Name = "saveKey";
            this.saveKey.Size = new System.Drawing.Size(61, 32);
            this.saveKey.TabIndex = 4;
            this.saveKey.Text = "Save";
            this.saveKey.UseVisualStyleBackColor = true;
            this.saveKey.Click += new System.EventHandler(this.saveKey_Click);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabel.Location = new System.Drawing.Point(505, 19);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(2, 18);
            this.durationLabel.TabIndex = 17;
            // 
            // computeKey
            // 
            this.computeKey.AutoSize = true;
            this.computeKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.computeKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.computeKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.computeKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.computeKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.computeKey.Location = new System.Drawing.Point(239, 40);
            this.computeKey.Name = "computeKey";
            this.computeKey.Size = new System.Drawing.Size(93, 32);
            this.computeKey.TabIndex = 2;
            this.computeKey.Text = "Compute";
            this.computeKey.UseVisualStyleBackColor = true;
            this.computeKey.Click += new System.EventHandler(this.computeKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "Power:";
            // 
            // powerTextBox
            // 
            this.powerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.powerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerTextBox.Location = new System.Drawing.Point(91, 133);
            this.powerTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.powerTextBox.Multiline = true;
            this.powerTextBox.Name = "powerTextBox";
            this.powerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.powerTextBox.Size = new System.Drawing.Size(997, 468);
            this.powerTextBox.TabIndex = 14;
            // 
            // numberInputTextBox
            // 
            this.numberInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberInputTextBox.Location = new System.Drawing.Point(91, 40);
            this.numberInputTextBox.Name = "numberInputTextBox";
            this.numberInputTextBox.Size = new System.Drawing.Size(142, 29);
            this.numberInputTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Input a number:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(413, 37);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "Large Power Computation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Exponent:";
            // 
            // exponentInputTextBox
            // 
            this.exponentInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exponentInputTextBox.Location = new System.Drawing.Point(91, 78);
            this.exponentInputTextBox.Name = "exponentInputTextBox";
            this.exponentInputTextBox.Size = new System.Drawing.Size(142, 29);
            this.exponentInputTextBox.TabIndex = 1;
            // 
            // displayKey
            // 
            this.displayKey.AutoSize = true;
            this.displayKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.displayKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.displayKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayKey.Location = new System.Drawing.Point(239, 78);
            this.displayKey.Name = "displayKey";
            this.displayKey.Size = new System.Drawing.Size(79, 32);
            this.displayKey.TabIndex = 3;
            this.displayKey.Text = "Display";
            this.displayKey.UseVisualStyleBackColor = true;
            this.displayKey.Click += new System.EventHandler(this.displayKey_Click);
            // 
            // multiPowKey
            // 
            this.multiPowKey.AutoSize = true;
            this.multiPowKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.multiPowKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.multiPowKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.multiPowKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiPowKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiPowKey.Location = new System.Drawing.Point(395, 40);
            this.multiPowKey.Name = "multiPowKey";
            this.multiPowKey.Size = new System.Drawing.Size(98, 32);
            this.multiPowKey.TabIndex = 20;
            this.multiPowKey.Text = "Multi-Pow";
            this.multiPowKey.UseVisualStyleBackColor = true;
            this.multiPowKey.Click += new System.EventHandler(this.multiPowKey_Click);
            // 
            // UserControlBigPowUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.multiPowKey);
            this.Controls.Add(this.displayKey);
            this.Controls.Add(this.exponentInputTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveKey);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.computeKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.powerTextBox);
            this.Controls.Add(this.numberInputTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlBigPowUi";
            this.Size = new System.Drawing.Size(1088, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveKey;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Button computeKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox powerTextBox;
        private System.Windows.Forms.TextBox numberInputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox exponentInputTextBox;
        private System.Windows.Forms.Button displayKey;
        private System.Windows.Forms.Button multiPowKey;
    }
}
