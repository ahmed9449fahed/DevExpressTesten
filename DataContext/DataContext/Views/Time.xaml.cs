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
using System.Windows.Threading;

namespace DataContext.Views
{
    /// <summary>
    /// Interaction logic for Radial.xaml
    /// </summary>
    public partial class Time : UserControl
    {

        DispatcherTimer timer=new DispatcherTimer();
        public Time()
        {
            InitializeComponent();
            UpdateTime();
            timer.Tick += new EventHandler(OnTimeEvent);
            timer.Interval=new TimeSpan(0,0,1);
            timer.Start();
        }

        private void OnTimeEvent(object sender, EventArgs e)
        {   
            UpdateTime();
        }

        private void UpdateTime()
        {
           Time7Segment.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
            if(DateTime.Now.Hour>12)
            HourIndicatorNewYork.Value = Convert.ToInt16(DateTime.Now.Hour)-12 + Convert.ToDouble(DateTime.Now.Minute) / 60;
            else
            {
                HourIndicatorNewYork.Value = Convert.ToInt16(DateTime.Now.Hour)+Convert.ToDouble(DateTime.Now.Minute)/60;
            }
            MinuteIndicatorNewYork.Value = Convert.ToDouble(DateTime.Now.Minute) * 2 / 10;
            SecondIndicatorNewYork.Value = Convert.ToDouble(DateTime.Now.Second) * 2 / 10;
        }
    }
}
