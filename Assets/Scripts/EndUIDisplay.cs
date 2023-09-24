using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUIDisplay : MonoBehaviour            //Attached to the EndGameCanvas game object
{
    [SerializeField]
    private GameManager gameManager;

    [Tooltip("Text Mesh Object of the Score Text")]
    public TextMeshProUGUI ScoreText;

    [Header("GameObject Variables")]
    public GameObject GamePlayPrefab;
    public GameObject EndGameGO;
    public GameObject InfoPanelPrefab;

    private InfoUIDisplay InfoUIDisplay;

    private void OnEnable()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ScoreText.text = "Scored: " + gameManager.GameScore;
    }

    /*
     * Selecting the Mode Button
     * Pass in the Button Object
     */
    public void OnModeButtonSelect(Button button)
    {
        if (button.name == "EasyModeButton")
        {
            gameManager.ModeSelected = GameManager.GameModes.easy;
        }
        else if (button.name == "MediumModeButton")
        {
            gameManager.ModeSelected = GameManager.GameModes.medium;
        }
        else
        {
            gameManager.ModeSelected = GameManager.GameModes.hard;
        }

        GameObject GamePlayUIClone = Instantiate(GamePlayPrefab, this.transform.position, this.transform.rotation) as GameObject;
        GamePlayUIClone.name = "Gameplay";       

        Destroy(EndGameGO);        
    }

    /*
    * Selecting the Info Button
    * Pass in the Button Object
    * Instantiate the infopanelprefab
    */
    public void OnInfoSelect(Button button)
    {
        GameObject InfoUIClone = Instantiate(InfoPanelPrefab, this.transform.position, this.transform.rotation) as GameObject;
        InfoUIClone.name = button.name;
        InfoUIDisplay = InfoUIClone.GetComponent<InfoUIDisplay>();
        InfoUIDisplay.OnInsantiate(button.name);
    }
}
