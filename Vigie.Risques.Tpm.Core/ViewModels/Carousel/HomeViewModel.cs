using Sword.Swl.Framework.Xamarin.Services.Contracts;
using Sword.Swl.Framework.Xamarin.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Vigie.Risques.Tpm.Core.Interfaces;
using Vigie.Risques.Tpm.Core.Models;
using Vigie.Risques.Tpm.Core.ViewModels.Carousel;
using Vigie.Risques.Tpm.Core.Views.Carousel;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.ViewModels
{
    public class HomeViewModel : CarouselViewModelBase, ICarouselViewModel /*ViewModelBase*/
    {
        private ObservableCollection<VigieTheme> _vigieThemes;

        public HomeViewModel(ILogProvider logProvider, INavigationService navigation, CarouselItemViewBase content, string iconSource)
           : base(logProvider, navigation, content, iconSource)
        {
        }

        #region Properties

        public string Message
        {
            get { return Resources.Labels.HomeTitle + " " + Configuration.Config.AppConfig.ApplicationName; }
        }

        public override string Title => Resources.Labels.HomeTitle;

        public ObservableCollection<VigieTheme> VigieThemes
        {
            get => _vigieThemes;
            set => SetProperty(ref _vigieThemes, value);
        }

        #endregion

        #region Commands

        #endregion

        public override Task InitializeBeforeNavigationAsync()
        {
            return Task.CompletedTask;
        }

        public override Task InitializeAfterNavigationAsync()
        {
            VigieThemes = new ObservableCollection<VigieTheme>()
            {
            };

            return Task.CompletedTask;
        }
    }
}
