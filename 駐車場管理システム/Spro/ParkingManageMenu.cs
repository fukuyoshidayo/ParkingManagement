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
    public partial class ParkingManageMenu : BsForm
    {
        public ParkingManageMenu()
        {
            InitializeComponent();
        }

        private void ParkingManageMenu_Load(object sender, EventArgs e)
        {
            DateTime dTime1 = new DateTime(2020, 1, 1);
            DateTime dTime2 = new DateTime(2021, 1, 1);
            int i = Util.MonthDiff(dTime1, dTime2);

        }

        private void bt_Master_Click(object sender, EventArgs e)
        {
            OpenForm(new MasterMenu());
        }

        private void bt_Agreement_Click(object sender, EventArgs e)
        {
            OpenForm(new AgreemenMenut());
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_Payment_Click(object sender, EventArgs e)
        {
            OpenForm(new PaymentMenu());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
