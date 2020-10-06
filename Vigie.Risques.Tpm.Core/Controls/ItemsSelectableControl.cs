using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.Controls
{
    public class ItemsSelectableControl : ItemsControl
    {
        public event EventHandler SelectedItemChanged;

        protected readonly ICommand ItemSelectedCommand;

        public ItemsSelectableControl() : base()
        {
            ItemClicked += ItemsSelectableControl_ItemClicked;
        }

        #region Bindable

        #region SelectedItem

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(
                nameof(SelectedItem),
                typeof(object),
                typeof(ItemsSelectableControl),
                default(object),
                BindingMode.TwoWay,
                propertyChanged: OnSelectedItemChanged);

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && bindable is ItemsSelectableControl uc)
            {
                uc.SelectedItemChanged?.Invoke(uc, EventArgs.Empty);
                uc.ItemSelectedCommand?.Execute(newValue);
            }
        }
        #endregion

        #endregion

        private void ItemsSelectableControl_ItemClicked(object sender, object e)
        {
            SelectedItem = e;
        }
    }
}
