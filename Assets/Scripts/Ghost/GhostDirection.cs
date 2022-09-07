using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDirection : MonoBehaviour
{
    private Vector2 directionToTake;
    private MovementController ghostMovement;
    private GhostController ghostController;

    private void Start()
    {
        ghostMovement = GetComponent<MovementController>();
        //ghostController = GetComponent<GhostController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Node newNode = collision.GetComponent<Node>();

        if (newNode != null)
        {

            directionToTake = choseRandomDirection(newNode.availableDirections, newNode);
            Debug.Log(directionToTake);
            //ghostController.newDirection = directionToTake;

            //ghostMovement.SetDirection(directionToTake);
            transform.position += (new Vector3(directionToTake.x,directionToTake.y)*4*Time.deltaTime);

        }
    }



    Vector2 choseRandomDirection(List<Vector2> listDirection, Node node )
    {
        int indexRandom = Random.Range(0, listDirection.Count);
        //if (node.availableDirections[indexRandom] == -ghostMovement.Direction)
        //{
        //    indexRandom++;

        //    // Wrap the index back around if overflowed
        //    if (indexRandom >= node.availableDirections.Count)
        //    {
        //        indexRandom = 0;
        //    }
        //}

        return listDirection[indexRandom];
    }
}
