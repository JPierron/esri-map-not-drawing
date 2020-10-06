using System;
using System.Collections.Generic;
using System.Text;

namespace Vigie.Risques.Tpm.Core.Configuration
{
    public class ConfigInt : IConfig
    {
        public string ApplicationName => "Vigie.Risques.Tpm (Int)";

        public string AppCenterAndroidAppId => "";

        public string AppCenterIosAppId => "";

        public string MapLayerEvenementsPoint => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Evenement_rec/FeatureServer/0";
        public string MapLayerEvenementsLine => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Evenement_rec/FeatureServer/1";
        public string MapLayerCities => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Commune/FeatureServer/0";
        public string MapLayerIode => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Iode/FeatureServer/1";
        public string MapLayerDefibrillateur => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Defibrillateur/FeatureServer/1";
        public string MapLayerRassemblement => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Rassemblement/FeatureServer/1";

        public string ApiBaseUrl => "https://vigie-risques-rec.azurewebsites.net/api/";

        public string ArcGISRuntimeLiteLicenseKey => "runtimelite,1000,rud7132046788,none,4N5X0H4AH5C4LMZ59187";
    }
}
