namespace BookShop
{
    partial class TitleScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleScreen));
            btnEasy = new Button();
            lblDifficulty = new Label();
            btnNormal = new Button();
            btnHard = new Button();
            lblTeamName = new Label();
            btnAbout = new Button();
            lblNameGame = new Label();
            SuspendLayout();
            // 
            // btnEasy
            // 
            btnEasy.BackColor = Color.LawnGreen;
            btnEasy.FlatStyle = FlatStyle.Flat;
            btnEasy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEasy.Location = new Point(320, 298);
            btnEasy.Margin = new Padding(3, 2, 3, 2);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(262, 38);
            btnEasy.TabIndex = 0;
            btnEasy.Text = "Легкий";
            btnEasy.UseVisualStyleBackColor = false;
            btnEasy.Click += btnEasy_Click;
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.BackColor = Color.DarkGray;
            lblDifficulty.FlatStyle = FlatStyle.Flat;
            lblDifficulty.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblDifficulty.ForeColor = Color.Navy;
            lblDifficulty.Location = new Point(285, 251);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(308, 22);
            lblDifficulty.TabIndex = 1;
            lblDifficulty.Text = "Выберите уровень сложности:";
            // 
            // btnNormal
            // 
            btnNormal.BackColor = Color.DarkOrange;
            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnNormal.Location = new Point(320, 352);
            btnNormal.Margin = new Padding(3, 2, 3, 2);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(262, 38);
            btnNormal.TabIndex = 2;
            btnNormal.Text = "Нормальный";
            btnNormal.UseVisualStyleBackColor = false;
            btnNormal.Click += btnNormal_Click;
            // 
            // btnHard
            // 
            btnHard.BackColor = Color.Red;
            btnHard.FlatStyle = FlatStyle.Flat;
            btnHard.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnHard.Location = new Point(320, 406);
            btnHard.Margin = new Padding(3, 2, 3, 2);
            btnHard.Name = "btnHard";
            btnHard.Size = new Size(262, 38);
            btnHard.TabIndex = 3;
            btnHard.Text = "Сложный";
            btnHard.UseVisualStyleBackColor = false;
            btnHard.Click += btnHard_Click;
            // 
            // lblTeamName
            // 
            lblTeamName.AutoSize = true;
            lblTeamName.BackColor = Color.DarkGray;
            lblTeamName.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTeamName.ForeColor = Color.Navy;
            lblTeamName.Location = new Point(494, 469);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(342, 19);
            lblTeamName.TabIndex = 4;
            lblTeamName.Text = "Команда: №2 \"Бессонные программисты";
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.DarkTurquoise;
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAbout.Location = new Point(-1, 0);
            btnAbout.Margin = new Padding(3, 2, 3, 2);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(262, 30);
            btnAbout.TabIndex = 5;
            btnAbout.Text = "Об игре";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += btnAbout_Click;
            // 
            // lblNameGame
            // 
            lblNameGame.AutoSize = true;
            lblNameGame.BackColor = Color.Transparent;
            lblNameGame.Font = new Font("Vladimir Script", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameGame.ForeColor = Color.White;
            lblNameGame.Location = new Point(38, 81);
            lblNameGame.Name = "lblNameGame";
            lblNameGame.Size = new Size(715, 36);
            lblNameGame.TabIndex = 6;
            lblNameGame.Text = "Симулятор продавца в сказочной книжной лавке";
            // 
            // TitleScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(859, 490);
            Controls.Add(lblNameGame);
            Controls.Add(btnAbout);
            Controls.Add(lblTeamName);
            Controls.Add(btnHard);
            Controls.Add(btnNormal);
            Controls.Add(lblDifficulty);
            Controls.Add(btnEasy);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "TitleScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEasy;
        private Label lblDifficulty;
        private Button btnNormal;
        private Button btnHard;
        private Label lblTeamName;
        private Button btnAbout;
        private Label lblNameGame;
    }
}