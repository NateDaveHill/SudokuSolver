using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Size = 9;
        List<GridData> boardData = new List<GridData>();



        public MainWindow()
        {
            InitializeComponent();
            SudokuBoard.ItemsSource = LoadCollectionData();
        }

        private List<GridData> LoadCollectionData()
        {

            boardData.Add(new GridData()
            {
                One = 1,
                Two = 2,
                Three = 3
            });

            boardData.Add(new GridData()
            {
                One = 0,
                Two = 2,
                Three = 1
            });

            boardData.Add(new GridData()
            {
                One = 2,
                Two = 3,
                Three = 2
            });

            return boardData;
        }

        private void BtnSolve_OnClick(object sender, RoutedEventArgs e)
        {
            List<GridData> updatedNumbers = new List<GridData>();
            List<int> currentColumn = new List<int>();
            IEnumerable<int> missingNumbers = null;
            int itemInColumn = 0;


            var numbers = SudokuBoard.ItemsSource as IEnumerable<GridData>;
            if (numbers != null)
            {

                foreach (var item in boardData)
                {
                    Type type = typeof(GridData);

                    PropertyInfo[] properties = type.GetProperties();

                    foreach (var property in properties)
                    {
                        string propertyName = property.Name;
                        int propertyValue = Convert.ToInt32(property.GetValue(item));

                    }
                }


                foreach (var item in numbers)
                {
                    itemInColumn = item.One;
                    currentColumn.Add(item.One);
                }

                for (int i = 0; i < 3; i++)
                {
                    missingNumbers = Enumerable.Range(1, 3).Except(currentColumn);
                }


                foreach (var number in numbers)
                {
                    if (number.One == 0)
                    {
                        foreach (var missingNumber in missingNumbers)
                        {
                            updatedNumbers.Add(new GridData { One = missingNumber, Two = number.Two, Three = number.Three });
                        }
                    }
                    else
                    {
                        updatedNumbers.Add(number);
                    }
                }

                SudokuBoard.ItemsSource = updatedNumbers;

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