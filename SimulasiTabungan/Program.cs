using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimulasiTabungan
{
    static class Program
    {
        static public List<Pengguna> LsPengguna = new List<Pengguna>();
        static public List<Tabungan> LsTabungan = new List<Tabungan>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FTabungan());
        }

        static public int Login(string IdPengguna, string password)
        {
            int inx = cariID(IdPengguna);
            if (!LsPengguna[inx].ValPass(password))
            {
                throw new ArgumentException("Password Salah");
            }
            return inx;
        }

        static public void Dartar(Pengguna pengguna)
        {
            if (LsPengguna.Count != 0)
            {
                //cari
                int i = 0;
                Boolean ketemu = false;
                while ((i < LsPengguna.Count) && !ketemu)
                {
                    if (pengguna.IdPengguna == LsPengguna[i].IdPengguna)
                        ketemu = true;
                    else
                        i++;
                }

                if (ketemu)
                    throw new ArgumentException("Username telah digunakan");
                else
                {
                    LsPengguna.Add(pengguna);
                    LsTabungan.Add(new Tabungan(pengguna.IdPengguna));
                }
            }
            else
            {
                LsPengguna.Add(pengguna);
                LsTabungan.Add(new Tabungan(pengguna.IdPengguna));
            }
        }

        public static int cariID(string IdPengguna)
        {

            if (LsPengguna.Count != 0)
            {

                int i = 0;
                Boolean ketemu = false;
                while ((i < LsPengguna.Count) && !ketemu)
                {
                    if (IdPengguna == LsPengguna[i].IdPengguna)
                        ketemu = true;
                    else
                        i++;
                }

                if (!ketemu)
                    throw new Exception("IdUser ini tidak di temukan");


                return i;
            }
            else
            {
                throw new Exception("Belum ada member");
            }
        }
    }
}
