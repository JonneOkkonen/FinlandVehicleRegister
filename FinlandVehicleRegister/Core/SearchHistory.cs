﻿using System;
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
        public static readonly string FileName = ApplicationData.Current.LocalFolder.Path + @"\SearchHistory.bin";
        private static IFormatter formatter = new BinaryFormatter();
        public static List<SearchHistoryItem> List = new List<SearchHistoryItem>();

        public static void Read()
        {
            try
            {
                Stream openStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                List = (List<SearchHistoryItem>)formatter.Deserialize(openStream);
                openStream.Close();
            }
            catch
            {
                throw;
            }
        }

        public static void Save()
        {
            try
            {
                Stream writeMultipleStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(writeMultipleStream, List);
                writeMultipleStream.Close();
            }
            catch
            {
                throw;
            }
        }

        public static void AddItem(SearchHistoryItem item)
        {
            List.Add(item);
        }
    }
}
