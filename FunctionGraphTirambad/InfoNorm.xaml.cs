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
    /// Interaction logic for InfoNorm.xaml
    /// </summary>
    public partial class InfoNorm : Window
    {
        public InfoNorm()
        {
            InitializeComponent();
        }


        private void graph_Click(object sender, RoutedEventArgs e)
        {
            {
                Graph plot = new Graph();

                int count = 2;
                double y, x, var, mean;

                ///get information from user and make sure its valid
                if (!(double.TryParse(meanIn.Text, out mean)))
                    MessageBox.Show("Invalid mean");
                else
                    count--;

                ///get information from user and make sure its valid & within range
                if (!(double.TryParse(varIn.Text, out var)))
                    MessageBox.Show("Invalid standard deviation");
                else if (var <= 0)
                    MessageBox.Show("Number must be greater than 0");
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

                        ///Use Normal distribution formula to calculate y-point
                        y = 1.0 / (Math.Sqrt(var) * Math.Sqrt(Math.PI * 2));
                        y = y * Math.Exp(Math.Pow((x - mean), 2) / (-2.0 * var));

                        ///shrink height of graph to fit window
                        y *= 10.0;
                        if (var >= 1)
                            y *= 20.0;
                        else if (var < 1)
                            y *= 10;

                        y = 150 - y;

                        plot.norm.Points.Add(new Point(i, y));
                    }

                    ///label y-axis tick marks
                    if (var < 1)
                    {
                        y = .3;
                        x = -.3;
                        for (int i = 0; i < 4; i++)
                        {
                            count++;
                            plot.setText(count, y.ToString());
                            count++;
                            plot.setText(count, x.ToString());
                            y += .3;
                            x -= .3;
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
        }



        

        private void meanIn_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
