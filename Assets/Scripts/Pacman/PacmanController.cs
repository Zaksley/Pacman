using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PacmanController : MonoBehaviour
{
    public bool canMove = false;

    private Vector2 _directionPacman;
    private MovementController _movementController;
    private PacmanAnimationController _animationController;

    private void Awake()
    {
        _movementController = GetComponent<MovementController>();
        _animationController = GetComponent<PacmanAnimationController>();
    }
    
    private void Start()
    {
        _directionPacman = Vector2.zero;
        _animationController.PlayStart();
    }
    
    private void Update()
    {
        if(canMove)
        {
            Move();
            Rotate();
        }
    }
    public void StopMoving()
    {
        _directionPacman = Vector2.zero;
        _movementController.SetDirection(_directionPacman);
        canMove = false;
    }
    public void StartMoving()
    {
        _animationController.PlayRun();
        GetComponent<CircleCollider2D>().enabled = true;
        canMove = true;
    }

    private void Move()
    {
        _directionPacman = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_directionPacman != Vector2.zero)
        {
            _movementController.SetDirection(_directionPacman);
        }
    }
    
    private void Rotate()
    {
        float angle = Mathf.Atan2(_movementController.Direction.y, _movementController.Direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
}
