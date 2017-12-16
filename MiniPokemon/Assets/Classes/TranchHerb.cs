using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class TranchHerb : Attack
{
    public GameObject animator;

    public TranchHerb():base(0.5f)
    {
    }


    public override void Animation(int attacker, int defender)
    {
        animator.SetActive(true);
    }
}