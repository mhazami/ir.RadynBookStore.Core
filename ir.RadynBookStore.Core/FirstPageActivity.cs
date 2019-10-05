
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.App;
using Android.Views;
using ActionBar = Android.App.ActionBar;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ir.RadynBookStore.Core
{
    [Activity(Label = "FirstPageActivity", Theme = "@style/RadynBlueTheme", MainLauncher = true)]
    public class FirstPageActivity : AppCompatActivity
    {
        private Button btnCreate;
        private Button btnIndex;
        private Toolbar toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.index);
            btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            btnIndex = FindViewById<Button>(Resource.Id.btnIndex);
            toolbar = FindViewById<Toolbar>(Resource.Id.RadynBlueTooltBar);
            toolbar.TextAlignment = TextAlignment.Center;
            this.toolbar.ChildViewAdded += ToolbarChildAdded;
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "فروشگاه کتاب رادین";

            btnCreate.Click += delegate
            {
                Intent intent = new Intent(this, typeof(CreateActivity));
                StartActivity(intent);
            };
            btnIndex.Click += delegate
            {
                Intent intent = new Intent(this, typeof(IndexActivity));
                StartActivity(intent);
            };



        }

        private void ToolbarChildAdded(object sender, ViewGroup.ChildViewAddedEventArgs e)
        {
            if (e.Child is Android.Support.V7.Widget.AppCompatTextView tv)
            {
                // identify the title text view and center it
                tv.LayoutParameters = new Android.Support.V7.Widget.Toolbar.LayoutParams(ActionBar.LayoutParams.WrapContent, ActionBar.LayoutParams.WrapContent, (int)GravityFlags.Right);
            }
        }
        Android.Widget.SearchView searchView;
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.mainmenu, menu);
            var searchItem = menu.FindItem(Resource.Id.action_search);
            
            //searchView = searchItem.ActionProvider.JavaCast<Android.Widget.SearchView>();

            //searchView.QueryTextSubmit += (sender, args) =>
            //{
            //    Toast.MakeText(this, "You searched: " + args.Query, ToastLength.Short).Show();

            //};
            return base.OnCreateOptionsMenu(menu);
        }
    }
}