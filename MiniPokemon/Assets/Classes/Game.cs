using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;

public class Game : MonoBehaviour {
    public bool gameStarted = false;

    public Trainer trainer;
    public Trainer opponent;

    private Pokemon pokeTrainer;
    private Pokemon pokeOppo;


    public GameObject pikachuGO; //prefab
    public GameObject salamecheGO; //prefab

    private GameObject pika;
    private GameObject sala;

	public void GameInit() {

        Debug.Log("Game started");

        gameStarted = true;

        foreach (Pokemon pokemon in trainer.listPokemon)
        {
            if (pokemon.damage == Pokemon.pikachu.damage)
            {
                pika = Instantiate(pikachuGO, new Vector3(0, 0, 2), Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                sala = Instantiate(salamecheGO, new Vector3(0, 0, -2), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                pokeTrainer = Pokemon.pikachu;
                pokeOppo = Pokemon.dracaufeu;
            }
            else
            {
                sala = Instantiate(salamecheGO, new Vector3(0, 0, 2), Quaternion.Euler(new Vector3(0, 180, 0)));
                pika = Instantiate(pikachuGO, new Vector3(0, 0, -2), Quaternion.Euler(new Vector3(0, 0, 0)));
                pokeTrainer = Pokemon.dracaufeu;
                pokeOppo = Pokemon.pikachu;
            }
        }

        GameLaunched();
    }

    public void GameLaunched()
    {

    }
}
