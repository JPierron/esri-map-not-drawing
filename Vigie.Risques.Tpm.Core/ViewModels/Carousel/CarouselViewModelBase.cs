using Sword.Swl.Framework.Xamarin.Services.Contracts;
using Sword.Swl.Framework.Xamarin.ViewModels;
using System.Threading.Tasks;
using Vigie.Risques.Tpm.Core.Interfaces;
using Vigie.Risques.Tpm.Core.Views.Carousel;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.ViewModels.Carousel
{
    public abstract class CarouselViewModelBase : ViewModelBase, ICarouselViewModel
    {
        private bool _isSelected;
        private CarouselItemViewBase _content;
        private string _iconSource;

        public CarouselItemViewBase Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public string IconSource
        {
            get => _iconSource;
            set => SetProperty(ref _iconSource, value);
        }

        public bool IsSelected 
        {
            get => _isSelected;
            set 
            { 
                if (SetProperty(ref _isSelected, value))
                {
                    NotifyPropertyChanged(nameof(TitleForegroundColor));
                    NotifyPropertyChanged(nameof(TitleBackgroundColor));
                }
            }
        }


        public Color TitleForegroundColor 
        {
            get
            {
                return IsSelected 
                    ? (Color)App.Current.Resources["BlueSecondaryColor"]
                    : Color.White;
            }
        }

        public Color TitleBackgroundColor
        {
            get
            {
                return IsSelected
                    ? Color.White
                    : (Color)App.Current.Resources["BlueSecondaryColor"];
            }
        }

        public CarouselViewModelBase (ILogProvider logProvider, INavigationService navigation, CarouselItemViewBase content, string iconSource)
            : base(logProvider, navigation)
        {
            Content = content;
            IconSource = iconSource;
        }

        public async Task Initialize()
        {
            Content.Init(this);
            await InitializeAfterNavigationIfNecessaryAsync();
        }
    }
}
