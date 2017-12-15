using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class Pikachu : Pokemon
{
    public Pikachu():base("Pikachu", 100, 70, Poketype.ELECTRICK)
    {
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.R))
        {
            attackList[0].Animation();
        }
    }
}
