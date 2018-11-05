using AsynchdownloadPrj.Services;
using AsynchdownloadPrj.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace AsynchdownloadPrj
{
    public partial class Form1 : Form
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly DownloadService _downloadService;

        public Form1()
        {
            //We can inject this dependices as well
            _cancellationTokenSource = new CancellationTokenSource();
            _downloadService = new DownloadService();
            InitializeComponent();
        }

        private void addUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(urlText.Text))
            {
                listUrls.Items.Add(urlText.Text);
            }
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            dashboardProgress.Value = e.PercentageComplete;
            PrintResults(e.SitesDownloaded);
        }

        private async void executeAsync_Click(object sender, EventArgs e)
        {
            var listOfUrls = _downloadService.GetPreparedList(listUrls);
            if (listOfUrls != null)
            {
                Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
                progress.ProgressChanged += ReportProgress;

                var watch = Stopwatch.StartNew();
                try
                {
                    var results = await _downloadService.RunDownloadAsync(progress, _cancellationTokenSource.Token, listOfUrls);
                    PrintResults(results);
                }
                catch (OperationCanceledException)
                {
                    resultsWindow.Text += $@"Downloading was cancelled. { Environment.NewLine }";
                }

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                resultsWindow.Text += $@"Total execution time: { elapsedMs }";
            }
        }

        private void cancelOperation_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void PrintResults(List<UrlDataModel> results)
        {
            resultsWindow.Text = "";
            foreach (var item in results)
            {
                resultsWindow.Text += $@"{ item.UrlName } downloaded: { item.UrlData.Length } characters long.{ Environment.NewLine }";
            }
        }
    }
}
