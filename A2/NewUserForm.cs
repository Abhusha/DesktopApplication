using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace A2
{
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form1 = new LoginForm();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            String filePath = @"..\login.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            string username1 = textBox1.Text;                     //MessageBox.Show(username,"Name");
            string password1= textBox2.Text;                      //MessageBox.Show(password, "Name");
            string reEnteredPassword = textBox3.Text;            //MessageBox.Show(reEnteredPassword, "Name");
            string firstName1= textBox4.Text;                     //MessageBox.Show(firstName, "Name");
            string lastName1= textBox5.Text;                      //MessageBox.Show(lastName, "Name");
            string date1= dateTimePicker1.Text;                  //MessageBox.Show(date, "Name");
            string userType1 = comboBox1.SelectedItem.ToString(); //MessageBox.Show(userType, "Name");

            if (password1==reEnteredPassword)
            {
                // Add new User's detail to login.txt file
                List<Person> people = new List<Person>();
                people.Add(new Person { UserName = username1, Password = password1, UserType = userType1, FirstName = firstName1, Lastname = lastName1, Date = date1 });
                
                foreach (var person in people)
                    lines.Add($"{person.UserName},{person.Password},{person.UserType},{person.FirstName},{person.Lastname},{person.Date}");
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Your Username and Password has been saved", "New Account Generated");
                LoginForm form1 = new LoginForm();
                MessageBox.Show("You can now LogIn", "New Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please be Careful. Password and Re-entered Password are not same", "Alert");
                this.Close();
                NewUserForm form2 = new NewUserForm();
                form2.Show();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string name = textBox1.Text;           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
