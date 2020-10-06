using Sword.Swl.Framework.Xamarin.ViewModels;
using Sword.Swl.Framework.Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Vigie.Risques.Tpm.Core.Interfaces;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.Views.Carousel
{
    public abstract class CarouselItemViewBase
        : ContentView, IView
    {
        public bool HasNavigationBar { get; set; } = false;

        public ViewModelBase ViewModel { get; set; }

        public void Init(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
            BindingContext = ViewModel;
            OnViewModelAttached();
        }

        public virtual void OnViewModelAttached() { }
    }
}
