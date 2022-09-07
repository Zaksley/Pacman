using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDirection : MonoBehaviour
{
    private Vector2 directionToTake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Node>())
        {
            Debug.Log("meet node");
            Node node = collision.GetComponent<Node>();
            directionToTake = choseRandomDirection(node.availableDirections);
            GetComponent<MovementController>().SetDirection(directionToTake);

        }
    }

    Vector2 choseRandomDirection(List<Vector2> listDirection)
    {
        int indexRandom = Random.Range(0, listDirection.Count);
        return listDirection[indexRandom];
    }
}
