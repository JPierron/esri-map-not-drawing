using Sword.Swl.Framework.Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vigie.Risques.Tpm.Core.Controls;
using Vigie.Risques.Tpm.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vigie.Risques.Tpm.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuView : ViewBase<SideMenuViewModel, RootViewControl>
    {
        public SideMenuView()
        {
            InitializeComponent();
        }
    }
}