using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int totalSeconds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button2.Enabled = false;

            for (int i = 0; i < 60; i++)
            {
                this.comboBox1.Items.Add(i.ToString());
                this.comboBox2.Items.Add(i.ToString());
            }
            this.comboBox1.SelectedIndex = 20;
            this.comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = true;

            int minutes = int.Parse(this.comboBox1.SelectedItem.ToString());
            int seconds = int.Parse(this.comboBox2.SelectedItem.ToString());

            totalSeconds = (minutes * 60) + seconds;

            this.timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.button1.Enabled = true;

            totalSeconds = 0;
            this.timer1.Enabled = false;
            this.label1.Text = "00:00";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds - (minutes * 60);
                this.label1.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                this.timer1.Stop();
                this.label1.Text = "00:00";
                MessageBox.Show("Rest your eyes!");
            }
        }
    }
}
