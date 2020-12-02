using UnityEngine;


namespace Labyrinth
{
    public class Flicker
    {
        private Material _flickeringBonus;
        
        public Flicker(InteractiveObject flickeringBonus)
        {
            _flickeringBonus = flickeringBonus.GetComponent<Renderer>().material;;
        }
        
        public void MakeItFlicker()
        {
            _flickeringBonus.color = new Color(_flickeringBonus.color.r, _flickeringBonus.color.g, _flickeringBonus.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
