using FlippyPong.Customization;
using Mirror;
using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class Ball : NetworkBehaviour, IBall
    {
        [SerializeField] private SpriteRenderer _sprite = default;
        
        public void Apply(ColorCustomization data)
        {
            _sprite.color = data.Color;
        }

        public void Apply(SizeCustomization data)
        {
            transform.localScale = Vector3.one * data.Size;
        }
    }
}