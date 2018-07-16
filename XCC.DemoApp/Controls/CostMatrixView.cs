using System;

using Xamarin.Forms;
using XCC.Contracts;

namespace XCC.DemoApp.Controls
{
    /// <summary>
    /// UI control for viewing, or editing a cost-matrix grid
    /// </summary>
    public class CostMatrixView : AbsoluteLayout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.DemoApp.Controls.CostMatrixView"/> class.
        /// </summary>
        public CostMatrixView()
        {
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Fill;
        }

        /// <summary>
        /// The matrix source property.
        /// </summary>
        public static readonly BindableProperty MatrixSourceProperty =
                BindableProperty.Create(
                    "MatrixSource", typeof(CostMatrix), typeof(CostMatrixView),
                    defaultValue: default(CostMatrix), propertyChanged: OnMatrixSourceChanged);

        /// <summary>
        /// Gets or sets the matrix source.
        /// </summary>
        /// <value>The matrix sourc.</value>
        public CostMatrix MatrixSource
        {
            get { return (CostMatrix)GetValue(MatrixSourceProperty); }
            set { SetValue(MatrixSourceProperty, value); }
        }

        /// <summary>
        /// Ons the matrix source changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        static void OnMatrixSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CostMatrixView)bindable).OnMatrixSourceChangedImpl((CostMatrix)oldValue, (CostMatrix)newValue);
        }

        /// <summary>
        /// Ons the matrix source changed impl.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        protected virtual void OnMatrixSourceChangedImpl(CostMatrix oldValue, CostMatrix newValue)
        {
            Children.Clear();

            if (MatrixSource == null)
                return;

            for (int row = 0; row < MatrixSource.NumberOfRows; row++)
            {
                for (int col = 0; col < MatrixSource.NumberOfColumns; col++)
                {
                    var cell = new MatrixCell()
                    {
                        Row = row,
                        Column = col,
                        Text = MatrixSource[row, col].ToString()
                    };

                    Children.Add(cell);
                }
            }

            UpdateCells(Width, Height);
        }

        /// <summary>
        /// The cost path property.
        /// </summary>
        public static readonly BindableProperty CostPathProperty =
            BindableProperty.Create(
            "CostPath", typeof(TraversalPath), typeof(CostMatrixView),
            defaultValue: default(TraversalPath), propertyChanged: OnCostPathChanged);

        /// <summary>
        /// Gets or sets the cost path.
        /// </summary>
        /// <value>The cost path.</value>
        public TraversalPath CostPath
        {
            get { return (TraversalPath)GetValue(CostPathProperty); }
            set { SetValue(CostPathProperty, value); }
        }

        /// <summary>
        /// Ons the cost path changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        static void OnCostPathChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CostMatrixView)bindable).OnCostPathChangedImpl((TraversalPath)oldValue, (TraversalPath)newValue);
        }

        /// <summary>
        /// Ons the cost path changed impl.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        protected virtual void OnCostPathChangedImpl(TraversalPath oldValue, TraversalPath newValue)
        {
            var path = CostPath ?? new TraversalPath(0);
            var columnCount = path.RowIndices.Length;

            //reset all cells
            foreach (View view in Children)
            {
                var cell = (MatrixCell)view;
                var currentColumn = cell.Column;
                var currentRow = cell.Row + 1;

                var pathMatch = (currentColumn < columnCount)
                    && (path.RowIndices[currentColumn] == currentRow);

                if(pathMatch)
                {
                    cell.IsPartOfLowestCostPath = true;
                    cell.IsValid = path.IsValid;
                }
                else
                {
                    cell.IsPartOfLowestCostPath = false;
                    cell.IsValid = true;
                }

            }   
        }

        /// <summary>
        /// Ons the size allocated.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            UpdateCells(width, height);
        }

        /// <summary>
        /// Updates the cells for position and dimensions.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        void UpdateCells(double width, double height)
        {
            if (width <= 0 || height <= 0)
                return;

            if (MatrixSource == null)
                return;

            var rowsSize = height / MatrixSource.NumberOfRows;
            var colsSize = width / MatrixSource.NumberOfColumns;

            foreach (View view in Children)
            {
                var cell = (MatrixCell)view;

                SetLayoutBounds(cell,
                    new Rectangle(cell.Column * colsSize,
                        cell.Row * rowsSize,
                        colsSize,
                        rowsSize));
            }
        }

    }
}

