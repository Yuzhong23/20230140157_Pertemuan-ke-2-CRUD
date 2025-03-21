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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Validasi input tidak boleh kosong
                    if (txtNIM.Text == "" || txtNama.Text == "" || txtEmail.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "")
                    {
                        MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open(); // Membuka koneksi database
                    string query = "INSERT INTO Mahasiswa (NIM, Nama, Email, Telepon, Alamat) VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Menambahkan parameter untuk menghindari SQL Injection
                        cmd.Parameters.AddWithValue("@NIM", txtNIM.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery(); // Eksekusi perintah SQL
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Memuat ulang data setelah menambahkan
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil ditambahkan", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void BtnTambah_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Validasi input tidak boleh kosong
                    if (txtNIM.Text == "" || txtNama.Text == "" || txtEmail.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "")
                    {
                        MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open(); // Membuka koneksi database
                    string query = "INSERT INTO Mahasiswa (NIM, Nama, Email, Telepon, Alamat) VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Menambahkan parameter untuk menghindari SQL Injection
                        cmd.Parameters.AddWithValue("@NIM", txtNIM.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery(); // Eksekusi perintah SQL
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Memuat ulang data setelah menambahkan
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil ditambahkan", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {

            if (dgvMahasiswa.SelectedRows.Count > 0) // Mengecek apakah ada data yang dipilih
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string nim = dgvMahasiswa.SelectedRows[0].Cells["NIM"].Value.ToString();
                            conn.Open(); // Membuka koneksi database
                            string query = "DELETE FROM Mahasiswa WHERE NIM = @NIM";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@NIM", nim);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData(); // Memuat ulang data setelah penghapusan
                                    ClearForm();
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak berhasil dihapus", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void BtnRefresh_Click(object sender, EventArgs e)
        {

            LoadData(); // Memuat ulang data saat tombol refresh ditekan
            MessageBox.Show($"Jumlah Kolom : {dgvMahasiswa.ColumnCount}\nJumlah Baris: {dgvMahasiswa.RowCount}",
                "Debugging DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Mengecek apakah baris yang diklik valid
            {
                DataGridViewRow row = dgvMahasiswa.Rows[e.RowIndex];

                // Mengisi form dengan data dari baris yang dipilih
                txtNIM.Text = row.Cells[0].Value.ToString();
                txtNama.Text = row.Cells[1].Value.ToString();
                txtEmail.Text = row.Cells[2].Value.ToString();
                txtTelepon.Text = row.Cells[3].Value.ToString();
                txtAlamat.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
