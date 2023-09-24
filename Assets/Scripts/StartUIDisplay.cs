using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUIDisplay : MonoBehaviour            //Attached to the startmenucanvas game object
{   
    private GameManager gameManager;

    [Header("Canvas Variables")]
    public GameObject StartMenuCanvasGO;      

    [Header("Prefab Variables")]
    public GameObject InfoPanelPrefab;
    public GameObject GamePlayPrefab;

    private InfoUIDisplay infoUIDisplay;  

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
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

        GameObject gamePlayUIClone = Instantiate(GamePlayPrefab, this.transform.position, this.transform.rotation) as GameObject;
        gamePlayUIClone.name = "Gameplay";        

        Destroy(StartMenuCanvasGO);
    }

    /*
    * Selecting the Info Button
    * Pass in the Button Object
    * instantiate the infopanelprefab
    */
    public void OnInfoSelect(Button button)
    {
        GameObject infoUIClone = Instantiate(InfoPanelPrefab, this.transform.position, this.transform.rotation) as GameObject;
        infoUIClone.name = button.name;
        infoUIDisplay = infoUIClone.GetComponent<InfoUIDisplay>();
        infoUIDisplay.OnInstantiate(button.name);
    }
}
