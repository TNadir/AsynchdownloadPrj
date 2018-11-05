﻿using AsynchdownloadPrj.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchdownloadPrj.Interface
{
    public interface IDownloadService
    {
        Task<List<UrlDataModel>> RunDownloadAsync(IProgress<ProgressReportModel> progress,
           CancellationToken cancellationToken, List<string> websites);

        List<string> GetPreparedList(ListBox listBox);

        Task<UrlDataModel> DownloadWebsiteAsync(string url);
    }
}
