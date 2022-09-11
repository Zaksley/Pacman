using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Vector2 initialDirection;
    [SerializeField] private float speed;
    public Vector2 newDirection;

    private void Start()
    {
        newDirection = initialDirection;
    }

    private void Update()
    {
        transform.position += (new Vector3(newDirection.x, newDirection.y)*speed*Time.deltaTime);

    }
    private void Eat()
    {
        FindObjectOfType<GameManager>().PacmanEaten();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
}
