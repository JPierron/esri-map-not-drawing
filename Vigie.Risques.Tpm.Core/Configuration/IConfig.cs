using System;
using System.Collections.Generic;
using System.Text;

namespace Vigie.Risques.Tpm.Core.Configuration
{
    public interface IConfig
    {
        string ApplicationName { get; }

        string AppCenterAndroidAppId { get; }

        string AppCenterIosAppId { get; }

        string MapLayerEvenementsPoint { get; }
        string MapLayerEvenementsLine { get; }
        string MapLayerCities { get; }
        string MapLayerIode { get; }
        string MapLayerDefibrillateur { get; }
        string MapLayerRassemblement { get; }

        string ApiBaseUrl { get; }

        string ArcGISRuntimeLiteLicenseKey { get; }
    }
}
