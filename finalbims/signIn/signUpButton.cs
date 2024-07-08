private void signUpButton_Click(object sender, EventArgs e)
{
    // Retrieve user input from textboxes
    string username = usernameSignUpTextBox.Text.Trim();
    string email = emailAddressTextbox.Text.Trim();
    string password = passwordSignUpTextBox.Text.Trim();

    // Validate inputs
    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
    {
        MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return; // Stop further execution
    }

    // Create an instance of the Authentication class
    Authentication auth = new Authentication();

    // Attempt to sign up the new user
    bool signUpSuccess = auth.SignUp(username, email, password);

    if (signUpSuccess)
    {
        // If sign-up is successful, show a success message
        MessageBox.Show("Sign-up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Optionally, clear the textboxes or navigate the user to another form
        usernameSignUpTextBox.Clear();
        emailAddressTextbox.Clear();
        passwordSignUpTextBox.Clear();

        this.Hide();
        SignInForm signInForm = new SignInForm();
        signInForm.ShowDialog();
    }
    else
    {
        // If sign-up failed (e.g., user already exists), show an error message
        MessageBox.Show("Sign-up failed. User might already exist.", "Sign-up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}