using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUIDisplay : MonoBehaviour            //Attached to the startmenucanvas game object
{   
    private GameManager gameManager;

    [Header("Canvas Variables")]
    public GameObject StartMenuCanvasGO;    
    public GameObject GamePlayCanvasGO;

    public GameObject InfoPanelPrefab;

    public GameObject GamePlayPrefab;

    private InfoUIDisplay InfoUIDisplay;  

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

        GameObject GamePlayUIClone = Instantiate(GamePlayPrefab, this.transform.position, this.transform.rotation) as GameObject;
        GamePlayUIClone.name = "Gameplay";        

        Destroy(StartMenuCanvasGO);
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
