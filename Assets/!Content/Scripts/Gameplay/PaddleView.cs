using FlippyPong.Gameplay;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PaddleView : NetworkBehaviour, IPaddleView
{
    [SerializeField] private Field _field = default;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    
    public void SetPosition(float position)
    {
        if (!hasAuthority)
        {
            return;
        }
        
        var viewPosition = transform.position;
        var viewExtents = _collider.bounds.extents;

        var limit_a = _field.Bounds.min.x + viewExtents.x;
        var limit_b = _field.Bounds.max.x - viewExtents.x;

        viewPosition.x = Mathf.Lerp(limit_a, limit_b, position);

        transform.position = viewPosition;
    }
}
