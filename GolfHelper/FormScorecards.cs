using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GolfHelper
{
    public partial class FormScorecards : Form
    {
        private FormGamePlay gamePlayForm;

        public FormScorecards(FormGamePlay gamePlayInstance)
        {
            InitializeComponent();
            gamePlayForm = gamePlayInstance;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            gamePlayForm.RefreshData(); // Refresh GamePlay form
            gamePlayForm.Show(); // Show the same instance instead of creating new one
            this.Close(); 
        }

        private void btnAddScorecard_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text;
            int numHoles;

            if (string.IsNullOrWhiteSpace(courseName) || !int.TryParse(cbxNumHoles.SelectedItem?.ToString(), out numHoles))
            {
                MessageBox.Show("Please enter a valid course name and number of holes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Server=localhost;Database=golf_handicap_helper;Uid=root;Pwd=;";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insert scorecard
                    string query = "INSERT INTO Scorecards (course_name, number_of_holes) VALUES (@course_name, @num_holes)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@course_name", courseName);
                        command.Parameters.AddWithValue("@num_holes", numHoles);
                        command.ExecuteNonQuery();

                        long scorecardId = command.LastInsertedId;

                        foreach (DataGridViewRow row in dgvHoles.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                            {
                                int holeNumber = Convert.ToInt32(row.Cells[0].Value);
                                int holeHandicap = Convert.ToInt32(row.Cells[1].Value);

                                string handicapQuery = "INSERT INTO Handicaps (scorecard_id, hole_number, hole_handicap) VALUES (@scorecard_id, @hole_number, @hole_handicap)";
                                using (var handicapCommand = new MySqlCommand(handicapQuery, connection))
                                {
                                    handicapCommand.Parameters.AddWithValue("@scorecard_id", scorecardId);
                                    handicapCommand.Parameters.AddWithValue("@hole_number", holeNumber);
                                    handicapCommand.Parameters.AddWithValue("@hole_handicap", holeHandicap);
                                    handicapCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("Scorecard added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Temp detach
                        cbxNumHoles.SelectedIndexChanged -= cbxNumHoles_SelectedIndexChanged;

                        // Reset inputs
                        txtCourseName.Clear();
                        cbxNumHoles.SelectedIndex = -1; // Reset ComboBox selection
                        dgvHoles.Rows.Clear(); // Clear DataGridView rows

                        // Reattach
                        cbxNumHoles.SelectedIndexChanged += cbxNumHoles_SelectedIndexChanged;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add scorecard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxNumHoles_SelectedIndexChanged(object? sender, EventArgs e)
        {
            dgvHoles.Rows.Clear();

            int numHoles = 0;

            // Check ComboBox for null
            if (cbxNumHoles.SelectedItem != null)
            {
                string? selectedItem = cbxNumHoles.SelectedItem.ToString();

                // Handle numeric selections (e.g., "9" or "18")
                if (int.TryParse(selectedItem, out numHoles))
                {
                    // Add row for each hole
                    for (int i = 1; i <= numHoles; i++)
                    {
                        dgvHoles.Rows.Add(i, 0); // Pre-fill Hole Number and Handicap with default values
                    }
                }
                // Handle "Combination" selection
                else if (selectedItem == "Combination")
                {
                    // Example: Add rows for 18 holes in a combination course setup
                    for (int i = 1; i <= 18; i++)
                    {
                        dgvHoles.Rows.Add(i, 0); // Pre-fill Hole Number and Handicap with default values
                    }
                }
                else
                {
                    // error handling
                    MessageBox.Show("Invalid selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Handle null
                MessageBox.Show("Please select the number of holes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
