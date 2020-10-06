using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Vigie.Risques.Tpm.Core.Controls;
using Vigie.Risques.Tpm.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace Vigie.Risques.Tpm.iOS.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null)
            {
                Control.SearchBarStyle = UISearchBarStyle.Default;
                Control.ShowsCancelButton = false;
                Control.BackgroundColor = UIColor.Clear;
                Control.BarTintColor = UIColor.Clear;
                Control.Translucent = true;
                Control.SetBackgroundImage(new UIImage(), UIBarPosition.Any, UIBarMetrics.Default);

                if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
                {
                    Control.SearchTextField.BackgroundColor = UIColor.White;
                }

                if (Element is CustomSearchBar customSearchBar)
                {
                    customSearchBar.IsCancelVisibleChanged += CustomSearchBar_IsCancelVisibleChanged;
                    customSearchBar.TextChanged += CustomSearchBar_TextChanged;
                }
            }
        }

        private void SetCancelButtonVisibility(bool isCancelVisivble)
        {
            this.Control.ShowsCancelButton = isCancelVisivble;

            if (isCancelVisivble)
            {
                var test = Control.Descendants();
                UIButton cancelButton = Control.Descendants().OfType<UIButton>().FirstOrDefault();

                if (cancelButton != null)
                {
                    cancelButton.SetTitle(Core.Resources.Labels.Cancel, UIControlState.Normal);
                }
            }
        }

        private void CustomSearchBar_IsCancelVisibleChanged(object sender, EventArgs e)
        {
            if (sender is CustomSearchBar customSearchBar)
            {
                SetCancelButtonVisibility(customSearchBar.IsCancelVisible);
            }
        }

        private void CustomSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is CustomSearchBar customSearchBar && string.IsNullOrEmpty(customSearchBar.Text))
            {
                SetCancelButtonVisibility(customSearchBar.IsCancelVisible);
            }
        }
    }

}