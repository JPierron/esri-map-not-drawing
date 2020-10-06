using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Vigie.Risques.Tpm.Core.Controls;
using Vigie.Risques.Tpm.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace Vigie.Risques.Tpm.Droid.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            var _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetCornerRadius(DpToPixels(Context, 30f));
            _gradientBackground.SetColor(Color.White.ToAndroid());
            Control.SetBackground(_gradientBackground);

            // Customize frame color
            int frameId = Control.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            Android.Views.View frameView = (Control.FindViewById(frameId) as Android.Views.View);
            frameView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }

}