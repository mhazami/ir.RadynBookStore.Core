using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DataStructure;
using DataStructure.Repository;
using ir.RadynBookStore.Core.Utility;
using SQLite.Net.Platform.XamarinAndroid;

namespace ir.RadynBookStore.Core
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
        private TextView _author;
        private TextView _abstract;
        private TextView _price;
        private TextView _name;
        private Button _btnEdit;
        private Button _btnDelete;
        private int _id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.details);
            string id = Intent.GetStringExtra("id");
            _id = int.Parse(id);
            DefinitionControls();
            LoadControls();

            _btnEdit.Click += delegate
            {
                var intent = new Intent(this, typeof(EditActivity));
                intent.PutExtra("id", _id.ToString());
                StartActivity(intent);
            };

            _btnDelete.Click += delegate
            {
                new DbManager(new SQLitePlatformAndroid(), ConnectionUtils.DataBasePath()).DeleteBook(_id);
                Intent intetn = new Intent(this, typeof(IndexActivity));
                StartActivity(intetn);
            };
        }

        public void DefinitionControls()
        {
            _name = FindViewById<TextView>(Resource.Id.detailsName);
            _btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            _btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            _abstract = FindViewById<TextView>(Resource.Id.detailsAbstract);
            _author = FindViewById<TextView>(Resource.Id.detailsAuthor);
            _price = FindViewById<TextView>(Resource.Id.detailsPrice);
        }

      

        public void LoadControls()
        {
            Book book = new DbManager(new SQLitePlatformAndroid(), ConnectionUtils.DataBasePath()).GetBook(_id);
            _name.Text = book.Name;
            _abstract.Text = book.Abstract;
            _author.Text = book.Author;
            _price.Text = book.Price.ToString("N0");
        }
    }
}