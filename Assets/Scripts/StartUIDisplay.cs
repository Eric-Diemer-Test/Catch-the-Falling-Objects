using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUIDisplay : MonoBehaviour            //Attached to the startmenucanvas game object
{   
    private GameManager gameManager;

    [Header("Canvas Variables")]
    public GameObject StartMenuCanvasGO;
    public GameObject EndMenuCanvasGO;
    public GameObject GamePlayCanvasGO;

    public GameObject InfoPanelGO;
    public GameObject MediumInfoGO;
    public GameObject HardInfoGO;

    [Tooltip("Text Mesh Object of the Timer Text")]
    public TextMeshProUGUI TimerText;

    [Tooltip("Text Mesh Object of the Info Title Text")]
    public TextMeshProUGUI InfoTitleText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartMenuCanvasGO.SetActive(true);
        EndMenuCanvasGO.SetActive(false);
        GamePlayCanvasGO.SetActive(false);
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
        
        StartMenuCanvasGO.SetActive(false);      
        GamePlayCanvasGO.SetActive(true);
    }   

    /*
    * Selecting the Info Button
    * Pass in the Button Object
    */
    public void OnInfoSelect(Button button)
    {
        Debug.Log("Name is " + button.name);

        MediumInfoGO.SetActive(false);
        HardInfoGO.SetActive(false);

        if (button.name == "EasyInfo")
        {
            TimerText.text = "2 minutes";
            InfoTitleText.text = "Easy Mode Info";
        }
        else if (button.name == "MediumInfo")
        {
            TimerText.text = "1 minute";
            InfoTitleText.text = "Medium Mode Info";
            MediumInfoGO.SetActive(true);          
        }
        else 
        {
            TimerText.text = "1 minute";
            InfoTitleText.text = "Hard Mode Info";
            HardInfoGO.SetActive(true);
        }

        InfoPanelGO.SetActive(true);
    }

    /*
    * Selecting the Close Info Button
    */
    public void OnInfoClose()
    {
        InfoPanelGO.SetActive(false);
    }
}
