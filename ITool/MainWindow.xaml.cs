using System;
using System.Collections.Generic;
using System.Linq;
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
using sy07073.mobile.game.sdk.unit;
namespace ITool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           this.tbResult.Text=Des.decodeValue(this.textBox.Text);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.tbResult.Text = Des.encode(this.textBox.Text);
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
           // api = getgame_uv & gameid = 62Ks.V60!3
            this.tbResult.Text = "";
        }
    }
}
