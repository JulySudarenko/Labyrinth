using UnityEditor;
using UnityEngine;


namespace Labyrinth
{
    public class ColorBallParty : EditorWindow
    {
        //private GameObject _labyrinthBottom;
        private static GameObject _objectInstantiate;
        private string _nameObject = "ColorBall";
        private bool _groupColorBallEnabled;
        private bool _randomColor = true;
        private int _countColorBall = 1;
        private float _minX = -13.0f;
        private float _maxX = 13.0f;
        private float _minZ = -13.0f;
        private float _maxZ = 13.0f;

        public void OnGUI()
        {
            GUILayout.Label("Создаваемый объект", EditorStyles.boldLabel);
            _objectInstantiate = EditorGUILayout.ObjectField("Создаваемый объект",
                _objectInstantiate, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            _groupColorBallEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
                _groupColorBallEnabled);
            _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
            _countColorBall = EditorGUILayout.IntSlider("Количество объектов",
                _countColorBall, 1, 1000);
            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("Создать объект");
            if (button)
            {
                if (_objectInstantiate)
                {
                    GameObject root = new GameObject("DiscoBall");
                    for (int i = 0; i < _countColorBall; i++)
                    {
                        Vector3 pos = new Vector3(Random.Range(_minX, _maxX), 
                            0.0f, Random.Range(_minZ, _maxZ));
                        GameObject temp = Instantiate(_objectInstantiate, pos, Quaternion.identity);
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();
                        if (tempRenderer && _randomColor)
                        {
                            tempRenderer.material.color = Random.ColorHSV();
                        }
                    }
                }
            }
        }
    }
}
