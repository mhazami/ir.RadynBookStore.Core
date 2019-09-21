
using Android.App;
using Android.OS;
using Android.Widget;
using DataStructure;
using DataStructure.Repository;
using ir.RadynBookStore.Core.Utility;
using System;

namespace ir.RadynBookStore.Core
{
    [Activity(Label = "CreateActivity")]
    public class CreateActivity : Activity
    {
        private EditText _name;
        private EditText _author;
        private EditText _abstract;
        private EditText _price;
        private Button _btnSave;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.create);
            DefinitionControls();
            _btnSave.Click += delegate
            {
                Book book = GetDataFromControls();
                if (new DbManager(ConnectionUtils.DataBasePath).InsertBook(book) != 0)
                {
                    string message = $"کتاب جدید با عنوان {book.Name} با موفقیت ثبت شد";
                    ClearControls();
                    Toast.MakeText(this, message, ToastLength.Long).Show();
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
        }

        public Book GetDataFromControls()
        {
            Book book = new Book()
            {
                Name = _name.Text,
                Author = _author.Text,
                Price = Convert.ToDecimal(_price.Text),
                Abstract = _abstract.Text,
                FileId = 0
            };
            return book;
        }

        public void ClearControls()
        {
            _name.Text = _abstract.Text = _price.Text = _author.Text = string.Empty;
        }
    }
}