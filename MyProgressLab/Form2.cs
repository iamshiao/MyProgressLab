using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProgressLab
{
    public partial class Form2 : Form
    {
        BackgroundWorker _bgWorker;
        public Form2()
        {
            InitializeComponent();

            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += WorkInBG;
            _bgWorker.ProgressChanged += UpdateProgressBar;
            _bgWorker.RunWorkerCompleted += Finish;
            _bgWorker.WorkerReportsProgress = true;
        }

        private void Finish(object sender, RunWorkerCompletedEventArgs args)
        {
            MessageBox.Show("Finished");
            pbProgress.Value = 0;
        }

        private void UpdateProgressBar(object sender, ProgressChangedEventArgs args)
        {
            pbProgress.Value = args.ProgressPercentage;
        }

        private void WorkInBG(object sender, DoWorkEventArgs args)
        {
            for (int i = 0; i < 100; i++)
            {
                _bgWorker.ReportProgress(i + 1);
                Thread.Sleep(100 - i);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!_bgWorker.IsBusy)
            {
                _bgWorker.RunWorkerAsync();
            }
        }
    }
}
