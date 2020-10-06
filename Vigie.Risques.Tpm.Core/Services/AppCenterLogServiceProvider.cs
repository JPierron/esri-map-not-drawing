using Vigie.Risques.Tpm.Core.Services.Contracts;
using Sword.Swl.Framework.Xamarin.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vigie.Risques.Tpm.Core.Services
{
    public class AppCenterLogServiceProvider : ILogProvider
    {
        public AppCenterLogServiceProvider()
        {
        }

        public ILog GetLogFor<T>()
        {
            return GetLogFor(typeof(T).FullName);
        }

        public ILog GetLogFor(string name)
        {
            return new AppCenterLogService(name);
        }
    }
}
