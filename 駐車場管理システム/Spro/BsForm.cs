using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ssk
{
    public partial class BsForm : Form
    {
        

        public bool ShowReturn
        {
            get
            {
                return bt_return.Visible;
            }
            set
            {
                bt_return.Visible = value;
            }
        }
        
        public BsForm()
        {
            InitializeComponent();
            bt_return.Visible = ShowReturn;
        }
        protected BsForm _parent;
        protected string _code;
        protected BsForm _child = null;


        [System.Security.Permissions.SecurityPermission(
           System.Security.Permissions.SecurityAction.LinkDemand,
           Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                return;
            }

            base.WndProc(ref m);
        }

        public void OpenForm(BsForm child)
        {
            OpenForm(child, false);
        }

        public void OpenForm(BsForm child, bool parent_visible)
        {
            if (_child == null)
            {
                _child = child;
                child._parent = this;
                child._parent.Visible = parent_visible;
                if (parent_visible)
                {
                    child.ShowDialog();
                }
                else
                {
                    child.Visible = true;
                }
            }
        }

        public void Bye()
        {
            if (_child == null)
            {
                if (_parent != null)
                {
                    if (_parent.Visible)
                    {
                        _parent.Visible = false;
                    }
                    _parent._child = null;
                    _parent.Visible = true;
                    Application.DoEvents();
                }
                Close();
            }
        }

        private void parent_close(BsForm p)
        {
            if (p._parent != null) parent_close(p._parent);
            p.Close();
        }

        public void mes(string s)
        {
            statusLabel.Text = s;
            Application.DoEvents();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!e.Control)
                {
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void BsForm_Load(object sender, EventArgs e)
        {
            bt_return.Visible = ShowReturn;
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }
    }
}
