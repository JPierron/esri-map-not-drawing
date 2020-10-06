using Vigie.Risques.Tpm.Core.Services.Mocks;
using Vigie.Risques.Tpm.Core.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Tests
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            Setup();
        }

        protected virtual void Setup()
        {
            DependencyService.Register<ICacheService, MockCacheService>();
        }
    }
}
