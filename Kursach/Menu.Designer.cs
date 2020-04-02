namespace Kursach
{
    partial class menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.судентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.полученнаяПодготовкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вУСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вУЗToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналПризывниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.журналToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.судентыToolStripMenuItem,
            this.полученнаяПодготовкаToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.справочникToolStripMenuItem.Text = "Данные";
            // 
            // судентыToolStripMenuItem
            // 
            this.судентыToolStripMenuItem.Name = "судентыToolStripMenuItem";
            this.судентыToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.судентыToolStripMenuItem.Text = "Студенты";
            this.судентыToolStripMenuItem.Click += new System.EventHandler(this.судентыToolStripMenuItem_Click);
            // 
            // полученнаяПодготовкаToolStripMenuItem
            // 
            this.полученнаяПодготовкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вУСToolStripMenuItem,
            this.вУЗToolStripMenuItem});
            this.полученнаяПодготовкаToolStripMenuItem.Name = "полученнаяПодготовкаToolStripMenuItem";
            this.полученнаяПодготовкаToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.полученнаяПодготовкаToolStripMenuItem.Text = "Полученная подготовка";
            // 
            // вУСToolStripMenuItem
            // 
            this.вУСToolStripMenuItem.Name = "вУСToolStripMenuItem";
            this.вУСToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.вУСToolStripMenuItem.Text = "ВУС";
            this.вУСToolStripMenuItem.Click += new System.EventHandler(this.вУСToolStripMenuItem_Click);
            // 
            // вУЗToolStripMenuItem
            // 
            this.вУЗToolStripMenuItem.Name = "вУЗToolStripMenuItem";
            this.вУЗToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.вУЗToolStripMenuItem.Text = "ВУЗ";
            this.вУЗToolStripMenuItem.Click += new System.EventHandler(this.вУЗToolStripMenuItem_Click);
            // 
            // журналToolStripMenuItem
            // 
            this.журналToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.журналПризывниковToolStripMenuItem});
            this.журналToolStripMenuItem.Name = "журналToolStripMenuItem";
            this.журналToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.журналToolStripMenuItem.Text = "Журнал";
            // 
            // журналПризывниковToolStripMenuItem
            // 
            this.журналПризывниковToolStripMenuItem.Name = "журналПризывниковToolStripMenuItem";
            this.журналПризывниковToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.журналПризывниковToolStripMenuItem.Text = "Журнал призывников";
            this.журналПризывниковToolStripMenuItem.Click += new System.EventHandler(this.журналПризывниковToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "menu";
            this.Text = "Меню";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem судентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналПризывниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem полученнаяПодготовкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вУСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вУЗToolStripMenuItem;
    }
}

