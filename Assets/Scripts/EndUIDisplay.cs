using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUIDisplay : MonoBehaviour            //Attached to the EndGameCanvas game object
{
    [SerializeField]
    private GameData gameData;

    [Tooltip("Text Mesh Object of the Score Text")]
    public TextMeshProUGUI ScoreText;

    [Header("GameObject Variables")]
    public GameObject GamePlayPrefab;
    public GameObject EndGameGO;
    public GameObject InfoPanelPrefab;

    private InfoUIDisplay infoUIDisplay;

    /*
     * Called on enable of the object
     */
    private void OnEnable()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        ScoreText.text = "Scored: " + gameData.GameScore;
    }

    /*
     * Selecting the Mode Button
     * Pass in the Button Object
     */
    public void OnModeButtonSelect(Button button)
    {
        if (button.name == "EasyModeButton")
        {
            gameData.ModeSelected = GameData.GameModes.easy;
        }
        else if (button.name == "MediumModeButton")
        {
            gameData.ModeSelected = GameData.GameModes.medium;
        }
        else
        {
            gameData.ModeSelected = GameData.GameModes.hard;
        }

        GameObject gamePlayUIClone = Instantiate(GamePlayPrefab, this.transform.position, this.transform.rotation) as GameObject;
        gamePlayUIClone.name = "Gameplay";       

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
        infoUIDisplay = InfoUIClone.GetComponent<InfoUIDisplay>();
        infoUIDisplay.OnInstantiate(button.name);
    }
}
