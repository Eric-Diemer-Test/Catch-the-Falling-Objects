using System.Collections;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField]
    private GameData gameData; 

    private Vector3 endPosition = Vector3.zero;

    private float lerpDuration = 0;

    private void OnEnable()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
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
                lerpDuration = (gameData.FallingObjectsFallSpeeds[0] * gameData.FallingObjectsSpeed[(int)gameData.ModeSelected]);
                break;

            case "Bream":
                lerpDuration = (gameData.FallingObjectsFallSpeeds[1] * gameData.FallingObjectsSpeed[(int)gameData.ModeSelected]); ;
                break;

            case "Bass":
                lerpDuration = (gameData.FallingObjectsFallSpeeds[2] * gameData.FallingObjectsSpeed[(int)gameData.ModeSelected]); ;
                break;

            case "Snake":
                lerpDuration = (gameData.FallingObjectsFallSpeeds[3] * gameData.FallingObjectsSpeed[(int)gameData.ModeSelected]); ;
                break;

            case "Hook":
                lerpDuration = (gameData.FallingObjectsFallSpeeds[4] * gameData.FallingObjectsSpeed[(int)gameData.ModeSelected]); ;
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
