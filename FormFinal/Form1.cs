using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            Conexion oconn = new Conexion();
            dataGridView1.DataSource = oconn.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar
            FormAgregar agregar = new FormAgregar();
            agregar.ShowDialog();
            cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Editar
            int? id = GetId();
            FormEditar editar = new FormEditar(id);
            editar.ShowDialog();
            cargar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Eliminar
            Conexion oconn = new Conexion();
            int? id = GetId();
            oconn.Eliminar((int)id);
            cargar();

        }

       




        //obtener el id de la celda seleccionada
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

       
    }

}
