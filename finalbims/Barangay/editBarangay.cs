using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BIMS_dan._dan_bimsBarangayDataset;

namespace BIMS_dan {
public partial class ControllerEditBarangayModal : UserControl {
  public ControllerEditBarangayModal() {
    InitializeComponent();
    this.barangaysDatatable.CellClick += new DataGridViewCellEventHandler(
        this.barangaysDatatable_CellContentClick);
  }

  private void ControllerEditBarangayModal_Load(object sender, EventArgs e) {}

  private void cancelButton_Click(object sender, EventArgs e) {
    this.ParentForm.Close();
  }

  private void
  barangaysDatatable_CellContentClick(object sender,
                                      DataGridViewCellEventArgs e) {
    // Check if the click is on a row, not the column header
    if (e.RowIndex >= 0) {
      // Access the DataGridView
      DataGridView dgv = sender as DataGridView;
      if (dgv == null)
        return;

      // Get the 'barangayNameDataGridViewTextBoxColumn' column value of the
      // clicked row
      string barangayName = dgv.Rows[e.RowIndex]
                                .Cells["barangayNameDataGridViewTextBoxColumn"]
                                .Value.ToString();
      string barangayAddress = dgv.Rows[e.RowIndex]
                                   .Cells["addressDataGridViewTextBoxColumn"]
                                   .Value.ToString();
      string barangayDescription =
          dgv.Rows[e.RowIndex]
              .Cells["descriptionDataGridViewTextBoxColumn"]
              .Value.ToString();
    }
  }

  private async void applyChangesButtonBarangay_Click(object sender,
                                                      EventArgs e) {
    InitializeComponent();
    this.barangaysDatatable.CellClick += new DataGridViewCellEventHandler(
        this.barangaysDatatable_CellContentClick);
    // Assume you have textboxes for ID, name, address, description, and a
    // PictureBox for the logo
    string barangayID = barangayIDDataGridViewTextBoxColumn.Text;
    byte[] barangayLogo = BarangayDB.ImageToByteArray(
        BarangayLogoImageChange); // Assuming barangayDB is an instance of
                                  // BarangayDB
    string barangayName = BarangayNameEditTextBox.Text;
    string address = addressTextBox.Text;
    string description = descriptionTextBox.Text;

    BarangayDB db = new BarangayDB();
    bool success = await BarangayDB.UpdateBarangayAsync(
        barangayID, barangayLogo, barangayName, address, description);

    if (success) {
      MessageBox.Show("Barangay updated successfully.");
      // Optionally, refresh the DataGridView to show the updated information
      await BarangayDB.RefreshBarangaysTableAsync(barangaysDatatable);
    } else {
      MessageBox.Show("Failed to update barangay.");
    }
  }
}
}
