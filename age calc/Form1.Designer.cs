namespace age_calc
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel = null!;
        private Label titleLabel = null!;
        private Label subtitleLabel = null!;
        private Label scoreCaptionLabel = null!;
        private Label scoreLabel = null!;
        private Label statusLabel = null!;
        private Panel boardPanel = null!;
        private Button restartButton = null!;
        private Label controlsLabel = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            titleLabel = new Label();
            subtitleLabel = new Label();
            scoreCaptionLabel = new Label();
            scoreLabel = new Label();
            statusLabel = new Label();
            boardPanel = new Panel();
            restartButton = new Button();
            controlsLabel = new Label();
            headerPanel.SuspendLayout();
            SuspendLayout();

            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(860, 720);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(226, 232, 240);
            KeyPreview = true;
            MinimumSize = new Size(760, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake · Classic Arcade";

            headerPanel.BackColor = Color.FromArgb(30, 41, 59);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 112;
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(scoreCaptionLabel);
            headerPanel.Controls.Add(scoreLabel);
            headerPanel.Controls.Add(statusLabel);

            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(34, 18);
            titleLabel.Text = "SNAKE";

            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 9.5F);
            subtitleLabel.ForeColor = Color.FromArgb(148, 163, 184);
            subtitleLabel.Location = new Point(37, 62);
            subtitleLabel.Text = "Classic arcade · Eat, grow, survive";

            scoreCaptionLabel.AutoSize = true;
            scoreCaptionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            scoreCaptionLabel.ForeColor = Color.FromArgb(148, 163, 184);
            scoreCaptionLabel.Location = new Point(620, 21);
            scoreCaptionLabel.Text = "SCORE";

            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            scoreLabel.ForeColor = Color.FromArgb(45, 212, 191);
            scoreLabel.Location = new Point(616, 38);
            scoreLabel.Text = "0000";

            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            statusLabel.ForeColor = Color.FromArgb(250, 204, 21);
            statusLabel.Location = new Point(716, 50);
            statusLabel.Text = "READY";

            boardPanel.BackColor = Color.FromArgb(15, 23, 42);
            boardPanel.BorderStyle = BorderStyle.FixedSingle;
            boardPanel.Location = new Point(34, 138);
            boardPanel.Size = new Size(792, 504);
            boardPanel.TabIndex = 0;
            boardPanel.Paint += boardPanel_Paint;

            restartButton.BackColor = Color.FromArgb(14, 165, 233);
            restartButton.FlatAppearance.BorderSize = 0;
            restartButton.FlatStyle = FlatStyle.Flat;
            restartButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            restartButton.ForeColor = Color.White;
            restartButton.Location = new Point(34, 660);
            restartButton.Size = new Size(132, 38);
            restartButton.Text = "Restart game";
            restartButton.UseVisualStyleBackColor = false;
            restartButton.Click += restartButton_Click;

            controlsLabel.AutoSize = true;
            controlsLabel.Font = new Font("Segoe UI", 9.5F);
            controlsLabel.ForeColor = Color.FromArgb(148, 163, 184);
            controlsLabel.Location = new Point(190, 671);
            controlsLabel.Text = "Move with  ↑ ↓ ← →  or  W A S D     ·     Press Space to restart";

            Controls.Add(headerPanel);
            Controls.Add(boardPanel);
            Controls.Add(restartButton);
            Controls.Add(controlsLabel);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}