using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Labyrinth
{
    public class JsonData<T> : IData<T>
    {
        public void Save(List<T> data, string path = null)
        {
            List<string> str = new List<string>();
            foreach (var d in data)
            {
                JsonUtility.ToJson(d).AddTo(str);
            }

            File.WriteAllLines(path, str);
        }

        public List<T> Load(string path = null)
        {
            var loadSaveList = new List<T>();

            using (var file = File.OpenText(path))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    JsonUtility.FromJson<T>(line).AddTo(loadSaveList);
                }
            }

            return loadSaveList;
        }
    }
}
