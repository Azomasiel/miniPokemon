﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class Attack : MonoBehaviour
{
    public float ratio;
    [SerializeField]
    private Trainer trainer;
    [SerializeField]
    private Trainer opponent;


    public virtual void Animation(int attacker, int defender)
    {
        opponent.listPokemon[defender].life -= trainer.listPokemon[attacker].damage * ratio;
    }

    public Attack(float ratio)
    {
        this.ratio = ratio;
    }
}
