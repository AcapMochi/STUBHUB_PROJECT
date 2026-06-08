using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUBHUB_PROJECT
{
    public partial class MainMenu : Form
    {
        LoginForm form = null;
        int X = 239;
        int Y = 245;
        public MainMenu(LoginForm lf)
        {
            InitializeComponent();
            form = lf;
        }

        private void ChooseEventButton_Click(object sender, EventArgs e)
        {
            Button buttonClone = new Button();
            buttonClone.Parent = this;
            buttonClone.Size = ChooseEventButton.Size;
            buttonClone.Location = new Point(X, Y);

            //Y += 40;
            //buttonClone.Visible = !buttonClone.Visible;s
        }
    }
}
