using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudPractice
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            PersonaDB oPersonaDB = new PersonaDB();
            dataGridView1.DataSource = oPersonaDB.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 oForm = new Form2();
            oForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if(Id != null)
            {
                Form2 oForm2 = new Form2(Id);
                oForm2.ShowDialog();   
                Refresh();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
            int? Id = GetId();
            try
            {
                if (Id != null)
                {
                    PersonaDB oPersonaDB = new PersonaDB();
                    oPersonaDB.Delete((int)Id);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar: " +ex.Message);
            }
            
        }
        #region HELPER
        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}