using AsynchdownloadPrj.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchdownloadPrj
{
    public partial class Form1 : Form
    {
        List<DocumentObject> Urllist;
        private const string DIRpath = @"D://files/";
        public Form1()
        {
            InitializeComponent();
            //Here We can apply DI containers
            Urllist = new List<DocumentObject>();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            //list.Add(new DocumentObject { docUrl = "https://morooq.com/Content/UIContent/images/MorooqLogo.png" });

            Urllist.Add(new DocumentObject { docUrl = textBox1.Text });
            ShowURLlist();
        }

        private void ShowURLlist()
        {
            listBox1.Items.Clear();
            foreach (var item in Urllist)
            {
                listBox1.Items.Add(item.docUrl + " " + item.status);
            }
            countFiles();
        }
        private void countFiles()
        {
            
            var list = Directory.GetFiles(DIRpath);
            if (list.Length > 0)
            {
                label2.Text = "Downloaded files count: " + list.Count();
            }
          
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
            await DownloadMultipleFilesAsync(Urllist);
        
        }

        private async Task DownloadFileAsync(DocumentObject doc)
        {
            var docobject = Urllist.FirstOrDefault(x => x.ID == doc.ID);
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    Thread.Sleep(2000);
                    string downloadToDirectory = DIRpath + doc.docName;
                    await webClient.DownloadFileTaskAsync(new Uri(doc.docUrl), downloadToDirectory);
                    docobject.status = "success downloaded";
       
                }
            }
            catch (Exception ex)
            {
                docobject.status = "downloading failed";
           
            }
        }

        private async Task DownloadMultipleFilesAsync(List<DocumentObject> doclist)
        {
           // listBox1.Items.Clear();
            await Task.WhenAll(doclist.Select(doc => DownloadFileAsync(doc)));
            ShowURLlist();
        }


    }
}
