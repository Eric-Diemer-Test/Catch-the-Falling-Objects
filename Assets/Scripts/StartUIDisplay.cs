using UnityEngine;
using UnityEngine.UI;

public class StartUIDisplay : MonoBehaviour            //Attached to the startmenucanvas game object
{   
    private GameData gameData;

    [Header("Canvas Variables")]
    public GameObject StartMenuCanvasGO;      

    [Header("Prefab Variables")]
    public GameObject InfoPanelPrefab;
    public GameObject GamePlayPrefab;

    private InfoUIDisplay infoUIDisplay;  

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();        
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
