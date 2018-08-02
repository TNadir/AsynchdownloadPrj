using System;
using System.IO;

namespace AsynchdownloadPrj
{
    public class DocumentObject
    {
        GenerateID getid;
        public DocumentObject()
        {
            getid = new GenerateID();
        }

        public int ID 
        {
            get
            {
              return  getid.ID;
            }
        }

        public string docName {
        get {
                try
                {

                    var filename = "downloadedfile" + this.ID;
                    return filename + Path.GetExtension(this.docUrl);
                }
                catch (Exception ex)
                {

                    return null;
                }
              
            }
        }
        public string docUrl { get; set; }
        public string status { get; set; }
    }
}