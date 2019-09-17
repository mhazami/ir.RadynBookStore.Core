using Android.App;
using Android.Views;
using Android.Widget;
using DataStructure;
using System.Collections.Generic;
using FileHandler = ir.RadynBookStore.Core.Utility.FileHandler;

namespace ir.RadynBookStore.Core.Adabtors
{
    public class BookListAD : BaseAdapter<Book>
    {
        private readonly Activity _context;
        private List<Book> _books;
        public BookListAD(Activity context, List<Book> books)
        {
            _context = context;
            _books = books;
        }

        public override long GetItemId(int position)
        {
            return _books[position].Id;
        }



        public override Book this[int position] => _books[position];

        public override int Count => _books.Count;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Book item = _books[position];
            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.bookRowItemLayout, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.rowTitle).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.rowAuthor).Text = item.Author;
            convertView.FindViewById<TextView>(Resource.Id.rowPrice).Text = item.Price.ToString("N0");
            if (item.FileId != 0)
            {
                convertView.FindViewById<ImageView>(Resource.Id.rowimg).SetImageBitmap(FileHandler.ConverteToBitmap(item.FileId));
            }

            return convertView;
        }
    }
}