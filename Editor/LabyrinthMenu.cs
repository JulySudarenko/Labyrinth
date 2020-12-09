using UnityEditor;


namespace Labyrinth
{
    public class LabyrinthMenu
    {
        [MenuItem("Labyrinth/Add disco ball")]
        private static void MenuDiscoBallCreator()
        {
            EditorWindow.GetWindow(typeof(ColorBallParty), false, "Add dicko ball");
        }
        
        [MenuItem("Labyrinth/Add color bonus")]
        private static void MenuColorBonusCreator()
        {
            EditorWindow.GetWindow(typeof(ColorBallParty), false, "Add color bonus");
        }
    }
}
