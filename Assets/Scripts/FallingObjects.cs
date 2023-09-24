using System.Collections;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager; 

    private Vector3 endPosition = Vector3.zero;

    private float lerpDuration = 0;

    private void OnEnable()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        endPosition = new Vector3(this.transform.position.x, -500.0f, this.transform.position.z);        

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
                lerpDuration = (gameManager.FallingObjectsFallSpeeds[0] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]);
                break;

            case "Bream":
                lerpDuration = (gameManager.FallingObjectsFallSpeeds[1] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;

            case "Bass":
                lerpDuration = (gameManager.FallingObjectsFallSpeeds[2] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;

            case "Snake":
                lerpDuration = (gameManager.FallingObjectsFallSpeeds[3] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;

            case "Hook":
                lerpDuration = (gameManager.FallingObjectsFallSpeeds[4] * gameManager.FallingObjectsSpeed[(int)gameManager.ModeSelected]); ;
                break;
        }

        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, endPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        this.transform.position = endPosition;        
    }    
}
