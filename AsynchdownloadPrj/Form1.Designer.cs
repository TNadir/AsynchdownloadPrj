namespace AsynchdownloadPrj
{
    partial class Form1
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
            this.addUrl = new System.Windows.Forms.Button();
            this.urlText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultsWindow = new System.Windows.Forms.Label();
            this.cancelOperation = new System.Windows.Forms.Button();
            this.executeAsync = new System.Windows.Forms.Button();
            this.listUrls = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // addUrl
            // 
            this.addUrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUrl.Location = new System.Drawing.Point(443, 12);
            this.addUrl.Name = "addUrl";
            this.addUrl.Size = new System.Drawing.Size(187, 44);
            this.addUrl.TabIndex = 0;
            this.addUrl.Text = "Add url for download ";
            this.addUrl.UseVisualStyleBackColor = false;
            this.addUrl.Click += new System.EventHandler(this.addUrl_Click);
            // 
            // urlText
            // 
            this.urlText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.urlText.Location = new System.Drawing.Point(133, 25);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(289, 20);
            this.urlText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter URL";
            // 
            // resultsWindow
            // 
            this.resultsWindow.AutoSize = true;
            this.resultsWindow.Location = new System.Drawing.Point(654, 65);
            this.resultsWindow.Name = "resultsWindow";
            this.resultsWindow.Size = new System.Drawing.Size(0, 13);
            this.resultsWindow.TabIndex = 10;
            // 
            // cancelOperation
            // 
            this.cancelOperation.BackColor = System.Drawing.Color.Red;
            this.cancelOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelOperation.Location = new System.Drawing.Point(443, 204);
            this.cancelOperation.Name = "cancelOperation";
            this.cancelOperation.Size = new System.Drawing.Size(187, 47);
            this.cancelOperation.TabIndex = 11;
            this.cancelOperation.Text = "Cancel";
            this.cancelOperation.UseVisualStyleBackColor = false;
            this.cancelOperation.Click += new System.EventHandler(this.cancelOperation_Click);
            // 
            // executeAsync
            // 
            this.executeAsync.BackColor = System.Drawing.Color.Chartreuse;
            this.executeAsync.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executeAsync.Location = new System.Drawing.Point(443, 109);
            this.executeAsync.Name = "executeAsync";
            this.executeAsync.Size = new System.Drawing.Size(187, 47);
            this.executeAsync.TabIndex = 12;
            this.executeAsync.Text = "Download";
            this.executeAsync.UseVisualStyleBackColor = false;
            this.executeAsync.Click += new System.EventHandler(this.executeAsync_Click);
            // 
            // listUrls
            // 
            this.listUrls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listUrls.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.listUrls.FormattingEnabled = true;
            this.listUrls.Location = new System.Drawing.Point(30, 65);
            this.listUrls.Name = "listUrls";
            this.listUrls.Size = new System.Drawing.Size(392, 186);
            this.listUrls.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 800);
            this.Controls.Add(this.executeAsync);
            this.Controls.Add(this.cancelOperation);
            this.Controls.Add(this.resultsWindow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlText);
            this.Controls.Add(this.listUrls);
            this.Controls.Add(this.addUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addUrl;
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label resultsWindow;
        private System.Windows.Forms.Button cancelOperation;
        private System.Windows.Forms.Button executeAsync;
        private System.Windows.Forms.ListBox listUrls;
    }
}

