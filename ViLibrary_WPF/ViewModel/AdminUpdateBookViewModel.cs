using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using ViLibrary_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;
using Data;
using Service;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Controls;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminUpdateBookViewModel : BaseViewModel
    {
        private UnitOfWork _unitOfWork;

        private Book book;
        public Book Book { get { return book; } set { book = value; OnPropertyChanged(); } }

        public ICommand Update {  get; set; }
        public AdminUpdateBookViewModel(Book book, LibraryDbContext _context) 
        {
            _unitOfWork = new UnitOfWork(_context);
            this.book = book;
            Update = new RelayCommand<Window>(p => true, p =>
            {
                try
                {
                    var name = p.FindName("tbBName") as TextBox;
                    var author = p.FindName("tbBAuthor") as TextBox;
                    var isbn = p.FindName("tbBISBN") as TextBox;
                    var price = p.FindName("tbBPrice") as TextBox;
                    var copies = p.FindName("tbBCopy") as TextBox;

                    if (_unitOfWork._bookService.Get(b => b.BookISBN == isbn.Text) != null)
                    {
                        MessageBox.Show("ISBN existed!");
                    } else
                    {
                        book.BookName = name.Text;
                        book.BookAuthor = author.Text;
                        book.BookISBN = isbn.Text;
                        book.BookPrice = decimal.Parse(price.Text);
                        book.BookCopies = int.Parse(copies.Text);

                        _unitOfWork._bookService.Update(book);
                        _unitOfWork.Save();
                        p.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot update book!");
                }
            });
        }
    }
}
