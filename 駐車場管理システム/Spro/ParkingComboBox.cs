using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ssk;

namespace Spro
{
    public partial class ParkingComboBox : UserControl
    {
        public ParkingComboBox()
        {
            InitializeComponent();
        }

        private void ParkingComboBox_Load(object sender, EventArgs e)
        {
            Util.SetParkingComboBox(cmb_ParkngList);
        }
    }
}
