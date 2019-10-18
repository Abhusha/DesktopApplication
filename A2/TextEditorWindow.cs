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
    public partial class Form3 : Form
    {
        UserType userType = new UserType();
        public Form3()
        {
            InitializeComponent();
                       
        }

        public void ShowDetail(String username1)
        {
            toolStripLabel2.Text = username1;
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
             AboutForm form4 = new AboutForm();
             form4.Show();

            DialogResult result = MessageBox.Show("Microsoft Visual Studio 15.7 !!", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(result == DialogResult.OK)
            {
                this.Hide();
               // form4.Hide();                                           
            }           
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginForm form1 = new LoginForm();
                form1.Show();
            }            
        }

        //------------------------------------------------------------------
        //Open File: Menu Strip
        //------------------------------------------------------------------
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Text File Only";
            ofd.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";

            DialogResult dr = ofd.ShowDialog();
            if(dr==DialogResult.OK)
            {
                string filename = ofd.FileName;
                MessageBox.Show(ofd.FileName, "File Link");
                MessageBox.Show(ofd.SafeFileName, "File Name");
                StreamReader read1 = new StreamReader(File.OpenRead(ofd.FileName));
                richTextBox1.Text = read1.ReadToEnd();
                read1.Dispose();                
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------------------
        //Save : Menu Strip
        //---------------------------------------------------------------
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    StreamWriter write1 = new StreamWriter(File.Create(save.FileName));
                    write1.Write(richTextBox1.Text);
                    write1.Dispose();
                }
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    StreamWriter write1 = new StreamWriter(File.Create(save.FileName));
                    write1.Write(richTextBox1.Text);
                    write1.Dispose();
                }
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //------------------------------------------------------------------
        //Cut : Menu Strip
        //-----------------------------------------------------------------
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                if (richTextBox1.SelectedText != string.Empty)
                    Clipboard.SetText(richTextBox1.SelectedText);
                    richTextBox1.SelectedText = string.Empty;
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);           
        }
        //------------------------------------------------------------------------------
        //Copy: Menu Strip
        //-----------------------------------------------------------------------------
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                if (richTextBox1.SelectedText != string.Empty)
                    Clipboard.SetText(richTextBox1.SelectedText);
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        //--------------------------------------------------------------------------
        //Paste: Menu Strip
        //-------------------------------------------------------------------------
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                string copyString = Clipboard.GetText();
                richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, copyString);
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
        }

        //----------------------------------------------------------
        //This section converts Font to Bold: Menu Strip
        //----------------------------------------------------------
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }

        //---------------------------------------------------------------------------------
        //Font Type-font Family: Menu Strip
        //---------------------------------------------------------------------------------
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                if (richTextBox1.SelectedText != String.Empty)
                    try
                    {
                        richTextBox1.Font = new Font(toolStripComboBox1.Text, richTextBox1.Font.Size);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error occured", "Error");
                    }
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //--------------------------------------------------------------
        //This section Loads all Font family on comboBox1 of MenuStrip
        //--------------------------------------------------------------
        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(font.Name.ToString());
            }
        }

        //----------------------------------
        //This section changes the Font SIZE
        //----------------------------------
        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                try
                {
                    if (toolStripComboBox2.SelectedIndex > 0)
                    {
                        // MessageBox.Show(toolStripComboBox2.SelectedIndex.ToString());
                        //richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 36);
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, float.Parse(toolStripComboBox2.SelectedItem.ToString()));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occured", "Error");
                }
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);                     
        }



        //---------------------------------------
        //This section converts Font to Italics
        //---------------------------------------
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }



        //------------------------------------------------------
        //This section is to Underline to the Selected Font
        //------------------------------------------------------
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            //used to show username: Tool Strip Label
            string text = toolStripLabel2.Text;
            MessageBox.Show(text, "Login as Username: ");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {  }

        

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //----------------------------------------
        //Open File: Tool Strip
        //----------------------------------------
        private void openToolStripButton_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Open Text File Only";
                ofd.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";

                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string filename = ofd.FileName;
                    MessageBox.Show(ofd.FileName, "File Link");
                    MessageBox.Show(ofd.SafeFileName, "File Name");
                    StreamReader read1 = new StreamReader(File.OpenRead(ofd.FileName));
                    richTextBox1.Text = read1.ReadToEnd();
                    read1.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Error Occured !!", "Error");
            }

        }
        //----------------------------------------------------------
        //Save File: Tool Strip
        //----------------------------------------------------------
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter write1 = new StreamWriter(File.Create(save.FileName));
                    write1.Write(richTextBox1.Text);
                    write1.Dispose();
                }
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        //--------------------------------------------------------
        //Save As: Tool Strip
        //-------------------------------------------------------
        private void saveAsStripButton_Click(object sender, EventArgs e)
        {

            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    StreamWriter write1 = new StreamWriter(File.Create(save.FileName));
                    write1.Write(richTextBox1.Text);
                    write1.Dispose();
                }
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        //----------------------------------------------------------------------------
        //New File Created: Menu Item
        //----------------------------------------------------------------------------
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "/" + "new.rtf";
            if (!File.Exists(path))
            {
                File.CreateText(path);
                MessageBox.Show("New File created", "Information");
            }
            else
                MessageBox.Show("This file already exists. Please check", "Information");
        }
        //----------------------------------------------------------------------------------
        //New File: Tool Strip
        //-----------------------------------------------------------------------------------

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "/" + "new.rtf";
            if (!File.Exists(path))
            {
                File.CreateText(path);
                MessageBox.Show("New File created", "Information");
            }
            else
                MessageBox.Show("This file already exists. Please check", "Information");
        }

       

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------
        //Paste: Left Tool Strip
        //-------------------------------------------------------------------
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                string copyString = Clipboard.GetText();
                richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, copyString);
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //-------------------------------------------------------
        //Cut File: Left Tool Strip
        //-------------------------------------------------------
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                if (richTextBox1.SelectedText != string.Empty)
                    Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = string.Empty;
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //---------------------------------------------------------------------------
        //Copy: Left Tool Strip
        //---------------------------------------------------------------------------
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string text = toolStripLabel2.Text;
            bool isAllowedToEdit = userType.IsAllowedToEdit(text);
            if (isAllowedToEdit == true)
            {
                if (richTextBox1.SelectedText != string.Empty)
                    Clipboard.SetText(richTextBox1.SelectedText);
            }
            else
                MessageBox.Show("You are not Allowed to Edit", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Menu Item
        }
    }
}
