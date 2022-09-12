using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool findPacman = false;
    private Vector2 upDirection = Vector2.up;
    private Vector2 downDirection = Vector2.down;
    private Vector2 rightDirection = Vector2.right;
    private Vector2 leftDirection = Vector2.left;
    private Pacman pacman;

    public LayerMask excludeLayers;
    public List<Vector2> availableDirections = new List<Vector2>();
    public List<Vector2> initialDirections = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {    
        CheckDirectionAvailable(upDirection);
        CheckDirectionAvailable(downDirection);
        CheckDirectionAvailable(rightDirection);
        CheckDirectionAvailable(leftDirection);;
        foreach (Vector2 direction in initialDirections)
        {
            availableDirections.Add(direction);
        }
        pacman = GameObject.FindObjectOfType<Pacman>();
        findPacman = GameObject.FindObjectOfType<GameManager>().GhostFollowPacman;
    }

    void CheckDirectionAvailable(Vector2 direction)
    {
        RaycastHit2D hitdata = Physics2D.Raycast(gameObject.transform.position, direction, 2f, ~excludeLayers);
        Debug.DrawRay(gameObject.transform.position, direction*2f, Color.red, 30f);
        if (hitdata.collider == null)
        {
            initialDirections.Add(direction);
        }
    }


    private void Update()
    {
        if(findPacman)
        {
            foreach (Vector2 direction in initialDirections)
            {
                Vector2 pacmanDirection = pacman.transform.position - transform.position;
                if(Vector2.Angle(direction, pacmanDirection) < 45)
                {
                    
                    availableDirections.Add(direction);
                }
            }

            if(availableDirections.Count > 1000)
            {
                availableDirections.Clear();
                foreach (Vector2 direction in initialDirections)
                {
                   availableDirections.Add(direction);
                }
            }
        }
    }
    
}
