using Sword.Swl.Framework.Xamarin.Services.Contracts;
using System;
using System.Threading.Tasks;
using Vigie.Risques.Tpm.Core.Interfaces;
using Vigie.Risques.Tpm.Core.ViewModels.Carousel;
using Esri.ArcGISRuntime.Mapping;
using Vigie.Risques.Tpm.Core.Views.Carousel;
using Vigie.Risques.Tpm.Core.Services;
using Vigie.Risques.Tpm.Core.Configuration;

namespace Vigie.Risques.Tpm.Core.ViewModels
{
    public class MapViewModel : CarouselViewModelBase, ICarouselViewModel
    {
        private readonly MapVectorCacheService _cacheService;

        private FeatureLayer _cityLayer;
        private FeatureLayer _eventPointLayer;
        private FeatureLayer _eventLineLayer;
        private FeatureLayer _defibrillateurLayer;
        private FeatureLayer _iodeLayer;
        private FeatureLayer _rassemblementLayer;

        private Map _map = new Map(Basemap.CreateStreets());

        public MapViewModel(
            ILogProvider logProvider,
            INavigationService navigation,
            CarouselItemViewBase content,
            string iconSource)
            : base(logProvider, navigation, content, iconSource)
        {

            _cityLayer = new FeatureLayer(new Uri(Config.AppConfig.MapLayerCities));
            _eventPointLayer = new FeatureLayer(new Uri(Config.AppConfig.MapLayerEvenementsPoint));
            _eventLineLayer = new FeatureLayer(new Uri(Config.AppConfig.MapLayerEvenementsLine));

            _defibrillateurLayer = new FeatureLayer(new Uri(Config.AppConfig.MapLayerDefibrillateur));
            _iodeLayer = new FeatureLayer(new Uri(Config.AppConfig.MapLayerIode));
            _rassemblementLayer = new FeatureLayer(new Uri(Config.AppConfig.MapLayerRassemblement));

            TpmMap.Loaded += OnMapLoaded;
        }

        public Viewpoint CurrentViewpoint { get; set; }

        /// <summary>
        /// Gets or sets the map
        /// </summary>
        public Map TpmMap
        {
            get { return _map; }
            set { _map = value; NotifyPropertyChanged(nameof(TpmMap)); }
        }

        public override string Title => Resources.Labels.MapTitle;

        public override Task InitializeAfterNavigationAsync()
        {
            return Task.CompletedTask;
        }

        public override Task InitializeBeforeNavigationAsync()
        {
            return Task.CompletedTask;
        }

        private void OnMapLoaded(object sender, EventArgs e)
        {
            TpmMap.OperationalLayers.Add(_cityLayer);
            TpmMap.OperationalLayers.Add(_eventPointLayer);
            TpmMap.OperationalLayers.Add(_eventLineLayer);

            TpmMap.OperationalLayers.Add(_defibrillateurLayer);
            TpmMap.OperationalLayers.Add(_iodeLayer);
            TpmMap.OperationalLayers.Add(_rassemblementLayer);
        }
    }
}
