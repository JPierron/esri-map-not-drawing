using Sword.Swl.Framework.Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vigie.Risques.Tpm.Core.Models
{
    public class VigieTheme : NotifyPropertyChangedBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}
