using System.Collections;
using UnityEngine;

public class CatcherControls : MonoBehaviour            //Attached to the Catcher game object
{
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (gameManager.IsStunned)
        {
            return;
        }

        if ((Input.GetKey(KeyCode.LeftArrow)) && (this.GetComponent<Transform>().transform.localPosition.x > -584.0f))
        {            
            this.GetComponent<Transform>().transform.Translate((gameManager.CatcherMoveSpeed[(int)gameManager.ModeSelected] * -1.0f), 0f, 0f);            
        }

        if ((Input.GetKey(KeyCode.RightArrow)) && (this.GetComponent<Transform>().transform.localPosition.x < 584.0f))
        {
            this.GetComponent<Transform>().transform.Translate((gameManager.CatcherMoveSpeed[(int)gameManager.ModeSelected] * 1.0f), 0f, 0f);
        }
    }

    /*
     * On trigger event to set effect each spawned object has based on tag
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Minnow")
        {
            gameManager.GameScore += gameManager.FallingObjectsScores[0];
            this.GetComponent<AudioSource>().PlayOneShot(gameManager.FailingObjectsCatchSounds[0]);           
        }
        else if (other.tag == "Bream")
        {
            gameManager.GameScore += gameManager.FallingObjectsScores[1];
            this.GetComponent<AudioSource>().PlayOneShot(gameManager.FailingObjectsCatchSounds[1]);
        }
        else if (other.tag == "Bass")
        {
            gameManager.GameScore += gameManager.FallingObjectsScores[2];
            this.GetComponent<AudioSource>().PlayOneShot(gameManager.FailingObjectsCatchSounds[2]);
        }
        else if (other.tag == "Snake")
        {
            gameManager.GameScore += gameManager.FallingObjectsScores[3];
            this.GetComponent<AudioSource>().PlayOneShot(gameManager.FailingObjectsCatchSounds[3]);
        }
        else if (other.tag == "Hook")
        {
            gameManager.IsStunned = true;
            this.GetComponent<AudioSource>().PlayOneShot(gameManager.FailingObjectsCatchSounds[4]);
            StartCoroutine(RemoveStun());
        }

        gameManager.NumberObjectsSpawned--;
        Destroy(other.gameObject);
    }

    /*
     * Coroutine to remove the stun effect from catcher 
     */
    IEnumerator RemoveStun()
    {
        yield return new WaitForSeconds(3.0f);
        gameManager.IsStunned = false;
    }
}
