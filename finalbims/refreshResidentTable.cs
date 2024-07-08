public async Task RefreshResidentsTableAsync(DataGridView residentsTable) {
  string query =
      @"SELECT id, picture, lastName, firstName, middleName, birthdate, sex, " +
      @"civilStatus, address, yearsResiding, occupation FROM residentsTable";

  using (SqlConnection conn = new SqlConnection(connectionString)) {
    await conn.OpenAsync();
    using (SqlCommand cmd = new SqlCommand(query, conn)) {
      DataTable dataTable = new DataTable();
      using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
        adapter.Fill(dataTable);
      }
      residentsTable.DataSource = dataTable;
    }
  }
}