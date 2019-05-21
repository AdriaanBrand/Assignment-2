using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Opdrag_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] pro = { 1, 2, 3 };
            int n = pro.Length;

            int[] burstTime = { 10, 5, 8 };

            int qntm = 2;
            findAvgTime(pro, n, burstTime, qntm);
        }

        static void findWaitTime(int []proc, int n, int []btime, int []wtime, int qntm)
        {
            int[] remBurstTime = new int[n];

            for(int i = 0; i < n; i++)
            {
                remBurstTime[i] = btime[i];
            }

            int t = 0;

            while(true)
            {
                bool done = true;

                for (int i = 0; i < n; i++)
                {
                    if(remBurstTime[i] > 0)
                    {
                        done = false;

                        if(remBurstTime[i] > qntm)
                        {
                            t += qntm;
                            remBurstTime[i] -= qntm;
                        }
                        else
                        {
                            t = t + remBurstTime[i];
                            wtime[i] = t - btime[i];
                            remBurstTime[i] = 0;
                        }
                    }
                }
                if(done == true)
                {
                    break;
                }
            }
            
        }

        static void findTurnAroundTime(int []proc, int n, int []btime, int []wtime, int []turnTime)
        {
            for(int i = 0; i <n; i++)
            {
                turnTime[i] = btime[i] + wtime[i];
            }
        }

        public void findAvgTime(int[] proc, int n, int []btime, int qntm)
        {
            int []wtime = new int[n];
            int []turnAroundTime = new int[n];
            int total_wtime = 0;
            int total_turnTime = 0;

            findWaitTime(proc, n, btime, wtime, qntm);

            findTurnAroundTime(proc, n, btime, wtime, turnAroundTime);

            listBox1.Items.Add("Processes " + " Burst time " +
                    " Waiting time " + " Turn around time");

            for(int i = 0; i < n; i++)
            {
                total_wtime = total_wtime + wtime[i];
                total_turnTime = total_turnTime + turnAroundTime[i];
                listBox1.Items.Add(" " + (i + 1) + "\t\t" + btime[i]
                         + "\t " + wtime[i] + "\t\t " + turnAroundTime[i]);
            }

            label1.Text = "Average waiting time = " +
                        (float)total_wtime / (float)n;
            label2.Text = "Average turn around time = " +
                        (float)total_turnTime / (float)n;
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
