using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public class BonusCreator : MonoBehaviour
    {
        public GameObject Bottom;
        [FormerlySerializedAs("ColorBonus")] public GameObject ColorBonusPrefab;
        public ColorBonus ColorBonus;
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
            for (int i = 0; i < Count; i++)
            {
                if (ColorBonusPrefab != null & !ColorBonus)
                {
                    Instantiate(ColorBonusPrefab, GenerateNewPoint(),
                        Quaternion.identity, _root).AddComponent<ColorBonus>();
                }
                else
                {
                    throw new ErrorNews("Не выходит каменный цветок");
                }
            }
        }

        private Vector3 GenerateNewPoint()
        {
            Vector3 result = Vector3.zero;

            int attempt = 10;
            var pos = Bottom.transform.position;
            var size = Bottom.transform.localScale;

            for (int i = 0; i < attempt; i++)
            {
                var checkPoint = new Vector3(Random.Range(pos.x - size.x / 2, pos.x + size.x / 2),
                    0.0f, Random.Range(pos.z - size.z / 2, pos.z + size.z / 2));
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
