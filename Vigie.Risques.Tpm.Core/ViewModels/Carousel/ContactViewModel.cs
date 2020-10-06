using Sword.Swl.Framework.Xamarin.Services.Contracts;
using System.Threading.Tasks;
using Vigie.Risques.Tpm.Core.Interfaces;
using Vigie.Risques.Tpm.Core.ViewModels.Carousel;
using Vigie.Risques.Tpm.Core.Views.Carousel;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.ViewModels
{
    public class ContactViewModel : CarouselViewModelBase, ICarouselViewModel /*ViewModelBase*/
    {
        public ContactViewModel(ILogProvider logProvider, INavigationService navigation, CarouselItemViewBase content, string iconSource)
           : base(logProvider, navigation, content, iconSource)
        {
            content.Init(this);
        }

        public override string Title => Resources.Labels.ContactTitle;

        public override Task InitializeAfterNavigationAsync()
        {
            return Task.CompletedTask;
        }

        public override Task InitializeBeforeNavigationAsync()
        {
            return Task.CompletedTask;
        }
    }
}
