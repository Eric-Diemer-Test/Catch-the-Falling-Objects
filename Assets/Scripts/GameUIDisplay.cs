using TMPro;
using UnityEngine;

public class GameUIDisplay : MonoBehaviour            //Attached to the UI game object
{
    [SerializeField]
    private GameManager gameManager;

    [Tooltip("Text Mesh Object of the Score Text")]
    public TextMeshProUGUI ScoreText;

    [Tooltip("Text Mesh Object of the Timer Text")]
    public TextMeshProUGUI TimerText;
    
    private float Timer;

    [Header("Canvas Variables")]
    public GameObject EndMenuCanvasGO;
    public GameObject GamePlayCanvasGO;

    public GameObject MediumObjectsGO;
    public GameObject HardObjectsGO;

    public GameObject FallingObectGO;

    private bool isGameOver;    

    private void OnEnable()
    {
        isGameOver = false;
        gameManager.GameScore = 0;
        MediumObjectsGO.SetActive(false);
        HardObjectsGO.SetActive(false);      

        //set the display timers based on game mode
        if (gameManager.ModeSelected == GameManager.GameModes.easy)
        {
            Timer = 120;
        }
        else if (gameManager.ModeSelected == GameManager.GameModes.medium)
        {
            Timer = 60;
            MediumObjectsGO.SetActive(true);
        }
        else if (gameManager.ModeSelected == GameManager.GameModes.hard)
        {
            Timer = 60;
            HardObjectsGO.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + gameManager.GameScore;
        OnCountDown();
    }

    /*
     * Set the count down display
     */
    public void OnCountDown()
    {
        if (!isGameOver) 
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
                int Minutes = Mathf.FloorToInt(Timer / 60F);
                int Seconds = Mathf.FloorToInt(Timer - Minutes * 60);

                string NeatTime = string.Format("{0:00}:{1:00}", Minutes, Seconds);

                TimerText.text = "Time: " + NeatTime;
            }
            else
            {
                OnGameOver();
            }
        }
    }

    /*
     * Open the Game Over Menu
     * And clean up before restarting
     * */
    public void OnGameOver()
    {
        isGameOver = true;
        GamePlayCanvasGO.SetActive(false);
        EndMenuCanvasGO.SetActive(true);

        //destory all left over falling objects
        foreach (Transform child in FallingObectGO.transform)
        {
            Destroy(child.gameObject);
        }

        gameManager.NumberObjectsSpawned = 0;        

        gameManager.IsStunned = false;
    }
}
