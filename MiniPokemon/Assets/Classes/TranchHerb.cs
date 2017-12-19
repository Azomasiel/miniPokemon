using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class TranchHerb : Attack
{
    public static float ratio;
    public static GameObject animator;
    private static GameObject instance;

    public TranchHerb():base(0.5f)
    {
    }


    public static void Animation(bool isPlayer)
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
        instance = Instantiate(animator, position, rotation);
        DestroyObject(instance, 3);
    }
}