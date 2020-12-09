using UnityEngine;


namespace Labyrinth
{
    public class ColorController
    {
        private Renderer _coloringBonus;

        public ColorController(InteractiveObject coloringBonus)
        {
            _coloringBonus = coloringBonus.GetComponent<Renderer>();
        }

        public void ChangeColor()
        {
            _coloringBonus.sharedMaterial.color = Random.ColorHSV();
        }
    }
}
