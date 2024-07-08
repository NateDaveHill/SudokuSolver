using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Size = 9;


        public MainWindow()
        {
            InitializeComponent();
            SudokuBoard.ItemsSource = LoadCollectionData();
            
        }

        private List<GridData> LoadCollectionData()
        {
            List<GridData> boardData = new List<GridData>();
            boardData.Add(new GridData()
            {
                One = 1,
                Two = 2,
                Three = 3
            });
            
            boardData.Add(new GridData()
            {
                One = 3,
                Two = 2,
                Three = 1
            });
            
            boardData.Add(new GridData()
            {
                One = 1,
                Two = 3,
                Three = 2
            });

            return boardData;
        }

        private void BtnSolve_OnClick(object sender, RoutedEventArgs e)
        {
            List<int> currentColumn = new List<int>();
            int itemInColumn = 0;

            var items = SudokuBoard.ItemsSource as IEnumerable<GridData>;
            if (items != null)
            {
                foreach (var item in items)
                {
                    itemInColumn = item.One;
                    currentColumn.Add(item.One);
                }

                for (int i = 0; i < 3; i++)
                {
                    var result = Enumerable.Range(0, 3).Except(currentColumn);
                }
            }
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRandomPopulate_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}