namespace FeedBuilder
{
    using System;
    using System.Collections.Specialized;

    [Serializable]
    public class Settings
    {
        public string BaseUrl { get; set; }

        public bool Cleanup { get; set; }

        public bool CompareDate { get; set; }

        public bool CompareHash { get; set; }

        public bool CompareSize { get; set; }

        public bool CompareVersion { get; set; }

        public bool CopyFiles { get; set; }

        public string FeedXml { get; set; }

        public bool IgnoreDebugSymbols { get; set; }

        public StringCollection IgnoreFiles { get; set; }

        public bool IgnoreVsHosting { get; set; }

        public string OutputFolder { get; set; }

        public Settings()
        {
            Reset();
        }

        public void Reset()
        {
            Cleanup = true;
            CompareDate = false;
            CompareHash = true;
            CompareSize = false;
            CompareVersion = true;
            CopyFiles = true;
            FeedXml = String.Empty;
            IgnoreDebugSymbols = true;
            IgnoreFiles = new StringCollection();
            IgnoreVsHosting = true;
            OutputFolder = String.Empty;
        }
    }
}