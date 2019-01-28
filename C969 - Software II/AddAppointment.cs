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

        public static bool appHasConflict(DateTime startTime, DateTime endTime)
        {
            foreach (var app in DataHelper.getAppointments().Values)
            {
                if (startTime < DateTime.Parse(app["end"].ToString()) && DateTime.Parse(app["start"].ToString()) < endTime)
                    return true;
            }
            return false;
        }

        public static bool appIsOutsideBusinessHours(DateTime startTime, DateTime endTime)
        {
            startTime = startTime.ToLocalTime();
            endTime = endTime.ToLocalTime();
            DateTime businessStart = DateTime.Today.AddHours(8); // 8am
            DateTime businessEnd = DateTime.Today.AddHours(17); // 5pm
            if (startTime.TimeOfDay > businessStart.TimeOfDay && startTime.TimeOfDay < businessEnd.TimeOfDay &&
                endTime.TimeOfDay > businessStart.TimeOfDay && endTime.TimeOfDay < businessEnd.TimeOfDay)
                return false;

            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string timestamp = DataHelper.createTimestamp();
            int userId = DataHelper.getCurrentUserId();
            string username = DataHelper.getCurrentUserName();
            DateTime startTime = startTimePicker.Value.ToUniversalTime();
            DateTime endTime = endTimePicker.Value.ToUniversalTime();

            try
            {
                if(appHasConflict(startTime, endTime))
                    throw new appointmentException();
                else
                {
                    try
                    {
                        if (appIsOutsideBusinessHours(startTime, endTime))
                            throw new appointmentException();
                        else
                        {
                            DataHelper.createRecord(timestamp, username, "appointment", $"'{customerIdTextBox.Text}', '{startTimePicker.Value.ToUniversalTime().ToString("u")}', '{endTimePicker.Value.ToUniversalTime().ToString("u")}', '{typeTextBox.Text}'", userId);
                            mainFormObject.updateCalendar();
                            Close();
                        }
                    }
                    catch (appointmentException ex){ ex.businessHours(); }
                }
            }
            catch (appointmentException ex){ ex.appOverlap(); }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
