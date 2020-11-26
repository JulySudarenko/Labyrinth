using UnityEditor;


namespace Labyrinth
{
    public class LabyrinthMenu
    {
        [MenuItem("Labyrinth/Add color ball")]
        private static void MenuOptionWindow()
        {
            EditorWindow.GetWindow(typeof(ColorBallParty), false, "Add color ball");
        }
    }
}
