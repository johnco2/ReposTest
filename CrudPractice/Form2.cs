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
    public partial class Form2 : Form
    {
        private int? Id;
        public Form2(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if(this.Id != null)
                LoadData();
        }

        private void LoadData()
        {
            PersonaDB oPersonaDB = new PersonaDB();
            Persona oPersona = oPersonaDB.Get((int)Id);

            txtNombre.Text = oPersona.Nombre;
            txtEdad.Text = oPersona.Edad.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonaDB oPersonaDB = new PersonaDB();
            try
            {
                if(Id==null)
                    oPersonaDB.Add(txtNombre.Text, int.Parse(txtEdad.Text));
                else
                    oPersonaDB.Update(txtNombre.Text, int.Parse(txtEdad.Text), (int)Id);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
