using Android.Content;
using Android.Views;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using XCC.DemoApp.Controls;
using XCC.DemoApp.Droid;

[assembly: ExportRenderer(typeof(MatrixCell), typeof(MatrixCellRenderer))]
namespace XCC.DemoApp.Droid
{
    /// <summary>
    /// Matrix cell renderer.
    /// </summary>
    public class MatrixCellRenderer : EntryRenderer
    {
        public MatrixCellRenderer(Context context) : base(context) { }

        public static void Initialize() { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e?.OldElement == null)
            {
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
                Control.Gravity = (GravityFlags.CenterVertical | GravityFlags.CenterHorizontal);
            }
        }
    }
}
