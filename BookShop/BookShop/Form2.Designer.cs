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
            tabPageOrderBook = new TabPage();
            btnAddBook = new Button();
            btnGenerate = new Button();
            txtPrice = new TextBox();
            lblPrice = new Label();
            txtPages = new TextBox();
            lblPages = new Label();
            txtGenre = new TextBox();
            lblGenre = new Label();
            txtAuthor = new TextBox();
            lblAuthor = new Label();
            txtTitle = new TextBox();
            lblTitle = new Label();
            tabPageStore = new TabPage();
            panelMiddle = new Panel();
            panelBottom = new Panel();
            btnSell = new Button();
            lblBookInfo = new Label();
            lblInfoCaption = new Label();
            panelSearch = new Panel();
            btnSearch = new Button();
            lstBooks = new ListBox();
            txtSearch = new TextBox();
            panelTop = new Panel();
            cmbGeneres = new ComboBox();
            lblGenereSelect = new Label();
            lblBalance = new Label();
            lblBalanceCaption = new Label();
            errorProvider1 = new ErrorProvider(components);
            lblUnhappyCaption = new Label();
            tabPageDeliveries = new TabPage();
            lstDeliveries = new ListBox();
            lblDeliveryInfo = new Label();
            btnAccept = new Button();
            btnReject = new Button();
            rbPlagiat = new RadioButton();
            rbTypo = new RadioButton();
            lblOrderedMark = new Label();
            lblUnhappyCount = new Label();
            tabPageCustomers = new TabPage();
            lstCustomers = new ListBox();
            lblCustomerRequest = new Label();
            txtCustomerSearch = new TextBox();
            btnFindBook = new Button();
            lblMaxPrice = new Label();
            txtSellPrice = new TextBox();
            btnSellToCustomer = new Button();
            btnRefuseCustomer = new Button();
            lblQueueInfo = new Label();
            tabControlMain.SuspendLayout();
            tabPageOrderBook.SuspendLayout();
            tabPageStore.SuspendLayout();
            panelMiddle.SuspendLayout();
            panelBottom.SuspendLayout();
            panelSearch.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            tabPageDeliveries.SuspendLayout();
            tabPageCustomers.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageOrderBook);
            tabControlMain.Controls.Add(tabPageStore);
            tabControlMain.Controls.Add(tabPageDeliveries);
            tabControlMain.Controls.Add(tabPageCustomers);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControlMain.Location = new Point(10, 10);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new Point(10, 10);
            tabControlMain.RightToLeftLayout = true;
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(860, 616);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageOrderBook
            // 
            tabPageOrderBook.BackColor = Color.BurlyWood;
            tabPageOrderBook.BackgroundImageLayout = ImageLayout.Zoom;
            tabPageOrderBook.Controls.Add(btnAddBook);
            tabPageOrderBook.Controls.Add(btnGenerate);
            tabPageOrderBook.Controls.Add(txtPrice);
            tabPageOrderBook.Controls.Add(lblPrice);
            tabPageOrderBook.Controls.Add(txtPages);
            tabPageOrderBook.Controls.Add(lblPages);
            tabPageOrderBook.Controls.Add(txtGenre);
            tabPageOrderBook.Controls.Add(lblGenre);
            tabPageOrderBook.Controls.Add(txtAuthor);
            tabPageOrderBook.Controls.Add(lblAuthor);
            tabPageOrderBook.Controls.Add(txtTitle);
            tabPageOrderBook.Controls.Add(lblTitle);
            tabPageOrderBook.ForeColor = SystemColors.ActiveCaptionText;
            tabPageOrderBook.Location = new Point(4, 48);
            tabPageOrderBook.Name = "tabPageOrderBook";
            tabPageOrderBook.Padding = new Padding(3);
            tabPageOrderBook.Size = new Size(852, 564);
            tabPageOrderBook.TabIndex = 0;
            tabPageOrderBook.Text = "Заказать книгу";
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.Gold;
            btnAddBook.FlatStyle = FlatStyle.Flat;
            btnAddBook.ForeColor = SystemColors.ActiveCaptionText;
            btnAddBook.Location = new Point(240, 230);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(200, 40);
            btnAddBook.TabIndex = 11;
            btnAddBook.Text = "Добавить книгу";
            btnAddBook.UseVisualStyleBackColor = false;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.MediumOrchid;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Location = new Point(20, 230);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(200, 40);
            btnGenerate.TabIndex = 10;
            btnGenerate.Text = "Случайная генерация";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // txtPrice
            // 
            txtPrice.BackColor = SystemColors.Info;
            txtPrice.Location = new Point(180, 180);
            txtPrice.MaxLength = 10;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 31);
            txtPrice.TabIndex = 9;
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
            // txtPages
            // 
            txtPages.BackColor = SystemColors.Info;
            txtPages.Location = new Point(180, 140);
            txtPages.MaxLength = 10;
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(100, 31);
            txtPages.TabIndex = 7;
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
            // txtGenre
            // 
            txtGenre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGenre.BackColor = SystemColors.Info;
            txtGenre.Location = new Point(180, 100);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(280, 31);
            txtGenre.TabIndex = 5;
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
            // txtAuthor
            // 
            txtAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAuthor.BackColor = SystemColors.Info;
            txtAuthor.Location = new Point(180, 60);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(280, 31);
            txtAuthor.TabIndex = 3;
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
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.BackColor = SystemColors.Info;
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
            tabPageStore.BackColor = Color.BurlyWood;
            tabPageStore.Controls.Add(panelMiddle);
            tabPageStore.Controls.Add(panelTop);
            tabPageStore.Location = new Point(4, 48);
            tabPageStore.Name = "tabPageStore";
            tabPageStore.Padding = new Padding(3);
            tabPageStore.Size = new Size(852, 564);
            tabPageStore.TabIndex = 1;
            tabPageStore.Text = "Магазин";
            // 
            // panelMiddle
            // 
            panelMiddle.Controls.Add(panelBottom);
            panelMiddle.Controls.Add(panelSearch);
            panelMiddle.Dock = DockStyle.Fill;
            panelMiddle.Location = new Point(3, 83);
            panelMiddle.Name = "panelMiddle";
            panelMiddle.Size = new Size(846, 478);
            panelMiddle.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnSell);
            panelBottom.Controls.Add(lblBookInfo);
            panelBottom.Controls.Add(lblInfoCaption);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 309);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(846, 169);
            panelBottom.TabIndex = 2;
            // 
            // btnSell
            // 
            btnSell.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSell.BackColor = Color.DarkOrange;
            btnSell.Enabled = false;
            btnSell.FlatStyle = FlatStyle.Flat;
            btnSell.Location = new Point(609, 86);
            btnSell.Name = "btnSell";
            btnSell.Size = new Size(200, 50);
            btnSell.TabIndex = 3;
            btnSell.Text = "Продать книгу";
            btnSell.UseVisualStyleBackColor = false;
            btnSell.Click += btnSell_Click;
            // 
            // lblBookInfo
            // 
            lblBookInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblBookInfo.AutoSize = true;
            lblBookInfo.Location = new Point(13, 41);
            lblBookInfo.Name = "lblBookInfo";
            lblBookInfo.Size = new Size(182, 25);
            lblBookInfo.TabIndex = 1;
            lblBookInfo.Text = "Здесь появиться info";
            // 
            // lblInfoCaption
            // 
            lblInfoCaption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblInfoCaption.AutoSize = true;
            lblInfoCaption.Location = new Point(13, 9);
            lblInfoCaption.Name = "lblInfoCaption";
            lblInfoCaption.Size = new Size(191, 25);
            lblInfoCaption.TabIndex = 0;
            lblInfoCaption.Text = "Информация о книге:";
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(lstBooks);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(846, 243);
            panelSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkTurquoise;
            btnSearch.Dock = DockStyle.Right;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(746, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 243);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // lstBooks
            // 
            lstBooks.BackColor = SystemColors.Info;
            lstBooks.FormattingEnabled = true;
            lstBooks.ItemHeight = 25;
            lstBooks.Location = new Point(0, 43);
            lstBooks.Name = "lstBooks";
            lstBooks.Size = new Size(740, 179);
            lstBooks.TabIndex = 1;
            lstBooks.SelectedIndexChanged += lstBooks_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = SystemColors.Info;
            txtSearch.Location = new Point(3, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 31);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Поиск по названию или ID";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Transparent;
            panelTop.Controls.Add(lblUnhappyCount);
            panelTop.Controls.Add(lblUnhappyCaption);
            panelTop.Controls.Add(cmbGeneres);
            panelTop.Controls.Add(lblGenereSelect);
            panelTop.Controls.Add(lblBalance);
            panelTop.Controls.Add(lblBalanceCaption);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(846, 80);
            panelTop.TabIndex = 0;
            panelTop.Paint += panelTop_Paint;
            // 
            // cmbGeneres
            // 
            cmbGeneres.BackColor = SystemColors.Info;
            cmbGeneres.Cursor = Cursors.SizeWE;
            cmbGeneres.FlatStyle = FlatStyle.Flat;
            cmbGeneres.FormattingEnabled = true;
            cmbGeneres.Location = new Point(519, 35);
            cmbGeneres.Name = "cmbGeneres";
            cmbGeneres.Size = new Size(250, 33);
            cmbGeneres.TabIndex = 3;
            cmbGeneres.SelectedIndexChanged += cmbGenres_SelectedIndexChanged;
            // 
            // lblGenereSelect
            // 
            lblGenereSelect.AutoSize = true;
            lblGenereSelect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblGenereSelect.Location = new Point(519, 9);
            lblGenereSelect.Name = "lblGenereSelect";
            lblGenereSelect.Size = new Size(159, 28);
            lblGenereSelect.TabIndex = 2;
            lblGenereSelect.Text = "Выберите жанр:";
            lblGenereSelect.Click += lblGenereSelect_Click;
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
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // lblUnhappyCaption
            // 
            lblUnhappyCaption.AutoSize = true;
            lblUnhappyCaption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUnhappyCaption.Location = new Point(200, 10);
            lblUnhappyCaption.Name = "lblUnhappyCaption";
            lblUnhappyCaption.Size = new Size(288, 28);
            lblUnhappyCaption.TabIndex = 4;
            lblUnhappyCaption.Text = "Неудовлетворенные клиенты:";
            lblUnhappyCaption.Click += lblUnhappyCaption_Click;
            // 
            // tabPageDeliveries
            // 
            tabPageDeliveries.BackColor = Color.BurlyWood;
            tabPageDeliveries.Controls.Add(lblOrderedMark);
            tabPageDeliveries.Controls.Add(rbTypo);
            tabPageDeliveries.Controls.Add(rbPlagiat);
            tabPageDeliveries.Controls.Add(btnReject);
            tabPageDeliveries.Controls.Add(btnAccept);
            tabPageDeliveries.Controls.Add(lblDeliveryInfo);
            tabPageDeliveries.Controls.Add(lstDeliveries);
            tabPageDeliveries.Location = new Point(4, 48);
            tabPageDeliveries.Name = "tabPageDeliveries";
            tabPageDeliveries.Padding = new Padding(3);
            tabPageDeliveries.Size = new Size(852, 564);
            tabPageDeliveries.TabIndex = 2;
            tabPageDeliveries.Text = "Поставки";
            // 
            // lstDeliveries
            // 
            lstDeliveries.BackColor = SystemColors.Info;
            lstDeliveries.Dock = DockStyle.Left;
            lstDeliveries.FormattingEnabled = true;
            lstDeliveries.ItemHeight = 25;
            lstDeliveries.Location = new Point(3, 3);
            lstDeliveries.Name = "lstDeliveries";
            lstDeliveries.Size = new Size(300, 558);
            lstDeliveries.TabIndex = 0;
            // 
            // lblDeliveryInfo
            // 
            lblDeliveryInfo.AutoSize = true;
            lblDeliveryInfo.BorderStyle = BorderStyle.FixedSingle;
            lblDeliveryInfo.Location = new Point(350, 20);
            lblDeliveryInfo.Name = "lblDeliveryInfo";
            lblDeliveryInfo.Size = new Size(189, 27);
            lblDeliveryInfo.TabIndex = 1;
            lblDeliveryInfo.Tag = "";
            lblDeliveryInfo.Text = "Информация о книге";
            // 
            // btnAccept
            // 
            btnAccept.BackColor = Color.YellowGreen;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Location = new Point(350, 250);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(120, 40);
            btnAccept.TabIndex = 2;
            btnAccept.Text = "Принять";
            btnAccept.UseVisualStyleBackColor = false;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.Tomato;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Location = new Point(500, 250);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(120, 40);
            btnReject.TabIndex = 3;
            btnReject.Text = "Отклонить";
            btnReject.UseVisualStyleBackColor = false;
            // 
            // rbPlagiat
            // 
            rbPlagiat.AutoCheck = false;
            rbPlagiat.AutoSize = true;
            rbPlagiat.Location = new Point(350, 300);
            rbPlagiat.Name = "rbPlagiat";
            rbPlagiat.Size = new Size(97, 29);
            rbPlagiat.TabIndex = 4;
            rbPlagiat.Text = "Плагиат";
            rbPlagiat.UseVisualStyleBackColor = true;
            // 
            // rbTypo
            // 
            rbTypo.AutoSize = true;
            rbTypo.Location = new Point(470, 300);
            rbTypo.Name = "rbTypo";
            rbTypo.Size = new Size(110, 29);
            rbTypo.TabIndex = 5;
            rbTypo.TabStop = true;
            rbTypo.Text = "Опечатка";
            rbTypo.UseVisualStyleBackColor = true;
            // 
            // lblOrderedMark
            // 
            lblOrderedMark.AutoSize = true;
            lblOrderedMark.Location = new Point(350, 222);
            lblOrderedMark.Name = "lblOrderedMark";
            lblOrderedMark.Size = new Size(87, 25);
            lblOrderedMark.TabIndex = 6;
            lblOrderedMark.Text = "Заказано";
            lblOrderedMark.Visible = false;
            // 
            // lblUnhappyCount
            // 
            lblUnhappyCount.AutoSize = true;
            lblUnhappyCount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUnhappyCount.Location = new Point(200, 42);
            lblUnhappyCount.Name = "lblUnhappyCount";
            lblUnhappyCount.Size = new Size(26, 31);
            lblUnhappyCount.TabIndex = 5;
            lblUnhappyCount.Text = "0";
            // 
            // tabPageCustomers
            // 
            tabPageCustomers.BackColor = Color.BurlyWood;
            tabPageCustomers.Controls.Add(lblQueueInfo);
            tabPageCustomers.Controls.Add(btnRefuseCustomer);
            tabPageCustomers.Controls.Add(btnSellToCustomer);
            tabPageCustomers.Controls.Add(txtSellPrice);
            tabPageCustomers.Controls.Add(lblMaxPrice);
            tabPageCustomers.Controls.Add(btnFindBook);
            tabPageCustomers.Controls.Add(txtCustomerSearch);
            tabPageCustomers.Controls.Add(lblCustomerRequest);
            tabPageCustomers.Controls.Add(lstCustomers);
            tabPageCustomers.Location = new Point(4, 48);
            tabPageCustomers.Name = "tabPageCustomers";
            tabPageCustomers.Padding = new Padding(3);
            tabPageCustomers.Size = new Size(852, 564);
            tabPageCustomers.TabIndex = 3;
            tabPageCustomers.Text = "Покупатели";
            // 
            // lstCustomers
            // 
            lstCustomers.BackColor = SystemColors.Info;
            lstCustomers.Dock = DockStyle.Left;
            lstCustomers.FormattingEnabled = true;
            lstCustomers.ItemHeight = 25;
            lstCustomers.Items.AddRange(new object[] { "У Вас пока нет ни одного покупателя" });
            lstCustomers.Location = new Point(3, 3);
            lstCustomers.Name = "lstCustomers";
            lstCustomers.Size = new Size(312, 558);
            lstCustomers.TabIndex = 0;
            // 
            // lblCustomerRequest
            // 
            lblCustomerRequest.AutoSize = true;
            lblCustomerRequest.Location = new Point(350, 20);
            lblCustomerRequest.Name = "lblCustomerRequest";
            lblCustomerRequest.Size = new Size(211, 25);
            lblCustomerRequest.TabIndex = 1;
            lblCustomerRequest.Text = "Требование покупателя:";
            // 
            // txtCustomerSearch
            // 
            txtCustomerSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerSearch.BackColor = SystemColors.Info;
            txtCustomerSearch.Location = new Point(350, 50);
            txtCustomerSearch.Name = "txtCustomerSearch";
            txtCustomerSearch.Size = new Size(300, 31);
            txtCustomerSearch.TabIndex = 2;
            // 
            // btnFindBook
            // 
            btnFindBook.BackColor = Color.DarkTurquoise;
            btnFindBook.FlatStyle = FlatStyle.Flat;
            btnFindBook.Location = new Point(350, 90);
            btnFindBook.Name = "btnFindBook";
            btnFindBook.Size = new Size(150, 35);
            btnFindBook.TabIndex = 3;
            btnFindBook.Text = "Найти книгу";
            btnFindBook.UseVisualStyleBackColor = false;
            // 
            // lblMaxPrice
            // 
            lblMaxPrice.AutoSize = true;
            lblMaxPrice.Location = new Point(350, 135);
            lblMaxPrice.Name = "lblMaxPrice";
            lblMaxPrice.Size = new Size(234, 25);
            lblMaxPrice.TabIndex = 4;
            lblMaxPrice.Text = "Максимальная цена: 0 руб.";
            lblMaxPrice.Visible = false;
            // 
            // txtSellPrice
            // 
            txtSellPrice.BackColor = SystemColors.Info;
            txtSellPrice.Location = new Point(350, 170);
            txtSellPrice.Name = "txtSellPrice";
            txtSellPrice.Size = new Size(150, 31);
            txtSellPrice.TabIndex = 5;
            // 
            // btnSellToCustomer
            // 
            btnSellToCustomer.BackColor = Color.DarkOrange;
            btnSellToCustomer.FlatStyle = FlatStyle.Flat;
            btnSellToCustomer.Location = new Point(350, 210);
            btnSellToCustomer.Name = "btnSellToCustomer";
            btnSellToCustomer.Size = new Size(150, 40);
            btnSellToCustomer.TabIndex = 6;
            btnSellToCustomer.Text = "Продать";
            btnSellToCustomer.UseVisualStyleBackColor = false;
            // 
            // btnRefuseCustomer
            // 
            btnRefuseCustomer.BackColor = Color.Tomato;
            btnRefuseCustomer.FlatStyle = FlatStyle.Flat;
            btnRefuseCustomer.Location = new Point(520, 210);
            btnRefuseCustomer.Name = "btnRefuseCustomer";
            btnRefuseCustomer.Size = new Size(150, 40);
            btnRefuseCustomer.TabIndex = 7;
            btnRefuseCustomer.Text = "Отказать";
            btnRefuseCustomer.UseVisualStyleBackColor = false;
            // 
            // lblQueueInfo
            // 
            lblQueueInfo.AutoSize = true;
            lblQueueInfo.Location = new Point(350, 270);
            lblQueueInfo.Name = "lblQueueInfo";
            lblQueueInfo.Size = new Size(130, 25);
            lblQueueInfo.TabIndex = 8;
            lblQueueInfo.Text = "Очередь: 0 / 5";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(880, 636);
            Controls.Add(tabControlMain);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(898, 683);
            Name = "MainForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Книжный магазин";
            tabControlMain.ResumeLayout(false);
            tabPageOrderBook.ResumeLayout(false);
            tabPageOrderBook.PerformLayout();
            tabPageStore.ResumeLayout(false);
            panelMiddle.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            tabPageDeliveries.ResumeLayout(false);
            tabPageDeliveries.PerformLayout();
            tabPageCustomers.ResumeLayout(false);
            tabPageCustomers.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabPageOrderBook;
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
        private Label lblUnhappyCaption;
        private TabPage tabPageDeliveries;
        private ListBox lstDeliveries;
        private Button btnAccept;
        private Label lblDeliveryInfo;
        private RadioButton rbTypo;
        private RadioButton rbPlagiat;
        private Button btnReject;
        private Label lblUnhappyCount;
        private Label lblOrderedMark;
        private TabPage tabPageCustomers;
        private ListBox lstCustomers;
        private TextBox txtCustomerSearch;
        private Label lblCustomerRequest;
        private Button btnSellToCustomer;
        private TextBox txtSellPrice;
        private Label lblMaxPrice;
        private Button btnFindBook;
        private Label lblQueueInfo;
        private Button btnRefuseCustomer;
    }
}