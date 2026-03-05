namespace BookShop
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControlMain = new TabControl();
            tabPageNewBook = new TabPage();
            txtTitle = new TextBox();
            lblTitle = new Label();
            tabPageStore = new TabPage();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblGenre = new Label();
            txtGenre = new TextBox();
            lblPages = new Label();
            txtPages = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            btnGenerate = new Button();
            btnAddBook = new Button();
            errorProvider1 = new ErrorProvider(components);
            panelTop = new Panel();
            lblBalanceCaption = new Label();
            lblBalance = new Label();
            lblGenereSelect = new Label();
            cmbGeneres = new ComboBox();
            panelMiddle = new Panel();
            panelSearch = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lstBooks = new ListBox();
            panelBottom = new Panel();
            lblInfoCaption = new Label();
            lblBookInfo = new Label();
            btnSell = new Button();
            tabControlMain.SuspendLayout();
            tabPageNewBook.SuspendLayout();
            tabPageStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panelTop.SuspendLayout();
            panelMiddle.SuspendLayout();
            panelSearch.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageNewBook);
            tabControlMain.Controls.Add(tabPageStore);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControlMain.Location = new Point(10, 10);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new Point(10, 10);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(860, 616);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageNewBook
            // 
            tabPageNewBook.Controls.Add(btnAddBook);
            tabPageNewBook.Controls.Add(btnGenerate);
            tabPageNewBook.Controls.Add(txtPrice);
            tabPageNewBook.Controls.Add(lblPrice);
            tabPageNewBook.Controls.Add(txtPages);
            tabPageNewBook.Controls.Add(lblPages);
            tabPageNewBook.Controls.Add(txtGenre);
            tabPageNewBook.Controls.Add(lblGenre);
            tabPageNewBook.Controls.Add(txtAuthor);
            tabPageNewBook.Controls.Add(lblAuthor);
            tabPageNewBook.Controls.Add(txtTitle);
            tabPageNewBook.Controls.Add(lblTitle);
            tabPageNewBook.Location = new Point(4, 48);
            tabPageNewBook.Name = "tabPageNewBook";
            tabPageNewBook.Padding = new Padding(3);
            tabPageNewBook.Size = new Size(852, 564);
            tabPageNewBook.TabIndex = 0;
            tabPageNewBook.Text = "Новая книга";
            tabPageNewBook.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Location = new Point(180, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(280, 31);
            txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.ImageAlign = ContentAlignment.TopRight;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(141, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Название книги";
            // 
            // tabPageStore
            // 
            tabPageStore.Controls.Add(panelMiddle);
            tabPageStore.Controls.Add(panelTop);
            tabPageStore.Location = new Point(4, 48);
            tabPageStore.Name = "tabPageStore";
            tabPageStore.Padding = new Padding(3);
            tabPageStore.Size = new Size(852, 564);
            tabPageStore.TabIndex = 1;
            tabPageStore.Text = "Магазин";
            tabPageStore.UseVisualStyleBackColor = true;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(20, 60);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(67, 25);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Автор:";
            // 
            // txtAuthor
            // 
            txtAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAuthor.Location = new Point(180, 60);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(280, 31);
            txtAuthor.TabIndex = 3;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(20, 100);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(62, 25);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "Жанр:";
            // 
            // txtGenre
            // 
            txtGenre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGenre.Location = new Point(180, 100);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(280, 31);
            txtGenre.TabIndex = 5;
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Location = new Point(20, 140);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(145, 25);
            lblPages.TabIndex = 6;
            lblPages.Text = "Кол-во страниц:";
            // 
            // txtPages
            // 
            txtPages.Location = new Point(180, 140);
            txtPages.MaxLength = 10;
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(100, 31);
            txtPages.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 180);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(57, 25);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Цена:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(180, 180);
            txtPrice.MaxLength = 10;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 31);
            txtPrice.TabIndex = 9;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.Transparent;
            btnGenerate.Location = new Point(20, 230);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(200, 40);
            btnGenerate.TabIndex = 10;
            btnGenerate.Text = "Случайная генерация";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.Transparent;
            btnAddBook.Location = new Point(240, 230);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(200, 40);
            btnAddBook.TabIndex = 11;
            btnAddBook.Text = "Добавить книгу";
            btnAddBook.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(cmbGeneres);
            panelTop.Controls.Add(lblGenereSelect);
            panelTop.Controls.Add(lblBalance);
            panelTop.Controls.Add(lblBalanceCaption);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(846, 80);
            panelTop.TabIndex = 0;
            // 
            // lblBalanceCaption
            // 
            lblBalanceCaption.AutoSize = true;
            lblBalanceCaption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblBalanceCaption.Location = new Point(20, 10);
            lblBalanceCaption.Name = "lblBalanceCaption";
            lblBalanceCaption.Size = new Size(169, 28);
            lblBalanceCaption.TabIndex = 0;
            lblBalanceCaption.Text = "Баланс магазина:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblBalance.Location = new Point(20, 40);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(66, 28);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "0 руб.";
            // 
            // lblGenereSelect
            // 
            lblGenereSelect.AutoSize = true;
            lblGenereSelect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblGenereSelect.Location = new Point(300, 15);
            lblGenereSelect.Name = "lblGenereSelect";
            lblGenereSelect.Size = new Size(159, 28);
            lblGenereSelect.TabIndex = 2;
            lblGenereSelect.Text = "Выберите жанр:";
            // 
            // cmbGeneres
            // 
            cmbGeneres.FormattingEnabled = true;
            cmbGeneres.Location = new Point(300, 40);
            cmbGeneres.Name = "cmbGeneres";
            cmbGeneres.Size = new Size(250, 33);
            cmbGeneres.TabIndex = 3;
            // 
            // panelMiddle
            // 
            panelMiddle.Controls.Add(panelBottom);
            panelMiddle.Controls.Add(txtSearch);
            panelMiddle.Controls.Add(panelSearch);
            panelMiddle.Dock = DockStyle.Fill;
            panelMiddle.Location = new Point(3, 83);
            panelMiddle.Name = "panelMiddle";
            panelMiddle.Size = new Size(846, 478);
            panelMiddle.TabIndex = 1;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(lstBooks);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(846, 50);
            panelSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(10, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 31);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Поиск по названию или ID...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Right;
            btnSearch.Location = new Point(746, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 50);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // lstBooks
            // 
            lstBooks.FormattingEnabled = true;
            lstBooks.ItemHeight = 25;
            lstBooks.Location = new Point(0, 0);
            lstBooks.Name = "lstBooks";
            lstBooks.Size = new Size(746, 50);
            lstBooks.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnSell);
            panelBottom.Controls.Add(lblBookInfo);
            panelBottom.Controls.Add(lblInfoCaption);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 328);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(846, 150);
            panelBottom.TabIndex = 2;
            // 
            // lblInfoCaption
            // 
            lblInfoCaption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblInfoCaption.AutoSize = true;
            lblInfoCaption.Location = new Point(20, 10);
            lblInfoCaption.Name = "lblInfoCaption";
            lblInfoCaption.Size = new Size(191, 25);
            lblInfoCaption.TabIndex = 0;
            lblInfoCaption.Text = "Информация о книге:";
            // 
            // lblBookInfo
            // 
            lblBookInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblBookInfo.AutoSize = true;
            lblBookInfo.Location = new Point(20, 40);
            lblBookInfo.Name = "lblBookInfo";
            lblBookInfo.Size = new Size(182, 25);
            lblBookInfo.TabIndex = 1;
            lblBookInfo.Text = "Здесь появиться info";
            // 
            // btnSell
            // 
            btnSell.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSell.Enabled = false;
            btnSell.Location = new Point(500, 60);
            btnSell.Name = "btnSell";
            btnSell.Size = new Size(200, 50);
            btnSell.TabIndex = 2;
            btnSell.Text = "Продать книгу";
            btnSell.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(880, 636);
            Controls.Add(tabControlMain);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MaximumSize = new Size(898, 683);
            Name = "MainForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Книжный магазин";
            tabControlMain.ResumeLayout(false);
            tabPageNewBook.ResumeLayout(false);
            tabPageNewBook.PerformLayout();
            tabPageStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMiddle.ResumeLayout(false);
            panelMiddle.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabPageNewBook;
        private TabPage tabPageStore;
        private TextBox txtTitle;
        private Label lblTitle;
        private Label lblAuthor;
        private TextBox txtGenre;
        private Label lblGenre;
        private TextBox txtAuthor;
        private TextBox txtPages;
        private Label lblPages;
        private TextBox txtPrice;
        private Label lblPrice;
        private Button btnGenerate;
        private Button btnAddBook;
        private ErrorProvider errorProvider1;
        private Panel panelTop;
        private Label lblBalanceCaption;
        private Label lblGenereSelect;
        private Label lblBalance;
        private ComboBox cmbGeneres;
        private Panel panelMiddle;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstBooks;
        private Panel panelBottom;
        private Label lblBookInfo;
        private Label lblInfoCaption;
        private Button btnSell;
    }
}