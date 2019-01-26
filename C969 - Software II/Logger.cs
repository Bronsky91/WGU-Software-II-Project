using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Software_II
{
    class Logger
    {
        public static void writeUserLoginLog(int userId)
        {
            string path = "log.text";
            string log = $"User with ID of {userId} logged in at {DataHelper.createTimestamp()}" + Environment.NewLine;

            File.AppendAllText(path, log);
        }
    }
}
