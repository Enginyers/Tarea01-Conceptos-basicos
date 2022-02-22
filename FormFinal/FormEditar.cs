using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFinal
{
    public partial class FormEditar : Form
    {
        private int? Id;
        public FormEditar(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void FormEditar_Load(object sender, EventArgs e)
        {
            Conexion oconn = new Conexion();

            Datos odatos = oconn.Get((int)Id);
            textNum.Text = odatos.num_producto.ToString();
            textPedido.Text = odatos.pedido.ToString();
            textNombre.Text = odatos.Nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion oconn = new Conexion();
            oconn.Editar(int.Parse(textNum.Text), int.Parse(textPedido.Text), textNombre.Text,(int)Id);
            this.Close();
        }
    }
}
