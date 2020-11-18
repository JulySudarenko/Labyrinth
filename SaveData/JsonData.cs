using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections.Generic;


namespace Labyrinth
{
    public class JsonData<T> : IData<T>
    {
        public void Save(List<T> data, string path = null)
        {
            string str = null;
            
            foreach (var d in data)
            {
                str += JsonUtility.ToJson(d);
            }

            //File.WriteAllText(path, Crypto.CryptoXOR(str));
            File.WriteAllText(path, str);
        }

        public List<T> Load(string path = null)
        {
            var str = File.ReadAllText(path); 
            // return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str));
            return JsonUtility.FromJson<List<T>>(str);
        }
    }
}