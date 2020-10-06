using Sword.Swl.Framework.Xamarin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vigie.Risques.Tpm.Core.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedRootViewControl : Grid, IRootViewControl
    {
        public HomeTabbedRootViewControl()
        {
            InitializeComponent();
        }

        public void SetContent(View view)
        {
            ViewContent.Children.Clear();
            ViewContent.Children.Add(view);
            UpdateTitleColor();
        }

        public void SetHasNavigationBar(bool value)
        {
            NavigationBar.IsVisible = value;
        }

        private void UpdateTitleColor()
        {
            //if (Parent is Page parent)
            //{
            //    Title.TextColor = parent.BackgroundColor.Luminosity > 0.88
            //        ? Color.Black
            //        : Color.White;
            //}
        }
    }
}