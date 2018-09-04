using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MenuCard.Core
{
    public class AccountViewModel : MvxViewModel
    {
        public readonly IMvxNavigationService _navigationService;

        public AccountViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task Fechar()
        {
            await NavigationService.Close(this);
        }
    }
}
