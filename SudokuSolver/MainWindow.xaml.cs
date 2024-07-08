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
            throw new NotImplementedException();
        }
    }
}