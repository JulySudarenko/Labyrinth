using UnityEngine;


namespace Labyrinth
{
    public class ColorController// : IExecute
    {
        private Color _coloringBonus;

        public ColorController(InteractiveObject coloringBonus)
        {
            _coloringBonus = coloringBonus.GetComponent<Renderer>().sharedMaterial.color;
        }

        public void ChangeColor()
        {
            _coloringBonus = Random.ColorHSV();
        }

        public void Execute()
        {
            ChangeColor();
        }
    }
}
