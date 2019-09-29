
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
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
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "شرکت رسپینا رادین";
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

    
    }
}