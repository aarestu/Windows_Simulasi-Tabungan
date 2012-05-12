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
    public partial class FDaftar : Form
    {
        Pengguna P = new Pengguna();

        public FDaftar()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void daftar2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Anda yakin", "Daftar", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                try
                {
                    P.IdPengguna = UserName.Text;
                    P.pass = Password.Text;
                    P.Nama = Nama.Text;
                    P.Alamat = Alamat.Text;

                    Program.Dartar(P);
                    this.DialogResult = DialogResult.OK;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
