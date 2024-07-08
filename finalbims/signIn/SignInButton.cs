private void signInButton_Click(object sender, EventArgs e) {
  // Retrieve user input from textboxes
  string username = usernameSignInTextBox.Text;
  string password = passwordSignInTextBox.Text;

  // Instance of the Authentication class
  Authentication auth = new Authentication();

  // Attempt to login with the provided credentials
  bool loginSuccess = auth.Login(username, password);

  if (loginSuccess) {
    // Login successful
    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
    // Proceed to the next part of your application
    this.Close();
    BarangayLists barangayListsForm = new BarangayLists();
    barangayListsForm.Show();

  } else {
    // Login failed
    MessageBox.Show("Login Failed. Please check your username and password.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
}