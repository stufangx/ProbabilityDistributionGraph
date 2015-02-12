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
using MathNet;

namespace FunctionGraphTirambad
{
    /// <summary>
    /// Interaction logic for InfoBin.xaml
    /// </summary>
    public partial class InfoBin : Window
    {
        public InfoBin()
        {
            InitializeComponent();
        }
        private double factorial(int n)
        {
            int fact=1;
            if (n <= 0)
            {
                //Console.Write("(" + n + "," + fact + ")");
                return 1;
                
            }
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            //Console.Write("(Number" + n + ", Factorial" + fact + ")");
            return fact;
        }
        private void graph_Click(object sender, RoutedEventArgs e)
        {
            
                Graph plot = new Graph();

                int count = 2;
                int N,x;
                double y, P;

                ///get information from user and make sure its valid
                if (!(int.TryParse(totalIn.Text, out N)))
                    MessageBox.Show("Number of Trials should be integer values");
                else
                    count--;
                if (!(double.TryParse(probIn.Text, out P)))
                    MessageBox.Show("Invalid Probability Value");
                else if (P > 1 || P < 0)
                    MessageBox.Show("Invalid Probability Value");
                else
                    count--;
                



                if (count == 0)
                {
                    for (int i = 0; i < 301; i++)
                    {
                        x = (i - 150)/5;
                        
                            if (i > 0 && i < 150 && (i % 30) == 0)
                            {
                                count++;
                                plot.setText(count, x.ToString());
                                //Console.Write("(" + x + ")");
                            }
                            else if (i >= 152 && i < 300 && ((i - 1) % 30) == 0)
                            {
                                count++;
                                plot.setText(count, x.ToString());
                                //Console.Write("(" + x + ")");
                            }

                            //Use Exponential distribution formula to c  laculate y-point
                            if (x < 0)
                            {
                                y = 0;
                            }
                            else
                            {
                                //try
                                //{
                                    if (x < N)
                                    {
                                        y = (MathNet.Numerics.SpecialFunctions.Factorial(N) / (MathNet.Numerics.SpecialFunctions.Factorial(x) * MathNet.Numerics.SpecialFunctions.Factorial(N-x))) * Math.Pow(P, x) * Math.Pow((1 - P), (N - x));


                                        y *= 30.0;
                                        if (P >= 0.5)
                                            y *= 20.0;
                                        else
                                            y *= 10;

                                        y = 150 - y;
                                        plot.norm.Points.Add(new Point(i, y));
                                        
                                        
                                       // Console.Write("(" + x + "," + y + ")");
                                    }
                                    //Console.Write("(" + i + "," + y + ")");
                                //}
                                //catch (DivideByZeroException error)
                                //{
                                  //  MessageBox.Show("Divide By Zero Exception");

                                //}
                            }
                            
                            ///shrink height of graph to fit window
                            ///
                            /*  y *= 10.0;
                              if (P >= 0.5)
                                  y *= 20.0;
                              else 
                                  y *= 10;

                              y = 150 - y;

                              // y *= 10;

                              //y = 150 - y;*/

                            //plot.norm.Points.Add(new Point(i, y));
                            //plot.norm.Points.Add(new Point(i, y));
                            //Console.Write("Exp Value" + Math.Exp(1.0));
                            //Console.Write("(" + x + "," + y + ")");
                        

                    }
                    ///label y-axis tick marks
                    ///
                    double xx;
                    //if (N >= 20)
                    //{
                        y = 0.05;
                         xx = -0.05;
                        for (int i = 0; i < 4; i++) 
                        {
                            count++;
                            plot.setText(count, y.ToString());
                            count++;
                            plot.setText(count, xx.ToString());
                            y += .05;
                            xx -= .05;
                        }
                    //}
                    /*else
                    {
                        y = 0.150786;
                        xx = -0.150786;
                        for (int i = 0; i < 4; i++)
                        {
                            count++;
                            plot.setText(count, y.ToString());
                            count++;
                            plot.setText(count, xx.ToString());
                            y += 0.150786;
                            xx -= 0.150786;
                        }
                    }*/

                    plot.ShowDialog();
                
            }
        }

    }
}
