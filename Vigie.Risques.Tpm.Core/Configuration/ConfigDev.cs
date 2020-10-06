using System;
using System.Collections.Generic;
using System.Text;

namespace Vigie.Risques.Tpm.Core.Configuration
{
    public class ConfigDev : IConfig
    {
        public string ApplicationName => "Vigie.Risques.Tpm (Dev)";

        public string AppCenterAndroidAppId => "714259c3-bc64-4ce4-8cb9-377a9567ad87";

        public string AppCenterIosAppId => "";

        public string MapLayerEvenementsPoint => "https://services5.arcgis.com/T4tG0zyYSo9LhWci/arcgis/rest/services/PEvenement/FeatureServer/0";
        public string MapLayerEvenementsLine => "https://services5.arcgis.com/T4tG0zyYSo9LhWci/arcgis/rest/services/PEvenement/FeatureServer/1";
        public string MapLayerCities => "https://services5.arcgis.com/T4tG0zyYSo9LhWci/arcgis/rest/services/PCommunes/FeatureServer/0";
        public string MapLayerIode => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Iode/FeatureServer/1";
        public string MapLayerDefibrillateur => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Defibrillateur/FeatureServer/1";
        public string MapLayerRassemblement => "https://services6.arcgis.com/5mEtJyK0dGzH3gtk/arcgis/rest/services/PUB_Rassemblement/FeatureServer/1";

        public string ApiBaseUrl => "https://vigie-risques-tpm-api.azurewebsites.net/api/";

        public string ArcGISRuntimeLiteLicenseKey => "runtimelite,1000,rud1423338572,none,TRB3LNBHPBJ5RJE15143";
    }
}
