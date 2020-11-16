using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public static class TimeScaleForBonus
    {
        public delegate void MakeBaseSpeed();
        public static void StartTheCountdown(MonoBehaviour parent, int interval, MakeBaseSpeed speedMaker)
        {
            parent.StartCoroutine(TimeBonus(interval, speedMaker));
        }
        
        public static IEnumerator TimeBonus(int interval, MakeBaseSpeed speedMaker)
        {
            yield return new WaitForSeconds(interval);
        
            speedMaker();
        }
    }
}
