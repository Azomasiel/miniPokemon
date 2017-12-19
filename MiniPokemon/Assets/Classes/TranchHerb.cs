using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class TranchHerb : Attack
{
    public static float ratio = 0.7f;
    public GameObject animator;

    public TranchHerb()
    {
    }


    public void Animation(bool isPlayer)
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
        GameObject instance = Instantiate(animator, position, rotation);
        DestroyObject(instance, 3);
    }
}