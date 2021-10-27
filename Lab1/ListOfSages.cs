using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab1
{
    public partial class ListOfSages : Form
    {
        SageBookDBContext db = new SageBookDBContext();
        Book Book;
        public List<Sage> SelectedSages = new List<Sage>();
        public ListOfSages(Book book)
        {
            this.Book = book;
            InitializeComponent();
        }

        private void ListOfSages_Load(object sender, EventArgs e)
        {
            this.SelectedSages = db.Sages.Where(b => b.Books.Where(s => s.IdBook == Book.IdBook).Count() == 0).Select(x => x).ToList();
            var sages = this.SelectedSages.Select(x => new { Id = x.IdSage, Name = x.name }).ToList();
            this.clbSages.DataSource = sages;
            this.clbSages.DisplayMember = "Name";
            this.clbSages.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = this.clbSages.Items.Count - 1; i > -1; i--)
            {
                if (!this.clbSages.GetItemChecked(i))
                    this.SelectedSages.RemoveAt(i);
            }
            this.Visible = false;
        }
    }
}
