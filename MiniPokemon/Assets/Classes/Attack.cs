using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class Attack : MonoBehaviour
{
     public float ratio;

    public virtual void Animation(GameObject attacker, GameObject defender)
    {
    }

    public Attack(float ratio)
    {
        this.ratio = ratio;
    }
}
