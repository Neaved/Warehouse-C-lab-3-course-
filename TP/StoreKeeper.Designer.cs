namespace TP
{
    partial class StoreKeeper
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
            this.components = new System.ComponentModel.Container();
            this.errorList = new System.Windows.Forms.TabPage();
            this.listBox8 = new System.Windows.Forms.ListBox();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.toStockList = new System.Windows.Forms.TabPage();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.courierList = new System.Windows.Forms.TabPage();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timerClient = new System.Windows.Forms.Timer(this.components);
            this.timerProvider = new System.Windows.Forms.Timer(this.components);
            this.timerError = new System.Windows.Forms.Timer(this.components);
            this.errorList.SuspendLayout();
            this.toStockList.SuspendLayout();
            this.courierList.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorList
            // 
            this.errorList.BackColor = System.Drawing.Color.Silver;
            this.errorList.Controls.Add(this.listBox8);
            this.errorList.Controls.Add(this.listBox7);
            this.errorList.Location = new System.Drawing.Point(4, 28);
            this.errorList.Name = "errorList";
            this.errorList.Size = new System.Drawing.Size(705, 530);
            this.errorList.TabIndex = 3;
            this.errorList.Tag = "3";
            this.errorList.Text = "Список ошибок";
            // 
            // listBox8
            // 
            this.listBox8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox8.FormattingEnabled = true;
            this.listBox8.ItemHeight = 19;
            this.listBox8.Location = new System.Drawing.Point(12, 30);
            this.listBox8.Name = "listBox8";
            this.listBox8.ScrollAlwaysVisible = true;
            this.listBox8.Size = new System.Drawing.Size(680, 479);
            this.listBox8.TabIndex = 4;
            this.listBox8.SelectedIndexChanged += new System.EventHandler(this.listBox8_SelectedIndexChanged);
            this.listBox8.DoubleClick += new System.EventHandler(this.listBox8_DoubleClick);
            // 
            // listBox7
            // 
            this.listBox7.Enabled = false;
            this.listBox7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox7.FormattingEnabled = true;
            this.listBox7.ItemHeight = 19;
            this.listBox7.Items.AddRange(new object[] {
            "№ заказа | Клиент               | Заказ "});
            this.listBox7.Location = new System.Drawing.Point(12, 7);
            this.listBox7.Name = "listBox7";
            this.listBox7.Size = new System.Drawing.Size(680, 23);
            this.listBox7.TabIndex = 3;
            // 
            // toStockList
            // 
            this.toStockList.BackColor = System.Drawing.Color.Silver;
            this.toStockList.Controls.Add(this.listBox6);
            this.toStockList.Controls.Add(this.listBox5);
            this.toStockList.Location = new System.Drawing.Point(4, 28);
            this.toStockList.Name = "toStockList";
            this.toStockList.Size = new System.Drawing.Size(705, 530);
            this.toStockList.TabIndex = 2;
            this.toStockList.Tag = "2";
            this.toStockList.Text = "Список доставок";
            // 
            // listBox6
            // 
            this.listBox6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox6.FormattingEnabled = true;
            this.listBox6.ItemHeight = 19;
            this.listBox6.Location = new System.Drawing.Point(12, 30);
            this.listBox6.Name = "listBox6";
            this.listBox6.ScrollAlwaysVisible = true;
            this.listBox6.Size = new System.Drawing.Size(680, 479);
            this.listBox6.TabIndex = 2;
            this.listBox6.SelectedIndexChanged += new System.EventHandler(this.listBox6_SelectedIndexChanged);
            this.listBox6.DoubleClick += new System.EventHandler(this.listBox6_DoubleClick);
            // 
            // listBox5
            // 
            this.listBox5.Enabled = false;
            this.listBox5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 19;
            this.listBox5.Items.AddRange(new object[] {
            "№ заказа | Поставщик            | Заказ "});
            this.listBox5.Location = new System.Drawing.Point(12, 7);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(680, 23);
            this.listBox5.TabIndex = 1;
            // 
            // courierList
            // 
            this.courierList.BackColor = System.Drawing.Color.Silver;
            this.courierList.Controls.Add(this.listBox4);
            this.courierList.Controls.Add(this.listBox3);
            this.courierList.Location = new System.Drawing.Point(4, 28);
            this.courierList.Name = "courierList";
            this.courierList.Padding = new System.Windows.Forms.Padding(3);
            this.courierList.Size = new System.Drawing.Size(705, 530);
            this.courierList.TabIndex = 1;
            this.courierList.Tag = "1";
            this.courierList.Text = "Список отправки";
            // 
            // listBox4
            // 
            this.listBox4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 19;
            this.listBox4.Location = new System.Drawing.Point(12, 30);
            this.listBox4.Name = "listBox4";
            this.listBox4.ScrollAlwaysVisible = true;
            this.listBox4.Size = new System.Drawing.Size(680, 479);
            this.listBox4.TabIndex = 3;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            this.listBox4.DoubleClick += new System.EventHandler(this.listBox4_DoubleClick);
            // 
            // listBox3
            // 
            this.listBox3.Enabled = false;
            this.listBox3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 19;
            this.listBox3.Items.AddRange(new object[] {
            "№ заказа | Клиент               | Заказ "});
            this.listBox3.Location = new System.Drawing.Point(12, 7);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(680, 23);
            this.listBox3.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.courierList);
            this.tabControl1.Controls.Add(this.toStockList);
            this.tabControl1.Controls.Add(this.errorList);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(-5, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 562);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(705, 530);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timerClient
            // 
            this.timerClient.Interval = 10000;
            this.timerClient.Tick += new System.EventHandler(this.timerClient_Tick);
            // 
            // timerProvider
            // 
            this.timerProvider.Interval = 10000;
            this.timerProvider.Tick += new System.EventHandler(this.timerProvider_Tick);
            // 
            // timerError
            // 
            this.timerError.Interval = 10000;
            this.timerError.Tick += new System.EventHandler(this.timerError_Tick);
            // 
            // StoreKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(704, 561);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StoreKeeper";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервис Кладовщика";
            this.errorList.ResumeLayout(false);
            this.toStockList.ResumeLayout(false);
            this.courierList.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage errorList;
        private System.Windows.Forms.TabPage toStockList;
        private System.Windows.Forms.TabPage courierList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox listBox8;
        private System.Windows.Forms.ListBox listBox7;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Timer timerClient;
        private System.Windows.Forms.Timer timerProvider;
        private System.Windows.Forms.Timer timerError;
        private System.Windows.Forms.TabPage tabPage1;
    }
}