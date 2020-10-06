using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.Controls
{
    public class CustomSearchBar : SearchBar
    {
        public event EventHandler IsCancelVisibleChanged;

        public static BindableProperty IsCancelVisibleProperty = BindableProperty.Create(
            nameof(IsCancelVisible),
            typeof(bool),
            typeof(CustomSearchBar),
            false,
            propertyChanged: IsCancelVisiblePropertyChanged);

        public bool IsCancelVisible
        {
            get { return (bool)GetValue(IsCancelVisibleProperty); }
            set { SetValue(IsCancelVisibleProperty, value); }
        }

        private static void IsCancelVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != newValue && bindable is CustomSearchBar uc)
            {
                uc.IsCancelVisibleChanged?.Invoke(uc, EventArgs.Empty);
            }
        }
    }

}
