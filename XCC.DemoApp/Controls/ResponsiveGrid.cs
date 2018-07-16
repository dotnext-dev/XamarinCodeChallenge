using System;

using Xamarin.Forms;

namespace XCC.DemoApp.Controls
{
    /// <summary>
    /// Responsive stack layout.
    /// </summary>
    public class ResponsiveGrid : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.DemoApp.Controls.ResponsiveGrid"/> class.
        /// </summary>
        public ResponsiveGrid()
        {
            RowDefinitions.Add(new RowDefinition());
            RowDefinitions.Add(new RowDefinition());

            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            //ensure view is loaded
            if (width <= 0 || height <= 0)
                return;

            //ensure atleast 2 children available to switch orientation for
            if (Children.Count <= 1)
                return;

            var firstChild = Children[0];
            var secondChild = Children[1];

            //and switch orienation based on landscape or potrait mode
            if(width < height)
            {
                SetRowSpan(firstChild, 1);
                SetRowSpan(secondChild, 1);

                SetColumnSpan(firstChild, 2);
                SetColumnSpan(secondChild, 2);

                SetRow(firstChild, 0);
                SetRow(secondChild, 1);

                SetColumn(firstChild, 0);
                SetColumn(secondChild, 0);
            }
            else
            {
                SetRowSpan(firstChild, 2);
                SetRowSpan(secondChild, 2);

                SetColumnSpan(firstChild, 1);
                SetColumnSpan(secondChild, 1);

                SetRow(firstChild, 0);
                SetRow(secondChild, 0);

                SetColumn(firstChild, 0);
                SetColumn(secondChild, 1);
            }
        }
    }
}

