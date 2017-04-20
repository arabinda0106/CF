using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using WinSCP;

namespace CodeFights
{
    public class WinSCPTest
    {
        public void Test()
        {
            string sftpServerName = "sftp-stg.ets.org";
            string sftpUser = "intSysSSIS";
            string sftpPassword = "h5@Ug4pE";

            string winScpExePath = "C:\\Users\\asahoo\\Documents\\CF\\C#\\CodeFights\\bin\\Debug\\WinSCP.exe";

            string tumbleWeedFolder = "/CRDS-K12TEST/Score_Reso1";
            string localFolder = "C:\\Users\\asahoo\\Documents\\CF\\C#\\CodeFights\\bin\\Debug\\Data\\";

            //string FileName = "Testing_File.txt";

            TimeSpan timeout = new TimeSpan(0, 5, 0);

            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = sftpServerName,
                UserName = sftpUser,
                Password = sftpPassword,
                GiveUpSecurityAndAcceptAnySshHostKey = true,
                Timeout = timeout
            };

            Session session = new Session();

            session.ReconnectTime = timeout;
            session.ExecutablePath = winScpExePath;
            session.Open(sessionOptions);

            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Automatic;

            TransferOperationResult transferResult;

            //download files

            if (tumbleWeedFolder.Substring(tumbleWeedFolder.Length - 1, 1) == "/")
                tumbleWeedFolder = tumbleWeedFolder + "*.*";
            else
                tumbleWeedFolder = tumbleWeedFolder + "/*.*";

            transferResult = session.GetFiles(tumbleWeedFolder, localFolder, false, transferOptions);
            transferResult.Check();

            //get filenames
            DirectoryInfo folder = new DirectoryInfo(localFolder);
            List<string> fileNames = new List<string>();

            foreach (FileInfo file in folder.GetFiles())
                fileNames.Add(file.FullName);

        }
    }
}
