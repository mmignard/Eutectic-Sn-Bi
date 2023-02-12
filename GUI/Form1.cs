using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EutecticGui
{
    public partial class Form1 : Form
    {
        EutecticComms theBoard;
        private const int maxDataInHist = 40;
        private const int plotWidth = 180;
        private String savePartialStr = "";
        private double[] tempHist = new double[maxDataInHist];
        int tempHistPtr = 0;
        System.IO.StreamWriter logFile;

        public Form1()
        {
            InitializeComponent();
            theBoard = new EutecticComms();
            PopulatePorts();
            chart1.ChartAreas[0].AxisY.Maximum = 400;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = plotWidth;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 30;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 30;
            chart1.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
        }

        private void PopulatePorts()
        {
            object selItem = comboBox_CommPort.SelectedItem;

            string[] portNames;
            portNames = EutecticComms.GetPortNames();
            comboBox_CommPort.Enabled = false;
            comboBox_CommPort.Items.Clear();
            comboBox_CommPort.Items.AddRange(portNames);
            if (portNames.Length > 0)
            {
                if (selItem != null)
                {
                    if (comboBox_CommPort.Items.Contains(selItem))
                    {
                        comboBox_CommPort.SelectedIndex = comboBox_CommPort.Items.IndexOf(selItem);
                    }
                    else
                    {
                        comboBox_CommPort.SelectedIndex = 0;
                        SelectPort();
                    }
                }
                else
                { // Nothing was previously selected, so we are using the first item on the list
                    comboBox_CommPort.SelectedIndex = 0;
                }
                comboBox_CommPort.Enabled = true;
            }
        }

        private void SelectPort()
        {
            theBoard.SetPort((string)comboBox_CommPort.SelectedItem);
            theBoard.Open();
            System.Threading.Thread.Sleep(300);
        }

        private String[] removeFirst(String[] inSt)
        {
            return (inSt);
        }

        private void addValToData(String str)
        {
            if (tempHistPtr < (maxDataInHist - 1))
            {
                tempHistPtr++;
            }
            else
            {
                for (int i = 0; i < tempHistPtr; ++i)
                {
                    tempHist[i] = tempHist[i + 1];
                }
            }
            tempHist[tempHistPtr] = Convert.ToDouble(str);

            chart1.Series[0].Points.AddY(tempHist[tempHistPtr]);
            if (chart1.Series[0].Points.Count > plotWidth)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }

            if (checkBox_Log.Checked)
            {  //go to http://www.epochconverter.com/ to convert back to date/time
                logFile.WriteLine((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + "," + tempHist[tempHistPtr]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String newDataStr = theBoard.ReadExisting(); //get most recent info from Arduino board
            char[] delimiterChars = { '\r', '\n' };

            //split the string into words, convert full words to numbers, then save in history and update plot
            string[] words = newDataStr.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            if (savePartialStr.Length != 0)
            {
                if(newDataStr.IndexOf('\n') <= 1)
                    addValToData(savePartialStr);
                else
                    words[0] = savePartialStr + words[0];
                savePartialStr = "";
            }
            for (int i=0; i<words.Length-1; ++i)
            {
                addValToData(words[i]);
            }
            if ((newDataStr.LastIndexOf('\r') >= (newDataStr.Length - 2)) && (words.Length > 0))
                addValToData(words[words.Length-1]);
            else
                if (words.Length > 0)
                    savePartialStr = words[words.Length-1];

            //update the text with the history
            textBox_Data.Text = "";
            for (int i=0; i<=tempHistPtr; ++i)
            {
                textBox_Data.Text += tempHist[i].ToString("N2");
                textBox_Data.Text += Environment.NewLine;
            }

        }


        private void checkBox_Connect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Connect.Checked)
            {
                SelectPort();
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                theBoard.Close();
            }
        }

        private void OpenLog()
        {
            if (logFile == null)
            {
                string logFileName = "c:\\temp\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";
                logFile = new System.IO.StreamWriter(logFileName);
            }
        }

        private void checkBox_Log_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Log.Checked) {
                OpenLog();
            } else if (logFile != null) {
                    logFile.Close();
                    logFile = null;
            }
        }

    }
}
