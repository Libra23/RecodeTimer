using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecodeTimer
{
    class SerialPortProcessor
    {
        private SerialPort myPort = null;
        private Thread receiveThread = null;

        public String PortName { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }

        public SerialPortProcessor()
        {
            BaudRate = 9600;
            Parity = Parity.None;
            DataBits = 8;
            StopBits = StopBits.One;
        }

        public void Start()
        {
            if(myPort == null)
            {
                myPort = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits);
                myPort.DtrEnable = true;
                myPort.RtsEnable = true;
                myPort.Open();
                receiveThread = new Thread(SerialPortProcessor.ReceiveWork);
                receiveThread.Start(this);
            }

        }

        public static void ReceiveWork(object target)
        {
            SerialPortProcessor my = target as SerialPortProcessor;
            my.ReceiveData();
        }

        public void WriteData(byte[] buffer)
        {
            myPort.Write(buffer, 0, buffer.Length);
        }

        public delegate void DataReceivedHandler(byte[] data);
        public event DataReceivedHandler DataReceived;

        public void ReceiveData()
        {
            if (myPort == null)
            {
                return;
            }
            do
            {
                try
                {
                    int rbyte = myPort.BytesToRead;
                    byte[] buffer = new byte[rbyte];
                    int read = 0;
                    while (read < rbyte)
                    {
                        int length = myPort.Read(buffer, read, rbyte - read);
                        read += length;
                    }
                    if (rbyte > 0)
                    {
                        DataReceived(buffer);
                    }
                }
                catch (IOException ex)
                {
                }
                catch (InvalidOperationException ex)
                {
                }
            } while (myPort.IsOpen);
        }

        public void Close()
        {
            if (receiveThread != null && myPort != null)
            {
                myPort.Close();
                receiveThread.Join();
            }
        }
    }
}
