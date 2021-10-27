namespace Lab1
{
    partial class ListOfBooks
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
            this.components = new System.ComponentModel.Container();
            this.clbBooks = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clbBooks
            // 
            this.clbBooks.FormattingEnabled = true;
            this.clbBooks.Location = new System.Drawing.Point(12, 12);
            this.clbBooks.Name = "clbBooks";
            this.clbBooks.Size = new System.Drawing.Size(242, 184);
            this.clbBooks.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Books";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sageBindingSource
            // 
            this.sageBindingSource.DataSource = typeof(Lab1.Models.Sage);
            // 
            // ListOfBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 243);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clbBooks);
            this.Name = "ListOfBooks";
            this.Text = "ListOfBooks";
            this.Load += new System.EventHandler(this.ListOfBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource sageBindingSource;
        private System.Windows.Forms.CheckedListBox clbBooks;
        private System.Windows.Forms.Button button1;
    }
}