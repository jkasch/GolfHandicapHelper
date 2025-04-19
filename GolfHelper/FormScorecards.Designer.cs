namespace GolfHelper
{
    partial class FormScorecards
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
            label1 = new Label();
            txtCourseName = new TextBox();
            label2 = new Label();
            cbxNumHoles = new ComboBox();
            dgvHoles = new DataGridView();
            HoleNumber = new DataGridViewTextBoxColumn();
            HoleHandicap = new DataGridViewTextBoxColumn();
            btnAddScorecard = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHoles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 22);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Course Name:";
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(167, 19);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(125, 27);
            txtCourseName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 67);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 2;
            label2.Text = "Number of Holes:\r\n";
            // 
            // cbxNumHoles
            // 
            cbxNumHoles.FormattingEnabled = true;
            cbxNumHoles.Items.AddRange(new object[] { "9", "18", "Combination" });
            cbxNumHoles.Location = new Point(168, 67);
            cbxNumHoles.Name = "cbxNumHoles";
            cbxNumHoles.Size = new Size(151, 28);
            cbxNumHoles.TabIndex = 3;
            cbxNumHoles.SelectedIndexChanged += cbxNumHoles_SelectedIndexChanged;
            // 
            // dgvHoles
            // 
            dgvHoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoles.Columns.AddRange(new DataGridViewColumn[] { HoleNumber, HoleHandicap });
            dgvHoles.Location = new Point(44, 140);
            dgvHoles.Name = "dgvHoles";
            dgvHoles.RowHeadersWidth = 51;
            dgvHoles.Size = new Size(325, 188);
            dgvHoles.TabIndex = 4;
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
            // btnAddScorecard
            // 
            btnAddScorecard.Location = new Point(44, 348);
            btnAddScorecard.Name = "btnAddScorecard";
            btnAddScorecard.Size = new Size(153, 47);
            btnAddScorecard.TabIndex = 5;
            btnAddScorecard.Text = "Add New Scorecard";
            btnAddScorecard.UseVisualStyleBackColor = true;
            btnAddScorecard.Click += btnAddScorecard_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(220, 348);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(149, 47);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back to Main Menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // FormScorecards
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 450);
            Controls.Add(btnBack);
            Controls.Add(btnAddScorecard);
            Controls.Add(dgvHoles);
            Controls.Add(cbxNumHoles);
            Controls.Add(label2);
            Controls.Add(txtCourseName);
            Controls.Add(label1);
            Name = "FormScorecards";
            Text = "Add Scorecards";
            ((System.ComponentModel.ISupportInitialize)dgvHoles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCourseName;
        private Label label2;
        private ComboBox cbxNumHoles;
        private DataGridView dgvHoles;
        private Button btnAddScorecard;
        private Button btnBack;
        private DataGridViewTextBoxColumn HoleNumber;
        private DataGridViewTextBoxColumn HoleHandicap;
    }
}