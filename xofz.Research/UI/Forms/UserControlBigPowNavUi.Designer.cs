﻿namespace xofz.Research.UI.Forms
{
    partial class UserControlBigPowNavUi
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
            this.homeKey = new System.Windows.Forms.Button();
            this.controlHubKey = new System.Windows.Forms.Button();
            this.rotationKey = new System.Windows.Forms.Button();
            this.factorialKey = new System.Windows.Forms.Button();
            this.primesKey = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel.Controls.Add(this.homeKey, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.controlHubKey, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.rotationKey, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.factorialKey, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.primesKey, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.loginKey, 6, 0);
            this.tableLayoutPanel.Controls.Add(this.shutdownKey, 7, 0);
            this.tableLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1088, 50);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // homeKey
            // 
            this.homeKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.homeKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.homeKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeKey.Location = new System.Drawing.Point(3, 3);
            this.homeKey.Name = "homeKey";
            this.homeKey.Size = new System.Drawing.Size(130, 44);
            this.homeKey.TabIndex = 7;
            this.homeKey.Text = "Home";
            this.homeKey.UseVisualStyleBackColor = true;
            this.homeKey.Click += new System.EventHandler(this.homeKey_Click);
            // 
            // controlHubKey
            // 
            this.controlHubKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlHubKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.controlHubKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.controlHubKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlHubKey.Location = new System.Drawing.Point(683, 3);
            this.controlHubKey.Name = "controlHubKey";
            this.controlHubKey.Size = new System.Drawing.Size(130, 44);
            this.controlHubKey.TabIndex = 6;
            this.controlHubKey.Text = "Control Hub";
            this.controlHubKey.UseVisualStyleBackColor = true;
            this.controlHubKey.Visible = false;
            this.controlHubKey.Click += new System.EventHandler(this.controlHubKey_Click);
            // 
            // rotationKey
            // 
            this.rotationKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.rotationKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.rotationKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotationKey.Location = new System.Drawing.Point(411, 3);
            this.rotationKey.Name = "rotationKey";
            this.rotationKey.Size = new System.Drawing.Size(130, 44);
            this.rotationKey.TabIndex = 5;
            this.rotationKey.Text = "Rotation";
            this.rotationKey.UseVisualStyleBackColor = true;
            this.rotationKey.Click += new System.EventHandler(this.rotationKey_Click);
            // 
            // factorialKey
            // 
            this.factorialKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.factorialKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.factorialKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.factorialKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.factorialKey.Location = new System.Drawing.Point(275, 3);
            this.factorialKey.Name = "factorialKey";
            this.factorialKey.Size = new System.Drawing.Size(130, 44);
            this.factorialKey.TabIndex = 4;
            this.factorialKey.Text = "Factorial";
            this.factorialKey.UseVisualStyleBackColor = true;
            this.factorialKey.Click += new System.EventHandler(this.factorialKey_Click);
            // 
            // primesKey
            // 
            this.primesKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.primesKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.primesKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.primesKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.primesKey.Location = new System.Drawing.Point(139, 3);
            this.primesKey.Name = "primesKey";
            this.primesKey.Size = new System.Drawing.Size(130, 44);
            this.primesKey.TabIndex = 3;
            this.primesKey.Text = "Primes";
            this.primesKey.UseVisualStyleBackColor = true;
            this.primesKey.Click += new System.EventHandler(this.primesKey_Click);
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
            // UserControlBigPowNavUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "UserControlBigPowNavUi";
            this.Size = new System.Drawing.Size(1088, 50);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button controlHubKey;
        private System.Windows.Forms.Button rotationKey;
        private System.Windows.Forms.Button factorialKey;
        private System.Windows.Forms.Button primesKey;
        private System.Windows.Forms.Button loginKey;
        private System.Windows.Forms.Button shutdownKey;
        private System.Windows.Forms.Button homeKey;
    }
}
