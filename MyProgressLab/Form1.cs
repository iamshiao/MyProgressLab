using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProgressLab
{
    public partial class Form1 : Form
    {
        IProgress<int> _progress;
        public Form1()
        {
            InitializeComponent();

            _progress = new Progress<int>(UpdateProgressBar);
        }

        private void UpdateProgressBar(int val)
        {
            pbProgress.Value = val;

            if (val == 100)
            {
                MessageBox.Show("Finished");
                pbProgress.Value = 0;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (pbProgress.Value == 0)
            {
                await Task.Run(async () =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        _progress.Report(i + 1);
                        await Task.Delay(100 - i);
                    }
                });
            }
        }
    }
}
