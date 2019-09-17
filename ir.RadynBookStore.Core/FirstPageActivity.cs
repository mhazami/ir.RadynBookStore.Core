
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ir.RadynBookStore.Core
{
    [Activity(Label = "FirstPageActivity", MainLauncher = true)]
    public class FirstPageActivity : Activity
    {
        private Button btnCreate;
        private Button btnIndex;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.index);
            btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            btnIndex = FindViewById<Button>(Resource.Id.btnIndex);
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