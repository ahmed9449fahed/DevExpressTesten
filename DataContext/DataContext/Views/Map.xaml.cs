using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DataContext.Annotations;

namespace DataContext.Views
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl,INotifyPropertyChanged
    {
        DispatcherTimer timer = new DispatcherTimer();
        public Map()
        {
            
            DataContext = this;
            InitializeComponent();
            UpdateTime();
            timer.Tick += new EventHandler(OnTimeEvent);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        private void OnTimeEvent(object sender, EventArgs e)
        {
            UpdateTime();
        }

        public static int index=0;
        public int flipflop = 0;
        private void UpdateTime()
        {
            if (flipflop==0)
            {
                Positions = _positions[index];
                Positions2 = _positions2[index];
                index++;
                if (index >= _positions.Length-1)
                    flipflop = 1;
            }
            if (flipflop == 1)
            {
                Positions = _positions[index];
                Positions2 = _positions2[index];
                index--;
                if (index <=0)
                    flipflop = 0;
            }

            
           
        }


        private string[] _positions = new[]
        {
            "53.542314, 9.894747",
            "53.542200, 9.900669",
            "53.542212, 9.906184",
            "53.542161, 9.909145",
            "53.542404, 9.915368",
            "53.541957, 9.921955",
            "53.541996, 9.928435",
            "53.541957, 9.933413",
            "53.541843, 9.938070",
            "53.542034, 9.943499",
            "53.542812, 9.950408",
            "53.543551, 9.956137",
            "53.544138, 9.958862",
            "53.544444, 9.962746",
            "53.544380, 9.965772"
        };

        public string Positions
        {
            get { return _positions[index]; }
            set
            {
                if(Equals(_positions,value))
                    return;
                _positions[index]= value;
                OnPropertyChanged(nameof(Positions));
            }
        }
        private string[] _positions2 = new[]
       {
            "53.542645, 9.891056",
            "53.542398, 9.897322",
            "53.542231, 9.904296",
            "53.542263, 9.907525",
            "53.542423, 9.913726",
            "53.542811, 9.920989",
            "53.542328, 9.926611",
            "53.541339, 9.931514",
            "53.541594, 9.935774",
            "53.541945, 9.941632",
            "53.542914, 9.948123",
            "53.543895, 9.954560",
            "53.544399, 9.960107",
            "53.544425, 9.961534",
            "53.545152, 9.965664"
        };

        public string Positions2
        {
            get { return _positions2[index]; }
            set
            {
                if (Equals(_positions2, value))
                    return;
                _positions2[index] = value;
                OnPropertyChanged(nameof(Positions2));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }

    public class ShipPosition
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}
