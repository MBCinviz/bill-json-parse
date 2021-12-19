
namespace BillJsonParse
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
            this.btnJsonParse = new System.Windows.Forms.Button();
            this.textJsonConvert = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnJsonParse
            // 
            this.btnJsonParse.Location = new System.Drawing.Point(433, 12);
            this.btnJsonParse.Name = "btnJsonParse";
            this.btnJsonParse.Size = new System.Drawing.Size(123, 23);
            this.btnJsonParse.TabIndex = 0;
            this.btnJsonParse.Text = "JSON DOSYA SEÇ";
            this.btnJsonParse.UseVisualStyleBackColor = true;
            this.btnJsonParse.Click += new System.EventHandler(this.btnJsonParse_Click);
            // 
            // textJsonConvert
            // 
            this.textJsonConvert.Location = new System.Drawing.Point(12, 12);
            this.textJsonConvert.Name = "textJsonConvert";
            this.textJsonConvert.Size = new System.Drawing.Size(405, 426);
            this.textJsonConvert.TabIndex = 1;
            this.textJsonConvert.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 450);
            this.Controls.Add(this.textJsonConvert);
            this.Controls.Add(this.btnJsonParse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJsonParse;
        private System.Windows.Forms.RichTextBox textJsonConvert;
    }
}

