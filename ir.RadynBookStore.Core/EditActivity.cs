using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DataStructure;
using DataStructure.Repository;
using ir.RadynBookStore.Core.Utility;

namespace ir.RadynBookStore.Core
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {
        private int _id;
        private EditText _name;
        private EditText _author;
        private EditText _abstract;
        private EditText _price;
        private Button _btnSave;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.edit);
            string id = Intent.GetStringExtra("id");
            _id = int.Parse(id);
            DefinitionControls();
            LoadControls();
            _btnSave.Click += delegate
            {
                Book book = GetDataFromControls();
                if (new DbManager(ConnectionUtils.DataBasePath).UpdateBook(book) != 0)
                {
                    Intent intetn = new Intent(this, typeof(IndexActivity));
                    StartActivity(intetn);
                }
            };
        }

        public void DefinitionControls()
        {
            _name = FindViewById<EditText>(Resource.Id.Name);
            _abstract = FindViewById<EditText>(Resource.Id.Abstract);
            _author = FindViewById<EditText>(Resource.Id.Author);
            _price = FindViewById<EditText>(Resource.Id.Price);
            _btnSave = FindViewById<Button>(Resource.Id.btnSave);
            //Book book = new DbManager(new SQLitePlatformAndroid(), ConnectionUtils.DataBasePath()).GetBook(_id);

            //TextView title = FindViewById<TextView>(Resource.Id.txtTitle);
            //title.Text = $"ویرایش اطلاعات کتاب {book.Name}";
        }

        public Book GetDataFromControls()
        {
            Book book = new DbManager(ConnectionUtils.DataBasePath).GetBook(_id);

            book.Name = _name.Text;
            book.Author = _author.Text;
            book.Price = Convert.ToDecimal(_price.Text);
            book.Abstract = _abstract.Text;

            return book;
        }

        public void LoadControls()
        {
            Book book = new DbManager(ConnectionUtils.DataBasePath).GetBook(_id);
            _name.Text = book.Name;
            _abstract.Text = book.Abstract;
            _author.Text = book.Author;
            _price.Text = book.Price.ToString("N0");
        }
    }
}