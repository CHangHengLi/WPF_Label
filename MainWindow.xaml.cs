using System.Windows;

namespace WPF_Label
{
    public partial class MainWindow : Window
    {
        public string UserName { get; set; } = "张三";
        public double Price { get; set; } = 123.45;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
} 