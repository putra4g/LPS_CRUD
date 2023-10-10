using MySql.Data.MySqlClient;
using System.Data;

namespace LPS_CRUD.Models
{
	public class ProdukDataAccessLayer
	{
        string connectionString = "Server=localhost;Port=3306;Database=lps;Uid=root;Pwd=P@ssw0rdSam10;";
        //To View all Produk details    
        public IEnumerable<Produk> GetAllProduk()
        {
            List<Produk> lstProduk = new List<Produk>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("usp_getall_produk", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Produk Produk = new Produk();

                    Produk.id = Convert.ToInt32(rdr["id"]);
                    Produk.nama_barang = rdr["nama_barang"].ToString();
                    Produk.kode_barang = rdr["kode_barang"].ToString();
                    Produk.jumlah_barang = Convert.ToInt32(rdr["jumlah_barang"]);
                    Produk.tanggal = Convert.ToDateTime(rdr["tanggal"]);

                    lstProduk.Add(Produk);
                }
                con.Close();
            }
            return lstProduk;
        }

        //To Add new Produk record    
        public void AddProduk(Produk produk)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("usp_insert_produk", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_nama_barang", produk.nama_barang);
                cmd.Parameters.AddWithValue("@p_kode_barang", produk.kode_barang);
                cmd.Parameters.AddWithValue("@p_jumlah_barang", produk.jumlah_barang);
                cmd.Parameters.AddWithValue("@p_tanggal", produk.tanggal);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar Produk  
        public void UpdateProduk(Produk Produk)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("usp_update_produk", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_id", Produk.id);
                cmd.Parameters.AddWithValue("@p_nama_barang", Produk.nama_barang);
                cmd.Parameters.AddWithValue("@p_kode_barang", Produk.kode_barang);
                cmd.Parameters.AddWithValue("@p_jumlah_barang", Produk.jumlah_barang);
                cmd.Parameters.AddWithValue("@p_tanggal", Produk.tanggal);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular Produk  
        public Produk GetProdukData(int? id)
        {
            Produk produk = new Produk();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {

                MySqlCommand cmd = new MySqlCommand("usp_get_produk_byid", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_id", id);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    produk.id = Convert.ToInt32(rdr["id"]);
                    produk.nama_barang = rdr["nama_barang"].ToString();
                    produk.kode_barang = rdr["kode_barang"].ToString();
                    produk.jumlah_barang = Convert.ToInt32(rdr["jumlah_barang"]);
                    produk.tanggal = Convert.ToDateTime(rdr["tanggal"].ToString());
                }
            }
            return produk;
        }

        //To Delete the record on a particular Produk  
        public void DeleteProduk(int? id)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("usp_delete_produk", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
