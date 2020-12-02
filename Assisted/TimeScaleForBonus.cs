using System.Collections;
using UnityEngine;


namespace Labyrinth
{
    public static class TimeScaleForBonus
    {
        public delegate void UndoChangesToThePlayer();
        public static void StartTheCountdown(MonoBehaviour parent, int interval, UndoChangesToThePlayer cancelChanges)
        {
            parent.StartCoroutine(TimeBonus(interval, cancelChanges));
        }
        
        public static IEnumerator TimeBonus(int interval, UndoChangesToThePlayer cancelChanges)
        {
            yield return new WaitForSeconds(interval);
        
            cancelChanges();
        }
    }
}
