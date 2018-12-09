using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLCardProgrammer
{
    public partial class popUpProgramming : Form
    {
        public popUpProgramming(string _programa,string  __mode,int __bytes)
        {
            InitializeComponent();
            try
            {
                if (_programa != "")
                {
                    /*
                    txtMod.Text = "";
                    char sep = '\r';
                    int milliseconds = 10;
                    //Voy a enviar caracter por caractercmbSendMode.Items.Add("Byte-Byte (DEC)");
                    if (cmbSendMode.Text == "Byte-Byte (DEC)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int i = 0; i <= text.Length - 1; i++)
                        {
                            string character = text.Substring(i, 1);
                            int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                            ArduinoPort.WriteLine(caracter.ToString());
                            txtMod.Text += caracter.ToString() + "\r\n";
                            txtMod.ScrollToCaret();
                            pbLoad.Value = (i / text.Length) * 100;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }
                    else if (cmbSendMode.Text == "Byte-Byte (HEX)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int i = 0; i <= text.Length - 1; i += 1)
                        {
                            string character = text.Substring(i, 1);
                            ArduinoPort.WriteLine(character);
                            txtMod.Text += character + "\r\n";
                            txtMod.ScrollToCaret();
                            pbLoad.Value = (i / text.Length) * 100;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }
                    else if (cmbSendMode.Text == "2 byte-2 byte (HEX)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int i = 0; i <= text.Length - 2; i += 2)
                        {
                            string character = text.Substring(i, 2);
                            int caracter = int.Parse(character, System.Globalization.NumberStyles.HexNumber);
                            ArduinoPort.WriteLine(caracter.ToString());
                            txtMod.Text += character + "\r\n";
                            txtMod.ScrollToCaret();
                            pbLoad.Value = (i / text.Length) * 100;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }


                    else if (cmbSendMode.Text == "2 byte-2 byte (DEC)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int i = 0; i <= text.Length - 1; i += 2)
                        {
                            string character = text.Substring(i, 2);
                            string lineInt = "";
                            for (int bIndex = 0; bIndex <= character.Length - 1; bIndex++)
                            {
                                int caracter = int.Parse(character.Substring(bIndex, 1), System.Globalization.NumberStyles.HexNumber);
                                lineInt += caracter.ToString();
                            }
                            ArduinoPort.WriteLine(lineInt);
                            txtMod.Text += lineInt + "\r\n";
                            txtMod.ScrollToCaret();
                            pbLoad.Value = (i / text.Length) * 100;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }

                    else if (cmbSendMode.Text == "4 byte-4 byte (DEC)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int i = 0; i <= text.Length - 1; i += 4)
                        {
                            string character = text.Substring(i, 4);
                            string lineInt = "";
                            for (int bIndex = 0; bIndex <= character.Length - 1; bIndex++)
                            {
                                int caracter = int.Parse(character.Substring(bIndex, 1), System.Globalization.NumberStyles.HexNumber);
                                lineInt += caracter.ToString();
                            }
                            ArduinoPort.WriteLine(lineInt);
                            txtMod.Text += lineInt + "\r\n";
                            txtMod.ScrollToCaret();
                            pbLoad.Value = (i / text.Length) * 100;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }
                    else if (cmbSendMode.Text == "4 byte-4 byte (HEX)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\r\n", ""); //remove whitespaces
                        for (int i = 0; i <= text.Length - 4; i += 4)
                        {
                            string character = text.Substring(i, 4);
                            ArduinoPort.WriteLine(character);
                            txtMod.Text += character + "\r\n";
                            txtMod.ScrollToCaret();
                            pbLoad.Value = (i / text.Length) * 100;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }

                    else if (cmbSendMode.Text == "Line-Line (32-Bit)(DEC)")
                    {
                        string text = txtExe.Text;
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
                            ArduinoPort.WriteLine(lineInt);
                            txtMod.Text += lineInt + "\r\n";
                            txtMod.ScrollToCaret();
                            j = j + 10;
                            pbLoad.Value = j / text.Length;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }
                    else if (cmbSendMode.Text == "Line-Line (32-Bit)(HEX)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                        string[] lines = text.Split(sep);
                        int j = 0;
                        foreach (string line in lines)
                        {
                            string lineF = line.Replace("\r", "");
                            ArduinoPort.WriteLine(lineF);
                            txtMod.Text += lineF + "\r\n";
                            txtMod.ScrollToCaret();
                            j = j + 10;
                            pbLoad.Value = j / text.Length;
                            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                        }
                    }
                    else if (cmbSendMode.Text == "Line-Line (16-Bit)(DEC)")
                    {
                        string text = txtExe.Text;
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
                                ArduinoPort.WriteLine(lineInt);
                                txtMod.Text += lineInt + "\r\n";
                                txtMod.ScrollToCaret();
                                pbLoad.Value = j / text.Length;
                                Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                            }
                        }
                    }
                    else if (cmbSendMode.Text == "Line-Line (16-Bit)(HEX)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                        string[] lines = text.Split(sep);
                        foreach (string line in lines)
                        {
                            string lineF = line.Replace("\r", "");
                            for (int j = 0; j <= lineF.Length - 16; j += lineF.Length / 2)
                            {
                                string line16 = lineF.Substring(j, 16);
                                ArduinoPort.WriteLine(line16);
                                txtMod.Text += line16 + "\r\n";
                                txtMod.ScrollToCaret();
                                pbLoad.Value = j / text.Length;
                                Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                            }
                        }
                    }
                    else if (cmbSendMode.Text == "Line-Line (8-Bit)(DEC)")
                    {
                        string text = txtExe.Text;
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
                                ArduinoPort.WriteLine(lineInt);
                                txtMod.Text += lineInt + "\r\n";
                                txtMod.ScrollToCaret();
                                pbLoad.Value = j / text.Length;
                                Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                            }
                        }
                    }
                    else if (cmbSendMode.Text == "Line-Line (8-Bit)(HEX)")
                    {
                        string text = txtExe.Text;
                        text = text.Trim().Replace(" ", "").Replace("\n", ""); //remove whitespaces
                        string[] lines = text.Split(sep);
                        foreach (string line in lines)
                        {
                            string lineF = line.Replace("\r", "");
                            for (int j = 0; j <= lineF.Length - 8; j += lineF.Length / 4)
                            {
                                string line8 = lineF.Substring(j, 8);
                                ArduinoPort.WriteLine(line8);
                                txtMod.Text += line8 + "\r\n";
                                txtMod.ScrollToCaret();
                                pbLoad.Value = j / text.Length;
                                Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
                            }
                        }
                    }
                    pbLoad.Value = 100;
                    */
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
        private void popUpProgramming_Load(object sender, EventArgs e)
        {
           
        }

        private void txtProgram_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
