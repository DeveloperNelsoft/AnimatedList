using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AnimatedList.Classes;

namespace AnimatedList
{
    [Activity(Label = "AnimatedListActivity",  MainLauncher = true)]
    public class AnimatedListActivity : Activity
    {
        private List<Friend> mFriends;
        private ListView mListView;
        private EditText mSearch;
        private LinearLayout mContainer;
        private bool mAnimateDown;
        private bool mAnimating;

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

            FriendsAdapter adapter = new FriendsAdapter(this, Resource.Layout.row_friend, mFriends);
            mListView.Adapter = adapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.search:
                    //search icon has been clicked.
                    if (mAnimating)
                    {
                        return true;
                    }
                    if (!mAnimateDown)
                    {
                        //ListView is Up
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height - mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += Anim_AnimationStartDown;
                        anim.AnimationEnd += Anim_AnimationEndDown;
                        mContainer.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
                    }
                    else
                    {
                        //ListView is Down
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height + mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += Anim_AnimationStartUp;
                        anim.AnimationEnd += Anim_AnimationEndUp;
                        mContainer.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
                    }
                    mAnimateDown = !mAnimateDown;

                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void Anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mAnimating = true;
            mSearch.Animate().AlphaBy(1.0f).SetDuration(500).Start();
        }

        private void Anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mAnimating = false;
        }

        private void Anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mAnimating = true;
            mSearch.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
        }

        private void Anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mAnimating = false;
            mSearch.ClearFocus();
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);

        }
    }
}