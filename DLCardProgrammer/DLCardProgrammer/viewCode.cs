using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace DLCardProgrammer
{
    public partial class viewCode : Form
    {
        public string programa, mode, program2Send;
        public int numBytes = 0;
        public SerialPort sendPort;

        public viewCode(string _programa, string __mode, int __bytes, SerialPort ArduinoPort)
        {
            InitializeComponent();
            programa = _programa;
            mode = __mode;
            numBytes = __bytes;
            sendPort = ArduinoPort;
            pfillSendMode();
            pfillexe();
        }
        private void pfillexe()
        {
            txtOriginal.Text = programa;
        }
        private void pfillSendMode()
        {

            cmdSendMode.Items.Add("(HEX) Byte a Byte");
            cmdSendMode.Items.Add("(HEX) 2 Bytes a 2 Bytes)");
            cmdSendMode.Items.Add("(HEX) 4 Bytes a 4 Bytes");
            cmdSendMode.Items.Add("(HEX) 6 Bytes a 6 Bytes");
            cmdSendMode.Items.Add("(HEX) 8 Bytes a 8 Bytes");
            cmdSendMode.Items.Add("(HEX) Line to Line (8-Bit)");
            cmdSendMode.Items.Add("(HEX) Line to Line (16-Bit)");
            cmdSendMode.Items.Add("(HEX) Line to Line (32-Bit)");

            cmdSendMode.Items.Add("(DEC) Byte a Byte");
            cmdSendMode.Items.Add("(DEC) 2 Bytes a 2 Bytes)");
            cmdSendMode.Items.Add("(DEC) 4 Bytes a 4 Bytes");
            cmdSendMode.Items.Add("(DEC) 6 Bytes a 6 Bytes");
            cmdSendMode.Items.Add("(DEC) 8 Bytes a 8 Bytes");
            cmdSendMode.Items.Add("(DEC) Line to Line (8-Bit)");
            cmdSendMode.Items.Add("(DEC) Line to Line (16-Bit)");
            cmdSendMode.Items.Add("(DEC) Line to Line (32-Bit)");

            cmdSendMode.SelectedIndex = cmdSendMode.FindString(mode);
        }

        private void txtOriginal_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdSendMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            pFillTexttoSend();
            txtToSend.Text = program2Send;
        }
        private void pFillTexttoSend()
        {
            mode = cmdSendMode.Text;
            string text = programa;
            program2Send = "";
            if (checkBox1.Checked)
            {
                var sendText = "";
                char sep = '\r';
                if (cmdSendMode.Text.Contains("HEX"))
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


        private void btnProgram_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Ventana emergente     
            Form formularioEmergente = new popUpProgramming(programa, mode, numBytes,checkBox1.Checked, sendPort);
            formularioEmergente.Show();
            //Ahora la restauro
            this.WindowState = FormWindowState.Normal;
            Cursor.Current = Cursors.Default;
        }
    }
}
