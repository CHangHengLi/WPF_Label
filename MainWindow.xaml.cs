using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WPF_Label
{
    public partial class MainWindow : Window
    {
        public string UserName { get; set; } = "张三";
        public double Price { get; set; } = 123.45;
        public ICommand ExecuteCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ExecuteCommand = new RelayCommand(_ => MessageBox.Show("命令已执行"));
            
            // 注册语言变更事件
            LangRes.LanguageChanged += (s, e) => RefreshLanguageBindings();
        }

        // 富文本Label中的超链接点击事件
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        // 可点击Label的事件
        private void ViewMoreLabel_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("这里是详细信息内容");
        }

        private void SwitchLanguage_Click(object sender, RoutedEventArgs e)
        {
            // 调用LangRes中的ToggleLanguage方法切换语言
            LangRes.ToggleLanguage();
            // 强制刷新绑定
            RefreshLanguageBindings();
        }
        
        // 刷新语言绑定的方法
        private void RefreshLanguageBindings()
        {
            // 手动强制刷新绑定的标签文本
            lblUsername.Content = LangRes.UsernameLabel;
            lblPassword.Content = LangRes.PasswordLabel;
        }
    }

    // 简单RelayCommand实现
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
        public event System.EventHandler CanExecuteChanged { add { } remove { } }
    }
} 