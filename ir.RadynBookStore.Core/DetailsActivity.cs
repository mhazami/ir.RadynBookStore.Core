
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
        private EditText _amount;
        private Button _btnCancel;
        private Button _btnOrder;
        private int _id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.details);
            string id = Intent.GetStringExtra("id");
            _id = int.Parse(id);
            DefinitionControls();
            LoadControls();

            _btnCancel.Click += delegate
            {
                Intent intetn = new Intent(this, typeof(IndexActivity));
                StartActivity(intetn);
            };
        }

        public void DefinitionControls()
        {
            _name = FindViewById<TextView>(Resource.Id.detailsName);
            _amount = FindViewById<EditText>(Resource.Id.Amount);
            _btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            _btnOrder = FindViewById<Button>(Resource.Id.btnOrder);
            _abstract = FindViewById<TextView>(Resource.Id.detailsAbstract);
            _author = FindViewById<TextView>(Resource.Id.detailsAuthor);
            _price = FindViewById<TextView>(Resource.Id.detailsPrice);
        }

        public Order GetDataFromControls()
        {
            Order order = new Order()
            {
                BookTitle = _name.Text,
                Amount = int.Parse(_amount.Text),
                BookId = _id
            };
            return order;
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