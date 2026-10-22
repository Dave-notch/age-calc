namespace age_calc
{
    public partial class Form1 : Form
    {
        private const int Columns = 39;
        private const int Rows = 25;
        private readonly LinkedList<Point> snake = new();
        private readonly Random random = new();
        private readonly System.Windows.Forms.Timer gameTimer;
        private Point direction;
        private Point nextDirection;
        private Point food;
        private int score;
        private bool gameOver;

        public Form1()
        {
            InitializeComponent();

            gameTimer = new System.Windows.Forms.Timer { Interval = 105 };
            gameTimer.Tick += gameTimer_Tick;
            KeyDown += Form1_KeyDown;
            Shown += (_, _) => boardPanel.Focus();

            StartGame();
        }

        private void StartGame()
        {
            snake.Clear();
            Point start = new(Columns / 2, Rows / 2);
            snake.AddFirst(start);
            snake.AddLast(new Point(start.X - 1, start.Y));
            snake.AddLast(new Point(start.X - 2, start.Y));
            direction = new Point(1, 0);
            nextDirection = direction;
            score = 0;
            gameOver = false;
            scoreLabel.Text = "0000";
            statusLabel.Text = "PLAYING";
            statusLabel.ForeColor = Color.FromArgb(74, 222, 128);
            PlaceFood();
            gameTimer.Start();
            boardPanel.Invalidate();
        }

        private void gameTimer_Tick(object? sender, EventArgs e)
        {
            if (gameOver)
                return;

            direction = nextDirection;
            Point head = snake.First!.Value;
            Point next = new(head.X + direction.X, head.Y + direction.Y);
            bool eating = next == food;
            Point tail = snake.Last!.Value;

            bool hitWall = next.X < 0 || next.X >= Columns || next.Y < 0 || next.Y >= Rows;
            bool hitBody = snake.Contains(next) && (eating || next != tail);
            if (hitWall || hitBody)
            {
                EndGame();
                return;
            }

            snake.AddFirst(next);
            if (eating)
            {
                score++;
                scoreLabel.Text = score.ToString("0000");
                PlaceFood();
                if (snake.Count == Columns * Rows)
                    EndGame(true);
            }
            else
            {
                snake.RemoveLast();
            }

            boardPanel.Invalidate();
        }

        private void PlaceFood()
        {
            do
            {
                food = new Point(random.Next(Columns), random.Next(Rows));
            }
            while (snake.Contains(food));
        }

        private void EndGame(bool won = false)
        {
            gameOver = true;
            gameTimer.Stop();
            statusLabel.Text = won ? "YOU WIN" : "GAME OVER";
            statusLabel.ForeColor = won
                ? Color.FromArgb(45, 212, 191)
                : Color.FromArgb(248, 113, 113);
            boardPanel.Invalidate();
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                StartGame();
                e.Handled = true;
                return;
            }

            Point requested = e.KeyCode switch
            {
                Keys.Up or Keys.W => new Point(0, -1),
                Keys.Down or Keys.S => new Point(0, 1),
                Keys.Left or Keys.A => new Point(-1, 0),
                Keys.Right or Keys.D => new Point(1, 0),
                _ => direction
            };

            if (requested.X != -direction.X || requested.Y != -direction.Y)
                nextDirection = requested;

            if (e.KeyCode is Keys.Up or Keys.Down or Keys.Left or Keys.Right or Keys.W or Keys.A or Keys.S or Keys.D)
                e.Handled = true;
        }

        private void restartButton_Click(object? sender, EventArgs e)
        {
            StartGame();
            boardPanel.Focus();
        }

        private void boardPanel_Paint(object? sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cellWidth = boardPanel.ClientSize.Width / Columns;
            int cellHeight = boardPanel.ClientSize.Height / Rows;

            using var gridPen = new Pen(Color.FromArgb(25, 38, 62));
            for (int x = 1; x < Columns; x++)
                graphics.DrawLine(gridPen, x * cellWidth, 0, x * cellWidth, Rows * cellHeight);
            for (int y = 1; y < Rows; y++)
                graphics.DrawLine(gridPen, 0, y * cellHeight, Columns * cellWidth, y * cellHeight);

            Rectangle foodBounds = new(
                food.X * cellWidth + 4,
                food.Y * cellHeight + 4,
                Math.Max(4, cellWidth - 8),
                Math.Max(4, cellHeight - 8));
            using (var foodBrush = new SolidBrush(Color.FromArgb(251, 113, 133)))
                graphics.FillEllipse(foodBrush, foodBounds);

            int index = 0;
            foreach (Point segment in snake)
            {
                Rectangle segmentBounds = new(
                    segment.X * cellWidth + 2,
                    segment.Y * cellHeight + 2,
                    Math.Max(4, cellWidth - 4),
                    Math.Max(4, cellHeight - 4));
                Color segmentColor = index++ == 0
                    ? Color.FromArgb(45, 212, 191)
                    : Color.FromArgb(20, 184, 166);
                using var segmentBrush = new SolidBrush(segmentColor);
                graphics.FillRectangle(segmentBrush, segmentBounds);
            }

            if (gameOver)
            {
                using var overlay = new SolidBrush(Color.FromArgb(185, 15, 23, 42));
                graphics.FillRectangle(overlay, boardPanel.ClientRectangle);
                string message = statusLabel.Text == "YOU WIN" ? "BOARD CLEARED!" : "GAME OVER";
                using var messageFont = new Font("Segoe UI", 26F, FontStyle.Bold);
                using var hintFont = new Font("Segoe UI", 10F);
                using var messageBrush = new SolidBrush(Color.White);
                using var hintBrush = new SolidBrush(Color.FromArgb(148, 163, 184));
                SizeF messageSize = graphics.MeasureString(message, messageFont);
                SizeF hintSize = graphics.MeasureString("Press Space or Restart game to play again", hintFont);
                float centerX = boardPanel.ClientSize.Width / 2F;
                float centerY = boardPanel.ClientSize.Height / 2F;
                graphics.DrawString(message, messageFont, messageBrush, centerX - messageSize.Width / 2, centerY - 35);
                graphics.DrawString("Press Space or Restart game to play again", hintFont, hintBrush, centerX - hintSize.Width / 2, centerY + 12);
            }
        }
    }
}