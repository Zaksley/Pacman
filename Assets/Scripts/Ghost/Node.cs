using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    private Vector2 upDirection = Vector2.up;
    private Vector2 downDirection = Vector2.down;
    private Vector2 rightDirection = Vector2.right;
    private Vector2 leftDirection = Vector2.left;

    private LayerMask nodeMask;
    public List<Vector2> availableDirections = new List<Vector2>();
    public string collidername;
    // Start is called before the first frame update
    void Start()
    {
        nodeMask = gameObject.layer;
        CheckDirectionAvailable(upDirection);
        CheckDirectionAvailable(downDirection);
        CheckDirectionAvailable(rightDirection);
        CheckDirectionAvailable(leftDirection);
    }
    void CheckDirectionAvailable(Vector2 direction)
    {
        RaycastHit2D hitdata = Physics2D.Raycast(gameObject.transform.position, direction, 0.5f,nodeMask);
        Debug.DrawRay(gameObject.transform.position, direction*0.5f, Color.red, 30f);
        if (hitdata.collider == null)
        {

            availableDirections.Add(direction);
        }
        else collidername = hitdata.collider.name;

    }
}
