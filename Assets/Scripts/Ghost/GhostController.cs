using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Vector2 initialDirection;
    [SerializeField] private float speed;
    public Vector2 newDirection;
    private GhostAnimationController _animationController;
    public SpriteRenderer EyeSpriteRenderer;
    [SerializeField] private Sprite[] _sprites;

    private void Start()
    {
        newDirection = initialDirection;
        _animationController = GetComponent<GhostAnimationController>();
        _animationController.PlayRun();
    }

    private void Update()
    {
        transform.position += (new Vector3(newDirection.x, newDirection.y)*speed*Time.deltaTime);
        if(newDirection == Vector2.up)
        {
            EyeSpriteRenderer.sprite = _sprites[0];
        } 
        else if(newDirection == Vector2.right)
        {
            EyeSpriteRenderer.sprite = _sprites[1];
        }
        else if (newDirection == Vector2.down)
        {
            EyeSpriteRenderer.sprite = _sprites[2];
        }
        else if (newDirection == Vector2.left)
        {
            EyeSpriteRenderer.sprite = _sprites[3];
        }
    }

    private void Eat()
    {
        FindObjectOfType<GameManager>().PacmanEaten();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            other.GetComponent<CircleCollider2D>().enabled = false;
            Eat();
        }
    }
}
