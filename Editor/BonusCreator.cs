using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public class BonusCreator : MonoBehaviour
    {
        public GameObject Bottom;
        public GameObject ColorBonus;
        public string NameObject = "ColorBonus";
        public int Count = 10;
        private Transform _root;

        private void Awake()
        {
            CreateBonus();
        }

        private void CreateBonus()
        {
            _root = new GameObject("Root").transform;
            for (var i = 1; i <= Count; i++)
            {
                Instantiate(ColorBonus, GenerateNewPoint(), Quaternion.identity, _root);
            }
        }

        private Vector3 GenerateNewPoint()
        {
            Vector3 result = Vector3.zero;
            int attempt = 10;
            float minX = Bottom.transform.position.x - Bottom.transform.localScale.x / 2;
            float maxX = Bottom.transform.position.x + Bottom.transform.localScale.x / 2;
            float minZ = Bottom.transform.position.z - Bottom.transform.localScale.z / 2;
            float maxZ = Bottom.transform.position.z + Bottom.transform.localScale.z / 2;
            for (int i = 0; i < attempt; i++)
            {
                var checkPoint = new Vector3(Random.Range(minX, maxX),
                    0.0f, Random.Range(minZ, maxZ));
                var col = new Collider[3];
                int countColliders = Physics.OverlapSphereNonAlloc(checkPoint, 1.0f, col);
                Debug.Log($"попытка {i} коллайдеров {countColliders}");
                if (countColliders == 1)
                    return checkPoint;
            }
            return result;
        }
    };
}
