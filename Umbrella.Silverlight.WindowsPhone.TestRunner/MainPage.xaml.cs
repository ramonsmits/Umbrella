using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Reflection;
using Xunit;
using System.Threading;
using System.ComponentModel;
using nVentive.Umbrella;

namespace Umbrella.Silverlight.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(DoTests);
        }

        private void DoTests(object dummy)
        {
            try
            {
                var assembly = Assembly.Load("Umbrella.Tests.Silverlight");

                var typesQuery = from type in assembly.GetTypes()
                                 where type.IsPublic && !type.IsGenericType
                                 from method in type.GetMethods()
                                 where method.IsDefined(typeof(FactAttribute), true)
                                 select new
                                 {
                                     Type = type,
                                     Method = method
                                 };

                int testCount = 0;
                int failCount = 0;

                Dispatcher.BeginInvoke(() => result.Text = "Running");

                foreach (var fact in typesQuery)
                {
                    try
                    {
                        var instance = Activator.CreateInstance(fact.Type);
                        fact.Method.Invoke(instance, new object[0]);
                    }
                    catch (Exception /*e*/)
                    {
                        Dispatcher.BeginInvoke(
                             Actions.Create<int>(
                                count =>
                                {
                                    failedCountBlock.Text = count.ToString();
                                }
                            ),
                            ++failCount
                        );
                    }

                    Dispatcher.BeginInvoke(
                         Actions.Create<int>(
                            count =>
                            {
                                testCountBlock.Text = count.ToString();
                            }
                        ),
                        ++testCount
                    );
                }

                Dispatcher.BeginInvoke(() => result.Text = "Done");
            }
            catch (Exception e)
            {
                Dispatcher.BeginInvoke(() => result.Text = e.ToString());
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}