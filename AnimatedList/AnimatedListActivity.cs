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
using AnimatedList.Classes;

namespace AnimatedList
{
    [Activity(Label = "AnimatedListActivity")]
    public class AnimatedListActivity : Activity
    {
        private List<Friend> mFriends;
        private ListView mListView;
        private EditText mSearch;
        private LinearLayout mContainer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AnimatedList);

            mListView = FindViewById<ListView>(Resource.Id.listView);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);
            mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);

            mSearch.Alpha = 0;

            mFriends = new List<Friend>();
            mFriends.Add(new Friend { FirstName = "Arnold", LastName= "McFlight", Age = "30", Gender="male" });
            mFriends.Add(new Friend { FirstName = "Will", LastName = "Smith", Age = "40", Gender = "male" });
            mFriends.Add(new Friend { FirstName = "Jhon", LastName = "McClain", Age = "50", Gender = "male" });
            mFriends.Add(new Friend { FirstName = "Joe", LastName = "Mortog", Age = "36", Gender = "male" });
            mFriends.Add(new Friend { FirstName = "Jim", LastName = "Carrey", Age = "35", Gender = "male" });
            mFriends.Add(new Friend { FirstName = "Ethan", LastName = "Hunt", Age = "32", Gender = "male" });
            mFriends.Add(new Friend { FirstName = "Jason", LastName = "Burn", Age = "37", Gender = "male" });
            mFriends.Add(new Friend { FirstName = "Sylvestre", LastName = "Stallone", Age = "38", Gender = "male" });

            FriendsAdapter adapter = new FriendsAdapter(this, Resource.Layout.ro)




        }
    }
}