using System.Diagnostics;
using System.Windows.Forms;

namespace RunProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            ProcessStart();
        }

        private void ProcessStart()
        {
            try
            {

                if (textBox1.Text != "")
                {
                    Process.Start(textBox1.Text);
                }

            }
            catch (System.Exception)
            {
                try
                {
                    GetInstalledApps gia = new GetInstalledApps();
                    gia.GetInstalledAppPathAndRunProgram2(textBox1.Text);


                }
                catch
                {
                    MessageBox.Show("The Name is Wrong!");
                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                ProcessStart();
            }
        }






    }
}
