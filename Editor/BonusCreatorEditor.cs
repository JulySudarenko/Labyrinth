using UnityEditor;
using UnityEngine;


namespace Labyrinth
{
    [CustomEditor(typeof(BonusCreator))]
    public class BonusCreatorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            BonusCreator bonusCreator = (BonusCreator) target;
            bonusCreator.Bottom = EditorGUILayout.ObjectField("Лабиринт", bonusCreator.Bottom,
                typeof(GameObject), false) as GameObject;

            GUILayout.Label(bonusCreator.NameObject, EditorStyles.boldLabel);
            bonusCreator.Count = EditorGUILayout.IntSlider(bonusCreator.Count, 5, 30);
            bonusCreator.ColorBonusPrefab =
                EditorGUILayout.ObjectField("Создаваемый бонус", bonusCreator.ColorBonusPrefab,
                    typeof(GameObject), false) as GameObject;
        }
    }
}
