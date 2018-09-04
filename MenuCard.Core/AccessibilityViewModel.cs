using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MenuCard.Core
{
    public class AccessibilityViewModel : MvxViewModel
    {
        public readonly IMvxNavigationService _navigationService;

        public AccessibilityViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task Fechar()
        {
            await NavigationService.Close(this);
        }
    }
}
