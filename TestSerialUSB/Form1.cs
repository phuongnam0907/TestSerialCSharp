using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSerialUSB
{
    public partial class Form1 : Form
    {
        private Thread sendDataThread;
        private int count = 0;

        public Form1()
        {
            InitializeComponent();

            ThreadStart thread = new ThreadStart(sendData);
            sendDataThread = new Thread(thread);
            sendDataThread.Start();
        }

        private bool isAuto = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cbPorts.Items.AddRange(ports);
            if (ports.Count() > 0) cbPorts.SelectedIndex = 0;
            else cbPorts.SelectedIndex = -1;
            btnClose.Enabled = false;
            btnKeo.Enabled = false;
            btnBe.Enabled = false;
            btnCat.Enabled = false;
            btnNhan.Enabled = false;
            buttonAuto.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            btnKeo.Enabled = true;
            btnBe.Enabled = true;
            btnCat.Enabled = true;
            btnNhan.Enabled = true;
            buttonAuto.Enabled = true;

            try
            {
                serialPort1.PortName = cbPorts.Text;
                serialPort1.BaudRate = Convert.ToInt32("115200");
                serialPort1.DataBits = Convert.ToInt16("8");
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                serialPort1.Open();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            btnKeo.Enabled = false;
            btnBe.Enabled = false;
            btnCat.Enabled = false;
            btnKeo.Enabled = false;

            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(txtSend.Text + "\r\n");
                    txtSend.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    txtRec.Text = serialPort1.ReadExisting();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void btnKeo_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string a = "K" + numK.Value.ToString() + "\r\n";
                    data.Text = a;
                    serialPort1.Write(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBe_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string a = "B" + numB.Value.ToString() + "\r\n";
                    data.Text = a;
                    serialPort1.Write(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string a = "C\r\n";
                    data.Text = a;
                    serialPort1.Write(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string a = "N\r\n";
                    data.Text = a;
                    serialPort1.Write(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cbPorts.Items.Clear();
            cbPorts.Items.AddRange(ports);
            if (ports.Count() > 0)
            {
                cbPorts.SelectedIndex = 0;
                cbPorts.Text = "";
            }
            else cbPorts.SelectedIndex = -1;
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            if (isAuto)
            {
                buttonAuto.Text = "AUTO\nOFF";
            }
            else
            {
                buttonAuto.Text = "AUTO\nON";
            }
            isAuto = !isAuto;
        }

        private void sendData()
        {
            while (true)
            {
                if (isAuto)
                {
                    serialPort1.Write("OK");
                    Thread.Sleep(100);
                    //if (count == -10) count = 10;
                    //count--;
                    //serialPort1.Write("K" + count.ToString() + "\r\n");
                    //Thread.Sleep(1000);
                    //serialPort1.Write("B" + count.ToString() + "\r\n");
                    //Thread.Sleep(1000);
                    //serialPort1.Write("C\r\n");
                    //Thread.Sleep(1000);
                    //serialPort1.Write("N\r\n");
                    //Thread.Sleep(1000);
                }
            }
        }
    }
}
