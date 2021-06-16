using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DownloadService" in both code and config file together.
    public class DownloadService : IDownloadService
    {
        public File DownloadDocument()
        {
            File file = new File();
            file.Content = System.IO.File.ReadAllBytes(@"C:\MicrosoftTechnology\TFS\WCF\InterviewPreparation\14_P35_MTOMMessage\Data\IntroducationToWCF.pptx");
            file.Name = "IntroducationToWCF.pptx";
            return file;
        }

        
    }
}
