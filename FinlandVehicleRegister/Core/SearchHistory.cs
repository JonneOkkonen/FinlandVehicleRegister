using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FinlandVehicleRegister.Core
{
    public static class SearchHistory
    {
        public static readonly string Path = ApplicationData.Current.LocalFolder.Path + @"\SearchHistory.bin";
        private static IFormatter formatter = new BinaryFormatter();

        /// <summary>
        /// SearchHistory List
        /// </summary>
        public static List<SearchHistoryItem> List = new List<SearchHistoryItem>();

        /// <summary>
        /// Read SearchHistory from File
        /// </summary>
        public static void Read()
        {
            try
            {
                Stream openStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
                if(openStream.Length > 0)
                {
                    List = (List<SearchHistoryItem>)formatter.Deserialize(openStream);
                }
                openStream.Close();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Save SearchHistory to File
        /// </summary>
        public static void Save()
        {
            try
            {
                Stream writeMultipleStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(writeMultipleStream, List);
                writeMultipleStream.Close();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add new item to SearchHistoryList (not file)
        /// </summary>
        /// <param name="item"></param>
        public static void AddItem(SearchHistoryItem item)
        {
            if (List.Count >= 10) List.RemoveAt(0);
            List.Add(item);
        }
    }
}
