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

    private Rigidbody2D _body;
    private void Start()
    {
        if (gameObject.layer != 8)
        {
            //Touchable layer
            gameObject.layer = 8;
        }

        _body = GetComponent<Rigidbody2D>();
        //onTouchEnd.AddListener(ZeroOutVelocity);
    }

    void Update()
    {
        
    }

    public void MoveToTouchDelta(Vector2 delta)
    {
        _body.AddForce(delta);
    }

    public void MoveToTouch(Vector2 pos)
    {
        _body.MovePosition(pos);
    }

    private void ZeroOutVelocity()
    {
        Debug.Log("zeroing out velocity");
        _body.velocity = Vector2.zero;
    }
    
}
