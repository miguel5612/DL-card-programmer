using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace DLCardProgrammer
{
    public partial class popUpProgramming : Form
    {
        public string mode, program2Send;
        public int numBytes = 0;
        public bool lengthAdd = false;
        public SerialPort sendPort;
        public popUpProgramming(string __mode, int __bytes, Boolean lengthAddVal, string programa, SerialPort ArduinoPort)
        {
            InitializeComponent();
            mode = __mode;
            numBytes = __bytes;
            program2Send = programa;
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            lengthAdd = lengthAddVal;
            //Tamaño normal
            backgroundWorker1.RunWorkerAsync() ;
            sendPort = ArduinoPort;
            PBProgress.Minimum = 0;
            PBProgress.Maximum = 100;
            txtProgram.Font = new Font("Times New Roman", 16);
        }
        private void popUpProgramming_Load(object sender, EventArgs e)
        {
           
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var progress = e.ProgressPercentage>0?e.ProgressPercentage:0;
            PBProgress.Value = progress;
            txtProgram.Text += e.UserState;
            txtProgram.SelectionStart = txtProgram.Text.Trim().Replace(" ", "").Replace("\r\n", "").Length;
            txtProgram.ScrollToCaret();
        }
        private void txtProgram_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            //Close popup
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                if (program2Send != "")
                {
                    char sep = '\r';
                    int milliseconds = 10;
                    string text = program2Send;
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    double len = lines.Length;
                    double avance = 100 / len;
                    double cLines = 0;
                    foreach (string line in lines)
                    {
                        cLines+= avance;
                        if(cLines >=100)
                        {
                            cLines = cLines - (2 * avance);
                        }
                        string lineF = line.Replace("\r", "");
                        sendPort.WriteLine(lineF.ToString());
                        backgroundWorker1.ReportProgress((int)cLines, lineF + "\r\n");
                        Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                    }

                }
                else
                {
                    Form dlg1 = new Form();
                    dlg1.Text = "Debes cargar por lo menos un archivo .Exe";
                    dlg1.Visible = true;
                }

            }
            catch (Exception ex)
            {
                txtError.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            }
        }
}
}
