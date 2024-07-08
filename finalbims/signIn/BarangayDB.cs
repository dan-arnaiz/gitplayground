using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace BIMS_dan
{
    internal class BarangayDB
    {
        private string connectionString = @"Server=localhost;Database=dan-bims;Integrated Security=True;"; // Update with your actual connection string

        public void AddNewBarangay(string barangayName, string address, string description, byte[] BarangayLogo)
        {
            using (SqlConnection conn = new SqlConnection("connectionString"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("YourStoredProcName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add other parameters as needed
                    cmd.Parameters.AddWithValue("@BarangayName", barangayName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Description", description);

                    // Correctly specify the parameter for the BarangayLogo
                    if (BarangayLogo != null)
                    {
                        cmd.Parameters.Add("@BarangayLogo", SqlDbType.VarBinary, -1).Value = BarangayLogo;
                    }
                    else
                    {
                        cmd.Parameters.Add("@BarangayLogo", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public byte[] ImageToByteArray(PictureBox pictureBox)
        {
            using (var ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
