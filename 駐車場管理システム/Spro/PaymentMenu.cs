using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ssk;

namespace Spro
{
    public partial class PaymentMenu : BsForm
    {
        public PaymentMenu()
        {
            InitializeComponent();
        }

        private void bt_PayRegist_Click(object sender, EventArgs e)
        {
            OpenForm(new Payment());
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_Refund_Click(object sender, EventArgs e)
        {
            OpenForm(new PayRefund());
        }

        private void bt_Reminder_Click(object sender, EventArgs e)
        {
            OpenForm(new PayReminder());
        }

        private void bt_PaymentList_Click(object sender, EventArgs e)
        {
            OpenForm(new PaymentList());
        }

        private void bt_Koufuri_Click(object sender, EventArgs e)
        {
            OpenForm(new TransferAccount());
        }

        private void bt_Furikomi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("まだ作ってません");
        }
    }
}
