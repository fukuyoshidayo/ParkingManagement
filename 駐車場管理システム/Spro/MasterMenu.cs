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
    public partial class MasterMenu : BsForm
    {
        public MasterMenu()
        {
            InitializeComponent();
        }

        private void bt_ParkingMaster_Click(object sender, EventArgs e)
        {
            OpenForm(new ParkingMaster());
        }

        private void bt_SectionMaster_Click(object sender, EventArgs e)
        {
            OpenForm(new SectionMaster());
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_ClientMaster_Click(object sender, EventArgs e)
        {
            OpenForm(new SearchClient((int)Util.EditType.Client, 0, 0));
        }
    }
}
