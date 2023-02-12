using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace EutecticGui
{
    class EutecticComms
    {
        const int RS232_TIMEOUT = 500;

        public class QS_Comm_Exception : Exception
        {
            public QS_Comm_Exception() { }
            public QS_Comm_Exception(string message) : base(message) { }
        };

        public static string[] GetPortNames()
        {
            string[] res = SerialPort.GetPortNames();

            return res.ToArray();
        }

        public EutecticComms()
        {
            string[] ports = EutecticComms.GetPortNames();
            if (ports.Length > 0)
            {
                newPort(ports[0]);
                this.Open();
            }
        }

        public EutecticComms(string port)
        {
            newPort(port);
            this.Open();
        }

        private System.IO.Ports.SerialPort thePort;
        private byte[] inBuf = new byte[1024];
        private int inBufPtr = 0;
        private int inBufCnt = 0;
        private string portName = "";

        private bool IsOpen
        {
            get
            {
                return thePort.IsOpen;
            }
        }

        private void newPort(string name)
        {
            portName = name;
            thePort = new SerialPort(name, 9600);
            thePort.ReadTimeout = RS232_TIMEOUT;
            thePort.DataBits = 8;
            thePort.Parity = Parity.None;
            thePort.StopBits = StopBits.One;
            thePort.DtrEnable = false;
            thePort.Handshake = System.IO.Ports.Handshake.None;
            thePort.RtsEnable = false;
            thePort.ReadBufferSize = 2048;
            thePort.WriteBufferSize = 2048;
            thePort.WriteTimeout = RS232_TIMEOUT;
        }

        public void Close()
        {
            if (thePort.IsOpen)
            {
                thePort.Close();
            }
        }

        public void Open()
        {
            if (!thePort.IsOpen)
            {
                thePort.Open();
            }
        }

        private void DiscardInBuffer()
        {
            if (thePort.IsOpen)
            {
                thePort.DiscardInBuffer();
            }
            inBufCnt = 0;
            inBufPtr = 0;
        }

        private int ReadByte()
        {
            if (thePort.IsOpen)
            {
                if (inBufCnt == inBufPtr)
                {
                    int byteRead = thePort.ReadByte();
                    if (byteRead != -1)
                    {
                        if (inBufCnt == inBuf.Length)
                        { // wrap around
                            inBufCnt = 0;
                            inBufPtr = 0;
                        }
                        inBuf[inBufCnt++] = (byte)byteRead;
                    }
                }
            }
            if (inBufPtr < inBufCnt)
            {
                return (int)inBuf[inBufPtr++];
            }
            else
            {
                return -1;
            }
        }

        private bool Rewind(int n)
        {
            if (inBufPtr - n >= 0)
            {
                inBufPtr -= n;
                return true;
            }
            else
            {
                inBufPtr = 0;
                return false;
            }
        }

        private void Write(byte[] buf, int offset, int count)
        {
            thePort.Write(buf, offset, count);
        }

        public void SetPort(string port)
        {
            bool wasOpen = this.IsOpen;

            if (this.IsOpen)
            {
                this.Close();
            }
            newPort(port);
            if (wasOpen)
            {
                this.Open();
            }
        }

        public string ReadLine()
        {
            if (thePort.IsOpen)
            {
                return (thePort.ReadLine());
            }
            else
            {
                return ("");
            }
        }

        public string ReadExisting()
        {
            if (thePort.IsOpen)
            {
                return (thePort.ReadExisting());
            }
            else
            {
                return ("");
            }
        }
    }
}
