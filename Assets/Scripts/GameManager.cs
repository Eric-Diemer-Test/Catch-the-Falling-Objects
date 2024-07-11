using UnityEngine;

public class GameManager : MonoBehaviour        //attached to the GameManager object in MainScene
{    
    [Header("Global Variables")]
    public bool IsStunned = false;

    [Tooltip("Current Game Score")]
    public int GameScore = 0;

    [Tooltip("Current Number of Objects spawned")]
    public int NumberObjectsSpawned = 0;

    [Header("Catcher variables")]
    public float[] CatcherMoveSpeed =
    {
        .6f,
        .5f,
        .4f
    };
    
    [Header("Failing Objects Variables")]
    [Header("Element 0 is Minnow")]
    [Header("Element 1 is Bream")]
    [Header("Element 2 is Bass")]
    [Header("Element 3 is Snake")]
    [Header("Element 4 is Hook")]
    [Tooltip("Sprite Array")]
    public Sprite[] FallingObjectsImages = null;

    [Tooltip("Objects Scores When Caught")]
    public int[] FallingObjectsScores = null;

    [Tooltip("Objects Falling Speeds")]
    public float[] FallingObjectsFallSpeeds = null;

    [Tooltip("Objects Fall Chance")]
    public int[] FallingObjectsFallingChance = null;

    [Header("Chance to spawn each object must total 100")]
    [Header("Possible Edge Case if Lowest Chance is not IN the following:  Bass, Snake, Hook, Bream, Minnow -- See Z is an issue")]
    [Tooltip("Chance per Object for Easy Mode")]
    public int[] FallingObjectsSpawnChancesEasy = null;
    [Tooltip("Chance per Object for Medium Mode")]
    public int[] FallingObjectsSpawnChancesMedium = null;
    [Tooltip("Chance per Object for Hard Mode")]
    public int[] FallingObjectsSpawnChancesHard = null;

    [Tooltip("Objects Sounds When Caught")]
    public AudioClip[] FailingObjectsCatchSounds = null;

    [Header("How Many Spawn per Mode Variables")]  
    public int NumberOfSpawnersEasy = 6;
    public int NumberOfSpawnersMedium = 9;
    public int NumberOfSpawnersHard = 12;   
   
    public enum GameModes {easy, medium, hard }

    public GameModes ModeSelected = GameModes.easy;

    [Header("Game Mode Variables")]
    [Header("Element 0 is Easy")]
    [Header("Element 1 is Medium")]
    [Header("Element 2 is Hard")]
    [Tooltip("Objects Delay in spawning .5 the value is min and max is 1.5 the value")]
    public float[] FallingObjectsIntervals = null;

    [Tooltip("Increase speed per mode value is 1 is same speed less than 1 speeds up more than 1 slows down")]
    public float[] FallingObjectsSpeed = null;

    [Header("How many objects can be spawned at a time")]
    public int[] MaxNumberObjectsSpawned = null;

    [Tooltip("Stun Duration")]
    public float StunDur = 3.0f;

    public GameObject StartMenuPrefab;   

    // Start is called before the first frame update
    void Start()
    {
        GameObject StartUIClone = Instantiate(StartMenuPrefab, this.transform.position, this.transform.rotation) as GameObject;
        StartUIClone.name = "StartMenu";
    }
}
  
