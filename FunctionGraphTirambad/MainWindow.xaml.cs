using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunctionGraphTirambad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void normal_Click(object sender, RoutedEventArgs e)
        {
             InfoNorm infN = new InfoNorm();
            infN.ShowDialog();
        }

        private void exponential_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InfoExp infE = new InfoExp();
            infE.ShowDialog();
        }

        private void binomial_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InfoBin infB = new InfoBin();
            infB.ShowDialog();
        }

        private void poison_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InfoPois infP = new InfoPois();
            infP.ShowDialog();
        }

        private void rayleigh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InfoRayl infR = new InfoRayl();
            infR.ShowDialog();
        }

        

        
    }
}
