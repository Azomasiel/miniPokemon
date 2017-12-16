using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour {

    public int pokemon = 0;

    public void OnSelectionChanges(int pokemonIndex)
    {
        pokemon = pokemonIndex;
    }
}
