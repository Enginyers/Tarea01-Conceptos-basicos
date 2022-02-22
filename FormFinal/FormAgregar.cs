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
    public partial class FormAgregar : Form
    {
        public FormAgregar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion oconn = new Conexion();
            oconn.Agregar(int.Parse(textNum.Text),int.Parse(textPedido.Text),textNombre.Text);
            this.Close();

        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {

        }
    }
}
