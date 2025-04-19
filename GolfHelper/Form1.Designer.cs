namespace GolfHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtHandicap = new TextBox();
            btnAddGolfer = new Button();
            dgvGolfers = new DataGridView();
            btnGamePlay = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGolfers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 29);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 0;
            label1.Text = "Golfer Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(131, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 32);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 2;
            label2.Text = "Handicap:";
            // 
            // txtHandicap
            // 
            txtHandicap.Location = new Point(382, 29);
            txtHandicap.Name = "txtHandicap";
            txtHandicap.Size = new Size(125, 27);
            txtHandicap.TabIndex = 3;
            // 
            // btnAddGolfer
            // 
            btnAddGolfer.Location = new Point(535, 19);
            btnAddGolfer.Name = "btnAddGolfer";
            btnAddGolfer.Size = new Size(106, 49);
            btnAddGolfer.TabIndex = 4;
            btnAddGolfer.Text = "Add New Golfer";
            btnAddGolfer.UseVisualStyleBackColor = true;
            btnAddGolfer.Click += btnAddGolfer_Click;
            // 
            // dgvGolfers
            // 
            dgvGolfers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGolfers.Location = new Point(34, 77);
            dgvGolfers.Name = "dgvGolfers";
            dgvGolfers.RowHeadersWidth = 51;
            dgvGolfers.Size = new Size(545, 188);
            dgvGolfers.TabIndex = 5;
            dgvGolfers.CellContentClick += dgvGolfers_CellContentClick;
            // 
            // btnGamePlay
            // 
            btnGamePlay.Location = new Point(439, 289);
            btnGamePlay.Name = "btnGamePlay";
            btnGamePlay.Size = new Size(140, 51);
            btnGamePlay.TabIndex = 7;
            btnGamePlay.Text = "Back to Game Play";
            btnGamePlay.UseVisualStyleBackColor = true;
            btnGamePlay.Click += btnGamePlay_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGamePlay);
            Controls.Add(dgvGolfers);
            Controls.Add(btnAddGolfer);
            Controls.Add(txtHandicap);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Add Golfers";
            ((System.ComponentModel.ISupportInitialize)dgvGolfers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtHandicap;
        private Button btnAddGolfer;
        private DataGridView dgvGolfers;
        private Button btnGamePlay;
    }
}
