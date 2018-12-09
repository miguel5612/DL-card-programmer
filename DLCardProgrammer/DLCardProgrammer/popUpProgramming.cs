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
        public string programa,mode;
        public int numBytes = 0;
        public SerialPort sendPort;
        public popUpProgramming(string _programa,string  __mode,int __bytes, SerialPort ArduinoPort)
        {
            programa = _programa;
            mode = __mode;
            numBytes = __bytes;
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync() ;
            sendPort = ArduinoPort;
        }
        private void popUpProgramming_Load(object sender, EventArgs e)
        {
           
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            txtProgram.Text += e.UserState;
            txtProgram.ScrollToCaret();
        }
        private void txtProgram_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (programa != "")
                {
                    var txt = "";
                    char sep = '\r';
                    int milliseconds = 10;
                    //Voy a enviar caracter por caractercmbSendMode.Items.Add("Byte-Byte (DEC)");
                    if (mode == "(HEX) Byte a Byte")
                    {
                        string text = programa;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int b = 0; b <= numBytes - 1; b++)
                        {
                            string character = text.Substring(b, 1);
                            sendPort.WriteLine(character.ToString());
                            backgroundWorker1.ReportProgress(b, character.ToString() + "\r\n");
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }
                    else if(mode == "(DEC) Byte a Byte")
                    {
                        string text = programa;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int b = 0; b <= numBytes - 1; b++)
                        {
                            string character = text.Substring(b, 1);
                            int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                            sendPort.WriteLine(caracter.ToString());
                            backgroundWorker1.ReportProgress(b,caracter.ToString() + "\r\n");
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
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
            }
        }
    }
}
