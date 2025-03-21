using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan_ke_2
{
    public partial class Form1 : Form
    {
        // String koneksi ke database SQL Server
        private string connectionString = "Data Source=FATHUR\\YUZHONG;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";

        // Konstruktor Form1
        public Form1()
        {
            InitializeComponent(); // Inisialisasi komponen Form
        }

        // Event handler saat form pertama kali dimuat
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Memuat data mahasiswa ke DataGridView
        }


        private void ClearForm()
        {
            txtNIM.Clear();
            txtNama.Clear();
            txtEmail.Clear();
            txtTelepon.Clear();
            txtAlamat.Clear();
            txtNIM.Focus(); // Mengembalikan fokus ke input NIM
        }


        private void LoadData()
        {

        }


        private void BtnTambah_Click(object sender, EventArgs e)
        {

        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {

        }


        private void BtnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void dgvMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
