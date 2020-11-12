using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace CSharpUnityExamples
{
    public class FifthLessonTest : MonoBehaviour
    {
        private void Start()
        {
            SecondTask();
            Debug.Log("*****");
            ThirdTask();
            Debug.Log("*****");
            ForthTask();
        }

        private static void SecondTask()
        {
            List<string> text = new List<string>();
            text.AddRange(new string[]
            {
                "dkjfksjkfd887342kf  дывлб",
                "алыоjiue83429",
                "аошу ьвыулдл",
            });
            foreach (string t in text)
            {
                int count = t.CountSymbols();
                Debug.Log($"{count} символов в строке");
            }
        }

        private void ThirdTask()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] {4, 1, 4, 1, 9, 4, 4});
            FindSameNumber(list);
            Debug.Log("*****");
            FindSameObject(list);
            Debug.Log("*****");
            FindThrowLinq(list);
        }

        private void FindSameNumber(List<int> list)
        {

            for (int num = 0; num < list.Count; num++)
            {
                int count = 0;
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[num] == list[i])
                    {
                        count++;
                    }
                }

                Debug.Log($"{list[num]} встречается {count} раз(а)");
            }
        }

        private void FindSameObject<T>(List<T> list)
        {
            for (int obj = 0; obj < list.Count; obj++)
            {
                int count = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[obj].IsOneOf<T>(list[i]))
                    {
                        count++;
                    }
                }
                Debug.Log($"{list[obj]} встречается {count} раз(а)");
            }
        }
        
        private void FindThrowLinq<T>(List<T> list)
        {
            var queryDictionary = list.GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.Count());
            foreach (var q in queryDictionary)
            {
                Debug.Log(q);
            }
        }

        private static void ForthTask()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4},
                {"two", 2},
                {"one", 1},
                {"three", 3},
            };
            var d = dict.OrderBy(delegate(KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
            Debug.Log("*****");
            //через лямбда-выражение
            var l = dict.OrderBy(delegate(KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in l)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
            Debug.Log("*****");
            //через делегат
            int Func(KeyValuePair<string, int> pair) => pair.Value;

            var f = dict.OrderBy(Func);
            foreach (var pair in f)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }
    }
}