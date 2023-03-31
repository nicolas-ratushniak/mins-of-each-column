using System.ComponentModel;
using System.Windows;
using MatrixLib;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private string _matrixInput = "";

        public string MatrixInput
        {
            get => _matrixInput;

            set
            {
                if (value != _matrixInput)
                {
                    _matrixInput = value;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

    }
}
