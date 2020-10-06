using Sword.Swl.Framework.Xamarin.Views;
using Vigie.Risques.Tpm.Core.Controls;
using Vigie.Risques.Tpm.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Vigie.Risques.Tpm.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailsView : MasterDetailPage<MasterDetailsViewModel, RootViewControl>
    {
        public MasterDetailsView() 
            : base(App.Container)
        {
            InitializeComponent();
        }

        private void MenuButton_Clicked(object sender, System.EventArgs e)
        {
            IsPresented = !IsPresented;
        }
    }
}