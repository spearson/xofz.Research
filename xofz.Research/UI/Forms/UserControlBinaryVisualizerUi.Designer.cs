namespace xofz.Research.UI.Forms
{
    partial class UserControlBinaryVisualizerUi
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
            this.label2 = new System.Windows.Forms.Label();
            this.binaryTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.translateKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Binary form";
            // 
            // binaryTextBox
            // 
            this.binaryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.binaryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binaryTextBox.Location = new System.Drawing.Point(91, 133);
            this.binaryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.binaryTextBox.Multiline = true;
            this.binaryTextBox.Name = "binaryTextBox";
            this.binaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.binaryTextBox.Size = new System.Drawing.Size(997, 468);
            this.binaryTextBox.TabIndex = 11;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(91, 51);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(727, 29);
            this.inputTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input a number:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(272, 37);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Binary Visualizer";
            // 
            // translateKey
            // 
            this.translateKey.AutoSize = true;
            this.translateKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.translateKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.translateKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.translateKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.translateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translateKey.Location = new System.Drawing.Point(824, 51);
            this.translateKey.Name = "translateKey";
            this.translateKey.Size = new System.Drawing.Size(96, 32);
            this.translateKey.TabIndex = 13;
            this.translateKey.Text = "Translate";
            this.translateKey.UseVisualStyleBackColor = true;
            this.translateKey.Click += new System.EventHandler(this.translateKey_Click);
            // 
            // UserControlBinaryVisualizerUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.translateKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.binaryTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Name = "UserControlBinaryVisualizerUi";
            this.Size = new System.Drawing.Size(1088, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox binaryTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button translateKey;
    }
}
