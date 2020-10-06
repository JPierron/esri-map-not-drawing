using Sword.Swl.Framework.Xamarin.Services.Contracts;
using Sword.Swl.Framework.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vigie.Risques.Tpm.Core.ViewModels
{
    public class MasterDetailsViewModel : ViewModelBase
    {
        public MasterDetailsViewModel(ILogProvider logProvider, INavigationService navigation)
            : base(logProvider, navigation)
        {
        }

        public override string Title => string.Empty;

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
