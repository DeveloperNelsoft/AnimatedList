﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace AnimatedList.Classes
{
    class FriendsAdapter : BaseAdapter<Friend>
    {
        private Context mContext;
        private int mRow;
    }
}