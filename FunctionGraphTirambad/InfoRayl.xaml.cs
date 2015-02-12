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
using System.Windows.Shapes;

namespace FunctionGraphTirambad
{
    /// <summary>
    /// Interaction logic for InfoRayl.xaml
    /// </summary>
    public partial class InfoRayl : Window
    {
        public InfoRayl()
        {
            InitializeComponent();
        }

        private void graph_Click(object sender, RoutedEventArgs e)
        {

            Graph plot = new Graph();

            int count = 1;
            double y, x, sigma;

            ///get information from user and make sure its valid
            if (!(double.TryParse(paramIn.Text, out sigma)))
                MessageBox.Show("Invalid Arrival Rate");
            else
                count--;



            if (count == 0)
            {
                for (int i = 0; i < 301; i++)
                {
                    x = (i - 150.0) / 60;

                    if (i > 0 && i < 150 && (i % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }
                    else if (i > 160 && i < 300 && ((i - 1) % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }

                    //Use Exponential distribution formula to claculate y-point
                    if (x < 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        y = (x/(sigma*sigma))*Math.Exp((-1.0*x*x)/(sigma*sigma));
                    }

                    ///shrink height of graph to fit window
                    ///
                    y *= 10.0;
                    if (sigma >= 1)
                        y *= 20.0;
                    else if (sigma < 1)
                        y *= 10;

                    y = 150 - y;

                    // y *= 10;

                    //y = 150 - y;

                    plot.norm.Points.Add(new Point(i, y));
                    //Console.Write("Exp Value" + Math.Exp(1.0));
                    //Console.Write("(" + x + "," + y + ")");
                }

                ///label y-axis tick marks
                ///

                if (sigma >= 1)
                {
                    y = 0.2;
                    x = -0.2;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += .2;
                        x -= .2;
                    }
                }
                else
                {
                    y = 0.150786;
                    x = -0.150786;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += 0.150786;
                        x -= 0.150786;
                    }
                }

                plot.ShowDialog();

            }
        }

        private void meanIn_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
