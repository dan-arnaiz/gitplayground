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