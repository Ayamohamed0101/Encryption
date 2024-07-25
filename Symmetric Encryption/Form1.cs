using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symmetric_Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtOriginal.Multiline = true;  // Enable multiline
            txtOriginal.ScrollBars = ScrollBars.Vertical;  // Add vertical scroll bars
            txtOriginal.WordWrap = true;  // Enable word wrap
                                          ///
            
            txtEncrypted.Multiline = true;  // Enable multiline
            txtEncrypted.ScrollBars = ScrollBars.Vertical;  // Add vertical scroll bars
            txtEncrypted.WordWrap = true;  // Enable word wrap


        }
        public  void RadioButtonEnteredKey()
        {

        }
        private void txtOriginal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOriginal_Validating(object sender, CancelEventArgs e)
        {
            if (txtOriginal.Text==string.Empty)
            {
                errorProvider1 = new ErrorProvider();
                MessageBox.Show("Empty container ,enter text ??");

            }

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            // Create a new instance of the OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index
            openFileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box
            DialogResult result = openFileDialog.ShowDialog();

            // Process input if the user clicked OK
            if (result == DialogResult.OK)
            {
                // Open the selected file to read
                string filePath = openFileDialog.FileName;
                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    MessageBox.Show(fileContent, "File Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOriginal.Text=fileContent;
                }
                catch (IOException)
                {
                    MessageBox.Show("Error reading file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //switch
            if (guna2RadioButton1.Checked)
            {
                
                txtEncrypted.Text = clsEncryptionText.Encrypt(txtOriginal.Text, "1234567890123456");
                txtOriginal.Text = "";

            }
            else if (guna2RadioButton2.Checked)
            {

                txtEncrypted.Text = clsEncryptionText.Encrypt(txtOriginal.Text, "12345678901234561234567890123456");
                txtOriginal.Text = "";
            }
            else
            {
                txtEncrypted.Text = clsEncryptionText.Encrypt(txtOriginal.Text, "1234567890123456123456789012345612345678901234561234567890123456");
                txtOriginal.Text = "";
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked)
            {

                txtOriginal.Text = clsEncryptionText.Decrypt(txtEncrypted.Text, "1234567890123456");

            }
            else if (guna2RadioButton2.Checked)
            {

                txtOriginal.Text = clsEncryptionText.Decrypt(txtEncrypted.Text, "12345678901234561234567890123456");
            }
            else
            {
                txtOriginal.Text = clsEncryptionText.Decrypt(txtEncrypted.Text, "1234567890123456123456789012345612345678901234561234567890123456");
            }

        }
    }


    
}
