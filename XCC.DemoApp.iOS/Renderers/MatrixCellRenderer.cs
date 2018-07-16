
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using XCC.DemoApp.Controls;
using XCC.DemoApp.iOS;

[assembly: ExportRenderer(typeof(MatrixCell), typeof(MatrixCellRenderer))]
namespace XCC.DemoApp.iOS
{
    /// <summary>
    /// Matrix cell renderer.
    /// </summary>
    public class MatrixCellRenderer : EntryRenderer
    {
        public static void Initialize() { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}
