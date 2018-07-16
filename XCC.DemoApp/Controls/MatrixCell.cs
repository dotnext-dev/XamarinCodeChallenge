using System;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using XCC.Utilities;

namespace XCC.DemoApp.Controls
{
    public class MatrixCell : Entry
    {
        public MatrixCell()
        {
            HorizontalTextAlignment = TextAlignment.Center;
            MaxLength = 3;
        }

        #region properties

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <value>The row.</value>
        public int Row { set; get; }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>The column.</value>
        public int Column { set; get; }

        #endregion

        /// <summary>
        /// Updates the label style according to current state.
        /// </summary>
        protected virtual void UpdateStyle()
        {
            if (!IsTextValid)
                BackgroundColor = Color.Red;
            else if (IsPartOfLowestCostPath && IsPathValid)
                BackgroundColor = Color.FromHex("#aa00ff00");
            else if (IsPartOfLowestCostPath)
                BackgroundColor = Color.FromHex("#aaff0000");
            else
                BackgroundColor = Color.Transparent;

            var width = Width;
            var height = Height;

            if (width <= 0 || height <= 0)
                return;

            FontSize = Math.Min(ConsistentFontSize(), AvailableFontSize(width, height));
        }

        #region bindable properties

        /// <summary>
        /// Determines whether current cell is part of lowest cost path property.
        /// </summary>
        public static readonly BindableProperty IsPartOfLowestCostPathProperty =
            BindableProperty.Create(
                "IsPartOfLowestCostPath", typeof(bool), typeof(MatrixCell),
            defaultValue: default(bool), propertyChanged: OnIsPartOfLowestCostPathChanged);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:XCC.DemoApp.Controls.MatrixCell"/> is part of
        /// lowest cost path.
        /// </summary>
        /// <value><c>true</c> if is part of lowest cost path; otherwise, <c>false</c>.</value>
        public bool IsPartOfLowestCostPath
        {
            get { return (bool)GetValue(IsPartOfLowestCostPathProperty); }
            set { SetValue(IsPartOfLowestCostPathProperty, value); }
        }

        /// <summary>
        /// Ons the is part of lowest cost path changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        static void OnIsPartOfLowestCostPathChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((MatrixCell)bindable).UpdateStyle();
        }

        /// <summary>
        /// Determines whether current cell is part of valid path.
        /// </summary>
        public static readonly BindableProperty IsPathValidProperty =
            BindableProperty.Create(
            "IsPathValid", typeof(bool), typeof(MatrixCell),
            defaultValue: true, propertyChanged: OnIsPathValidChanged);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:XCC.DemoApp.Controls.MatrixCell"/> is part of valid path.
        /// </summary>
        /// <value><c>true</c> if is valid; otherwise, <c>false</c>.</value>
        public bool IsPathValid
        {
            get { return (bool)GetValue(IsPathValidProperty); }
            set { SetValue(IsPathValidProperty, value); }
        }

        /// <summary>
        /// Ons the is valid changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        static void OnIsPathValidChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((MatrixCell)bindable).UpdateStyle();
        }

        /// <summary>
        /// The is text valid property.
        /// </summary>
        public static readonly BindableProperty IsTextValidProperty =
            BindableProperty.Create(
                "IsTextValid", typeof(bool), typeof(MatrixCell),
                defaultValue: true);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:XCC.DemoApp.Controls.MatrixCell"/> is text valid.
        /// </summary>
        /// <value><c>true</c> if is text valid; otherwise, <c>false</c>.</value>
        public bool IsTextValid
        {
            get { return (bool)GetValue(IsTextValidProperty); }
            set { SetValue(IsTextValidProperty, value); }
        }


        #endregion

        /// <summary>
        /// Ons the size allocated.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width <= 0 || height <= 0)
                return;

            UpdateStyle();
        }

        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Text))
            {
                if(Parent is CostMatrixView matrixView)
                {
                    var costMatrix = matrixView.MatrixSource;
                    if (costMatrix != null)
                    {
                        costMatrix[Row, Column] = Text.ToCostValue();
                        IsTextValid = string.Equals(Text,
                                      costMatrix[Row, Column].ToString(),
                                      StringComparison.OrdinalIgnoreCase);
                        matrixView.UpdateMatrixState();
                    }    
                }

                UpdateStyle();
            }    
        }

        #region methods

        double ConsistentFontSize()
        {
            // Resolution in device-independent units per inch.
            double resolution = 160;

            // Do some numeric point sizes.
            int[] ptSizes = { 4, 6, 8, 10, 12 };

            // Select numeric point size you need from ptSize[] array 
            double ptSize = 10;

            // this is your new visually consistent font-size.
            var fontSize = resolution * ptSize / 72;
            return fontSize;
        }

        double AvailableFontSize(double width, double height)
        {
            //TODO: Change this to Device.RuntimePlatform
            double lineHeight = 1.2;
            double charWidth = 0.5;

            var charCount = (Text == null) ? 0 : Text.Length;
            charCount = Math.Max(charCount, 5);

            var view = Parent;
            // Because:
            //   lineCount = view.Height / (lineHeight * fontSize)
            //   charsPerLine = view.Width / (charWidth * fontSize)
            //   charCount = lineCount * charsPerLine
            // Hence, solving for fontSize:
            int fontSize = (int)Math.Sqrt(width * height /
                                (charCount * lineHeight * charWidth));
            return fontSize;
        }

        #endregion
    }
}

