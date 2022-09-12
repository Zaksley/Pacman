using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBase : MonoBehaviour
{
    enum basePositionGhost
    {
        Right,
        Center,
        Left
    }

    private GhostController ghostController;
    private bool goOut = false;
    private int index = 0;
    [SerializeField] private basePositionGhost basePosition;

    [SerializeField] GameObject nodeCenterBase;
    [SerializeField] GameObject nodePosition;
    [SerializeField] GameObject nodeEnd;

    [SerializeField] private float timeInBase;
    // Start is called before the first frame update
    void Start()
    {
        ghostController = gameObject.GetComponent<GhostController>();
        ghostController.initialDirection = Vector2.up;
    }

    void Timer()
    {
        if (timeInBase > 0)
        {
            timeInBase -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Timer();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!goOut)
        {
            if (collision.tag == "WallBase")
            {

                index++;
                if (index % 2 == 0)
                {

                    ghostController.newDirection = Vector3.up;

                }
                else
                {
                    ghostController.newDirection = Vector3.down;
                }

            }
        }

        if (collision.gameObject == nodePosition && timeInBase < 0)
        {
            goOut = true;
            if (basePosition == basePositionGhost.Left)
            {
                transform.position = collision.transform.position;
                ghostController.newDirection = Vector3.right;
            }
            if (basePosition == basePositionGhost.Right)
            {
                transform.position = collision.transform.position;
                ghostController.newDirection = Vector3.left;
            }
        }

        if (collision.gameObject == nodeCenterBase)
        {
            transform.position = collision.transform.position;
            ghostController.newDirection = Vector3.up;
        }

        if (collision.gameObject == nodeEnd)
        {
            gameObject.GetComponent<GhostDirection>().enabled=true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        

    }



}
