using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A2
{
    class UserType
    {

        public enum Type
        {
            View,
            Edit
        }
        

        public bool IsAllowedToEdit( String username1)
        {
            string filepath = @"..\login.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            bool editAllowed = false;
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                if (username1 == entries[0] & entries[2] == "Edit")
                {                   
                    editAllowed = true;
                    return editAllowed;
                }
            }
            return editAllowed;
        }       
    }
}
