using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Database
{
    private readonly string connectionString;

    public Database()
    {
        connectionString = @"Server=localhost;Database=dan-ims;Integrated Security=True;";
    }

    public DataTable GetAllComputerParts()
    {
        DataTable dataTable = new DataTable();
        string query = "SELECT ID, Name, Brand, Category, Price, Quantity, Supplier, Description FROM computerparts";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }

    public async Task<DataTable> GetAllComputerPartsAsync()
    {
        DataTable dataTable = new DataTable();
        string query = "SELECT ID, Name, Brand, Category, Price, Quantity, Supplier, Description FROM computerparts";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                await conn.OpenAsync();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }

    public bool AddComputerPart(string name, string brand, string category, decimal price, int quantity, string supplier, string description)
    {
        string query = "INSERT INTO computerparts (Name, Brand, Category, Price, Quantity, Supplier, Description) VALUES (@Name, @Brand, @Category, @Price, @Quantity, @Supplier, @Description)";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Brand", brand);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Supplier", supplier);
                    cmd.Parameters.AddWithValue("@Description", description);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }
        catch (SqlException ex)
        {
            // Log exception or notify the user
            return false;
        }
    }

    public async Task<bool> AddComputerPartAsync(string id, string name, string brand, string category, decimal price, int quantity, string supplier, string description)
    {
        string query = "INSERT INTO computerparts (ID, Name, Brand, Category, Price, Quantity, Supplier, Description) VALUES (@ID, @Name, @Brand, @Category, @Price, @Quantity, @Supplier, @Description)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Supplier", supplier);
                cmd.Parameters.AddWithValue("@Description", description);

                await conn.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();

                return result > 0;
            }
        }
    }

    public async Task<bool> DeleteComputerPartAsync(int id)
    {
        string query = "DELETE FROM computerparts WHERE ID = @ID";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
        }
        catch (SqlException ex)
        {
            // Log exception or notify the user
            return false;
        }
    }


    public async Task<bool> UpdateComputerPartAsync(int itemId, string name, string brand, string category, decimal price, int quantity, string supplier, string description)
    {
        string query = "UPDATE computerparts SET Name = @Name, Brand = @Brand, Category = @Category, Price = @Price, Quantity = @Quantity, Supplier = @Supplier, Description = @Description WHERE ID = @ID";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", itemId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Brand", brand);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Supplier", supplier);
                    cmd.Parameters.AddWithValue("@Description", description);

                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
        }
        catch (SqlException ex)
        {
            // Log exception or notify the user
            return false;
        }
    }

    public async Task<DataTable> SearchComputerPartsAsync(string searchText)
    {
        DataTable dataTable = new DataTable();
        string query = "SELECT * FROM computerparts WHERE Name LIKE @SearchText OR Brand LIKE @SearchText";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Use % wildcards to search for any occurrence of searchText
                    cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., logging)
            Console.WriteLine(ex.Message);
        }

        return dataTable;
    }





    // Add more methods as needed for updating, deleting, etc.
}