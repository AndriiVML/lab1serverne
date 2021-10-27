namespace Lab1
{
    partial class ListOfSages
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
            this.clbSages = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbSages
            // 
            this.clbSages.FormattingEnabled = true;
            this.clbSages.Location = new System.Drawing.Point(12, 12);
            this.clbSages.Name = "clbSages";
            this.clbSages.Size = new System.Drawing.Size(242, 184);
            this.clbSages.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Sages";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListOfSages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 243);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clbSages);
            this.Name = "ListOfSages";
            this.Text = "ListOfSages";
            this.Load += new System.EventHandler(this.ListOfSages_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbSages;
        private System.Windows.Forms.Button button1;
    }
}