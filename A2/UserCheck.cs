using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace A2
{
    class UserCheck
    {
        public bool LogInCheck(string username1, string password1)
        {
            string filepath = @"..\login.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            bool loginCheck = false;
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                if (username1 == entries[0] && password1 == entries[1])
                {
                    //MessageBox.Show(userType,"User Type");
                    loginCheck = true;
                    return loginCheck;
                }                
            }
            return loginCheck;
        }        
    }
}
