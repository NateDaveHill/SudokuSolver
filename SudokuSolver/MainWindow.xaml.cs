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
        }


        private void BtnSolve_OnClick(object sender, RoutedEventArgs e)
        {
            List<GridData> updatedNumbers = new List<GridData>();
            List<int> currentColumnOne = new List<int>();
            List<int> currentColumnTwo = new List<int>();
            List<int> currentColumnThree = new List<int>();
            IEnumerable<int> missingNumbersOne = null;
            IEnumerable<int> missingNumbersTwo = null;
            IEnumerable<int> missingNumbersThree = null;
            int itemInColumn = 0;


            var numbers = SudokuBoard.ItemsSource as IEnumerable<GridData>;
            if (numbers != null)
            {
                foreach (var item in numbers)
                {
                    itemInColumn = item.One;
                    currentColumnOne.Add(item.One);
                    currentColumnTwo.Add(item.Two);
                    currentColumnThree.Add(item.Three);
                }

              
                    missingNumbersOne = Enumerable.Range(1, 3).Except(currentColumnOne);
                    missingNumbersTwo = Enumerable.Range(1, 3).Except(currentColumnTwo);
                    missingNumbersThree = Enumerable.Range(1, 3).Except(currentColumnThree);
                


                foreach (var number in numbers)
                {
                    if (number.One == 0)
                    {
                        foreach (var missingNumber in missingNumbersOne)
                        {
                            updatedNumbers.Add(new GridData
                                { One = missingNumber, Two = number.Two, Three = number.Three });
                        }
                    }

                    else if (number.Two == 0)
                    {
                        foreach (var missingNumber in missingNumbersTwo)
                        {
                            updatedNumbers.Add(new GridData
                                { One = number.One, Two = missingNumber, Three = number.Three });
                        }
                    }

                    else if (number.Three == 0)
                    {
                        foreach (var missingNumber in missingNumbersThree)
                        {
                            updatedNumbers.Add(new GridData
                                { One = number.One, Two = number.Two, Three = missingNumber });
                        }
                    }

                    else
                    {
                        updatedNumbers.Add(number);
                    }
                }

                SudokuBoard.ItemsSource = null;
                SudokuBoard.ItemsSource = updatedNumbers;
            }
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRandomPopulate_OnClick(object sender, RoutedEventArgs e)
        {
            
            boardData.Add(new GridData()
            {
                One = 1,
                Two = 0,
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
                One = 1,
                Two = 3,
                Three = 0
            });

            SudokuBoard.ItemsSource = boardData;
        }
    }
}