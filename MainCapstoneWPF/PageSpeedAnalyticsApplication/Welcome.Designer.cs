namespace PageSpeedAnalyticsApplication
{
    partial class Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.EnterURLButton = new System.Windows.Forms.Button();
            this.EnterCSVButton = new System.Windows.Forms.Button();
            this.WelcomeHelpButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(134, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "PageSpeed Analytics Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EnterURLButton
            // 
            this.EnterURLButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterURLButton.Location = new System.Drawing.Point(209, 284);
            this.EnterURLButton.Name = "EnterURLButton";
            this.EnterURLButton.Size = new System.Drawing.Size(573, 94);
            this.EnterURLButton.TabIndex = 1;
            this.EnterURLButton.Text = "Enter URLs";
            this.EnterURLButton.UseVisualStyleBackColor = true;
            this.EnterURLButton.Click += new System.EventHandler(this.EnterURLButton_Click);
            // 
            // EnterCSVButton
            // 
            this.EnterCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterCSVButton.Location = new System.Drawing.Point(209, 456);
            this.EnterCSVButton.Name = "EnterCSVButton";
            this.EnterCSVButton.Size = new System.Drawing.Size(573, 100);
            this.EnterCSVButton.TabIndex = 2;
            this.EnterCSVButton.Text = "Run Using CSV";
            this.EnterCSVButton.UseVisualStyleBackColor = true;
            this.EnterCSVButton.Click += new System.EventHandler(this.EnterCSVButton_Click);
            // 
            // WelcomeHelpButton
            // 
            this.WelcomeHelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeHelpButton.Location = new System.Drawing.Point(43, 650);
            this.WelcomeHelpButton.Name = "WelcomeHelpButton";
            this.WelcomeHelpButton.Size = new System.Drawing.Size(235, 105);
            this.WelcomeHelpButton.TabIndex = 3;
            this.WelcomeHelpButton.Text = "Help";
            this.WelcomeHelpButton.UseVisualStyleBackColor = true;
            this.WelcomeHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(726, 650);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Padding = new System.Windows.Forms.Padding(1);
            this.QuitButton.Size = new System.Drawing.Size(235, 105);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 833);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.WelcomeHelpButton);
            this.Controls.Add(this.EnterCSVButton);
            this.Controls.Add(this.EnterURLButton);
            this.Controls.Add(this.label1);
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PageSpeed Analytics Application";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EnterURLButton;
        private System.Windows.Forms.Button EnterCSVButton;
        private System.Windows.Forms.Button WelcomeHelpButton;
        private System.Windows.Forms.Button QuitButton;
    }
}