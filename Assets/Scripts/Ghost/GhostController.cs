using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private bool vulnerable;
    public float vulnerableTime = 7f;
    public Vector2 initialDirection;
    [SerializeField] private float speed;
    public Vector2 newDirection;
    private GhostAnimationController _animationController;
    public SpriteRenderer EyeSpriteRenderer;
    [SerializeField] private Sprite[] _sprites;

    private void Start()
    {
        vulnerable = false;
        newDirection = initialDirection;
        _animationController = GetComponent<GhostAnimationController>();
        _animationController.PlayRun();
    }

    private void Update()
    {
        FindObjectOfType<GameManager>().GhostScared = vulnerable;
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

    private void Eaten()
    {
        transform.position = GetComponent<GhostBase>().nodeCenterBase.transform.position;
    }

    public void BecomeVulnerable()
    {
        vulnerable = true;
        speed = 6;
        _animationController.PlayRunVulnerable();
        Invoke(nameof(StopVulnerable), vulnerableTime);
    }

    public void StopVulnerable()
    {
        vulnerable = false;
        speed = 5;
        _animationController.PlayRun();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if(!vulnerable)
            {
                other.GetComponent<CircleCollider2D>().enabled = false;
                Eat();
            } else
            {
                Eaten();
            }
        }
    }
}
