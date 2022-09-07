using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PacmanController : MonoBehaviour
{
    private Vector2 _directionPacman;
    private MovementController _movementController;

    private void Awake()
    {
        _movementController = GetComponent<MovementController>(); 
    }
    
    private void Start()
    {
        _directionPacman = Vector2.zero;
    }
    
    private void Update()
    {
        Move();
        Rotate(); 
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
