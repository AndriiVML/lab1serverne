using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab1
{
    public partial class ListOfBooks : Form
    {
        SageBookDBContext db = new SageBookDBContext();
        Sage Sage;
        public List<Book> SelectedBooks = new List<Book>();
        public ListOfBooks(Sage sage)
        {
            this.Sage = sage;
            InitializeComponent();
        }

        private void ListOfBooks_Load(object sender, EventArgs e)
        {
            this.SelectedBooks = db.Books.Where(b => b.Sages.Where(s => s.IdSage == Sage.IdSage).Count() == 0).Select(x => x).ToList();
            var books = this.SelectedBooks.Select(x => new { Id = x.IdBook, Name = x.name }).ToList();
            try
            {
                this.clbBooks.DataSource = books;
            } finally
            {
                
            }
            this.clbBooks.DisplayMember = "Name";
            this.clbBooks.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = this.clbBooks.Items.Count - 1; i > -1; i--)
            {
                if (!this.clbBooks.GetItemChecked(i))
                    this.SelectedBooks.RemoveAt(i);
            }
            this.Visible = false;
        }
    }
}
