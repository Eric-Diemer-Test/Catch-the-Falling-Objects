using TMPro;
using UnityEngine;

public class GameUIDisplay : MonoBehaviour            //Attached to the Game play canvas prefab game object
{
    [SerializeField]
    private GameData gameData;

    [Tooltip("Text Mesh Object of the Score Text")]
    public TextMeshProUGUI ScoreText;

    [Tooltip("Text Mesh Object of the Timer Text")]
    public TextMeshProUGUI TimerText;
    
    private float timer;

    [Header("GameObject Variables")]
    public GameObject EndGamePrefab;
    public GameObject GamePlayCanvasGO;

    public GameObject MediumObjectsGO;
    public GameObject HardObjectsGO;

    public GameObject FallingObectGO;

    private bool isGameOver;    

    private void OnEnable()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        isGameOver = false;
        gameData.GameScore = 0;
        MediumObjectsGO.SetActive(false);
        HardObjectsGO.SetActive(false);      

        //set the display timers based on game mode
        if (gameData.ModeSelected == GameData.GameModes.easy)
        {
            timer = 120;
        }
        else if (gameData.ModeSelected == GameData.GameModes.medium)
        {
            timer = 60;
            MediumObjectsGO.SetActive(true);
        }
        else if (gameData.ModeSelected == GameData.GameModes.hard)
        {
            timer = 60;
            HardObjectsGO.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + gameData.GameScore;
        OnCountDown();
    }

    /*
     * Set the count down display
     */
    private void OnCountDown()
    {
        if (!isGameOver) 
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                int Minutes = Mathf.FloorToInt(timer / 60F);
                int Seconds = Mathf.FloorToInt(timer - Minutes * 60);

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
    private void OnGameOver()
    {
        gameData.NumberObjectsSpawned = 0;

        gameData.IsStunned = false;

        GameObject endGameUIClone = Instantiate(EndGamePrefab, new Vector3(0f,0f,0f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
        endGameUIClone.name = "EndGame";

        Destroy(GamePlayCanvasGO);       
    }
}
