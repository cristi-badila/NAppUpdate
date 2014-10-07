namespace FeedBuilder
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public class CustomSettingsProvider
    {
        private static CustomSettingsProvider _instance;

        public Settings Settings { get; private set; }

        public static CustomSettingsProvider Instance
        {
            get
            {
                return _instance ?? (_instance = new CustomSettingsProvider());
            }
        }

        private CustomSettingsProvider()
        {
            Settings = new Settings();
        }

        public void LoadFrom(string fileName)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(Settings));
                using (var streamReader = new StreamReader(fileName))
                {
                    Settings = (Settings)xmlSerializer.Deserialize(streamReader);
                }
            }
            catch (Exception ex)
            {
                var msg = string.Format("An error occurred while loading the file: {0}{0}{1}", Environment.NewLine, ex.Message);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveAs(string fileName)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(Settings));
                using (var streamWriter = new StreamWriter(fileName))
                {
                    xmlSerializer.Serialize(streamWriter, Settings);
                }
            }
            catch (Exception ex)
            {
                var msg = string.Format("An error occurred while saving the file: {0}{0}{1}", Environment.NewLine, ex.Message);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}