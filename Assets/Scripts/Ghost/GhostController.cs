using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public MovementController movement;

    private void Start()
    {
        movement = GetComponent<MovementController>();
    }
}
