using MySql.Data.MySqlClient;

namespace GolfHelper
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost;Database=golf_handicap_helper;Uid=root;Pwd=;";
        private FormGamePlay gamePlayForm;

        // Constructor accepting existing GamePlay form
        public Form1(FormGamePlay gamePlayInstance)
        {
            InitializeComponent();
            gamePlayForm = gamePlayInstance;
            LoadGolfers();
        }

        // Load golfers into DataGridView
        private void LoadGolfers()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT golfer_id, name, handicap FROM Golfers";
                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        var dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);
                        dgvGolfers.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load golfers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // adding a new golfer
        private void btnAddGolfer_Click(object sender, EventArgs e)
        {
            string golferName = txtName.Text;
            int golferHandicap;

            // Validate input
            if (string.IsNullOrWhiteSpace(golferName) || !int.TryParse(txtHandicap.Text, out golferHandicap))
            {
                MessageBox.Show("Please enter a valid name and handicap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Golfers (name, handicap) VALUES (@name, @handicap)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", golferName);
                        command.Parameters.AddWithValue("@handicap", golferHandicap);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Golfer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtHandicap.Clear();
                    LoadGolfers(); // Refresh DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add golfer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            gamePlayForm.RefreshData(); // Refresh GamePlay data
            gamePlayForm.Show(); // Show existing GamePlay instance
            this.Close(); // Close Form1
        }

        private void dgvGolfers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell clicks if needed
        }

        private void btnGamePlay_Click(object sender, EventArgs e)
        {
            if (gamePlayForm == null || gamePlayForm.IsDisposed)
            {
                gamePlayForm = new FormGamePlay(); // Only create if it doesn't exist
            }

            gamePlayForm.Show(); 
            gamePlayForm.RefreshData(); 
            this.Hide();
        }
    }
}

