using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchdownloadPrj
{
    public partial class Form1 : Form
    {
        private  CancellationTokenSource _cancellationTokenSource;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void addUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(urlText.Text))
            {
                listUrls.Items.Add(urlText.Text);
            }
        }
        private async void executeAsync_Click(object sender, EventArgs e)
        {
          
            resultsWindow.Text=string.Empty;

            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await AccessTheWebAsync(_cancellationTokenSource.Token);
                resultsWindow.Text += Environment.NewLine + @"Downloads complete.";
            }
            catch (OperationCanceledException)
            {
                resultsWindow.Text += Environment.NewLine + @"Downloads canceled.";
            }
            catch (Exception)
            {
                resultsWindow.Text += Environment.NewLine + @"Downloads failed.";
            }

            _cancellationTokenSource = null;
        }

        private void cancelOperation_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
        
        async Task AccessTheWebAsync(CancellationToken ct)
        {
            HttpClient client = new HttpClient();

            List<string> urlList = SetUpUrlList();

            IEnumerable<Task<int>> downloadTasksQuery =
                from url in urlList select ProcessURL(url, client, ct);

            List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

            while (downloadTasks.Count > 0)
            {
                Task<int> firstFinishedTask = await Task.WhenAny(downloadTasks);

                downloadTasks.Remove(firstFinishedTask);

                int length = await firstFinishedTask;

                resultsWindow.Text +=Environment.NewLine+ $@"Length of the download:  {length}";
            }
        }

        private List<string> SetUpUrlList()
        {
            var list = new List<string>();
            foreach (var item in listUrls.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        async Task<int> ProcessURL(string url, HttpClient client, CancellationToken ct)
        {
            HttpResponseMessage response = await client.GetAsync(url, ct);

            byte[] urlContents = await response.Content.ReadAsByteArrayAsync();

            return urlContents.Length;
        }
    }
}
