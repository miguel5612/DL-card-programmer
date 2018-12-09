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
using System.Globalization;
using System.Text;


namespace DLCardProgrammer
{
    public partial class Form1 : Form
    {
        public string _programa = string.Empty, program2Send;
        public string __mode = string.Empty;
        public int __bytes = 0;
        SerialPort ArduinoPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            //Al llamar a esta funcion se llena la lista de puertos:
            pLoadSerialPorts();
            //Al llamar a esta funcion se carga la lista de velocidades:
            fillBaudRate();
            //Al llamar a esta funcion se carga de forma automatica las formas de envio
            pfillSendMode();
            //Desactivo los demas botones hasta que  no se hace cada proceso
            btnLoadProgram.Enabled = false;
            btnViewCode.Enabled = false;
            btnProgram.Enabled = false;
            cmbTypeProgram.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void pfillSendMode()
        {

            cmbTypeProgram.Items.Add("(HEX) Byte a Byte");
            cmbTypeProgram.Items.Add("(HEX) 2 Bytes a 2 Bytes)");
            cmbTypeProgram.Items.Add("(HEX) 4 Bytes a 4 Bytes");
            cmbTypeProgram.Items.Add("(HEX) 6 Bytes a 6 Bytes");
            cmbTypeProgram.Items.Add("(HEX) 8 Bytes a 8 Bytes");
            cmbTypeProgram.Items.Add("(HEX) Line to Line (8-Bit)");
            cmbTypeProgram.Items.Add("(HEX) Line to Line (16-Bit)");
            cmbTypeProgram.Items.Add("(HEX) Line to Line (32-Bit)");

            cmbTypeProgram.Items.Add("(DEC) Byte a Byte");
            cmbTypeProgram.Items.Add("(DEC) 2 Bytes a 2 Bytes)");
            cmbTypeProgram.Items.Add("(DEC) 4 Bytes a 4 Bytes");
            cmbTypeProgram.Items.Add("(DEC) 6 Bytes a 6 Bytes");
            cmbTypeProgram.Items.Add("(DEC) 8 Bytes a 8 Bytes");
            cmbTypeProgram.Items.Add("(DEC) Line to Line (8-Bit)");
            cmbTypeProgram.Items.Add("(DEC) Line to Line (16-Bit)");
            cmbTypeProgram.Items.Add("(DEC) Line to Line (32-Bit)");

            cmbTypeProgram.SelectedIndex = 0;
        }
        private void fillBaudRate()
        {
            cmbBaudrate.Items.Add("4800");
            cmbBaudrate.Items.Add("9600");
            cmbBaudrate.Items.Add("19200");
            cmbBaudrate.Items.Add("38400");
            cmbBaudrate.Items.Add("57600");
            cmbBaudrate.Items.Add("115200");
            cmbBaudrate.Items.Add("250000");
            cmbBaudrate.SelectedIndex = 5;
        }
        private void pLoadSerialPorts()
        {
            var countPorts = 0;
            cmbPort.Items.Clear();
            foreach (String port in SerialPort.GetPortNames())
            {
                cmbPort.Items.Add(port);
                countPorts++;
            }
            if (countPorts == 0) cmbPort.Items.Add("COM3");
            cmbPort.SelectedIndex = 0;
        }

        private void btnUpdatePorts_Click(object sender, EventArgs e)
        {
            //Al llamar a esta funcion se llena la lista de puertos:
            pLoadSerialPorts();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            try
            {
                if (btnConnect.Text == "Conectar")
                {
                    //Conectar 

                    ArduinoPort.PortName = cmbPort.Text;
                    ArduinoPort.BaudRate = Int32.Parse(cmbBaudrate.Text);
                    ArduinoPort.DataBits = 8;
                    ArduinoPort.Parity = Parity.None;
                    ArduinoPort.StopBits = StopBits.One;
                    ArduinoPort.Handshake = Handshake.None;
                    try
                    {
                        ArduinoPort.Open();
                        btnConnect.Text = "Desconectar";
                        btnConnect.Enabled = true;
                        btnConnect.Enabled = true;
                        btnLoadProgram.Enabled = true;
                        btnViewCode.Enabled = false;
                        btnProgram.Enabled = false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    //Desconectar
                    ArduinoPort.Close();
                    btnConnect.Text = "Conectar";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnLoadProgram_Click(object sender, EventArgs e)
        {
            OpenFileDialog window = new OpenFileDialog();
            if (window.ShowDialog() == DialogResult.OK)
            {
                string location = window.FileName;
                byte[] file = File.ReadAllBytes(location);
                _programa = ByteArrayToString(file);
                _programa = formatStr(_programa, 4, 8);
                __bytes = _programa.Trim().Replace(" ", "").Replace("\r\n", "").Length;
                txtNumbytes.Text = __bytes.ToString() + "  bytes readed OK";
                btnViewCode.Enabled = true;
                btnProgram.Enabled = true;
                cmbTypeProgram.Enabled = true;
            }
        }


        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public static string formatStr(String inputText, int chunkSize, int CRSize)
        {
            string rText = " ";
            int counter = 0;
            foreach (string s in Split(inputText, chunkSize).ToList())
            {
                counter++;
                rText += " " + s;
                if (counter >= CRSize)
                {
                    rText += "  \r\n ";
                    counter = 0;
                }
            }
            return rText;
        }
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            pbLoad.Value = 0;
            pbLoad.Maximum = 100;
            pFillTexttoSend();
            __mode = cmbTypeProgram.Text;
            Cursor.Current = Cursors.WaitCursor;
            //Ventana emergente     
            Form formularioEmergente = new popUpProgramming( __mode,__bytes,chkSendWidth.Checked,program2Send, ArduinoPort);
            __mode = cmbTypeProgram.Text;
            formularioEmergente.Show();
            //Ahora la restauro
            this.WindowState = FormWindowState.Normal;
            Cursor.Current = Cursors.Default;
            /*
            
        */
        }

        private void btnViewCode_Click(object sender, EventArgs e)
        {
            pbLoad.Value = 0;
            pbLoad.Maximum = 100;
            __mode = cmbTypeProgram.Text;
            Cursor.Current = Cursors.WaitCursor;
            //Ventana emergente     
            Form formularioEmergente = new viewCode(_programa, __mode, __bytes, chkSendWidth.Checked, ArduinoPort);
            __mode = cmbTypeProgram.Text;
            formularioEmergente.Show();
            //Ahora la restauro
            this.WindowState = FormWindowState.Normal;
            Cursor.Current = Cursors.Default;
        }

        private void cmbTypeProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            pFillTexttoSend();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pFillTexttoSend();
        }
        private void pFillTexttoSend()
        {
            string mode = cmbTypeProgram.Text;
            string text = _programa;
            int numBytes = __bytes;
            program2Send = "";
            if (chkSendWidth.Checked)
            {
                var sendText = "";
                char sep = '\r';
                if (mode.Contains("HEX"))
                {
                    program2Send = __bytes.ToString("X") + "\r\n";
                }
                else
                {
                    program2Send = __bytes.ToString() + "\r\n";
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
