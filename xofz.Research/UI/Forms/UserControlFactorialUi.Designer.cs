namespace xofz.Research.UI.Forms
{
    partial class UserControlFactorialUi
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
            this.label1 = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.factorialTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.computeKey = new System.Windows.Forms.Button();
            this.durationLabel = new System.Windows.Forms.Label();
            this.saveKey = new System.Windows.Forms.Button();
            this.displayKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(354, 37);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Factorial Computation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input a number:";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(91, 51);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(142, 29);
            this.inputTextBox.TabIndex = 5;
            // 
            // factorialTextBox
            // 
            this.factorialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.factorialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factorialTextBox.Location = new System.Drawing.Point(91, 133);
            this.factorialTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.factorialTextBox.Multiline = true;
            this.factorialTextBox.Name = "factorialTextBox";
            this.factorialTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.factorialTextBox.Size = new System.Drawing.Size(997, 468);
            this.factorialTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Factorial:";
            // 
            // computeKey
            // 
            this.computeKey.AutoSize = true;
            this.computeKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.computeKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.computeKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.computeKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.computeKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.computeKey.Location = new System.Drawing.Point(239, 51);
            this.computeKey.Name = "computeKey";
            this.computeKey.Size = new System.Drawing.Size(93, 32);
            this.computeKey.TabIndex = 8;
            this.computeKey.Text = "Compute";
            this.computeKey.UseVisualStyleBackColor = true;
            this.computeKey.Click += new System.EventHandler(this.computeKey_Click);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabel.Location = new System.Drawing.Point(505, 19);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(2, 18);
            this.durationLabel.TabIndex = 9;
            // 
            // saveKey
            // 
            this.saveKey.AutoSize = true;
            this.saveKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.saveKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveKey.Location = new System.Drawing.Point(390, 51);
            this.saveKey.Name = "saveKey";
            this.saveKey.Size = new System.Drawing.Size(61, 32);
            this.saveKey.TabIndex = 10;
            this.saveKey.Text = "Save";
            this.saveKey.UseVisualStyleBackColor = true;
            this.saveKey.Click += new System.EventHandler(this.saveKey_Click);
            // 
            // displayKey
            // 
            this.displayKey.AutoSize = true;
            this.displayKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.displayKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.displayKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayKey.Location = new System.Drawing.Point(239, 89);
            this.displayKey.Name = "displayKey";
            this.displayKey.Size = new System.Drawing.Size(79, 32);
            this.displayKey.TabIndex = 22;
            this.displayKey.Text = "Display";
            this.displayKey.UseVisualStyleBackColor = true;
            this.displayKey.Click += new System.EventHandler(this.displayKey_Click);
            // 
            // UserControlFactorialUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.displayKey);
            this.Controls.Add(this.saveKey);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.computeKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.factorialTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlFactorialUi";
            this.Size = new System.Drawing.Size(1088, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox factorialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button computeKey;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Button saveKey;
        private System.Windows.Forms.Button displayKey;
    }
}
