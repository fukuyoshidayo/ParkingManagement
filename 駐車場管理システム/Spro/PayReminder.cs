﻿using System;
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
    public partial class PayReminder : BsForm
    {
        public PayReminder()
        {
            InitializeComponent();
        }

        private void PayReminder_Load(object sender, EventArgs e)
        {
            disp();
        }


        private void Header()
        {
            dgv_PayReminderList.Rows.Clear();
            dgv_PayReminderList.Columns.Clear();

            DataGridViewTextBoxColumn col;


            col = new DataGridViewTextBoxColumn();
            col.Name = "契約ID";
            col.Width = 60;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PayReminderList.Columns.Add(col);


            col = new DataGridViewTextBoxColumn();
            col.Name = "顧客名";
            col.Width = 100;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PayReminderList.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "駐車場";
            col.Width = 150;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PayReminderList.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "不足額";
            col.Width = 60;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PayReminderList.Columns.Add(col);


        }


        private void disp()
        {
            Header();

            int year = (int)dateCmb_TargetMonth.cmbYear.SelectedValue;
            int month = (int)dateCmb_TargetMonth.cmbMonth.SelectedValue;

            Util.PayDiff(dgv_PayReminderList, year, month, (int)Util.Remode.Reminder);
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }


        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            disp();
        }

    }
}
