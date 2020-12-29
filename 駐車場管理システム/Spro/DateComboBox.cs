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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace Spro
{
    public partial class DateComboBox : UserControl
    {
        public event EventHandler SelectedChange;

        public ComboBox cmbYear
        {
            get
            {
                return cmb_Year;
            }
            set
            {
                cmb_Year.SelectedValue = value.SelectedValue;
            }
        }
        public ComboBox cmbMonth
        {
            get
            {
                return cmb_Month;
            }
            set
            {
                cmb_Month.SelectedValue = value.SelectedIndex;
            }

        }
        public ComboBox cmbDay
        {
            get
            {
                return cmb_Day;
            }
            set
            {
                cmb_Day.SelectedValue = value.SelectedValue;
            }

        }



        public DateComboBox()
        {
            InitializeComponent();
        }

        private void DateComboBox_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            List<ItemSet> srcYear = new List<ItemSet>();
            List<ItemSet> srcMonth = new List<ItemSet>();
            List<ItemSet> srcDay = new List<ItemSet>();

            for (int i = -2; i < 3; i++)
            {
                string aa = (year + i).ToString();
                srcYear.Add(new ItemSet(year + i, aa));
            }
            this.cmb_Year.DataSource = srcYear;
            this.cmb_Year.DisplayMember = "ItemDisp";
            this.cmb_Year.ValueMember = "ItemValue";
            this.cmb_Year.SelectedValue = year;

            for (int i = 1; i < 13; i++)
            {
                string aa = String.Format("{0:00}", i);
                srcMonth.Add(new ItemSet(i, aa));
            }
            this.cmb_Month.DataSource = srcMonth;
            this.cmb_Month.DisplayMember = "ItemDisp";
            this.cmb_Month.ValueMember = "ItemValue";
            this.cmb_Month.SelectedValue = month;

            srcDay.Add(new ItemSet(1, "01"));
            srcDay.Add(new ItemSet(16, "16"));

            this.cmb_Day.DataSource = srcDay;
            this.cmb_Day.DisplayMember = "ItemDisp";
            this.cmb_Day.ValueMember = "ItemValue";
            this.cmb_Day.SelectedValue = 1;

        }


        public class ItemSet
        {
            // DisplayMemberとValueMemberにはプロパティで指定する仕組み
            public String ItemDisp { get; set; }
            public int ItemValue { get; set; }

            // プロパティをコンストラクタでセット
            public ItemSet(int v, String s)
            {
                ItemDisp = s;
                ItemValue = v;
            }
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = 0;
            if (cmb_Year.SelectedValue != null && cmb_Month.SelectedValue != null && cmb_Day.SelectedValue != null)
            {
                if (int.TryParse(cmb_Year.SelectedValue.ToString(), out a) && int.TryParse(cmb_Month.SelectedValue.ToString(), out a) && int.TryParse(cmb_Day.SelectedValue.ToString(), out a))
                {
                    if (this.SelectedChange != null)
                        this.SelectedChange(this, e);
                }
            }
        }

        private void cmb_Day_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //public ParkingManageMenu()
        //{
        //    InitializeComponent();
        //    DateComboBox1.SelectedChange += cmb_SelectedIndexChanged;
        //}


        //private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //int aa = (int)DateComboBox1.cmbYear.SelectedValue;
        //if (aa == 2021)
        //{
        //    label1.Text = "aaaaaaaa";
        //}
        //else
        //{
        //    label1.Text = "bbbbbb";
        //}

        //}




    }
}
