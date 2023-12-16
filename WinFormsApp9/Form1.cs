using Timer = System.Windows.Forms.Timer;

namespace ChangingColorApp
{
    
    public partial class Form1 : Form
    {
        private Button clickButton;
        private System.Windows.Forms.Timer colorChangeTimer;
        private int clickCount;
        private int maxAttemptRecord;
        private System.Windows.Forms.Timer gameTimer;
        private static readonly Color[] Colors = { Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Cyan, Color.Magenta, Color.White };
        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            clickButton = new Button();
            clickButton.Text = "Íàæìè ìåíÿ!";
            clickButton.Size = new Size(100, 50);
            clickButton.Location = new Point((ClientSize.Width - clickButton.Width) / 2, (ClientSize.Height - clickButton.Height) / 2);
            clickButton.Click += ClickButton_Click;

            Controls.Add(clickButton);

            colorChangeTimer = new System.Windows.Forms.Timer();
            colorChangeTimer.Interval = 1000; 
            colorChangeTimer.Tick += ColorChangeTimer_Tick;

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20000;
            gameTimer.Tick += GameTimer_Tick;

            StartGame();
        }

        private void StartGame()
        {
            clickCount = 0;
            gameTimer.Start();
            colorChangeTimer.Start();
        }

        private void ClickButton_Click(object sender, EventArgs e)
        {
            clickCount++;
        }

        private void ColorChangeTimer_Tick(object sender, EventArgs e)
        {
            BackColor = GetNextColor(BackColor);
        }

        private Color GetNextColor(Color currentColor)
        {
            int index = Array.IndexOf(Colors, currentColor);
            index = (index + 1) % Colors.Length;
            return Colors[index];
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            gameTimer.Stop();
            colorChangeTimer.Stop();

            if (clickCount > maxAttemptRecord)
            {
                maxAttemptRecord = clickCount;
            }

            MessageBox.Show($"Êîëè÷åñòâî êëèêîâ: {clickCount}\nÌàêñèìàëüíûé ðåêîðä ïî èòîãàì âñåõ ïîïûòîê: {maxAttemptRecord}", "Èãðà çàâåðøåíà");
            StartGame();
        }
    }    
}
