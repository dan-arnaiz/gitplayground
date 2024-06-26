private void editButton_Click(object sender, EventArgs e)
{
    if (dataGridView1.CurrentRow != null)
    {
        var selectedRow = dataGridView1.CurrentRow;
        using (Form modalForm = new Form())
        {
            editItemModal editItemModal = new editItemModal();
            modalForm.Controls.Add(editItemModal);
            editItemModal.Dock = DockStyle.Fill;
            modalForm.Size = new Size(490, 449);
            modalForm.StartPosition = FormStartPosition.CenterScreen;
            modalForm.ShowDialog();
        }
    }
    else
    {
        MessageBox.Show("Please select a row first.");
    }
}