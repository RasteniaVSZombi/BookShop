namespace BookShop
{
    partial class FormEndGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEndGame));
            photoLose = new PictureBox();
            phonoWin = new PictureBox();
            lbStats = new Label();
            ((System.ComponentModel.ISupportInitialize)photoLose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)phonoWin).BeginInit();
            SuspendLayout();
            // 
            // photoLose
            // 
            photoLose.BackColor = Color.Transparent;
            photoLose.BackgroundImage = (Image)resources.GetObject("photoLose.BackgroundImage");
            photoLose.BackgroundImageLayout = ImageLayout.Stretch;
            photoLose.ErrorImage = null;
            photoLose.InitialImage = null;
            photoLose.Location = new Point(98, 207);
            photoLose.Name = "photoLose";
            photoLose.Size = new Size(641, 205);
            photoLose.TabIndex = 1;
            photoLose.TabStop = false;
            // 
            // phonoWin
            // 
            phonoWin.BackColor = Color.Transparent;
            phonoWin.BackgroundImage = (Image)resources.GetObject("phonoWin.BackgroundImage");
            phonoWin.BackgroundImageLayout = ImageLayout.Stretch;
            phonoWin.ErrorImage = null;
            phonoWin.InitialImage = null;
            phonoWin.Location = new Point(98, 207);
            phonoWin.Name = "phonoWin";
            phonoWin.Size = new Size(641, 205);
            phonoWin.TabIndex = 0;
            phonoWin.TabStop = false;
            // 
            // lbStats
            // 
            lbStats.AutoSize = true;
            lbStats.BackColor = Color.PowderBlue;
            lbStats.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbStats.ForeColor = Color.Black;
            lbStats.Location = new Point(209, 9);
            lbStats.Name = "lbStats";
            lbStats.Size = new Size(371, 192);
            lbStats.TabIndex = 2;
            lbStats.Text = "Статистика:\r\nСложность:\r\nПрошло игрового времен:\r\nОставшийся баланс магазина:\r\nНедовольных покупателей\r\nОчередь:\r\n";
            lbStats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormEndGame
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(876, 544);
            Controls.Add(lbStats);
            Controls.Add(photoLose);
            Controls.Add(phonoWin);
            Name = "FormEndGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEndGame";
            ((System.ComponentModel.ISupportInitialize)photoLose).EndInit();
            ((System.ComponentModel.ISupportInitialize)phonoWin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox photoLose;
        private PictureBox phonoWin;
        private Label lbStats;
    }
}