using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
   public class Appointment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public object Label { get; set; }
        public object Status { get; set; }
    }
}
