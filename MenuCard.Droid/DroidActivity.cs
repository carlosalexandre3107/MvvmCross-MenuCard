using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MenuCard.Core;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using System.Threading.Tasks;

namespace MenuCard.Droid
{
    [MvxActivityPresentation]
    [Activity(Label = "Droid")]
    public class DroidActivity
        : MvxAppCompatActivity<DroidViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.droid_view);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (toolbar == null)
                return;

            SetSupportActionBar(toolbar);



            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (Android.Resource.Id.Home.Equals(item.ItemId))
                Task.Run(async () => await ViewModel.Fechar());

            return base.OnOptionsItemSelected(item);
        }
    }
}