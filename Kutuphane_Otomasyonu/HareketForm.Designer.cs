namespace Kutuphane_Otomasyonu
{
    partial class HareketForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUyeler = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKitaplar = new System.Windows.Forms.ComboBox();
            this.dateIade = new System.Windows.Forms.DateTimePicker();
            this.btnOduncVer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCeza = new System.Windows.Forms.Label();
            this.txtHareketID = new System.Windows.Forms.TextBox();
            this.btnIadeAl = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üye Seçin";
            // 
            // cmbUyeler
            // 
            this.cmbUyeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUyeler.FormattingEnabled = true;
            this.cmbUyeler.Location = new System.Drawing.Point(122, 26);
            this.cmbUyeler.Name = "cmbUyeler";
            this.cmbUyeler.Size = new System.Drawing.Size(121, 24);
            this.cmbUyeler.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kitap Seçin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "İade Tarihi:";
            // 
            // cmbKitaplar
            // 
            this.cmbKitaplar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKitaplar.FormattingEnabled = true;
            this.cmbKitaplar.Location = new System.Drawing.Point(122, 82);
            this.cmbKitaplar.Name = "cmbKitaplar";
            this.cmbKitaplar.Size = new System.Drawing.Size(121, 24);
            this.cmbKitaplar.TabIndex = 4;
            // 
            // dateIade
            // 
            this.dateIade.Location = new System.Drawing.Point(122, 139);
            this.dateIade.Name = "dateIade";
            this.dateIade.Size = new System.Drawing.Size(200, 22);
            this.dateIade.TabIndex = 5;
            // 
            // btnOduncVer
            // 
            this.btnOduncVer.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOduncVer.Location = new System.Drawing.Point(25, 187);
            this.btnOduncVer.Name = "btnOduncVer";
            this.btnOduncVer.Size = new System.Drawing.Size(149, 55);
            this.btnOduncVer.TabIndex = 6;
            this.btnOduncVer.Text = "ÖDÜNÇ VER";
            this.btnOduncVer.UseVisualStyleBackColor = false;
            this.btnOduncVer.Click += new System.EventHandler(this.btnOduncVer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(508, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gecikme Cezası:";
            // 
            // lblCeza
            // 
            this.lblCeza.AutoSize = true;
            this.lblCeza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCeza.Location = new System.Drawing.Point(675, 82);
            this.lblCeza.Name = "lblCeza";
            this.lblCeza.Size = new System.Drawing.Size(52, 25);
            this.lblCeza.TabIndex = 8;
            this.lblCeza.Text = "0 TL";
            // 
            // txtHareketID
            // 
            this.txtHareketID.Location = new System.Drawing.Point(795, 187);
            this.txtHareketID.Name = "txtHareketID";
            this.txtHareketID.Size = new System.Drawing.Size(100, 22);
            this.txtHareketID.TabIndex = 9;
            this.txtHareketID.Visible = false;
            // 
            // btnIadeAl
            // 
            this.btnIadeAl.BackColor = System.Drawing.Color.DarkOrange;
            this.btnIadeAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIadeAl.Location = new System.Drawing.Point(194, 187);
            this.btnIadeAl.Name = "btnIadeAl";
            this.btnIadeAl.Size = new System.Drawing.Size(160, 55);
            this.btnIadeAl.TabIndex = 10;
            this.btnIadeAl.Text = "İADE AL ";
            this.btnIadeAl.UseVisualStyleBackColor = false;
            this.btnIadeAl.Click += new System.EventHandler(this.btnIadeAl_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 278);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(702, 150);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // HareketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnIadeAl);
            this.Controls.Add(this.txtHareketID);
            this.Controls.Add(this.lblCeza);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOduncVer);
            this.Controls.Add(this.dateIade);
            this.Controls.Add(this.cmbKitaplar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUyeler);
            this.Controls.Add(this.label1);
            this.Name = "HareketForm";
            this.Text = "Ödünç / İade İşlemleri";
            this.Load += new System.EventHandler(this.HareketForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUyeler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKitaplar;
        private System.Windows.Forms.DateTimePicker dateIade;
        private System.Windows.Forms.Button btnOduncVer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCeza;
        private System.Windows.Forms.TextBox txtHareketID;
        private System.Windows.Forms.Button btnIadeAl;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}