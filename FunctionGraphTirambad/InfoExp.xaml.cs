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
    /// Interaction logic for InfoExp.xaml
    /// </summary>
    public partial class InfoExp : Window
    {
        public InfoExp()
        {
            InitializeComponent();
        }

        private void graph_Click(object sender, RoutedEventArgs e)
        {
            
                Graph plot = new Graph();

                int count = 1;
                double y, x,  lamda;

                ///get information from user and make sure its valid
                if (!(double.TryParse(rateIn.Text, out lamda)))
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
                            y = lamda*Math.Exp(-1.0 * lamda * x);
                        }
                        
                        ///shrink height of graph to fit window
                        ///
                        y *= 10.0;
                        if (lamda >= 1)
                            y *= 20.0;
                        else if (lamda < 1)
                            y *= 10;

                        y = 150 - y;
                        
                           // y *= 10;

                        //y = 150 - y;

                        plot.norm.Points.Add(new Point(i, y));
                        //Console.Write("Exp Value" + Math.Exp(1.0));
                        Console.Write("("+x+","+y+")");
                    }

                    ///label y-axis tick marks
                    ///
                   
                        if (lamda >= 1)
                        {
                            y = 0.4;
                            x = -0.4;
                            for (int i = 0; i < 4; i++)
                            {
                                count++;
                                plot.setText(count, y.ToString());
                                count++;
                                plot.setText(count, x.ToString());
                                y += .4;
                                x -= .4;
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
