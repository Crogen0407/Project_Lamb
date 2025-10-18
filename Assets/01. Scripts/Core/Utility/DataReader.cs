using CsvHelper;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Project_Lamb.Core.Utility
{
    public static class DataReader
    {
        public static async UniTask<List<T>> ReadCSV<T>(string csvPath) where T : IGameData
        {
            var fullPath = Path.Combine(Application.dataPath, "98.Datas", csvPath);
            string csvContent;

            using (var reader = new StreamReader(fullPath))
            {
                csvContent = await reader.ReadToEndAsync();
            }

            var result = await UniTask.RunOnThreadPool(() =>
            {
                using var stringReader = new StringReader(csvContent);
                using var csvData = new CsvReader(stringReader, CultureInfo.InvariantCulture);

                return csvData.GetRecords<T>().ToList();
            });

            return result;
        }
    }
}