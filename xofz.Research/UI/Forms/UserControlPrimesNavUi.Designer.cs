namespace xofz.Research.UI.Forms
{
    partial class UserControlPrimesNavUi
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rotationKey = new System.Windows.Forms.Button();
            this.loginKey = new System.Windows.Forms.Button();
            this.shutdownKey = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 8;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel.Controls.Add(this.rotationKey, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.loginKey, 6, 0);
            this.tableLayoutPanel.Controls.Add(this.shutdownKey, 7, 0);
            this.tableLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1088, 50);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // rotationKey
            // 
            this.rotationKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.rotationKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.rotationKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotationKey.Location = new System.Drawing.Point(3, 3);
            this.rotationKey.Name = "rotationKey";
            this.rotationKey.Size = new System.Drawing.Size(130, 44);
            this.rotationKey.TabIndex = 3;
            this.rotationKey.Text = "Rotation";
            this.rotationKey.UseVisualStyleBackColor = true;
            this.rotationKey.Click += new System.EventHandler(this.rotationKey_Click);
            // 
            // loginKey
            // 
            this.loginKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.loginKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.loginKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginKey.Location = new System.Drawing.Point(819, 3);
            this.loginKey.Name = "loginKey";
            this.loginKey.Size = new System.Drawing.Size(130, 44);
            this.loginKey.TabIndex = 1;
            this.loginKey.Text = "Log In";
            this.loginKey.UseVisualStyleBackColor = true;
            this.loginKey.Click += new System.EventHandler(this.loginKey_Click);
            // 
            // shutdownKey
            // 
            this.shutdownKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shutdownKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.shutdownKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.shutdownKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdownKey.Location = new System.Drawing.Point(955, 3);
            this.shutdownKey.Name = "shutdownKey";
            this.shutdownKey.Size = new System.Drawing.Size(130, 44);
            this.shutdownKey.TabIndex = 2;
            this.shutdownKey.Text = "Shutdown";
            this.shutdownKey.UseVisualStyleBackColor = true;
            this.shutdownKey.Click += new System.EventHandler(this.shutdownKey_Click);
            // 
            // UserControlPrimesNavUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlPrimesNavUi";
            this.Size = new System.Drawing.Size(1088, 50);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button rotationKey;
        private System.Windows.Forms.Button loginKey;
        private System.Windows.Forms.Button shutdownKey;
    }
}
