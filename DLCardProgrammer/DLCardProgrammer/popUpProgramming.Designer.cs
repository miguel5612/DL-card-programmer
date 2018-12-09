namespace DLCardProgrammer
{
    partial class popUpProgramming
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
            this.PBProgress = new System.Windows.Forms.ProgressBar();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // PBProgress
            // 
            this.PBProgress.Location = new System.Drawing.Point(164, 458);
            this.PBProgress.Name = "PBProgress";
            this.PBProgress.Size = new System.Drawing.Size(616, 23);
            this.PBProgress.TabIndex = 4;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // txtProgram
            // 
            this.txtProgram.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtProgram.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtProgram.Location = new System.Drawing.Point(77, 62);
            this.txtProgram.Multiline = true;
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.Size = new System.Drawing.Size(703, 355);
            this.txtProgram.TabIndex = 0;
            this.txtProgram.TextChanged += new System.EventHandler(this.txtProgram_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PROGRAMA ENVIADO POR EL PUERTO SERIE";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(142, 432);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(638, 20);
            this.txtError.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ERROR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "PROGRESO:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(164, 487);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "btnExit";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // popUpProgramming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(888, 515);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PBProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProgram);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "popUpProgramming";
            this.Text = "º";
            this.Load += new System.EventHandler(this.popUpProgramming_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtError;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar PBProgress;
        private System.Windows.Forms.Button btnCancelar;
    }
}