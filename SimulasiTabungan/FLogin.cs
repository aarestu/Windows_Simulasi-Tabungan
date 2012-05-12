using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimulasiTabungan
{
    public partial class FLogin : Form
    {
        public int inx;

        public FLogin()
        {
            InitializeComponent();
        }

        private void Daftar_Click(object sender, EventArgs e)
        {
            FDaftar Fdaftar = new FDaftar();
            Fdaftar.ShowDialog();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                inx = Program.Login(UserName.Text, Password.Text);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}
