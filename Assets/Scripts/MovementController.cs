using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    public new Rigidbody2D Rb { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _speedMultiplier = 1.0f;

    public Vector2 InitialDirection;
    [SerializeField] private LayerMask _obstacleLayer;

    public Vector2 Direction { get; private set; }
    public Vector2 NextDirection { get; private set; }
    public Vector3 StartingPosition { get; private set; } 
    
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        StartingPosition = transform.position; 
    }

    private void Start()
    {
        ResetState();
    }

    private void ResetState()
    {
        _speedMultiplier = 1.0f;
        Direction = InitialDirection;
        NextDirection = Vector2.zero;
        transform.position = StartingPosition;
        Rb.isKinematic = false;
        enabled = true; 
    }

    private void Update()
    {
        if (NextDirection != Vector2.zero)
        {
            SetDirection(NextDirection);
        }
    }
    
    private void FixedUpdate()
    {
        Vector2 position = Rb.position;
        Vector2 translation = Direction * _speed * _speedMultiplier * Time.fixedDeltaTime; 
        Rb.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forcedDirection = false)
    {
        if (forcedDirection || !Occupied(direction))
        {
            this.Direction = direction;
            NextDirection = Vector2.zero; 
        }
        else
        {
            NextDirection = direction; 
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, _obstacleLayer);
        return hit.collider != null; 
    }
}
