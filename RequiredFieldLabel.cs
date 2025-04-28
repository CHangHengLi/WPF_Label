using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPF_Label
{
    public class RequiredFieldLabel : Label
    {
        static RequiredFieldLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RequiredFieldLabel), new FrameworkPropertyMetadata(typeof(RequiredFieldLabel)));
        }

        public RequiredFieldLabel()
        {
            this.Loaded += RequiredFieldLabel_Loaded;
        }

        private void RequiredFieldLabel_Loaded(object sender, RoutedEventArgs e)
        {
            // 创建一个StackPanel来布局内容
            StackPanel panel = new StackPanel { Orientation = Orientation.Horizontal };
            object originalContent = this.Content;
            this.Content = null;
            if (originalContent != null)
            {
                ContentPresenter cp = new ContentPresenter { Content = originalContent };
                panel.Children.Add(cp);
            }
            TextBlock asterisk = new TextBlock
            {
                Text = " *",
                Foreground = Brushes.Red,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Top
            };
            panel.Children.Add(asterisk);
            this.Content = panel;
        }
    }
} 