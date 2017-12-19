using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using miniPokemon;
using UnityEngine.UI;


public class Game : MonoBehaviour {
    public bool gameStarted = false;
    private int step = 0;
    private bool stepped = false;

    public Trainer trainer;
    public Trainer opponent;

    private Pokemon pokeTrainer; //Trainer's Pokemon
    private Pokemon pokeOppo; //Opponent's Pokemon
    bool isPika = true;

    public GameObject pikachuGO; //prefab
    public GameObject salamecheGO; //prefab

    private GameObject pika; //instance
    private GameObject sala; //instance

    public Attack[] attackList;

    private string turnDisplay;
    string displayTurn;
    private string chooseAttackDisplay;
    private string stateDisplay;

    private static int screenHeight = Screen.height;
    private static int screenWidth = Screen.width;
    private static int canvas0Height = screenHeight - 300;
    private static int canvas0Width = screenWidth/2 - 500;

    public GameObject canvas; //Prefab!
    public int fontSize;
    public Text textPrefab;
    static Color textColor = Color.white;

    Text attackText;
    Text turnText;
    Text announceText;

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

    public static Text AddTextToCanvas(string textString, GameObject canvasGameObject)
    {
        Text text = canvasGameObject.AddComponent<Text>();
        text.text = textString;
        
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        return text;
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
        if (gameStarted && pokeOppo.life > 0 && pokeTrainer.life > 0)
        {
            if (step == 0 && !stepped)
            {
                displayTurn = "Turn: " + frame;
                position = new Vector3(canvas0Width + 10, canvas0Height + 10, 0);
                turnText = AddText(displayTurn, fontSize, canvas, textPrefab, position);

                displayAnnounceMessage = announcementMessages[frame % nbMessages];
                position = new Vector3(canvas0Width + 10, canvas0Height + 110, 0);
                announceText = AddText(displayAnnounceMessage, fontSize, canvas, textPrefab, position);

                position = new Vector3(canvas0Width + 10, canvas0Height + 210, 0);
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
                    TranchHerb.Animation(true);
                    pokeOppo.GetHurt(pokeTrainer.damage * TranchHerb.ratio);
                    pokeTrainer.GetHurt(pokeOppo.damage * LanceFlamme.ratio);
                }
                else
                {
                    LanceFlamme.Animation(true);
                    pokeOppo.GetHurt(pokeTrainer.damage * LanceFlamme.ratio);
                    pokeTrainer.GetHurt(pokeOppo.damage * TranchHerb.ratio);
                }

                DestroyObject(turnText);
                DestroyObject(announceText);
                DestroyObject(attackText);

                displayTurn = "L'adversaire vous attaque !";
                position = new Vector3(canvas0Width + 10, canvas0Height + 10, 0);
                turnText = AddText(displayTurn, fontSize, canvas, textPrefab, position);

                displayAnnounceMessage = "Appuyer sur entrée pour continuer";
                position = new Vector3(canvas0Width + 10, canvas0Height + 110, 0);
                announceText = AddText(displayAnnounceMessage, fontSize, canvas, textPrefab, position);
                frame++;
            }

            if (!Input.GetKeyDown(KeyCode.Return) && step == 1) {
                stepped = false;
                step = 0;
                DestroyObject(turnText);
                DestroyObject(announceText);
            }

            
        }
    }
}