using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<SnakeSegment> snake = new List<SnakeSegment>();
        private int directionX = 1;
        private int directionY = 0;
        private System.Windows.Forms.Timer timer;
        private bool gameOver = false;
        private int moveStep = 1;
        private int score = 0;
        private PictureBox foodPictureBox;
        private System.Windows.Forms.Timer animationTimer;
        private Random random = new Random();
        private int foodX;
        private int foodY;
        private int specialFoodInterval = 10;
        private int specialFoodCounter = 0;
        private Button tryAgainButton;
        private bool isPaused = false;
        private Label pauseLabel;
        private Button resumeButton;
        private System.Windows.Forms.Timer countdownTimer;
        private int countdownValue = 3;

        public Form1()
        {
            InitializeComponent();
            pictureBoxBoard.TabStop = false;
            this.KeyPreview = true;
            this.btnStart.Click += new EventHandler(btnStart_Click);

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;

            tryAgainButton = new Button
            {
                Text = "Try Again",
                Font = new Font(FontFamily.GenericSansSerif, 12),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Parent = pictureBoxBoard,
                Visible = false
            };

            tryAgainButton.Click += TryAgainButton_Click;
        }




        private void InitializeSnake()
        {
            int startX = pictureBoxBoard.Width / 40;
            int startY = pictureBoxBoard.Height / 40;

            for (int i = 0; i < 5; i++)
            {
                snake.Add(new SnakeSegment(startX - i, startY));
            }
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 175;
            timer.Tick += UpdateSnake;
        }

        private void DrawSnake()
        {
            pictureBoxBoard.Controls.Clear();

            foreach (SnakeSegment segment in snake)
            {
                PictureBox segmentBox = new PictureBox
                {
                    BackColor = Color.MediumAquamarine,
                    Width = 20,
                    Height = 20,
                    Left = segment.X * 20,
                    Top = segment.Y * 20,
                    Parent = pictureBoxBoard
                };

                pictureBoxBoard.Controls.Add(segmentBox);
            }
        }

        private void DrawFood()
        {
            if (specialFoodCounter == specialFoodInterval)
            {
                DrawSpecialFood();
            }
            else
            {
                DrawRegularFood();
            }
        }

        private void DrawRegularFood()
        {
            foodPictureBox = new PictureBox
            {
                BackColor = Color.Teal,
                Width = 20,
                Height = 20,
                Left = foodX * 20,
                Top = foodY * 20,
                Parent = pictureBoxBoard
            };

            pictureBoxBoard.Controls.Add(foodPictureBox);
        }

        private void DrawSpecialFood()
        {
            foodPictureBox = new PictureBox
            {
                BackColor = Color.MidnightBlue,
                Width = 20,
                Height = 20,
                Left = foodX * 20,
                Top = foodY * 20,
                Parent = pictureBoxBoard
            };

            pictureBoxBoard.Controls.Add(foodPictureBox);
        }

        private void UpdateSnake(object sender, EventArgs e)
        {
            if (gameOver) return;

            int newX = snake[0].X + directionX * moveStep;
            int newY = snake[0].Y + directionY * moveStep;

            if (newX < 0 || newY < 0 || newX >= pictureBoxBoard.Width / 20 || newY >= pictureBoxBoard.Height / 20)
            {
                EndGame();
                return;
            }

            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[i].X == newX && snake[i].Y == newY)
                {
                    EndGame();
                    return;
                }
            }

            snake.Insert(0, new SnakeSegment(newX, newY));

            if (newX == foodX && newY == foodY)
            {
                GenerateFood();

                if (foodPictureBox.BackColor == Color.MidnightBlue)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        snake.Add(new SnakeSegment(snake[snake.Count - 1].X, snake[snake.Count - 1].Y));
                    }
                    score += 100;
                    specialFoodCounter = 0;
                }
                else
                {
                    snake.Add(new SnakeSegment(snake[snake.Count - 1].X, snake[snake.Count - 1].Y));
                    score += 20;
                    specialFoodCounter++;
                }

                labelScore.Text = (score.ToString() + " points");

                IncreaseSpeed();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            DrawSnake();
            DrawFood();
        }


        private void GenerateFood()
        {
            foodX = random.Next(pictureBoxBoard.Width / 20);
            foodY = random.Next(pictureBoxBoard.Height / 20);

            foreach (var segment in snake)
            {
                if (segment.X == foodX && segment.Y == foodY)
                {
                    GenerateFood();
                    return;
                }
            }

            if (specialFoodCounter == specialFoodInterval)
            {
                DrawSpecialFood();
                specialFoodCounter = 0;
            }
            else
            {
                DrawRegularFood();
                specialFoodCounter++;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (directionY == 0)
                    {
                        directionX = 0;
                        directionY = -1;
                    }
                    break;
                case Keys.Down:
                    if (directionY == 0)
                    {
                        directionX = 0;
                        directionY = 1;
                    }
                    break;
                case Keys.Left:
                    if (directionX == 0)
                    {
                        directionX = -1;
                        directionY = 0;
                    }
                    break;
                case Keys.Right:
                    if (directionX == 0)
                    {
                        directionX = 1;
                        directionY = 0;
                    }
                    break;
            }
        }

        private void EndGame()
        {
            timer.Stop();
            gameOver = true;
            DisplayGameOver();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    OnKeyDown(this, new KeyEventArgs(keyData));
                    return true; // Klawisz zosta³ obs³u¿ony
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameOver = false;
            snake.Clear();
            InitializeSnake();

            if (timer != null && timer.Enabled)
            {
                timer.Stop();
            }

            InitializeTimer();
            GenerateFood();
            timer.Start();
        }

        private void PauseGame()
        {
            if (!isPaused)
            {
                isPaused = true;
                timer.Stop();
                pauseLabel = new Label
                {
                    Text = "Game Paused",
                    Font = new Font(FontFamily.GenericSansSerif, 20),
                    ForeColor = Color.White,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = (pictureBoxBoard.Width - 200) / 2,
                    Top = (pictureBoxBoard.Height - 100) / 2
                };

                pauseLabel.BackColor = Color.Transparent;

                resumeButton = new Button
                {
                    Text = "Resume",
                    Font = new Font(FontFamily.GenericSansSerif, 12),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    Width = 100,
                    Height = 30,
                    Left = (pictureBoxBoard.Width - 100) / 2,
                    Top = pauseLabel.Bottom + 50
                };
                resumeButton.Click += ResumeButton_Click;

                pictureBoxBoard.Controls.Add(pauseLabel);
                pictureBoxBoard.Controls.Add(resumeButton);

                pauseLabel.BringToFront();
                resumeButton.BringToFront();
            }
        }

        private void ResumeGame()
        {
            if (isPaused)
            {
                isPaused = false;
                countdownTimer.Start();
            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdownValue > 0)
            {
                pauseLabel.Text = "Game Paused\nResuming in " + countdownValue;
                countdownValue--;
            }
            else
            {
                countdownTimer.Stop();
                timer.Start();
                countdownValue = 3;
                pictureBoxBoard.Controls.Remove(pauseLabel);
                pictureBoxBoard.Controls.Remove(resumeButton);
            }
        }

        private void IncreaseSpeed()
        {
            timer.Interval -= 3;
        }


        private void ResumeButton_Click(object sender, EventArgs e)
        {
            ResumeGame();
        }

        private void btnPause_Click_1(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void DisplayGameOver()
        {
            Label loseLabel = new Label
            {
                Text = "You Lose!",
                Font = new Font(FontFamily.GenericSansSerif, 20),
                ForeColor = Color.White,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Parent = pictureBoxBoard
            };

            tryAgainButton.Parent = pictureBoxBoard;
            tryAgainButton.Visible = true;

            loseLabel.Left = (pictureBoxBoard.Width - loseLabel.Width) / 2;
            loseLabel.Top = (pictureBoxBoard.Height - loseLabel.Height - tryAgainButton.Height - 10) / 2;

            tryAgainButton.Left = (pictureBoxBoard.Width - tryAgainButton.Width) / 2;
            tryAgainButton.Top = loseLabel.Bottom + 10;
        }



        private void TryAgainButton_Click(object sender, EventArgs e)
        {
            score = 0;
            labelScore.Text = score.ToString() + " points";

            gameOver = false;
            snake.Clear();
            InitializeSnake();

            if (timer != null && timer.Enabled)
            {
                timer.Stop();
            }

            InitializeTimer();
            GenerateFood();
            timer.Start();

            pictureBoxBoard.Controls.Clear();
        }
    }
}

