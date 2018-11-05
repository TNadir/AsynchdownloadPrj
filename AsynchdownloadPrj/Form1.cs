using AsynchdownloadPrj.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchdownloadPrj
{
    public partial class Form1 : Form
    {
        private readonly List<DocumentObject> _urllist;
        private const string DiRpath = @"D://files/";
        Stopwatch sw = new Stopwatch();
        private long d;
        private bool istoped = false;
        public Form1()
        {
            InitializeComponent();
            //Here We can apply DI containers
            _urllist = new List<DocumentObject>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //list.Add(new DocumentObject { docUrl = "https://morooq.com/Content/UIContent/images/MorooqLogo.png" });

            _urllist.Add(new DocumentObject { docUrl = textBox1.Text });
            ShowUrLlist();
        }

        private void ShowUrLlist()
        {
            Invoke(new Action(() =>
              {

                  listBox1.Items.Clear();
                  foreach (var item in _urllist)
                  {
                      listBox1.Items.Add(item.docUrl + " " + item.status);
                  }
                  CountFiles();

              }));
        }
        private void CountFiles()
        {
            var list = Directory.GetFiles(DiRpath);
            if (list.Length > 0)
            {
                label2.Text = @"Downloaded files count: " + list.Count();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Task.Run(() => DownloadMultipleFilesAsync(_urllist));

        }

        private async Task DownloadFileAsync(DocumentObject doc)
        {
            var docobject = _urllist.FirstOrDefault(x => x.ID == doc.ID);
            try
            {
                using (var webClient = new WebClient())
                {
                    if (!istoped)
                    {
                        Thread.Sleep(2000);
                        var downloadToDirectory = DiRpath + doc.docName;
                        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DoSomethingOnFinish);
                        webClient.QueryString.Add("fileName", doc.ID.ToString());
                        webClient.QueryString.Add("count", listBox1.Items.Count.ToString());
                        webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                        await webClient.DownloadFileTaskAsync(new Uri(doc.docUrl), downloadToDirectory);
                    }
                    else
                    {
                        
                    }


                    // if (docobject != null) docobject.status = "success downloaded";

                }
            }
            catch (Exception)
            {
                if (docobject != null) docobject.status = "downloading failed";

            }
            ShowUrLlist();
        }

        void DoSomethingOnFinish(object sender, AsyncCompletedEventArgs e)
        {

            var myFileNameId = Convert.ToInt32(((System.Net.WebClient)(sender)).QueryString["fileName"]);
            var count = Convert.ToInt32(((System.Net.WebClient)(sender)).QueryString["count"]);
            var docobject = _urllist.FirstOrDefault(x => x.ID == myFileNameId);
            if (docobject != null) docobject.status = "success downloaded";
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            d += e.BytesReceived;
            Invoke(new Action(() =>
            {
                labelSpeed.Text = string.Format("{0} kb/s", (d).ToString("0.00"));
            }));

        }

        private async Task DownloadMultipleFilesAsync(List<DocumentObject> doclist)
        {
            // listBox1.Items.Clear();
            await Task.WhenAll(doclist.Select(DownloadFileAsync));

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "Starting";

            var worker = new worker();
            worker.DoWork();

            while (!worker.IsComplete)
            {
                label3.Text = "," + worker.Value;
                // Thread.Sleep(100);
            }
            label3.Text = "Done";
            //Console.ReadKey();
        }
    }
}
