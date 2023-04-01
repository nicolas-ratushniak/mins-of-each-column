using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using MatrixLib;

namespace WpfApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _matrixInput = "";

        public string MatrixInput
        {
            get => _matrixInput;

            set
            {
                if (value != _matrixInput)
                {
                    _matrixInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private static double[,] GenerateDefaultMatrix()
        {
            double[,] matrix;

            MatrixBuilder builder = new();
            builder.SetSize(4, 6);
            builder.SetPrecision(1);
            builder.SetRange(-10, 11);
            matrix = builder.Build();

            return matrix;
        }

        private static MatrixDecoder GetDefaultMatrixDecoder()
        {
            MatrixDecoder decoder = new(new CultureInfo("en-US"));
            return decoder;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixInput = "";
            
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            double[,] matrix = GenerateDefaultMatrix();
            MatrixDecoder decoder = GetDefaultMatrixDecoder();

            string result = decoder.MatrixToString(matrix);

            MatrixInput = result;
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            if (helpTB.Visibility == Visibility.Visible)
            {
                helpTB.Visibility = Visibility.Hidden;
            }
            else
            {
                helpTB.Visibility = Visibility.Visible;
            }
        }
    }
}
