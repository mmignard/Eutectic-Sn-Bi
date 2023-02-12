namespace EutecticGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.checkBox_Log = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.comboBox_CommPort = new System.Windows.Forms.ComboBox();
            this.checkBox_Connect = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_Log
            // 
            this.checkBox_Log.AutoSize = true;
            this.checkBox_Log.Location = new System.Drawing.Point(111, 15);
            this.checkBox_Log.Name = "checkBox_Log";
            this.checkBox_Log.Size = new System.Drawing.Size(73, 17);
            this.checkBox_Log.TabIndex = 0;
            this.checkBox_Log.Text = "L:og Data";
            this.checkBox_Log.UseVisualStyleBackColor = true;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.checkBox_Log_CheckedChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.AxisX.Title = "Time (seconds)";
            chartArea4.AxisY.Title = "Temperature (degrees C)";
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(12, 55);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(942, 598);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // textBox_Data
            // 
            this.textBox_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Data.Location = new System.Drawing.Point(960, 13);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(67, 640);
            this.textBox_Data.TabIndex = 2;
            // 
            // comboBox_CommPort
            // 
            this.comboBox_CommPort.FormattingEnabled = true;
            this.comboBox_CommPort.Location = new System.Drawing.Point(266, 15);
            this.comboBox_CommPort.Name = "comboBox_CommPort";
            this.comboBox_CommPort.Size = new System.Drawing.Size(121, 21);
            this.comboBox_CommPort.TabIndex = 3;
            // 
            // checkBox_Connect
            // 
            this.checkBox_Connect.AutoSize = true;
            this.checkBox_Connect.Location = new System.Drawing.Point(408, 18);
            this.checkBox_Connect.Name = "checkBox_Connect";
            this.checkBox_Connect.Size = new System.Drawing.Size(66, 17);
            this.checkBox_Connect.TabIndex = 4;
            this.checkBox_Connect.Text = "Connect";
            this.checkBox_Connect.UseVisualStyleBackColor = true;
            this.checkBox_Connect.CheckedChanged += new System.EventHandler(this.checkBox_Connect_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 665);
            this.Controls.Add(this.checkBox_Connect);
            this.Controls.Add(this.comboBox_CommPort);
            this.Controls.Add(this.textBox_Data);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.checkBox_Log);
            this.Name = "Form1";
            this.Text = "Syeva Science Fair 2016";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Log;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.ComboBox comboBox_CommPort;
        private System.Windows.Forms.CheckBox checkBox_Connect;
        private System.Windows.Forms.Timer timer1;
    }
}

