using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Touchable : MonoBehaviour
{
    public Vector2 Position => new Vector2(transform.position.x, transform.position.y);

    public UnityEvent onTouchStart;
    public UnityEvent onDragged;
    public UnityEvent onHeld;
    public UnityEvent onTouchEnd;

    protected Rigidbody2D body;

    protected void Start()
    {
        if (gameObject.layer != 8)
        {
            //Touchable layer
            gameObject.layer = 8;
        }

        body = GetComponent<Rigidbody2D>();
        InitializeObject();
    }

    protected virtual void InitializeObject()
    {
    }
}
