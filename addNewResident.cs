private async void addResidentButton_Click(object sender, EventArgs e)
{
    using (Form modalForm = new Form())
    {
        ControllerAddNewResidentModal controllerAddNewResidentModal = new ControllerAddNewResidentModal();
        modalForm.Controls.Add(controllerAddNewResidentModal);
        controllerAddNewResidentModal.Dock = DockStyle.Fill;
        modalForm.Size = new Size(490, 449);
        modalForm.StartPosition = FormStartPosition.CenterScreen;
        modalForm.ShowDialog();

    }
}