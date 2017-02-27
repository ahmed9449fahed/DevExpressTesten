using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DataContext.Annotations;
using DevExpress.Xpf.Core;

namespace DataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow,INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext =this;                
            InitializeComponent();
        }


        private ObservableCollection<Song> _song=new ObservableCollection<Song>();
        public ObservableCollection<Song> TestSong
        {
            get { return _song; }
            set
            {
                _song = value;
                OnPropertyChanged(nameof(TestSong));
            }
        }
        private string _name;
        public new string Name2
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name2));
            }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Song s=new Song();
            s.Name = "test";
            s.Number = 1;
            Name2 = s.Name;
            TestSong.Add(s);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hallo");
        }
    }
}
