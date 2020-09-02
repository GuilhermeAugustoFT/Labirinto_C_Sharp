namespace apLabirinto
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.dgvLabirinto = new System.Windows.Forms.DataGridView();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCaminhos = new System.Windows.Forms.Label();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.btnEncontrarCaminhos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabirinto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLabirinto
            // 
            this.dgvLabirinto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabirinto.Location = new System.Drawing.Point(3, 82);
            this.dgvLabirinto.Name = "dgvLabirinto";
            this.dgvLabirinto.Size = new System.Drawing.Size(384, 405);
            this.dgvLabirinto.TabIndex = 0;
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Location = new System.Drawing.Point(418, 82);
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.Size = new System.Drawing.Size(712, 438);
            this.dgvCaminhos.TabIndex = 1;
            this.dgvCaminhos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaminhos_CellContentClick);
            this.dgvCaminhos.SelectionChanged += new System.EventHandler(this.dgvCaminhos_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Labirinto";
            // 
            // lbCaminhos
            // 
            this.lbCaminhos.AutoSize = true;
            this.lbCaminhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaminhos.Location = new System.Drawing.Point(452, 54);
            this.lbCaminhos.Name = "lbCaminhos";
            this.lbCaminhos.Size = new System.Drawing.Size(194, 22);
            this.lbCaminhos.TabIndex = 3;
            this.lbCaminhos.Text = "Caminhos encontrados";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirArquivo.Location = new System.Drawing.Point(758, 21);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(69, 49);
            this.btnAbrirArquivo.TabIndex = 4;
            this.btnAbrirArquivo.Text = "Abrir arquivo";
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            // 
            // btnEncontrarCaminhos
            // 
            this.btnEncontrarCaminhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncontrarCaminhos.Location = new System.Drawing.Point(848, 21);
            this.btnEncontrarCaminhos.Name = "btnEncontrarCaminhos";
            this.btnEncontrarCaminhos.Size = new System.Drawing.Size(75, 49);
            this.btnEncontrarCaminhos.TabIndex = 5;
            this.btnEncontrarCaminhos.Text = "Encontrar caminhos";
            this.btnEncontrarCaminhos.UseVisualStyleBackColor = true;
            this.btnEncontrarCaminhos.Click += new System.EventHandler(this.btnEncontrarCaminhos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 647);
            this.Controls.Add(this.btnEncontrarCaminhos);
            this.Controls.Add(this.btnAbrirArquivo);
            this.Controls.Add(this.lbCaminhos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCaminhos);
            this.Controls.Add(this.dgvLabirinto);
            this.Name = "Form1";
            this.Text = "Caminhos em labirinto";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabirinto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.DataGridView dgvLabirinto;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCaminhos;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.Button btnEncontrarCaminhos;
    }
}

