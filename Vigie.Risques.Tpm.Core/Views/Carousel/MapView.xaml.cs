using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Xamarin.Forms;
using Vigie.Risques.Tpm.Core.ViewModels;
using Vigie.Risques.Tpm.Core.Views.Carousel;
using Xamarin.Forms.Xaml;

namespace Vigie.Risques.Tpm.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : CarouselItemViewBase
    {

        public MapView()
        {
            InitializeComponent();

            TpmMapView.NavigationCompleted += (s, e) =>
            {
                ((MapViewModel)ViewModel).CurrentViewpoint = TpmMapView.GetCurrentViewpoint(ViewpointType.BoundingGeometry);
            };

            TpmMapView.GeoViewHolding += (s, e) =>
            {
            };

            TpmMapView.GeoViewTapped += OnMapViewTapped;
        }

        private async void OnMapViewTapped(object sender, GeoViewInputEventArgs e)
        {
        }

        public Esri.ArcGISRuntime.Xamarin.Forms.MapView GetMapView()
        {
            return TpmMapView;
        }

        public override void OnViewModelAttached()
        {
            TpmMapView.Map = ((MapViewModel)ViewModel).TpmMap;
        }
    }
}
