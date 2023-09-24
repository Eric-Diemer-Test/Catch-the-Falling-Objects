using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FallingObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject fallingObjectsPrefab;

    private void OnEnable()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(FirstSpawnDelay());
        StartCoroutine(SpawnLoop());
    }

    /*
    * First spawn of objects with a slight delay
    */
    IEnumerator FirstSpawnDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnFallingObject();
    }

    /*
     * Spawn Loop coroutine
     */
    IEnumerator SpawnLoop()
    {
        int rnd = 0;

        rnd = UnityEngine.Random.Range(Mathf.CeilToInt((int)gameManager.FallingObjectsIntervals[(int)gameManager.ModeSelected] * .5f), Mathf.CeilToInt((int)gameManager.FallingObjectsIntervals[(int)gameManager.ModeSelected] * 1.5f));

        yield return new WaitForSeconds(rnd);
        SpawnFallingObject();
        StartCoroutine(SpawnLoop());
    }

    /*
     * Spawn the object
     * Set all needed paramaters parent, Tag Name, Sprite, Name, Number Objects Spawned
     */
    private void SpawnFallingObject()
    {       
        if (gameManager.NumberObjectsSpawned < gameManager.MaxNumberObjectsSpawned[(int)gameManager.ModeSelected])
        {
            int rnd = 0;

            rnd = UnityEngine.Random.Range(0, 100);

            if (rnd > gameManager.FallingObjectsFallingChance[(int)gameManager.ModeSelected])
            {
                GameObject fallingObjectClone = Instantiate(fallingObjectsPrefab, this.transform.position, this.transform.rotation) as GameObject;
                fallingObjectClone.transform.SetParent(GameObject.Find("FallingObjects").transform);
                fallingObjectClone.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                fallingObjectClone.name = "Object" + gameManager.NumberObjectsSpawned;
                fallingObjectClone.tag = GetObjectTag();
                fallingObjectClone.GetComponent<Image>().sprite = GetObjectSprite(fallingObjectClone.tag);
                gameManager.NumberObjectsSpawned++;
            }
        }
        else
        {
           Debug.Log("Max number of spawned has been reached");
        }
    }

    /*
     * Get the Object Tag Based on the chances in the chance array for each mode
     * Possible Edge Case if Lowest Chance is not in the following order:  Bass, Snake, Hook, Bream, Minnow
     */
    private string GetObjectTag()
    {
        string tagName = "";

        int rnd = 0;

        rnd = UnityEngine.Random.Range(0, 100);    
        
        switch (gameManager.ModeSelected)                      
        {
            //Easy mode chances
            case GameManager.GameModes.easy:                            
                if ((rnd < gameManager.FallingObjectsSpawnChancesEasy[2])) 
                { //< 15 (Bass)
                    tagName = "Bass";
                }
                else if (rnd >= gameManager.FallingObjectsSpawnChancesEasy[0])  
                { //>= 50 (Minnow)
                    tagName = "Minnow";
                }
                else
                { // 15 - 49 (Bream)
                    tagName = "Bream";
                }
                break;

            //Medium mode chances
            case GameManager.GameModes.medium:                          

                if ((rnd < gameManager.FallingObjectsSpawnChancesMedium[2]))
                { //< 10 (Bass)
                    tagName = "Bass";
                }
                else if ((rnd >= gameManager.FallingObjectsSpawnChancesMedium[2]) && 
                    (rnd <= (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2])))
                { // >+ 10 (Bass) && <= 20 + 10 (Bass + Snake)
                    tagName = "Snake";
                }
                else if ((rnd >= (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2])) 
                    && (rnd <= (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2] + gameManager.FallingObjectsSpawnChancesMedium[1])))
                { // > 20 + 10 (Bass + Snake) && <= 10 + 20 + 25 (Bass + Snake + Bream)
                    tagName = "Bream";
                }
                else if ((rnd > (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2] + gameManager.FallingObjectsSpawnChancesMedium[1])))
                { //  > (10 + 20 + 25) (Bass + Snake + Bream)
                    tagName = "Minnow";
                }
                else
                { //just for any logic errors or edge cases
                    tagName = "Minnow";
                }
                break;

            //hard mode Chances
            case GameManager.GameModes.hard:                            
                if ((rnd < gameManager.FallingObjectsSpawnChancesMedium[2]))
                { //< 10 (Bass)
                    tagName = "Bass";
                }
                else if ((rnd >= gameManager.FallingObjectsSpawnChancesHard[2]) &&
                    (rnd <= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2])))
                { // >+ 10 (Bass) && <= 15 + 10 (Bass + Snake)
                    tagName = "Snake";
                }
                else if ((rnd >= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2]))
                    && (rnd <= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2] + gameManager.FallingObjectsSpawnChancesHard[4])))
                { // > 15 + 10 + 10 && <= 10 + 15 + 20 (Bass + Snake + Hook)
                    tagName = "Hook";
                }
                else if ((rnd >= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2] + gameManager.FallingObjectsSpawnChancesHard[1]))
                    && (rnd <= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2] 
                    + gameManager.FallingObjectsSpawnChancesHard[4] + gameManager.FallingObjectsSpawnChancesHard[1])))
                { // > 15 + 10 + 10 && <= 10 + 15 + 20 + 25 (Bass + Snake + Hook + Bream)
                    tagName = "Bream";
                }
                else if ((rnd > ((gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2]
                    + gameManager.FallingObjectsSpawnChancesHard[1] + gameManager.FallingObjectsSpawnChancesHard[4]))))
                { //  > 10 + 15 + 20 + 25 (Bass + Snake + Bream + Hook)
                    tagName = "Minnow";
                }
                else
                { //just for any logic errors or edge cases
                    tagName = "Minnow";
                }
                break;
        }         

        return tagName;
    }

    /*
     * Get the Sprite based on the Tag Name
     */
    private Sprite GetObjectSprite(String tagName)
    {
        Sprite spriteImage = null;

        switch (tagName)
        {
            case "Minnow":
                spriteImage = gameManager.FallingObjectsImages[0];
                break;
            case "Bream":
                spriteImage = gameManager.FallingObjectsImages[1];
                break;
            case "Bass":
                spriteImage = gameManager.FallingObjectsImages[2];
                break;
            case "Snake":
                spriteImage = gameManager.FallingObjectsImages[3];
                break;
            case "Hook":
                spriteImage = gameManager.FallingObjectsImages[4];
                break;
        }

        return spriteImage;
    }
}
