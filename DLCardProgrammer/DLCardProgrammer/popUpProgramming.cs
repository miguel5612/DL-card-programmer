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
        public string programa,mode, program2Send;
        public int numBytes = 0;
        public bool lengthAdd = false;
        public SerialPort sendPort;
        public popUpProgramming(string _programa,string  __mode,int __bytes,Boolean lengthAddVal, SerialPort ArduinoPort)
        {
            InitializeComponent();
            programa = _programa;
            mode = __mode;
            numBytes = __bytes;
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.WorkerReportsProgress = true;
            lengthAdd = lengthAddVal;
            //Tamaño normal
            backgroundWorker1.RunWorkerAsync() ;
            sendPort = ArduinoPort;
            PBProgress.Minimum = 0;
            PBProgress.Maximum = 100;
        }
        private void popUpProgramming_Load(object sender, EventArgs e)
        {
           
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var progress = e.ProgressPercentage>0?(e.ProgressPercentage * 100 / numBytes):0;
            PBProgress.Value = progress;
            txtProgram.Text += e.UserState;
            txtProgram.SelectionStart = txtProgram.Text.Length;
            txtProgram.ScrollToCaret();
            if (progress > 98)
            {
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
                //Close popup
                this.Close();
            }
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
                if (programa != "")
                {
                    var txt = "";
                    char sep = '\r';
                    int milliseconds = 10;
                    /*
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
                    */
                    pFillTexttoSend();
                    string text = program2Send;
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    var avance = lines.Length/100;
                    var cLines = 0;
                    foreach (string line in lines)
                    {
                        cLines+= avance;
                        if(cLines >=100)
                        {
                            cLines = cLines - (2 * avance);
                        }
                        string lineF = line.Replace("\r", "");
                        sendPort.WriteLine(lineF.ToString());
                        backgroundWorker1.ReportProgress(cLines, lineF + "\r\n");
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
            }
        }
        private void pFillTexttoSend()
        {
            string text = programa;
            program2Send = "";
            if (lengthAdd)
            {
                var sendText = "";
                char sep = '\r';
                if (mode.Contains("HEX"))
                {
                    program2Send = numBytes.ToString("X") + "\r\n";
                }
                else
                {
                    program2Send = numBytes.ToString() + "\r\n";
                }
                if (mode == "(HEX) Byte a Byte")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 1; b++)
                    {
                        string character = text.Substring(b, 1);
                        sendText += character + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(DEC) Byte a Byte")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 1; b++)
                    {
                        string character = text.Substring(b, 1);
                        int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                        sendText += caracter + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(HEX) 2 Bytes a 2 Bytes)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 2; b += 2)
                    {
                        string character = text.Substring(b, 2);
                        sendText += character + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(DEC) 2 Bytes a 2 Bytes)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 2; b += 2)
                    {
                        string character = text.Substring(b, 2);
                        int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                        sendText += caracter + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(HEX) 4 Bytes a 4 Bytes")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 4; b += 4)
                    {
                        string character = text.Substring(b, 4);
                        sendText += character + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(DEC) 4 Bytes a 4 Bytes")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 4; b += 4)
                    {
                        string character = text.Substring(b, 4);
                        int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                        sendText += caracter + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(HEX) 6 Bytes a 6 Bytes")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 6; b += 6)
                    {
                        string character = text.Substring(b, 6);
                        sendText += character + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(DEC) 6 Bytes a 6 Bytes")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 6; b += 6)
                    {
                        string character = text.Substring(b, 6);
                        int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                        sendText += caracter + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(HEX) 8 Bytes a 8 Bytes")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 8; b += 8)
                    {
                        string character = text.Substring(b, 8);
                        sendText += character + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(DEC) 8 Bytes a 8 Bytes")
                {
                    text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                    for (int b = 0; b <= numBytes - 8; b += 8)
                    {
                        string character = text.Substring(b, 8);
                        int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                        sendText += caracter + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(HEX) Line to Line (8-Bit)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    foreach (string line in lines)
                    {
                        string lineF = line.Replace("\r", "");
                        for (int j = 0; j <= lineF.Length - 8; j += lineF.Length / 4)
                        {
                            string line8 = lineF.Substring(j, 8);
                            string lineInt = "";
                            for (int i = 0; i <= line8.Length - 1; i++)
                            {
                                lineInt += line8.Substring(i, 1);
                            }
                            sendText += lineInt + "\r\n";
                        }
                        program2Send += sendText;
                    }
                }
                else if (mode == "(DEC) Line to Line (8-Bit)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    foreach (string line in lines)
                    {
                        string lineF = line.Replace("\r", "");
                        for (int j = 0; j <= lineF.Length - 8; j += lineF.Length / 4)
                        {
                            string line8 = lineF.Substring(j, 8);
                            string lineInt = "";
                            for (int i = 0; i <= line8.Length - 1; i++)
                            {
                                lineInt += int.Parse(line8.Substring(i, 1), System.Globalization.NumberStyles.HexNumber);
                            }
                            sendText += lineInt + "\r\n";
                        }
                        program2Send += sendText;
                    }
                }
                else if (mode == "(HEX) Line to Line (16-Bit)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    foreach (string line in lines)
                    {
                        string lineF = line.Replace("\r", "");
                        for (int j = 0; j <= lineF.Length - 16; j += lineF.Length / 2)
                        {
                            string line16 = lineF.Substring(j, 16);
                            string lineInt = "";
                            for (int i = 0; i <= line16.Length - 1; i++)
                            {
                                lineInt += line16.Substring(i, 1);
                            }
                            sendText += lineInt + "\r\n";
                        }
                        program2Send += sendText;
                    }
                }
                else if (mode == "(DEC) Line to Line (16-Bit)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    foreach (string line in lines)
                    {
                        string lineF = line.Replace("\r", "");
                        for (int j = 0; j <= lineF.Length - 16; j += lineF.Length / 2)
                        {
                            string line16 = lineF.Substring(j, 16);
                            string lineInt = "";
                            for (int i = 0; i <= line16.Length - 1; i++)
                            {
                                lineInt += int.Parse(line16.Substring(i, 1), System.Globalization.NumberStyles.HexNumber);
                            }
                            sendText += lineInt + "\r\n";
                        }
                    }
                    program2Send += sendText;
                }
                else if (mode == "(DEC) Line to Line (32-Bit)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    int j = 0;
                    foreach (string line in lines)
                    {
                        string lineF = line.Replace("\r", "");
                        string lineInt = "";
                        for (int i = 0; i <= lineF.Length - 1; i++)
                        {
                            lineInt += int.Parse(lineF.Substring(i, 1), System.Globalization.NumberStyles.HexNumber);
                        }
                        sendText += lineInt + "\r\n";
                    }
                    program2Send += sendText;
                }
                else if (mode == "(HEX) Line to Line (32-Bit)")
                {
                    text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                    string[] lines = text.Split(sep);
                    int j = 0;
                    foreach (string line in lines)
                    {
                        string lineF = line.Replace("\r", "");
                        sendText += lineF + "\r\n";
                    }
                    program2Send += sendText;
                }
            }
        }

    
    }
}
