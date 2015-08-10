namespace srtToTxt
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtNameFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.rbAcapoOgni10 = new System.Windows.Forms.RadioButton();
            this.rbACapoOgniRiga = new System.Windows.Forms.RadioButton();
            this.rbSenzaACapo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtNameFile
            // 
            this.txtNameFile.AllowDrop = true;
            this.txtNameFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameFile.Location = new System.Drawing.Point(12, 12);
            this.txtNameFile.Name = "txtNameFile";
            this.txtNameFile.Size = new System.Drawing.Size(204, 20);
            this.txtNameFile.TabIndex = 0;
            this.txtNameFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.txtNameFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(222, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Select srt file";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = global::srtToTxt.Properties.Resources.Export;
            this.btnExport.Location = new System.Drawing.Point(171, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(126, 118);
            this.btnExport.TabIndex = 2;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // rbAcapoOgni10
            // 
            this.rbAcapoOgni10.AutoSize = true;
            this.rbAcapoOgni10.Checked = true;
            this.rbAcapoOgni10.Location = new System.Drawing.Point(12, 38);
            this.rbAcapoOgni10.Name = "rbAcapoOgni10";
            this.rbAcapoOgni10.Size = new System.Drawing.Size(123, 17);
            this.rbAcapoOgni10.TabIndex = 5;
            this.rbAcapoOgni10.TabStop = true;
            this.rbAcapoOgni10.Text = "A capo ogni 10 righe";
            this.rbAcapoOgni10.UseVisualStyleBackColor = true;
            // 
            // rbACapoOgniRiga
            // 
            this.rbACapoOgniRiga.AutoSize = true;
            this.rbACapoOgniRiga.Location = new System.Drawing.Point(12, 61);
            this.rbACapoOgniRiga.Name = "rbACapoOgniRiga";
            this.rbACapoOgniRiga.Size = new System.Drawing.Size(102, 17);
            this.rbACapoOgniRiga.TabIndex = 6;
            this.rbACapoOgniRiga.Text = "A capo ogni riga";
            this.rbACapoOgniRiga.UseVisualStyleBackColor = true;
            // 
            // rbSenzaACapo
            // 
            this.rbSenzaACapo.AutoSize = true;
            this.rbSenzaACapo.Location = new System.Drawing.Point(12, 85);
            this.rbSenzaACapo.Name = "rbSenzaACapo";
            this.rbSenzaACapo.Size = new System.Drawing.Size(145, 17);
            this.rbSenzaACapo.TabIndex = 7;
            this.rbSenzaACapo.Text = "Tutto un file senza acapo";
            this.rbSenzaACapo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 171);
            this.Controls.Add(this.rbSenzaACapo);
            this.Controls.Add(this.rbACapoOgniRiga);
            this.Controls.Add(this.rbAcapoOgni10);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtNameFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(325, 210);
            this.Name = "Form1";
            this.Text = "Srt to text";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton rbAcapoOgni10;
        private System.Windows.Forms.RadioButton rbACapoOgniRiga;
        private System.Windows.Forms.RadioButton rbSenzaACapo;
    }
}

