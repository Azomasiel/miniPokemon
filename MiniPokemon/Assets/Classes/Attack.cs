using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class Attack : MonoBehaviour
{
    protected float ratio;

    public virtual void Animation()
    {
    }

    public Attack(float ratio)
    {
        this.ratio = ratio;
    }
}
