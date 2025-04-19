namespace GolfHelper
{
    partial class FormGamePlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblGolfers = new Label();
            lblScorecard = new Label();
            cbxScorecards = new ComboBox();
            btnCalculateStrokes = new Button();
            dgvGameResults = new DataGridView();
            HoleNumber = new DataGridViewTextBoxColumn();
            HoleHandicap = new DataGridViewTextBoxColumn();
            Player1 = new DataGridViewTextBoxColumn();
            Player2 = new DataGridViewTextBoxColumn();
            Player3 = new DataGridViewTextBoxColumn();
            Player4 = new DataGridViewTextBoxColumn();
            clbGolfers = new CheckedListBox();
            btnGolfers = new Button();
            btnScorecards = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGameResults).BeginInit();
            SuspendLayout();
            // 
            // lblGolfers
            // 
            lblGolfers.AutoSize = true;
            lblGolfers.Location = new Point(47, 44);
            lblGolfers.Name = "lblGolfers";
            lblGolfers.Size = new Size(59, 20);
            lblGolfers.TabIndex = 1;
            lblGolfers.Text = "Golfers:";
            // 
            // lblScorecard
            // 
            lblScorecard.AutoSize = true;
            lblScorecard.Location = new Point(325, 44);
            lblScorecard.Name = "lblScorecard";
            lblScorecard.Size = new Size(78, 20);
            lblScorecard.TabIndex = 2;
            lblScorecard.Text = "Scorecard:";
            // 
            // cbxScorecards
            // 
            cbxScorecards.FormattingEnabled = true;
            cbxScorecards.Location = new Point(409, 38);
            cbxScorecards.Name = "cbxScorecards";
            cbxScorecards.Size = new Size(151, 28);
            cbxScorecards.TabIndex = 3;
            // 
            // btnCalculateStrokes
            // 
            btnCalculateStrokes.Location = new Point(550, 354);
            btnCalculateStrokes.Name = "btnCalculateStrokes";
            btnCalculateStrokes.Size = new Size(195, 59);
            btnCalculateStrokes.TabIndex = 4;
            btnCalculateStrokes.Text = "Calculate Extra Strokes";
            btnCalculateStrokes.UseVisualStyleBackColor = true;
            btnCalculateStrokes.Click += btnCalculateStrokes_Click;
            // 
            // dgvGameResults
            // 
            dgvGameResults.AllowUserToAddRows = false;
            dgvGameResults.AllowUserToDeleteRows = false;
            dgvGameResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGameResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGameResults.Columns.AddRange(new DataGridViewColumn[] { HoleNumber, HoleHandicap, Player1, Player2, Player3, Player4 });
            dgvGameResults.Location = new Point(290, 101);
            dgvGameResults.Name = "dgvGameResults";
            dgvGameResults.RowHeadersVisible = false;
            dgvGameResults.RowHeadersWidth = 51;
            dgvGameResults.Size = new Size(455, 227);
            dgvGameResults.TabIndex = 6;
            // 
            // HoleNumber
            // 
            HoleNumber.HeaderText = "Hole Number";
            HoleNumber.MinimumWidth = 6;
            HoleNumber.Name = "HoleNumber";
            // 
            // HoleHandicap
            // 
            HoleHandicap.HeaderText = "Hole Handicap";
            HoleHandicap.MinimumWidth = 6;
            HoleHandicap.Name = "HoleHandicap";
            // 
            // Player1
            // 
            Player1.HeaderText = "Player 1";
            Player1.MinimumWidth = 6;
            Player1.Name = "Player1";
            // 
            // Player2
            // 
            Player2.HeaderText = "Player 2";
            Player2.MinimumWidth = 6;
            Player2.Name = "Player2";
            // 
            // Player3
            // 
            Player3.HeaderText = "Player 3";
            Player3.MinimumWidth = 6;
            Player3.Name = "Player3";
            // 
            // Player4
            // 
            Player4.HeaderText = "Player 4";
            Player4.MinimumWidth = 6;
            Player4.Name = "Player4";
            // 
            // clbGolfers
            // 
            clbGolfers.CheckOnClick = true;
            clbGolfers.FormattingEnabled = true;
            clbGolfers.Location = new Point(119, 39);
            clbGolfers.Name = "clbGolfers";
            clbGolfers.Size = new Size(150, 290);
            clbGolfers.TabIndex = 7;
            // 
            // btnGolfers
            // 
            btnGolfers.Location = new Point(119, 354);
            btnGolfers.Name = "btnGolfers";
            btnGolfers.Size = new Size(150, 29);
            btnGolfers.TabIndex = 8;
            btnGolfers.Text = "Add New Golfers";
            btnGolfers.UseVisualStyleBackColor = true;
            btnGolfers.Click += btnGolfers_Click;
            // 
            // btnScorecards
            // 
            btnScorecards.Location = new Point(578, 38);
            btnScorecards.Name = "btnScorecards";
            btnScorecards.Size = new Size(167, 29);
            btnScorecards.TabIndex = 9;
            btnScorecards.Text = "Add New Scorecards";
            btnScorecards.UseVisualStyleBackColor = true;
            btnScorecards.Click += btnScorecards_Click;
            // 
            // FormGamePlay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnScorecards);
            Controls.Add(btnGolfers);
            Controls.Add(clbGolfers);
            Controls.Add(dgvGameResults);
            Controls.Add(btnCalculateStrokes);
            Controls.Add(cbxScorecards);
            Controls.Add(lblScorecard);
            Controls.Add(lblGolfers);
            Name = "FormGamePlay";
            Text = "Game Play";
            //Activated += FormGamePlay_Activated;
            ((System.ComponentModel.ISupportInitialize)dgvGameResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblGolfers;
        private Label lblScorecard;
        private ComboBox cbxScorecards;
        private Button btnCalculateStrokes;
        private DataGridView dgvGameResults;
        private DataGridViewTextBoxColumn HoleNumber;
        private DataGridViewTextBoxColumn HoleHandicap;
        private DataGridViewTextBoxColumn Player1;
        private DataGridViewTextBoxColumn Player2;
        private DataGridViewTextBoxColumn Player3;
        private DataGridViewTextBoxColumn Player4;
        private CheckedListBox clbGolfers;
        private Button btnGolfers;
        private Button btnScorecards;
    }
}