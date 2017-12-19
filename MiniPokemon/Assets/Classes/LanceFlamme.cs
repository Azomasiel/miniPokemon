using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class LanceFlamme : MonoBehaviour
{
    public static float ratio = 0.5f;
    [SerializeField]
    public GameObject animator;

    /*public LanceFlamme()
    {
    }*/


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