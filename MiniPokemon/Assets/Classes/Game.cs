﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;
using UnityEngine.UI;


public class Game : MonoBehaviour {

    /*[Range(-900, 900)]
    public int x;
    [Range(-600, 600)]
    public int y;

    Text debugText;
    Vector3 positionDebug;*/



    public bool gameStarted = false;
    private int step = 0;
    private bool endWritten = false;
    private bool stepped = false;

    public Trainer trainer;
    public Trainer opponent;

    private Pokemon pokeTrainer; //Trainer's Pokemon
    private Pokemon pokeOppo; //Opponent's Pokemon
    bool isPika = true;

    public LanceFlamme lanceFlamme;
    public TranchHerb tranchHerb;

    public GameObject pikachuGO; //prefab
    public GameObject salamecheGO; //prefab

    private GameObject pika; //instance
    private GameObject sala; //instance

    private string turnDisplay;
    string displayTurn;
    private string chooseAttackDisplay;
    private string stateDisplay;

    private static int screenHeight = Screen.height;
    private static int screenWidth = Screen.width;
    private static int canvas0Height = -300;
    private static int canvas0Width = 200;

    public GameObject canvas; //Prefab!
    public int fontSize;
    public Text textPrefab;
    static Color textColor = Color.white;

    Text attackText;
    Text turnText;
    Text announceText;

    System.Random random = new System.Random();
    float ratioRandom;

    private static List<string> announcementMessages = new List<string> {"Votre adversaire est un dur à cuir à cuire ! Il faut agir !", "Allez ! Il ne faut qu'un tour pour anéantir cet avdersaire de pacotille !", "Cet adversaire méprisable ne paie rien pour attendre, sa mort est imminente !" };
    private static int frame = 0;
    static int nbMessages = announcementMessages.Count;
    string displayAnnounceMessage;

    Vector3 position; //to display text on UI

    public void GameInit() {

        gameStarted = true;

        foreach (Pokemon pokemon in trainer.listPokemon)
        {
            if (pokemon.damage == Pokemon.pikachu.damage) //if choice is Pikatchoum
            {
                pika = Instantiate(pikachuGO, new Vector3(0, 0, 10), Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                sala = Instantiate(salamecheGO, new Vector3(0, 0, -10), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                pokeTrainer = Pokemon.pikachu;
                pokeOppo = Pokemon.dracaufeu;
            }
            else //if choice is Salle à mèches
            {
                sala = Instantiate(salamecheGO, new Vector3(0, 0, 10), Quaternion.Euler(new Vector3(0, 180, 0)));
                pika = Instantiate(pikachuGO, new Vector3(0, 0, -10), Quaternion.Euler(new Vector3(0, 0, 0)));
                pokeTrainer = Pokemon.dracaufeu;
                pokeOppo = Pokemon.pikachu;
                isPika = false;
            }
        }
    }

    public static Text AddText(string textToDisplay, int fontSize, GameObject canvas, Text textPrefab, Vector3 position)
    {
        Text tempTextBox = Instantiate(textPrefab, position, Quaternion.identity) as Text;
        //Parent to the panel
        tempTextBox.transform.SetParent(canvas.transform, false);
        //Set the text box's text element font size and style:
        tempTextBox.fontSize = fontSize;
        //Set the text box's text element to the current textToDisplay:
        tempTextBox.text = textToDisplay;
        tempTextBox.color = Game.textColor;
        return tempTextBox;
    }

    public void Update()
    {
        /*positionDebug = new Vector3(x, y, 0);
        debugText = AddText("Debug", fontSize, canvas, textPrefab, positionDebug);*/
        if (gameStarted && pokeOppo.life > 0 && pokeTrainer.life > 0)
        {
            if (step == 0 && !stepped)
            {
                displayTurn = "Turn: " + frame;
                position = new Vector3(canvas0Width, canvas0Height, 0);
                turnText = AddText(displayTurn, fontSize, canvas, textPrefab, position);

                displayAnnounceMessage = announcementMessages[frame % nbMessages];
                position = new Vector3(canvas0Width, canvas0Height - 50, 0);
                announceText = AddText(displayAnnounceMessage, fontSize, canvas, textPrefab, position);

                position = new Vector3(canvas0Width, canvas0Height - 100, 0);
                if (isPika)
                    attackText = AddText("[A] - Noeud'Herbe", fontSize, canvas, textPrefab, position);
                else
                    attackText = AddText("[A] - Lance-Flamme", fontSize, canvas, textPrefab, position);
                stepped = true;
            }
            if (Input.GetKeyDown(KeyCode.A) && step == 0)
            {
                stepped = false;
                step = 1;

                if (isPika)
                {
                    tranchHerb.Animation(true);
                    ratioRandom = random.Next(2, 4);
                    pokeOppo.GetHurt((pokeTrainer.damage * TranchHerb.ratio) / ratioRandom);
                }
                else
                {
                    lanceFlamme.Animation(true);
                    ratioRandom = random.Next(2, 4);
                    pokeOppo.GetHurt((pokeTrainer.damage * LanceFlamme.ratio) / ratioRandom);
                }

                DestroyObject(turnText);
                DestroyObject(announceText);
                DestroyObject(attackText);
                if (pokeOppo.life > 0)
                {
                    displayTurn = "L'adversaire vous attaque !";
                    position = new Vector3(canvas0Width, canvas0Height, 0);
                    turnText = AddText(displayTurn, fontSize, canvas, textPrefab, position);

                    displayAnnounceMessage = "Appuyer sur Entrée pour continuer";
                    position = new Vector3(canvas0Width, canvas0Height -50, 0);
                    announceText = AddText(displayAnnounceMessage, fontSize, canvas, textPrefab, position);
                    frame++;
                }
                Debug.Log(pokeTrainer.life);
                Debug.Log(pokeOppo.life);
            }

            if (Input.GetKeyDown(KeyCode.Return) && step == 1) {
                stepped = false;
                step = 0;
                DestroyObject(turnText);
                DestroyObject(announceText);
                if (isPika)
                {
                    ratioRandom = random.Next(2, 4);
                    pokeTrainer.GetHurt((pokeOppo.damage * LanceFlamme.ratio) / ratioRandom);
                    lanceFlamme.Animation(false);
                }
                else
                {
                    ratioRandom = random.Next(2, 4);
                    pokeTrainer.GetHurt((pokeOppo.damage * TranchHerb.ratio) / ratioRandom);
                    tranchHerb.Animation(false);
                }
            }
            //DestroyObject(debugText, 1);
        }

        if (pokeOppo.life <= 0 && !endWritten)
        {
            displayAnnounceMessage = "BRAVO VOUS AVEZ TERRASSE L'ENNEMI!";
            position = new Vector3(canvas0Width, canvas0Height, 0);
            announceText = AddText(displayAnnounceMessage, fontSize, canvas, textPrefab, position);
            endWritten = true;
        }
        else if (pokeTrainer.life <= 0 && !endWritten)
        {
            displayAnnounceMessage = "Bravo, vous redoublez votre semestre!";
            position = new Vector3(canvas0Width, canvas0Height - 50, 0);
            announceText = AddText(displayAnnounceMessage, fontSize, canvas, textPrefab, position);
            endWritten = true;
        }
    }
}