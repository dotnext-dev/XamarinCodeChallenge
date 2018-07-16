using System;
using System.Threading.Tasks;
using System.Windows.Input;

using XCC.Contracts;
using XCC.Data;
using XCC.Utilities;

namespace XCC.DemoApp
{
    public class MainViewModel : BaseViewModel
    {
        #region fields

        CostMatrix m_costMatrix;
        TraversalPath m_traversalPath;
        PathProviderBase m_pathProvider;

        int m_rowCount;
        int m_colCount;

        ICommand m_calculateCmd;
        ICommand m_loadSampleCmd;

        #endregion

        #region properities

        /// <summary>
        /// Gets or sets the current cost matrix.
        /// </summary>
        /// <value>The current cost matrix.</value>
        public CostMatrix CurrentCostMatrix
        {
            get => m_costMatrix;
            set
            {
                SetProperty(ref m_costMatrix, value);
            }
        }

        /// <summary>
        /// Gets or sets the lowest cost path.
        /// </summary>
        /// <value>The lowest cost path.</value>
        public TraversalPath LowestCostPath
        {
            get => m_traversalPath;
            set
            {
                SetProperty(ref m_traversalPath, value);
            }
        }


        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>The row count.</value>
        public int RowCount
        {
            get => m_rowCount;
            set
            {
                if(SetProperty(ref m_rowCount, value))
                    SetCostMatrix();
            }
        }

        /// <summary>
        /// Gets or sets the column count.
        /// </summary>
        /// <value>The column count.</value>
        public int ColumnCount
        {
            get => m_colCount;
            set
            {
                if (SetProperty(ref m_colCount, value))
                    SetCostMatrix();
            }
        }

        /// <summary>
        /// Gets the calculate path command.
        /// </summary>
        /// <value>The calculate path command.</value>
        public ICommand CalculatePathCommand => m_calculateCmd = (m_calculateCmd ??
                                                                  new Xamarin.Forms.Command(async () => await OnCalculatePathAsync()));

        /// <summary>
        /// Gets the load sample command.
        /// </summary>
        /// <value>The load sample command.</value>
        public ICommand LoadSampleCommand => m_loadSampleCmd = (m_loadSampleCmd ??
                                                                new Xamarin.Forms.Command(OnLoadSample));


        /// <summary>
        /// Gets the path provider.
        /// </summary>
        /// <value>The path provider.</value>
        public PathProviderBase PathProvider => 
                                        m_pathProvider = (m_pathProvider ??
                                                          new SmartPathProvider(SampleDataSets.MaxCost));

        #endregion

        #region methods

        /// <summary>
        /// Sets the cost matrix as per updated rows, or columns.
        /// </summary>
        void SetCostMatrix()
        {
            CurrentCostMatrix = new CostMatrix(new int[m_rowCount, m_colCount]);
            LowestCostPath = null;
        }

        /// <summary>
        /// Initializes from given data-set
        /// </summary>
        /// <param name="dataSet">Sample1.</param>
        public void InitializeFrom(DataSet dataSet)
        {
            var costGrid = new CostMatrix(dataSet.MappedCostValues);
            m_colCount = costGrid.NumberOfColumns;
            m_rowCount = costGrid.NumberOfRows;
            m_costMatrix = costGrid;
            m_traversalPath = null;

            OnPropertyChanged(nameof(RowCount));
            OnPropertyChanged(nameof(ColumnCount));
            OnPropertyChanged(nameof(LowestCostPath));
            OnPropertyChanged(nameof(CurrentCostMatrix));
        }

        /// <summary>
        /// Ons the calculate path async.
        /// </summary>
        /// <returns>The calculate path async.</returns>
        async Task OnCalculatePathAsync()
        {
            var path = await GetPathFromProvider();
            LowestCostPath = path;
        }

        /// <summary>
        /// Gets the path from provider.
        /// </summary>
        /// <returns>The path from provider.</returns>
        async Task<TraversalPath> GetPathFromProvider()
        {
            if (CurrentCostMatrix == null)
                return new TraversalPath(0);

            var computedPath = await Task.Run(
                () => PathProvider.GetLowestTraversalPath(CurrentCostMatrix));

            return computedPath;
        }

        /// <summary>
        /// Ons the load sample.
        /// </summary>
        /// <param name="obj">Object.</param>
        void OnLoadSample(object obj)
        {
            if(obj is string index)
            {
                switch(index)
                {
                    case "1":
                        InitializeFrom(SampleDataSets.Sample2);
                        break;
                    case "2":
                        InitializeFrom(SampleDataSets.Sample3);
                        break;
                }
            }
        }

        #endregion
    }
}
