using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.BusinessLogicsContracts;
using Unity;


namespace AbstractShipyardView
{
    public partial class FormProducts : Form
    {
        private readonly IProductLogic _logic;
        
        public FormProducts(IProductLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormTravels_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                if (list != null)
                {
                    dataGridViewTravels.DataSource = list;
                    dataGridViewTravels.Columns[0].Visible = false;
                    dataGridViewTravels.Columns[3].Visible = false;
                    dataGridViewTravels.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormProduct>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTravels.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormProduct>();
                form.Id = Convert.ToInt32(dataGridViewTravels.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTravels.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewTravels.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logic.Delete(new ProductBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
