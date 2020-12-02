using UnityEngine;
using UnityEngine.Serialization;


namespace Labyrinth
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        public Transform BallTransform;

        public Mesh BallMesh;

        public Material BallMaterial;

        [SerializeField, Range(1, 100)] private float _speed;

        public float Speed => _speed;

    }
}
