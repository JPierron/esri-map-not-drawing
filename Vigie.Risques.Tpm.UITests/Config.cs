using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigie.Risques.Tpm.UITests
{
    public static class Config
    {
        public static string LogFolder { get; private set; }

        static Config()
        {
            LogFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UITests_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}
