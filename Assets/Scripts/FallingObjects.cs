using System.Collections;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager; 

    private Vector3 EndPosition = Vector3.zero;

    private float LerpDuration = 0;

    private void OnEnable()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        EndPosition = new Vector3(this.transform.position.x, -500.0f, this.transform.position.z);        

        StartCoroutine(StartFall());
    }

    /*
     * Start the fall coroutine speed based on tag of object
     */
    IEnumerator StartFall()
    {
        yield return new WaitForSeconds(0.1f); //a quick hack to solve a race condition       

        switch (this.gameObject.tag)
        {
            case "Minnow":
                LerpDuration = (gameManager.FallingObjectsFallSpeeds[0] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]);
                break;

            case "Bream":
                LerpDuration = (gameManager.FallingObjectsFallSpeeds[1] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;

            case "Bass":
                LerpDuration = (gameManager.FallingObjectsFallSpeeds[2] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;

            case "Snake":
                LerpDuration = (gameManager.FallingObjectsFallSpeeds[3] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;

            case "Hook":
                LerpDuration = (gameManager.FallingObjectsFallSpeeds[4] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;
        }

        float TimeElapsed = 0;

        while (TimeElapsed < LerpDuration)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, EndPosition, TimeElapsed / LerpDuration);
            TimeElapsed += Time.deltaTime;
            yield return null;
        }

        this.transform.position = EndPosition;        
    }    
}
