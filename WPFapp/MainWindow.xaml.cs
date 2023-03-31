using System.ComponentModel;
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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixInput = "";
        }
    }
}
