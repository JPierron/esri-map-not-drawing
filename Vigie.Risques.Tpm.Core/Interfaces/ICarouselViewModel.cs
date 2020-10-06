using Sword.Swl.Framework.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vigie.Risques.Tpm.Core.Views.Carousel;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.Interfaces
{
    public interface ICarouselViewModel : IViewModel
    {
        CarouselItemViewBase Content { get; set; }

        string IconSource { get; set; }

        bool IsSelected { get; set; }

        Color TitleForegroundColor { get; }

        Color TitleBackgroundColor { get; }

        Task Initialize();
    }
}
