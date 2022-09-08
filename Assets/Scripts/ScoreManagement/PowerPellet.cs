using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPelletEaten(this);

    }
}
