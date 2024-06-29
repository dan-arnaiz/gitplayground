private Task LoadControlAsync(UserControl control)
{
    return Task.Run(() =>
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(() => LoadControl(control)));
        }
        else
        {
            LoadControl(control);
        }
    });
}
