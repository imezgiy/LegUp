using Android.Content;
using LegUp.Droid.Renderers;
using LegUp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessSelect), typeof(BorderlessSelectRenderer))]
namespace LegUp.Droid.Renderers
{
    public class BorderlessSelectRenderer : PickerRenderer
    {
        public BorderlessSelectRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}