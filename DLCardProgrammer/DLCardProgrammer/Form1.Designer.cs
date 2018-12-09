namespace DLCardProgrammer
{
    partial class Form1
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
            this.lblPort = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaudrate = new System.Windows.Forms.ComboBox();
            this.btnLoadProgram = new System.Windows.Forms.Button();
            this.btnViewCode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTypeProgram = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProgram = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnUpdatePorts = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.txtNumbytes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(15, 18);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(52, 13);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "PUERTO";
            this.lblPort.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "BAUDRATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "CARGAR PROGRAMA";
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(150, 15);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(139, 21);
            this.cmbPort.TabIndex = 3;
            // 
            // cmbBaudrate
            // 
            this.cmbBaudrate.FormattingEnabled = true;
            this.cmbBaudrate.Location = new System.Drawing.Point(150, 43);
            this.cmbBaudrate.Name = "cmbBaudrate";
            this.cmbBaudrate.Size = new System.Drawing.Size(139, 21);
            this.cmbBaudrate.TabIndex = 4;
            // 
            // btnLoadProgram
            // 
            this.btnLoadProgram.Location = new System.Drawing.Point(150, 70);
            this.btnLoadProgram.Name = "btnLoadProgram";
            this.btnLoadProgram.Size = new System.Drawing.Size(139, 23);
            this.btnLoadProgram.TabIndex = 5;
            this.btnLoadProgram.Text = "Cargar programa";
            this.btnLoadProgram.UseVisualStyleBackColor = true;
            this.btnLoadProgram.Click += new System.EventHandler(this.btnLoadProgram_Click);
            // 
            // btnViewCode
            // 
            this.btnViewCode.Location = new System.Drawing.Point(150, 99);
            this.btnViewCode.Name = "btnViewCode";
            this.btnViewCode.Size = new System.Drawing.Size(139, 23);
            this.btnViewCode.TabIndex = 6;
            this.btnViewCode.Text = "Ver el codigo";
            this.btnViewCode.UseVisualStyleBackColor = true;
            this.btnViewCode.Click += new System.EventHandler(this.btnViewCode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "VER EL PROGRAMA";
            // 
            // cmbTypeProgram
            // 
            this.cmbTypeProgram.FormattingEnabled = true;
            this.cmbTypeProgram.Location = new System.Drawing.Point(150, 128);
            this.cmbTypeProgram.Name = "cmbTypeProgram";
            this.cmbTypeProgram.Size = new System.Drawing.Size(139, 21);
            this.cmbTypeProgram.TabIndex = 8;
            this.cmbTypeProgram.SelectedIndexChanged += new System.EventHandler(this.cmbTypeProgram_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "FORMA DE ENVIO ";
            // 
            // btnProgram
            // 
            this.btnProgram.Location = new System.Drawing.Point(150, 155);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(139, 23);
            this.btnProgram.TabIndex = 10;
            this.btnProgram.Text = "Programar Tarjeta";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "PROGRAMAR";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(313, 70);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 137);
            this.txtName.TabIndex = 12;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(313, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 23);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnUpdatePorts
            // 
            this.btnUpdatePorts.Location = new System.Drawing.Point(404, 12);
            this.btnUpdatePorts.Name = "btnUpdatePorts";
            this.btnUpdatePorts.Size = new System.Drawing.Size(85, 23);
            this.btnUpdatePorts.TabIndex = 14;
            this.btnUpdatePorts.Text = "Actualizar";
            this.btnUpdatePorts.UseVisualStyleBackColor = true;
            this.btnUpdatePorts.Click += new System.EventHandler(this.btnUpdatePorts_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "PROGRESO";
            // 
            // pbLoad
            // 
            this.pbLoad.Location = new System.Drawing.Point(150, 184);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(139, 23);
            this.pbLoad.TabIndex = 16;
            // 
            // txtNumbytes
            // 
            this.txtNumbytes.Location = new System.Drawing.Point(313, 42);
            this.txtNumbytes.Name = "txtNumbytes";
            this.txtNumbytes.Size = new System.Drawing.Size(246, 20);
            this.txtNumbytes.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(585, 234);
            this.Controls.Add(this.txtNumbytes);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnUpdatePorts);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnProgram);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTypeProgram);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnViewCode);
            this.Controls.Add(this.btnLoadProgram);
            this.Controls.Add(this.cmbBaudrate);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPort);
            this.Name = "Form1";
            this.Text = "DL Programador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaudrate;
        private System.Windows.Forms.Button btnLoadProgram;
        private System.Windows.Forms.Button btnViewCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTypeProgram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnUpdatePorts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar pbLoad;
        private System.Windows.Forms.TextBox txtNumbytes;
    }
}

