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
    public partial class AgreemenMenut : BsForm
    {
        public AgreemenMenut()
        {
            InitializeComponent();
        }

        private void AgreeEdit_Load(object sender, EventArgs e)
        {

        }

        private void bt_ToParking_Click(object sender, EventArgs e)
        {
            OpenForm(new AgreeToParking());
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void btn_ToClient_Click(object sender, EventArgs e)
        {
            OpenForm(new AgreeToClient());
        }
    }
}
