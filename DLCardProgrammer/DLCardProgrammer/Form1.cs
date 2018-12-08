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
        public string _programa = string.Empty;
        SerialPort ArduinoPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            //Al llamar a esta funcion se llena la lista de puertos:
            pLoadSerialPorts();

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
