using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using DataStructure;
using DataStructure.Repository;
using ir.RadynBookStore.Core.Adabtors;
using SQLite.Net.Platform.XamarinAndroid;
using System.Collections.Generic;
using Android.Content;

namespace ir.RadynBookStore.Core
{
    [Activity(Label = "IndexActivity")]
    public class IndexActivity : ListActivity
    {
        private List<Book> _books;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.index);
            _books = new DbManager(new SQLitePlatformAndroid(), Utility.ConnectionUtils.DataBasePath()).GetAllBooks();
            //_books = List();
            ListAdapter = new BookListAD(this, _books);
            ListView.ChoiceMode = ChoiceMode.None;
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Book selectedItem = _books[position];
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("id", selectedItem.Id.ToString());
            StartActivity(intent);

            base.OnListItemClick(l, v, position, id);
        }

   
    }
}