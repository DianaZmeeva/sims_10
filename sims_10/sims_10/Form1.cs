using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int i, j, index=0;
        double date = 0, now = 0, final_time, alpha;
        double[][] q =
        {
            new double[] { -0.4, 0.3, 0.1 },
            new double[] { 0.4, -0.8, 0.4 },
            new double[] { 0.1, 0.4, -0.5 },
        };

        double[,] p = new double[3,3];
        //double[][] p = new double [3][3];

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(now!=final_time)
            {
                date++;
                now = date / 10;
                day.Text = "Time: " + now;
            }
            else
            {
                change_text();
                start();
            }
           
        }

        private void change_text()
        {
            if (index == 0)
                weather.Text = "Clear";
            if (index == 1)
                weather.Text = "Cloudy";
            if (index == 2)
                weather.Text = "Overcast";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ind();
            start();
            button1.Visible = false;
        }

        private void start()
        {
            alpha= rnd.NextDouble();
            date = 0;
            now = 0;
            final_time = Math.Round((Math.Log(alpha) / (q[index][index])), 1);
            label1.Text = "Predict weather through: " + final_time;
            timer1.Enabled = true;
            index=pr(alpha);
        }

        private int pr(double alpha)
        {
            if (alpha < p[index,0])
                i = 0;
            else if (alpha < p[index, 0] + p[index, 1])
                i = 1;
            else
                i = 2;
            return i;
        }

        private void ind()
        {
            for (i=0; i<3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (i == j)
                        p[i,j] =0;
                    else
                    {
                        p[i,j] = Math.Round(Math.Abs(q[i][j] / q[i][i]),2);
                    }
                }
            }
        }
    }
}
