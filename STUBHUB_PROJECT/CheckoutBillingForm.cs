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
    public partial class CheckoutBillingForm : Form
    {
        public string cardName;
        public string cardNumber;
        public string ExpiryDate;
        public string securityCode;
        public CheckoutBillingForm()
        {
            InitializeComponent();
        }

        private void CheckoutBillingForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnContinueCheckout_Click(object sender, EventArgs e)
        {
            if (textBoxCardName.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter your Name on Card"); return;
            }

            if (textBoxCardNumber.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter your Card Number"); return;
            }

            if (textBoxExpiryDate.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter your Expiry Date"); return;
            }

            if (textBoxSecurityCode.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter your Security Code"); return;
            }

            cardName = textBoxCardName.Text;
            cardNumber = textBoxCardNumber.Text;
            ExpiryDate = textBoxExpiryDate.Text;
            securityCode = textBoxSecurityCode.Text;
            MessageBox.Show("Result: OK");
            this.DialogResult = DialogResult.OK;
        }
    }
}
