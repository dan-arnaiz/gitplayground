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


    public async Task RefreshBarangaysTableAsync(DataGridView barangaysDatatable)
    {
        string query = @"SELECT BarangayID, BarangayLogo, BarangayName, Address, Description FROM Barangays";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                DataTable dataTable = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
                barangaysDatatable.DataSource = dataTable;
            }
        }
    }
    public async Task AddNewBarangay(byte[] BarangayLogo, string barangayName, string address, string description)
    {
        string query = @"INSERT INTO Barangays (BarangayLogo, BarangayName, Address, Description)
                 VALUES (@BarangayLogo, @BarangayName, @Address, @Description)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@BarangayLogo", SqlDbType.Image).Value = BarangayLogo;
                cmd.Parameters.AddWithValue("@BarangayName", barangayName);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Description", description);

                await cmd.ExecuteNonQueryAsync();
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

    public async Task<bool> DeleteBarangayAsync(string BarangayID)
    {
        string query = "DELETE FROM Barangays WHERE BarangayID = @BarangayID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BarangayID", BarangayID);

                int result = await cmd.ExecuteNonQueryAsync();
                return result > 0;
            }
        }
    }
    public async Task<bool> UpdateBarangayAsync(string BarangayID, byte[] BarangayLogo, string barangayName, string address, string description)
    {
        string query = @"UPDATE Barangays
                     SET BarangayLogo = @BarangayLogo, BarangayName = @BarangayName, Address = @Address, Description = @Description 
                     WHERE BarangayID = @BarangayID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@BarangayLogo", SqlDbType.Image).Value = BarangayLogo ?? (object)DBNull.Value; // Handle null images
                cmd.Parameters.AddWithValue("@BarangayName", barangayName);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@BarangayID", BarangayID);

                int result = await cmd.ExecuteNonQueryAsync();
                return result > 0; // Returns true if the update was successful, false otherwise
            }
        }
    }






}
}
