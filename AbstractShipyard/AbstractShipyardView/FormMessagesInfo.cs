using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShipyardContracts.BusinessLogicsContracts;

namespace AbstractShipyardView
{
    public partial class FormMessagesInfo : Form
    {
        private readonly IMessageInfoLogic _logic;
        public FormMessagesInfo(IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            var list = _logic.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
