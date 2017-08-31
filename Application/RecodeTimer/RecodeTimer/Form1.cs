using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RecodeTimer
{
    public partial class Form1 : Form
    {
        SerialPortProcessor mSerialPort;
        byte[] rxPacket, txPacket;
        int[] nowTime;
        int[,,] recodeTime;
        const int TIMER_NUM = 3;
        const int START = 0;
        const int END = 1;
        const int HOUR = 0;
        const int MINUTE = 1;
        const int SECOND = 2;
        //const byte START_BYTE = 0xFE;
        //const byte END_BYTE = 0xFF;
        const byte START_BYTE = 0x73;
        const byte END_BYTE = 0x65;

        public Form1()
        {
            InitializeComponent();

            string[] PortList = SerialPort.GetPortNames();
            com_combo.Items.Clear();
            for (int i = 0; i < PortList.Length; i++)
            {
                com_combo.Items.Add(PortList[i]);
            }

            start_timer1.Format = DateTimePickerFormat.Custom;
            start_timer1.CustomFormat = "HH:mm";
            start_timer1.ShowUpDown = true;

            start_timer2.Format = DateTimePickerFormat.Custom;
            start_timer2.CustomFormat = "HH:mm";
            start_timer2.ShowUpDown = true;

            start_timer3.Format = DateTimePickerFormat.Custom;
            start_timer3.CustomFormat = "HH:mm";
            start_timer3.ShowUpDown = true;

            end_timer1.Format = DateTimePickerFormat.Custom;
            end_timer1.CustomFormat = "HH:mm";
            end_timer1.ShowUpDown = true;

            end_timer2.Format = DateTimePickerFormat.Custom;
            end_timer2.CustomFormat = "HH:mm";
            end_timer2.ShowUpDown = true;

            end_timer3.Format = DateTimePickerFormat.Custom;
            end_timer3.CustomFormat = "HH:mm";
            end_timer3.ShowUpDown = true;

            mSerialPort = new SerialPortProcessor();
            mSerialPort.DataReceived += DataReceivedCallback;
            rxPacket = new byte[256];
            txPacket = new byte[256];
            nowTime = new int[3];
            recodeTime = new int[TIMER_NUM, 2, 3];
        }

        private void com_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSerialPort.PortName = (String)com_combo.SelectedItem;
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            mSerialPort.Start();
        }

        private void transmit_button_Click(object sender, EventArgs e)
        {
            if(mSerialPort.PortName == null)
            {
                MessageBox.Show("Select COM Port!");
            }
            else
            {
                nowTime[0] = DateTime.Now.Hour;
                nowTime[1] = DateTime.Now.Minute;
                nowTime[2] = DateTime.Now.Second;

                for (int i = 0; i < TIMER_NUM; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            recodeTime[i, j, k] = 0;
                        }
                    }
                }

                if (enable_check1.Checked == true)
                {
                    recodeTime[0, 0, 0] = start_timer1.Value.Hour;
                    recodeTime[0, 0, 1] = start_timer1.Value.Minute;
                    recodeTime[0, 0, 2] = 0;
                    recodeTime[0, 1, 0] = end_timer1.Value.Hour;
                    recodeTime[0, 1, 1] = end_timer1.Value.Minute;
                    recodeTime[0, 1, 2] = 0;

                }
                else
                {

                }
                if (enable_check2.Checked == true)
                {
                    recodeTime[1, 0, 0] = start_timer2.Value.Hour;
                    recodeTime[1, 0, 1] = start_timer2.Value.Minute;
                    recodeTime[1, 0, 2] = 0;
                    recodeTime[1, 1, 0] = end_timer2.Value.Hour;
                    recodeTime[1, 1, 1] = end_timer2.Value.Minute;
                    recodeTime[1, 1, 2] = 0;
                }
                else
                {

                }
                if (enable_check2.Checked == true)
                {
                    recodeTime[2, 0, 0] = start_timer3.Value.Hour;
                    recodeTime[2, 0, 1] = start_timer3.Value.Minute;
                    recodeTime[2, 0, 2] = 0;
                    recodeTime[2, 1, 0] = end_timer3.Value.Hour;
                    recodeTime[2, 1, 1] = end_timer3.Value.Minute;
                    recodeTime[2, 1, 2] = 0;
                }
                else
                {

                }

                txPacket[0] = START_BYTE;

                txPacket[1] = (byte)nowTime[HOUR];
                txPacket[2] = (byte)nowTime[MINUTE];
                txPacket[3] = (byte)nowTime[SECOND];

                for (int i = 0; i < TIMER_NUM; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            txPacket[2 * 3 * i + 3 * j + k + 4] = (byte)recodeTime[i, j, k];
                        }
                    }
                }

                txPacket[22] = END_BYTE;

                mSerialPort.WriteData(txPacket);

                MessageBox.Show("Push Discconect !");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void disconnect_button_Click(object sender, EventArgs e)
        {
            mSerialPort.Close();
        }

        private void DataReceivedCallback(byte[] data)
        {
            /*
            String st = Encoding.UTF8.GetString(data);
            Invoke(new MethodInvoker(() => receive_text.Text += st));
            */        
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] == START_BYTE)
                {
                    Invoke(new MethodInvoker(() => receive_text.Text += "Start Writing" + Environment.NewLine));
                } else if(data[i] == END_BYTE)
                {
                    Invoke(new MethodInvoker(() => receive_text.Text += "End Writing" + Environment.NewLine));
                }
                //Console.Write(data[i]);
            }
        }
    }
}
