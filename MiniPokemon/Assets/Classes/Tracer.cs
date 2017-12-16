using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class Tracer : MonoBehaviour {

    public int pokemon = 0;
    [SerializeField]
    private Trainer trainer;
    [SerializeField]
    private Trainer opponent;

    public void OnSelectionChanges(int pokemonIndex)
    {
        pokemon = pokemonIndex;
    }

    public void ConfirmAdd()
    {
        trainer.AddPokemon(pokemon);
        opponent.AddPokemon(1 - pokemon);
    }
}
