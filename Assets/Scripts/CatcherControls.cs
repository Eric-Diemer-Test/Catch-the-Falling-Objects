using System.Collections;
using UnityEngine;

public class CatcherControls : MonoBehaviour            //Attached to the Catcher game object
{
    [SerializeField]
    private GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();

        if (gameData.ModeSelected == GameData.GameModes.easy)
        {
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (gameData.ModeSelected == GameData.GameModes.medium)
        {
            this.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
        else if (gameData.ModeSelected == GameData.GameModes.hard)
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {  
        if (gameData.IsStunned)
        {
            return;
        }

        if ((Input.GetKey(KeyCode.LeftArrow)) && (this.GetComponent<Transform>().transform.localPosition.x > -584.0f))
        {            
            this.transform.Translate((gameData.CatcherMoveSpeed[(int)gameData.ModeSelected] * -1.0f), 0f, 0f);            
        }

        if ((Input.GetKey(KeyCode.RightArrow)) && (this.GetComponent<Transform>().transform.localPosition.x < 584.0f))
        {
            this.transform.Translate((gameData.CatcherMoveSpeed[(int)gameData.ModeSelected] * 1.0f), 0f, 0f);
        }
    }

    /*
     * On trigger event to set effect each spawned object has based on tag
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Minnow")
        {
            gameData.GameScore += gameData.FallingObjectsScores[0];
            this.GetComponent<AudioSource>().PlayOneShot(gameData.FailingObjectsCatchSounds[0]);           
        }
        else if (other.tag == "Bream")
        {
            gameData.GameScore += gameData.FallingObjectsScores[1];
            this.GetComponent<AudioSource>().PlayOneShot(gameData.FailingObjectsCatchSounds[1]);
        }
        else if (other.tag == "Bass")
        {
            gameData.GameScore += gameData.FallingObjectsScores[2];
            this.GetComponent<AudioSource>().PlayOneShot(gameData.FailingObjectsCatchSounds[2]);
        }
        else if (other.tag == "Snake")
        {
            gameData.GameScore += gameData.FallingObjectsScores[3];
            this.GetComponent<AudioSource>().PlayOneShot(gameData.FailingObjectsCatchSounds[3]);
        }
        else if (other.tag == "Hook")
        {
            gameData.IsStunned = true;
            this.GetComponent<AudioSource>().PlayOneShot(gameData.FailingObjectsCatchSounds[4]);
            StartCoroutine(RemoveStun());
        }

        gameData.NumberObjectsSpawned--;
        Destroy(other.gameObject);
    }

    /*
     * Coroutine to remove the stun effect from the catcher 
     */
    IEnumerator RemoveStun()
    {
        yield return new WaitForSeconds(gameData.StunDur);
        gameData.IsStunned = false;
    }
}
