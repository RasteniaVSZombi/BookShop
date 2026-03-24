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
            btnEasy.BackColor = Color.YellowGreen;
            btnEasy.FlatStyle = FlatStyle.Flat;
            btnEasy.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEasy.Location = new Point(366, 319);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(299, 51);
            btnEasy.TabIndex = 0;
            btnEasy.Text = "Легкий";
            btnEasy.UseVisualStyleBackColor = false;
            btnEasy.Click += btnEasy_Click;
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.BackColor = Color.Transparent;
            lblDifficulty.FlatStyle = FlatStyle.Flat;
            lblDifficulty.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblDifficulty.ForeColor = Color.OrangeRed;
            lblDifficulty.Location = new Point(328, 272);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(349, 31);
            lblDifficulty.TabIndex = 1;
            lblDifficulty.Text = "Выберите уровень сложности:";
            // 
            // btnNormal
            // 
            btnNormal.BackColor = Color.DarkOrange;
            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnNormal.Location = new Point(366, 391);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(299, 51);
            btnNormal.TabIndex = 2;
            btnNormal.Text = "Нормальный";
            btnNormal.UseVisualStyleBackColor = false;
            btnNormal.Click += btnNormal_Click;
            // 
            // btnHard
            // 
            btnHard.BackColor = Color.Crimson;
            btnHard.FlatStyle = FlatStyle.Flat;
            btnHard.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnHard.Location = new Point(366, 463);
            btnHard.Name = "btnHard";
            btnHard.Size = new Size(299, 51);
            btnHard.TabIndex = 3;
            btnHard.Text = "Сложный";
            btnHard.UseVisualStyleBackColor = false;
            btnHard.Click += btnHard_Click;
            // 
            // lblTeamName
            // 
            lblTeamName.AutoSize = true;
            lblTeamName.BackColor = Color.Transparent;
            lblTeamName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTeamName.ForeColor = Color.OrangeRed;
            lblTeamName.Location = new Point(565, 625);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(405, 28);
            lblTeamName.TabIndex = 4;
            lblTeamName.Text = "Команда: №2 \"Бессонные программисты";
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.DarkTurquoise;
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAbout.Location = new Point(-1, 0);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(299, 40);
            btnAbout.TabIndex = 5;
            btnAbout.Text = "Об игре";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += btnAbout_Click;
            // 
            // lblNameGame
            // 
            lblNameGame.AutoSize = true;
            lblNameGame.BackColor = Color.Transparent;
            lblNameGame.Font = new Font("Vladimir Script", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNameGame.ForeColor = Color.OrangeRed;
            lblNameGame.Location = new Point(114, 227);
            lblNameGame.Name = "lblNameGame";
            lblNameGame.Size = new Size(823, 45);
            lblNameGame.TabIndex = 6;
            lblNameGame.Text = "Симулятор продавца в сказочной книжной лавке";
            lblNameGame.Click += lblNameGame_Click;
            // 
            // TitleScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(982, 653);
            Controls.Add(lblNameGame);
            Controls.Add(btnAbout);
            Controls.Add(lblTeamName);
            Controls.Add(btnHard);
            Controls.Add(btnNormal);
            Controls.Add(lblDifficulty);
            Controls.Add(btnEasy);
            DoubleBuffered = true;
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