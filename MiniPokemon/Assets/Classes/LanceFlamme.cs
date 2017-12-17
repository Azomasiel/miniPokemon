using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class LanceFlamme : Attack
{
    public GameObject animator;

    public LanceFlamme():base(0.7f)
    {
    }


    public override void Animation(GameObject pokemon, bool isPlayer)
    {
        Vector3 position;
        Quaternion rotation;
        if (isPlayer)
        {
            position = new Vector3(0, 0, 5);
            rotation = Quaternion.Euler(0, 180, 0);

        }
        else
        {
            position = new Vector3(0, 0, -5);
            rotation = Quaternion.Euler(0, 0, 0);
        }
        Instantiate(gameObject, position, rotation);
        DestroyObject(gameObject, 3);
    }
}