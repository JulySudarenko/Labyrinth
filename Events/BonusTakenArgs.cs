using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class BonusTakenObserver
    {
        public delegate void BonusTaken(object o);

public sealed class Source
        {
            private event BonusTaken _taken;

            public void Add(BonusTaken t)
            {
                _taken += t;
            }
        }
    }
}
