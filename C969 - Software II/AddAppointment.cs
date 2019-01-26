using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Software_II
{
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
            endTimePicker.Value = endTimePicker.Value.AddHours(1);
        }

        public MainForm mainFormObject;


        private void addButton_Click(object sender, EventArgs e)
        {
            string timestamp = DataHelper.createTimestamp();
            int userId = DataHelper.getCurrentUserId();
            string username = DataHelper.getCurrentUserName();
            DateTime startTime = startTimePicker.Value.ToUniversalTime();
            DateTime endTime = endTimePicker.Value.ToUniversalTime();

            try
            {
                if(DataHelper.appHasConflict(startTime, endTime))
                    throw new appException();
                else
                {
                    try
                    {
                        if (DataHelper.appIsOutsideBusinessHours(startTime, endTime))
                            throw new appException();
                        else
                        {
                            DataHelper.createRecord(timestamp, username, "appointment", $"'{customerIdTextBox.Text}', '{startTimePicker.Value.ToUniversalTime().ToString("u")}', '{endTimePicker.Value.ToUniversalTime().ToString("u")}', '{typeTextBox.Text}'", userId);
                            mainFormObject.updateCalendar();
                            Close();
                        }
                    }
                    catch (appException ex){ ex.businessHours(); }
                }
            }
            catch (appException ex){ ex.appOverlap(); }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
