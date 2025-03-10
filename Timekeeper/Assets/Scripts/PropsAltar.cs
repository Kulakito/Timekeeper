using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        private AltarManager altar;

        private void Awake()
        {
            targetColor = runes[0].color;
            altar = GetComponent<AltarManager>();
            altar.OnCollisionEvent += SetTargetColor;
        }

        private void SetTargetColor(bool active)
        {
            targetColor.a = active ? 1 : 0;
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }
}
