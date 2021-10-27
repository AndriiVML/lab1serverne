using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Main : Form
    {
        SageBookDBContext db = new SageBookDBContext();
        public List<Sage> SelectedSages;
        public List<Book> SelectedBooks;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        #region Help Methods

        private void Init()
        {
            BookBindingSource.DataSource = db.Books.ToList();
            SageBindingSource.DataSource = db.Sages.ToList();
            Book CurrentBook = (BookBindingSource.Current as Book) ?? new Book();
            Sage CurrentSage = (SageBindingSource.Current as Sage) ?? new Sage();
            BookSagesBindingSource.DataSource = CurrentBook.Sages.ToList();
            SageBooksBindingSource.DataSource = CurrentSage.Books.ToList();
            picSagePhoto.Image = null;
            picSagePhoto.ImageLocation = null;
        }
        private Book GetBookFromFormBookDetails()
        {
            Book book = new Book();
            int id = 0;
            if(Int32.TryParse(txtbBookId.Text, out id))
                book.IdBook = id;
            else
                book.IdBook = 0;
            book.name = txtbBookName.Text;
            book.description = txtbBookDescription.Text;
            return book;
        }
        private Sage GetSageFromFormSageDetails()
        {
            Sage sage = new Sage();
            int id = 0;
            if (Int32.TryParse(txtbSageId.Text, out id))
                sage.IdSage = id;
            else
                sage.IdSage = 0;
            sage.name = txtbSageName.Text;
            if (Int32.TryParse(txtbSageAge.Text, out id))
                sage.age = id;
            else
                sage.age = 0;
            sage.photo = picSagePhoto.ImageLocation;
            sage.city = txtbSageCity.Text;
            return sage;
        }
        private void ClearBookInputs()
        {
            txtbBookId.Text = "";
            txtbBookName.Text = "";
            txtbBookDescription.Text = "";
        }
        private void ClearSageInputs()
        {
            txtbSageId.Text = "";
            txtbSageName.Text = "";
            txtbSageAge.Text = "";
            txtbSageCity.Text = "";
            picSagePhoto.Image = null;
            picSagePhoto.ImageLocation = null;
        }
        private Image GetImage(string FilePath)
        {
            return (File.Exists(FilePath) ? (Image)(new Bitmap(Image.FromFile(FilePath), new Size(98, 138))) : null);
        }
        private void ListOfBooksFormVisibleChanged(object sender, EventArgs e)
        {
            Sage sage = SageBindingSource.Current as Sage;
            this.SelectedBooks = new List<Book>();
            ListOfBooks frm = (ListOfBooks)sender;
            if (!frm.Visible)
            {
                this.SelectedBooks = frm.SelectedBooks;
                frm.Dispose();
            }
            this.SageBooksBindingSource.DataSource = this.SelectedBooks;
            this.SelectedBooks.ForEach(x =>
                this.db.Sages.Find(sage.IdSage).Books.Add(this.db.Books.Find(x.IdBook))
            );
            this.db.SaveChanges();
        }
        private void ListOfSagesFormVisibleChanged(object sender, EventArgs e)
        {
            Book book = BookBindingSource.Current as Book;
            this.SelectedSages = new List<Sage>();
            ListOfSages frm = (ListOfSages)sender;
            if (!frm.Visible)
            {
                this.SelectedSages = frm.SelectedSages;
                frm.Dispose();
            }
            this.BookSagesBindingSource.DataSource = this.SelectedSages;
            this.SelectedSages.ForEach(x =>
                this.db.Books.Find(book.IdBook).Sages.Add(this.db.Sages.Find(x.IdSage))
            );
            this.db.SaveChanges();
        }
        #endregion Help Methods

        #region Buttons

        #region Book Buttons
        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            Book book = this.GetBookFromFormBookDetails();
            book.IdBook = 0;
            if (book != null)
            {
                db.RollBack();
                db.Books.Add(book);
                db.SaveChanges();
                this.Init();
            }
        }
        private void btnBookUpdate_Click(object sender, EventArgs e)
        {
            Book NewBook = this.GetBookFromFormBookDetails();
            Book OldBook = db.Books.Where(x => x.IdBook == NewBook.IdBook).Select(x => x).FirstOrDefault();
            if (NewBook != null && OldBook != null)
            {
                //OldBook.name = NewBook.name;
                //OldBook.description = NewBook.description;
                //Commented previous lines because BindingSources made updates
                db.SaveChanges();
                this.Init();
            }
            //OldBook.Sages = NewBook.Sages;
        }
        private void btnBookDelete_Click(object sender, EventArgs e)
        {
            Book book = this.GetBookFromFormBookDetails();
            book = db.Books.Find(book.IdBook);
            if (book != null && book.IdBook > 0)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                this.Init();
            }
        }
        private void btnBookAddSages_Click(object sender, EventArgs e)
        {
            Book book = BookBindingSource.Current as Book;
            ListOfSages form = new ListOfSages(book);
            form.Show();
            form.VisibleChanged += ListOfSagesFormVisibleChanged;
        }
        private void btnBookCancel_Click(object sender, EventArgs e)
        {
            this.ClearBookInputs();
            db.RollBack();
            this.Init();
        }
        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            Book CurrentBook = (BookBindingSource.Current as Book) ?? new Book();
            BookSagesBindingSource.DataSource = CurrentBook.Sages.ToList();
        }
        private void dgvBookSages_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Book book = BookBindingSource.Current as Book;
            Sage sage = BookSagesBindingSource.Current as Sage;
            sage = db.Sages.Find(sage.IdSage);
            if (sage != null)
            {
                db.Books.Where(s => s.IdBook == book.IdBook).Select(x => x).FirstOrDefault().Sages.Remove(sage);
            }
        }
        #endregion Book Buttons

        #region Sage Buttons
        private void btnSageAdd_Click(object sender, EventArgs e)
        {
            Sage sage = this.GetSageFromFormSageDetails();
            sage.IdSage = 0;
            if (sage != null)
            {
                db.RollBack();
                db.Sages.Add(sage);
                db.SaveChanges();
                this.Init();
            }
        }
        private void btnSageUpdate_Click(object sender, EventArgs e)
        {
            Sage NewSage = this.GetSageFromFormSageDetails();
            Sage OldSage = db.Sages.Where(x => x.IdSage == NewSage.IdSage).Select(x => x).FirstOrDefault();
            if (NewSage != null && OldSage != null)
            {
                //OldBook.name = NewBook.name;
                //OldBook.description = NewBook.description;
                //Commented previous lines because BindingSources made updates
                db.SaveChanges();
                this.Init();
            }
            //OldBook.Sages = NewBook.Sages;
        }
        private void btnSageDelete_Click(object sender, EventArgs e)
        {
            Sage sage = this.GetSageFromFormSageDetails();
            sage = db.Sages.Find(sage.IdSage);
            if (sage != null && sage.IdSage > 0)
            {
                db.Sages.Remove(sage);
                db.SaveChanges();
                this.Init();
            }
        }
        private void btnSageAddBooks_Click(object sender, EventArgs e)
        {
            Sage sage = SageBindingSource.Current as Sage;
            ListOfBooks form = new ListOfBooks(sage);
            form.Show();
            form.VisibleChanged += ListOfBooksFormVisibleChanged;
        }
        private void btnSageCancel_Click(object sender, EventArgs e)
        {
            this.ClearSageInputs();
            db.RollBack();
            this.Init();
            Sage CurrentSage = (SageBindingSource.Current as Sage) ?? new Sage();
            picSagePhoto.Image = this.GetImage(CurrentSage.photo);
        }
        private void btnSagePhotoBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picSagePhoto.Image = this.GetImage(ofd.FileName);
                    picSagePhoto.ImageLocation = ofd.FileName;
                    Sage obj = SageBindingSource.Current as Sage;
                    if (obj != null)
                    {
                        obj.photo = ofd.FileName;
                    }
                }
            }
        }
        private void dgvSages_SelectionChanged(object sender, EventArgs e)
        {
            Sage CurrentSage = (SageBindingSource.Current as Sage) ?? new Sage();
            picSagePhoto.Image = this.GetImage(CurrentSage.photo);
            SageBooksBindingSource.DataSource = CurrentSage.Books.ToList();
        }
        private void dgvSageBooks_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Sage sage = SageBindingSource.Current as Sage;
            Book book = SageBooksBindingSource.Current as Book;
            book = db.Books.Find(book.IdBook);
            if (book != null)
            {
                db.Sages.Where(s => s.IdSage == sage.IdSage).Select(x => x).FirstOrDefault().Books.Remove(book);
            }
        }

        #endregion Sage Buttons

        #endregion Buttons
    }
}
