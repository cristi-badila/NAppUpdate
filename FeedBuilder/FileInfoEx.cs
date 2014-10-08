using System.Diagnostics;
using System.IO;

namespace FeedBuilder
{
    using Microsoft.Deployment.WindowsInstaller;

    public class FileInfoEx
	{
		private readonly FileInfo myFileInfo;
		private readonly string myFileVersion;
		private readonly string myHash;

		public FileInfo FileInfo
		{
			get { return myFileInfo; }
		}

		public string FileVersion
		{
			get { return myFileVersion; }
		}

		public string Hash
		{
			get { return myHash; }
		}

        public string RelativeName { get; private set; }

		public FileInfoEx(string fileName, int rootDirLength)
		{
			myFileInfo = new FileInfo(fileName);
		    myFileVersion = fileName.EndsWith(".msi")
		                        ? GetMSIVersion(fileName)
		                        : FileVersionInfo.GetVersionInfo(fileName).FileVersion;
			if (myFileVersion != null) myFileVersion = myFileVersion.Replace(", ", ".");
			myHash = NAppUpdate.Framework.Utils.FileChecksum.GetSHA256Checksum(fileName);
            RelativeName = fileName.Substring(rootDirLength + 1);
		}

        private string GetMSIVersion(string msiPath)
	    {
            string versionString;
            using (var database = new Database(msiPath))
            {
                versionString = database.ExecuteScalar("SELECT `Value` FROM `Property` WHERE `Property` = '{0}'", "ProductVersion") as string;
            }

            return versionString;
	    }
	}
}
