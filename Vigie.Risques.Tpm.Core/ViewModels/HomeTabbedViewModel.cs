using Sword.Swl.Framework.Xamarin.Services.Contracts;
using Sword.Swl.Framework.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vigie.Risques.Tpm.Core.Interfaces;
using Vigie.Risques.Tpm.Core.Views;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.ViewModels
{
    public class HomeTabbedViewModel : ViewModelBase
    {
        private readonly ILogProvider _logProvider;

        private ObservableCollection<ICarouselViewModel> _carouselItems;
        private ICarouselViewModel _carouselItemSelected;

        public HomeTabbedViewModel(ILogProvider logProvider, INavigationService navigation)
            : base(logProvider, navigation)
        {
            _logProvider = logProvider;
        }

        public override string Title => string.Empty;

        public ObservableCollection<ICarouselViewModel> CarouselItems
        {
            get => _carouselItems;
            set => SetProperty(ref _carouselItems, value);
        }

        public ICarouselViewModel CarouselItemSelected
        {
            get => _carouselItemSelected;
            set
            {
                if (SetProperty(ref _carouselItemSelected, value))
                {
                    foreach (ICarouselViewModel carouselViewModel in CarouselItems)
                    {
                        carouselViewModel.IsSelected = false;
                    }

                    _carouselItemSelected.IsSelected = true;
                }
            }
        }

        #region commands

        public ICommand OpenMenuCommand => new Command(() => OpenMenu());

        #endregion

        public override async Task InitializeAfterNavigationAsync()
        {
            CarouselItems = new ObservableCollection<ICarouselViewModel>()
            {
                new HomeViewModel(_logProvider, NavigationService, new HomeView(), string.Empty),
                new InfosViewModel(_logProvider, NavigationService, new InfosView(), string.Empty),
                new ContactViewModel(_logProvider, NavigationService, new ContactView(), string.Empty),
                new MapViewModel(_logProvider, NavigationService, new MapView(), string.Empty)
            };

            foreach (ICarouselViewModel carouselViewModel in CarouselItems)
            {
                await carouselViewModel.Initialize();
            }
        }

        public override Task InitializeBeforeNavigationAsync()
        {
            return Task.CompletedTask;
        }


        #region private methods

        private void OpenMenu()
        {
            MasterDetailsView masterDetail = (Application.Current.MainPage as NavigationPage).CurrentPage as MasterDetailsView;
            masterDetail.IsPresented = !masterDetail.IsPresented;
        }

        #endregion
    }
}
