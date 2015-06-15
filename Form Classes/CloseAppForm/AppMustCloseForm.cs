using System;
using System.Windows.Forms;

namespace CSGO_Theme_Control.Form_Classes.CloseAppForm
{
    public partial class AppMustCloseForm : Form
    {
        public AppMustCloseForm(string DisplayMessage)
        {
            InitializeComponent();

            txtDisplay.Text = DisplayMessage;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
