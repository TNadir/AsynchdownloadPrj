using AsynchdownloadPrj.Interface;
using AsynchdownloadPrj.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchdownloadPrj.Services
{
    public class DownloadService : IDownloadService
    {
        public List<string> GetPreparedList(ListBox listBox)
        {
            var list = new List<string>();
            foreach (var item in listBox.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        public async Task<List<UrlDataModel>> RunDownloadAsync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken, List<string> websites)
        {
            List<UrlDataModel> output = new List<UrlDataModel>();
            ProgressReportModel report = new ProgressReportModel();
            using (var client = new HttpClient())
            {
                using (var semaphore = new SemaphoreSlim(100,100))
                {
                    foreach (string site in websites)
                    {
                        var tasks = DownloadUrlHelperAsync(site, semaphore, client);
                        var task = await Task.WhenAny(tasks);
                        var results = task.Result;
                        output.Add(results);

                        cancellationToken.ThrowIfCancellationRequested();

                        report.SitesDownloaded = output;
                        report.PercentageComplete = (output.Count * 100) / websites.Count;
                        progress.Report(report);
                    }
                   
                }
            }
            return output;
        }
        
        public async Task<UrlDataModel> DownloadUrlHelperAsync(string url, SemaphoreSlim semaphore, HttpClient client)
        {
            await semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                var dataModel = new UrlDataModel();
                using (var response = await client.GetAsync(url).ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        dataModel.UrlName = url;
                        dataModel.UrlData = string.Empty;
                        return null;
                    }

                    var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    dataModel.UrlName = url;
                    dataModel.UrlData = data.Length.ToString();
                    return dataModel;
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

    }
}
