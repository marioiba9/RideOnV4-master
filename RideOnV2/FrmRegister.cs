using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RideOnV2
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            string register = Program.gestor.registrarse(txtNombre.Text, txtMail.Text, txtTlf.Text, txtContra.Text, txtCuenta.Text, out bool errores);

            if (errores)
            {
                MessageBox.Show(register);
            }
            else
            {
                MessageBox.Show(register);
                FrmInicio frm = new FrmInicio();
                Close();

                frm.Show();
            }
        }
    }
}
