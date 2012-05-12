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
    public partial class FTabungan : Form
    {
        private FLogin fLogin = new FLogin();
        private int inx;

        public FTabungan()
        {
            InitializeComponent();

        }

        private void FTabungan_Load(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            fLogin.ShowDialog();
            if (fLogin.DialogResult != DialogResult.OK)
                Application.Exit();
            else
            {
                inx = fLogin.inx;
                CetakInfo();
                this.Text = "Tabungan - " + Program.LsPengguna[inx].Nama;
            }
        }

        private void CetakInfo()
        {
            lUsername.Text = Program.LsPengguna[inx].IdPengguna;
            lAlamat.Text = Program.LsPengguna[inx].Alamat;
            lNama.Text = Program.LsPengguna[inx].Nama;
            lSaldo.Text = "Rp. " + Convert.ToString(Program.LsTabungan[inx].saldo) + ",-";
            listBox_History.Items.Clear();
            for (int i = Program.LsTabungan[inx].PnjHistory(); i >= 0; i--)
            {
                listBox_History.Items.Add(Program.LsTabungan[inx].Lshistory(i));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void Tabung_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin?", "Tabung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.LsTabungan[inx].Simpan(Convert.ToInt32(NominalTab.Value), "Tabung");
                CetakInfo();
            }
        }

        private void Ambil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin?", "Ambil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Program.LsTabungan[inx].Ambil(Convert.ToInt32(NominalAm.Value), "Ambil");
                    CetakInfo();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Transfer_Click(object sender, EventArgs e)
        {

            int inxT;
            if (MessageBox.Show("Anda yakin?", "Ambil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    inxT = Program.cariID(Untuk.Text);
                    Program.LsTabungan[inx].Ambil(Convert.ToInt32(NominalTrans.Value), "untuk " + Untuk.Text);
                    Program.LsTabungan[inxT].Simpan(Convert.ToInt32(NominalTrans.Value), "dari " + Program.LsTabungan[inx].IdPengguna);
                    CetakInfo();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void daftarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDaftar Fdaftar = new FDaftar();
            Fdaftar.ShowDialog();
        }


    }
}
