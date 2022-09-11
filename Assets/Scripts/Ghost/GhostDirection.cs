using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDirection : MonoBehaviour
{
    public Vector2 directionToTake;
    private GhostController ghostController;


    private void Start()
    {
        gameObject.GetComponent<GhostBase>().enabled=false;
        ghostController = GetComponent<GhostController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Node newNode = collision.GetComponent<Node>();

        if (newNode != null)
        {

            directionToTake = choseRandomDirection(newNode.availableDirections, newNode);
            Debug.Log(directionToTake);
            transform.position = new Vector3(collision.transform.position.x,collision.transform.position.y,transform.position.z);
            ghostController.newDirection = directionToTake;

        }
    }



    private Vector2 choseRandomDirection(List<Vector2> listDirection, Node node )
    {
        int indexRandom = Random.Range(0, listDirection.Count);

        if (listDirection[indexRandom] == -ghostController.newDirection)
        {
            indexRandom++;
            if(indexRandom>= node.availableDirections.Count)
            {
                indexRandom = 0;
            }
        }

        return listDirection[indexRandom];
    }
}
