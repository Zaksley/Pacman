using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<GhostController>().newDirection = Vector3.right;
        collision.GetComponent<GhostDirection>().enabled=true;
    }
}
