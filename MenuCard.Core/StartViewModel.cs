using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MenuCard.Core
{
    public class StartViewModel : MvxViewModel
    {
        public readonly IMvxNavigationService _navigationService;
        public ObservableCollection<MenuDto> Items { get; set; }

        public StartViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            Items = new ObservableCollection<MenuDto>();
        }

        public Task ReloadData()
        {
            return Task.Run(() =>
            {
                try
                {
                    Items = new ObservableCollection<MenuDto>(GetList());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    RaisePropertyChanged(nameof(Items));
                }
            });
        }

        private int GetNotification(int min, int max) => new Random().Next(min, max);

        private IList<MenuDto> GetList()
        {
            return new List<MenuDto>
            {
                new MenuDto
                {
                    Id = Guid.NewGuid(),
                    Label = "Accessibility",
                    ActionCommand = GoToAccessibility,
                    IconName = "ic_accessibility_white_48dp",
                    NumberNotifications = GetNotification(1, 20),
                },
                new MenuDto
                {
                    Id = Guid.NewGuid(),
                    Label = "Account",
                    ActionCommand = GoToAccount,
                    IconName = "ic_account_box_white_48dp",
                    NumberNotifications = GetNotification(1, 50),
                },
                new MenuDto
                {
                    Id = Guid.NewGuid(),
                    Label = "Android",
                    ActionCommand = GoToAndroid,
                    IconName = "ic_android_white_48dp",
                    NumberNotifications = GetNotification(1, 30),
                },
            };
        }

        public IMvxAsyncCommand<MenuDto> NavegarCommand => new MvxAsyncCommand<MenuDto>(async (itemMenu) =>
        {
            await itemMenu.ActionCommand.ExecuteAsync();
        });

        public IMvxAsyncCommand GoToAccessibility => new MvxAsyncCommand(async () =>
        {
            await NavigationService.Navigate<AccessibilityViewModel>();
        });

        public IMvxAsyncCommand GoToAccount => new MvxAsyncCommand(async () =>
        {
            await NavigationService.Navigate<AccountViewModel>();
        });

        public IMvxAsyncCommand GoToAndroid => new MvxAsyncCommand(async () =>
        {
            await NavigationService.Navigate<DroidViewModel>();
        });
    }

    public class MenuDto
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public IMvxAsyncCommand ActionCommand { get; set; }
        public string IconName { get; set; }
        public int NumberNotifications { get; set; }
        public bool ShowNotifications => NumberNotifications > 0;
    }
}
