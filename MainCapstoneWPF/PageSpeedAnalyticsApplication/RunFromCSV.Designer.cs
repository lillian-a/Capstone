namespace PageSpeedAnalyticsApplication
{
    partial class RunFromCSV
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
            System.Windows.Forms.Button CSVChooseFileButton;
            this.CSVSubmitButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.CSVTitleLabel = new System.Windows.Forms.Label();
            this.CSVFileNameLabel = new System.Windows.Forms.Label();
            this.RunFromCSVCancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.RunFromCSVHelpButton = new System.Windows.Forms.Button();
            CSVChooseFileButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CSVChooseFileButton
            // 
            CSVChooseFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            CSVChooseFileButton.Location = new System.Drawing.Point(412, 206);
            CSVChooseFileButton.Name = "CSVChooseFileButton";
            CSVChooseFileButton.Size = new System.Drawing.Size(259, 82);
            CSVChooseFileButton.TabIndex = 2;
            CSVChooseFileButton.Text = "Select File";
            CSVChooseFileButton.UseVisualStyleBackColor = true;
            CSVChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // CSVSubmitButton
            // 
            this.CSVSubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CSVSubmitButton.Location = new System.Drawing.Point(731, 860);
            this.CSVSubmitButton.Name = "CSVSubmitButton";
            this.CSVSubmitButton.Size = new System.Drawing.Size(260, 100);
            this.CSVSubmitButton.TabIndex = 0;
            this.CSVSubmitButton.Text = "Submit";
            this.CSVSubmitButton.UseVisualStyleBackColor = true;
            this.CSVSubmitButton.Click += new System.EventHandler(this.CSVGoButton_Click);
            // 
            // CSVTitleLabel
            // 
            this.CSVTitleLabel.AutoSize = true;
            this.CSVTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSVTitleLabel.Location = new System.Drawing.Point(222, 43);
            this.CSVTitleLabel.Name = "CSVTitleLabel";
            this.CSVTitleLabel.Size = new System.Drawing.Size(563, 69);
            this.CSVTitleLabel.TabIndex = 1;
            this.CSVTitleLabel.Text = "Run From CSV File";
            this.CSVTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CSVFileNameLabel
            // 
            this.CSVFileNameLabel.AutoSize = true;
            this.CSVFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CSVFileNameLabel.Location = new System.Drawing.Point(418, 402);
            this.CSVFileNameLabel.Name = "CSVFileNameLabel";
            this.CSVFileNameLabel.Size = new System.Drawing.Size(222, 46);
            this.CSVFileNameLabel.TabIndex = 3;
            this.CSVFileNameLabel.Text = "File: NONE";
            // 
            // RunFromCSVCancelButton
            // 
            this.RunFromCSVCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RunFromCSVCancelButton.Location = new System.Drawing.Point(66, 860);
            this.RunFromCSVCancelButton.Name = "RunFromCSVCancelButton";
            this.RunFromCSVCancelButton.Size = new System.Drawing.Size(260, 100);
            this.RunFromCSVCancelButton.TabIndex = 4;
            this.RunFromCSVCancelButton.Text = "Cancel";
            this.RunFromCSVCancelButton.UseVisualStyleBackColor = true;
            this.RunFromCSVCancelButton.Click += new System.EventHandler(this.RunFromCSVCancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(61, 517);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(947, 175);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Method:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(643, 70);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(140, 50);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Both";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(368, 71);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(165, 50);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "HTML";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(122, 70);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(140, 50);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "CSV";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RunFromCSVHelpButton
            // 
            this.RunFromCSVHelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RunFromCSVHelpButton.Location = new System.Drawing.Point(396, 860);
            this.RunFromCSVHelpButton.Name = "RunFromCSVHelpButton";
            this.RunFromCSVHelpButton.Size = new System.Drawing.Size(260, 100);
            this.RunFromCSVHelpButton.TabIndex = 6;
            this.RunFromCSVHelpButton.Text = "Help";
            this.RunFromCSVHelpButton.UseVisualStyleBackColor = true;
            this.RunFromCSVHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // RunFromCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 1253);
            this.Controls.Add(this.RunFromCSVHelpButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RunFromCSVCancelButton);
            this.Controls.Add(this.CSVFileNameLabel);
            this.Controls.Add(CSVChooseFileButton);
            this.Controls.Add(this.CSVTitleLabel);
            this.Controls.Add(this.CSVSubmitButton);
            //this.MinimumSize = new System.Drawing.Size(1144, 1341);
            this.Name = "RunFromCSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PageSpeed Analytics Application";
            this.Load += new System.EventHandler(this.RunFromCSV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CSVSubmitButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label CSVTitleLabel;
        private System.Windows.Forms.Label CSVFileNameLabel;
        private System.Windows.Forms.Button RunFromCSVCancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button RunFromCSVHelpButton;
    }
}