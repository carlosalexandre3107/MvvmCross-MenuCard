using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MenuCard.Core;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using System.Threading.Tasks;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace MenuCard.Droid
{
    [MvxActivityPresentation]
    [Activity(Label = "@string/title")]
    public class MainActivity 
        : MvxAppCompatActivity<StartViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (toolbar == null)
                return;

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(true);

            //Set mode grid with 2 columns
            SetGridLayoutRecyclerView();

            //Load menu
            Task.Run(async () => await ViewModel.ReloadData());
        }

        private void SetGridLayoutRecyclerView()
        {
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.menu_recycler_view);
            if (recyclerView == null)
                return;

            recyclerView.SetLayoutManager(new GridLayoutManager(this, 2));
            recyclerView.HasFixedSize = true;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.updater, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (Resource.Id.menu_updater.Equals(item.ItemId))
                Task.Run(async () => await ViewModel.ReloadData());
            //ViewModel.GetNotificationCommand.Execute();

            return base.OnOptionsItemSelected(item);
        }
    }
}