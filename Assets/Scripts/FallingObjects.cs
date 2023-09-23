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
        EndPosition = new Vector3(this.transform.position.x, -300.0f, this.transform.position.z);

        switch (this.gameObject.tag)
        {
            case "Minnow":
                LerpDuration = gameManager.FallingObjectsFallSpeeds[0];
                break;

            case "Bream":
                LerpDuration = gameManager.FallingObjectsFallSpeeds[1];
                break;

            case "Bass":
                LerpDuration = gameManager.FallingObjectsFallSpeeds[2];
                break;

            case "Snake":
                LerpDuration = gameManager.FallingObjectsFallSpeeds[3];
                break;

            default:
                LerpDuration = gameManager.FallingObjectsFallSpeeds[0];
                break;
        }

        StartCoroutine(StartFall());
    }

    IEnumerator StartFall()
    {
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
