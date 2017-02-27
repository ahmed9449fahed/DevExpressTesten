using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataContext.Annotations;

namespace DataContext
{
   public class Song:INotifyPropertyChanged
    { 
        private string _name { get; set; }
        private int _number { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {if(Equals(Equals(_name,value)))
                    return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Number
        {
            get { return _number; }
            set
            {if(Equals(_number,value))
                    return;
                _number = value;
                OnPropertyChanged(nameof(Number));
            }            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
