using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUIDisplay : MonoBehaviour            //Attached to the EndGameCanvas game object
{
    [SerializeField]
    private GameManager gameManager;

    [Tooltip("Text Mesh Object of the Score Text")]
    public TextMeshProUGUI ScoreText;

    [Header("Canvas Variables")]
    public GameObject GamePlayCanvasGO;
    public GameObject EndGameCanvas;

    private void OnEnable()
    {      
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

        GamePlayCanvasGO.SetActive(true);
        EndGameCanvas.SetActive(false);
    }
}
