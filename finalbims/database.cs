using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BIMS_dan
{
    public class Database
    {
        public readonly string connectionString;

        public Database()
        {
            connectionString = @"Server=localhost;Database=dan-bims;Integrated Security=True;";
        }

        public async Task RefreshResidentsTableAsync(DataGridView residentsTable)
        {
            string query = @"SELECT picture, lastName, firstName, middleName, birthdate, sex, civilStatus, address, yearsResiding, occupation FROM residentsTable";

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
                    residentsTable.DataSource = dataTable;
                }
            }
        }

        public async Task AddResident(byte[] pictureData, string lastName, string firstName, string middleName, DateTime birthdate, string sex, string civilStatus, string address, int yearsResiding, string occupation)
        {
            string query = @"INSERT INTO residentsTable (picture, lastName, firstName, middleName, birthdate, sex, civilStatus, address, yearsResiding, occupation) 
                         VALUES (@picture, @lastName, @firstName, @middleName, @birthdate, @sex, @civilStatus, @address, @yearsResiding, @occupation)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@picture", SqlDbType.Image).Value = pictureData;
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                    cmd.Parameters.AddWithValue("@birthdate", birthdate);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@civilStatus", civilStatus);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@yearsResiding", yearsResiding);
                    cmd.Parameters.AddWithValue("@occupation", occupation);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<bool> DeleteResidentAsync(string id)
        {
            string query = "DELETE FROM residentsTable WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        } 
    }
}
