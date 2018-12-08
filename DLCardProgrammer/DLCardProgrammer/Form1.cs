﻿using System;
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
            //Al llamar a esta funcion se carga la lista de velocidades:
            fillBaudRate();
            //Al llamar a esta funcion se carga de forma automatica las formas de envio
            pfillSendMode();
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
    }
}
