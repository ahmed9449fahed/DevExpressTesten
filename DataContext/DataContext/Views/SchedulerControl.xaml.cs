using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DataContext.Annotations;

namespace DataContext
{
    /// <summary>
    /// Interaction logic for SchedulerControl.xaml
    /// </summary>
    public partial class SchedulerControl :INotifyPropertyChanged
    {
        public SchedulerControl()
        {
            DataContext = this;
            InitializeComponent();
        }

        private ObservableCollection<Appointment> _appointments=new ObservableCollection<Appointment>();

        public ObservableCollection<Appointment> Appointments
        {
            get { return _appointments; }
            set
            {
                if(Equals(_appointments,value))
                    return;
                _appointments = value;
                OnPropertyChanged(nameof(Appointments));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Addappointment();
        }


        public void Addappointment()
        {
            Appointment apo1 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 4, 0, 0),
                End = new DateTime(2017, 2, 13, 4, 30, 0),
                Subject = "Test",
                Status = 1,
                Description = "nothing",
                Label = 9

            };
            
            Appointment apo2 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 7, 0, 0),
                End = new DateTime(2017, 2, 13, 7, 10, 0),
                Subject = "Test",
                Status = 2,
                Description = "nothing",
                Label = 7

            };
            
            Appointment apo3 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 8, 0, 0),
                End = new DateTime(2017, 2, 13, 8, 3, 0),
                Subject = "Test",
                Status = 3,
                Description = "nothing",
                Label = 5

            };
            
            Appointment apo4 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 9, 0, 0),
                End = new DateTime(2017, 2, 13, 9, 3, 0),
                Subject = "Test",
                Status = 4,
                Description = "nothing",
                Label = 8

            };
            
            Appointment apo5 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 12, 0, 0),
                End = new DateTime(2017, 2, 13, 12, 50, 0),
                Subject = "Test",
                Status = 3,
                Description = "nothing",
                Label = 4

            };
            
            Appointment apo6 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 13, 0, 0),
                End = new DateTime(2017, 2, 13, 13, 40, 0),
                Subject = "Test",
                Status = 4,
                Description = "nothing",
                Label = 3

            };
          
            Appointment apo7 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 14, 0, 0),
                End = new DateTime(2017, 2, 13, 14, 25, 0),
                Subject = "Test",
                Status = 4,
                Description = "nothing",
                Label = 1

            };
            
            Appointment apo8 = new Appointment
            {
                Start = new DateTime(2017, 2, 13, 15, 0, 0),
                End = new DateTime(2017, 2, 13, 15, 20, 0),
                Subject = "Test",
                Status = 3,
                Description = "nothing",
                Label = 2

            };
            Appointment[] apoarray = {apo1, apo2, apo3, apo4, apo5, apo6, apo7, apo8};
            ObservableCollection<Appointment> testlist = new ObservableCollection<Appointment>();
            foreach (Appointment appointment in apoarray)
            {
                testlist.Add(appointment);
            }
            Appointments = testlist;
        }
    }
}
