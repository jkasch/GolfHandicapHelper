using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GolfHelper
{
    public partial class FormGamePlay : Form
    {
        public FormGamePlay()
        {
            InitializeComponent();
            LoadGolfers(); // Load golfers in ComboBox
            LoadScorecards(); // Load scorecards into the ComboBox
        }

        private void LoadGolfers()
        {
            string connectionString = "Server=localhost;Database=golf_handicap_helper;Uid=root;Pwd=;";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT golfer_id, name FROM Golfers";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add golfer to CheckedListBox
                                clbGolfers.Items.Add($"{reader["golfer_id"]}: {reader["name"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load golfers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void RefreshData()
        {
            // Clear existing golfers
            clbGolfers.Items.Clear();
            LoadGolfers(); // Reload golfers into the CheckedListBox

            // Clear existing scorecards
            cbxScorecards.Items.Clear();
            LoadScorecards(); // Reload scorecards into ComboBox
        }

        private void UpdatePlayerHeaders()
        {
            // Clear existing columns
            dgvGameResults.Columns.Clear();

            // Columns for hole numbers and handicaps
            dgvGameResults.Columns.Add("HoleNumber", "Hole");
            dgvGameResults.Columns.Add("HoleHandicap", "Handicap");

            // Get selected golfers and names with handicaps as headers
            string connectionString = "Server=localhost;Database=golf_handicap_helper;Uid=root;Pwd=;";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (var item in clbGolfers.CheckedItems)
                    {
                        string[] parts = (item?.ToString() ?? "").Split(':'); // Get golfer ID & name
                        if (parts.Length > 1)
                        {
                            string golferId = parts[0].Trim();
                            string golferName = parts[1].Trim();

                            // Get golfer's handicap
                            string query = "SELECT handicap FROM Golfers WHERE golfer_id = @golfer_id";
                            using (var command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@golfer_id", golferId);
                                object result = command.ExecuteScalar();
                                int handicap = result != null ? Convert.ToInt32(result) : 0; // Handle possible null

                                // Display player handicap in parentheses
                                string golferDisplayName = $"{golferName} ({handicap})";
                                dgvGameResults.Columns.Add(golferDisplayName, golferDisplayName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load handicaps: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // load scorecards into ComboBox
        private void LoadScorecards()
        {
            string connectionString = "Server=localhost;Database=golf_handicap_helper;Uid=root;Pwd=;";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT scorecard_id, course_name FROM Scorecards"; // Query to fetch scorecard ID and course name
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add scorecard name to ComboBox
                                cbxScorecards.Items.Add($"{reader["scorecard_id"]}: {reader["course_name"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load scorecards: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCalculateStrokes_Click(object sender, EventArgs e)
        {
            // check at least one golfer and one scorecard are selected
            if (clbGolfers.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select at least one golfer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxScorecards.SelectedItem == null)
            {
                MessageBox.Show("Select a scorecard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdatePlayerHeaders();

            // Get selected golfer IDs
            List<string> golferIds = new List<string>();
            foreach (var item in clbGolfers.CheckedItems)
            {
                string golferId = item?.ToString()?.Split(':')[0] ?? string.Empty;
                golferIds.Add(golferId);
            }

            // Get selected scorecard ID
            string scorecardId = cbxScorecards.SelectedItem?.ToString()?.Split(':')[0] ?? string.Empty;

            // Clear previous game results
            dgvGameResults.Rows.Clear();

            string connectionString = "Server=localhost;Database=golf_handicap_helper;Uid=root;Pwd=;";
            List<(int HoleNumber, int HoleHandicap)> holeHandicaps = new List<(int, int)>(); // Store hole handicap data

            try
            {
                // Get hole handicaps
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string holeQuery = "SELECT hole_number, hole_handicap FROM Handicaps WHERE scorecard_id = @scorecard_id";
                    using (var holeCommand = new MySqlCommand(holeQuery, connection))
                    {
                        holeCommand.Parameters.AddWithValue("@scorecard_id", scorecardId);

                        using (var holeReader = holeCommand.ExecuteReader())
                        {
                            while (holeReader.Read())
                            {
                                int holeNumber = Convert.ToInt32(holeReader["hole_number"]);
                                int holeHandicap = Convert.ToInt32(holeReader["hole_handicap"]);
                                holeHandicaps.Add((holeNumber, holeHandicap)); // Store hole handicap info
                            }
                        }
                    }
                }

                // Determine baseline handicap (lowest handicap)
                int baselineHandicap = int.MaxValue;

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (string golferId in golferIds)
                    {
                        string golferQuery = "SELECT handicap FROM Golfers WHERE golfer_id = @golfer_id";
                        using (var golferCommand = new MySqlCommand(golferQuery, connection))
                        {
                            golferCommand.Parameters.AddWithValue("@golfer_id", golferId);
                            int golferHandicap = Convert.ToInt32(golferCommand.ExecuteScalar());

                            if (golferHandicap < baselineHandicap)
                            {
                                baselineHandicap = golferHandicap;
                            }
                        }
                    }
                }

                // Loop through each hole and calculate extra strokes relative to baseline
                foreach (var (HoleNumber, HoleHandicap) in holeHandicaps)
                {
                    List<int> extraStrokes = new List<int>();

                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (string golferId in golferIds)
                        {
                            string golferQuery = "SELECT handicap FROM Golfers WHERE golfer_id = @golfer_id";
                            using (var golferCommand = new MySqlCommand(golferQuery, connection))
                            {
                                golferCommand.Parameters.AddWithValue("@golfer_id", golferId);
                                int golferHandicap = Convert.ToInt32(golferCommand.ExecuteScalar());

                                // Calculate strokes relative to the baseline handicap
                                int totalExtraStrokes = golferHandicap - baselineHandicap;

                                // Assign a stroke if there are remaining extra strokes
                                int strokesForThisHole = totalExtraStrokes > 0 && HoleHandicap <= totalExtraStrokes ? 1 : 0;
                                extraStrokes.Add(strokesForThisHole);
                            }
                        }
                    }

                    // Add row to DataGridView for the current hole
                    dgvGameResults.Rows.Add(
                        HoleNumber,
                        HoleHandicap,
                        extraStrokes.Count > 0 ? extraStrokes[0] : 0,
                        extraStrokes.Count > 1 ? extraStrokes[1] : 0,
                        extraStrokes.Count > 2 ? extraStrokes[2] : 0,
                        extraStrokes.Count > 3 ? extraStrokes[3] : 0
                    );
                }

                MessageBox.Show("Extra strokes calculated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to calculate strokes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGolfers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formGolfers = new Form1(this);
            formGolfers.ShowDialog();
            this.Show();
        }

        private void btnScorecards_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            FormScorecards formScorecards = new FormScorecards(this); // Pass GamePlay instance
            formScorecards.ShowDialog(); 
            this.Show(); 
        }
    }    
}
