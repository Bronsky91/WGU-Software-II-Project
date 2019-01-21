using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using MySql.Data.MySqlClient;

namespace C969___Software_II
{
    public class User
    {
        private int _userid;

        public int getUserid()
        {
            return _userid;
        }

        public void setUserid(int userid)
        {
            _userid = userid;
        }

    }
}
