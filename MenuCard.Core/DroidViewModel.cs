using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MenuCard.Core
{
    public class DroidViewModel : MvxViewModel
    {
        public readonly IMvxNavigationService _navigationService;

        public DroidViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task Fechar()
        {
            await NavigationService.Close(this);
        }
    }
}
