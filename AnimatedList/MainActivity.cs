using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace AnimatedList
{
    [Activity(Label = "AnimatedList", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button mBtnGoToList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBtnGoToList = FindViewById<Button>(Resource.Id.btnGoToList);

            mBtnGoToList.Click += MBtnGoToList_Click;
        }

        private void MBtnGoToList_Click(object sender, System.EventArgs e)
        {
            Intent animatedActivity = new Intent(this, typeof(AnimatedListActivity));
            StartActivity(animatedActivity);
        }
    }
}

