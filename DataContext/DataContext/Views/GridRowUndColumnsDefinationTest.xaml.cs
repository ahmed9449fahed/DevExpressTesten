using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for GridRowUndColumnsDefinationTest.xaml
    /// </summary>
    public partial class GridRowUndColumnsDefinationTest : UserControl,INotifyPropertyChanged
    {
        public GridRowUndColumnsDefinationTest()
        {
            DataContext = this;
            InitializeComponent();
        }
        private ObservableCollection<Info> _Infos = new ObservableCollection<Info>();

        public ObservableCollection<Info> Infos
        {
            get { return _Infos; }
            set
            {
                if(Equals(_Infos,value))
                    return;
                _Infos = value;
                OnPropertyChanged(nameof(Infos));
            }
        }
  
      
        private ObservableCollection<DateTime> _dateTest = new ObservableCollection<DateTime>();

        public ObservableCollection<DateTime> DateTest
        {
            get { return _dateTest; }
            set
            {
                if (Equals(_dateTest, value))
                    return;
                _dateTest = value;
                OnPropertyChanged(nameof(_dateTest));
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
            Infos.Clear();
            var reader = new StreamReader(File.OpenRead(@"C:\Users\afa\Desktop\Book1.csv"));
            
            while (!reader.EndOfStream)
            {
                Info i=new Info();
                var line = reader.ReadLine();
                var values = line.Split(',');
                i.Name = values[0];
                i.Id = values[1];
                i.Telephone = values[2];
                i.Date = DateTime.Now;
                Infos.Add(i);
            }

            DateTime d=new DateTime(2017,2,12);
            DateTest.Add(d);
        }
    }
    public class Info
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Telephone { get; set; }
        public DateTime Date { get; set; }
    }
}
