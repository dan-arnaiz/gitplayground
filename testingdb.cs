public async Task<DataTable> SearchResidentAsync(string searchTerm) {
  string query =
      @"SELECT id, picture, lastName, firstName, middleName, birthdate, sex, civilStatus, address, yearsResiding, occupation
                     FROM residentsTable
                     WHERE lastName LIKE @SearchTerm OR firstName LIKE @SearchTerm OR address LIKE @SearchTerm";

  using (SqlConnection conn = new SqlConnection(connectionString)) {
    await conn.OpenAsync();
    using (SqlCommand cmd = new SqlCommand(query, conn)) {
      // Use % wildcards to search for any string containing the searchTerm
      cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
      DataTable residentsDatatable = new DataTable();
      using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
        adapter.Fill(residentsDatatable);
      }
      return residentsDatatable;
    }
  }
}
