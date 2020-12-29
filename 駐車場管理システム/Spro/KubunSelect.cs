using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using ssk;

namespace Spro
{
    public partial class KubunSelect : ComboBox
    {
        public AutoScaleMode AutoScaleMode = AutoScaleMode.Font;
        
        /// <summary>
        /// Itemsに使用するテーブル名
        /// </summary>
        private string _tablename = string.Empty;
        public string TableName 
        {
            get 
            { 
                return _tablename; 
            }
            set 
            {
                _tablename = value;
                if (value != string.Empty)
                {
                    SetItems();
                }
            }
        }

        /// <summary>
        /// コードの項目名
        /// </summary>
        private string _code = string.Empty;
        public string Code 
        {
            get 
            { 
                return _code; 
            }
            set
            {
                _code = value;
                if (value != string.Empty)
                {
                    SetItems();
                }
            }
        }

        /// <summary>
        /// 表示する項目名
        /// </summary>
        private string _disp = string.Empty;
        public string Disp 
        {
            get 
            { 
                return _disp; 
            }

            set
            {
                _disp = value;
                if (value != string.Empty)
                {
                    SetItems();
                }
            }
        }

        public BindingList<KeyValuePair<string,int>> m_items = new BindingList<KeyValuePair<string,int>>();


        public KubunSelect()
        {
            InitializeComponent();
            SetItems();
        }
    }
}
