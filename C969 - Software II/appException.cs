using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Software_II
{
    class appException : ApplicationException
    {
        public void businessHours()
        {
            MessageBox.Show("Exception occured, appointments need to be within normal business hours");
        }

        public void appOverlap()
        {
            MessageBox.Show("Exception occured, your appointment time is conflicting with an already present appointment");
        }
    }
}
