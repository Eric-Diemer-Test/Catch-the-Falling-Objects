using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FallingObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;

    [SerializeField]
    private GameObject fallingObjectsPrefab;

    private void OnEnable()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
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

        rnd = UnityEngine.Random.Range(Mathf.CeilToInt((int)gameData.FallingObjectsIntervals[(int)gameData.ModeSelected] * .5f), Mathf.CeilToInt((int)gameData.FallingObjectsIntervals[(int)gameData.ModeSelected] * 1.5f));

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
        if (gameData.NumberObjectsSpawned < gameData.MaxNumberObjectsSpawned[(int)gameData.ModeSelected])
        {
            int rnd = 0;

            rnd = UnityEngine.Random.Range(0, 100);

            if (rnd > gameData.FallingObjectsFallingChance[(int)gameData.ModeSelected])
            {
                GameObject fallingObjectClone = Instantiate(fallingObjectsPrefab, this.transform.position, this.transform.rotation) as GameObject;
                fallingObjectClone.transform.SetParent(GameObject.Find("FallingObjects").transform);
                fallingObjectClone.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                fallingObjectClone.name = "Object" + gameData.NumberObjectsSpawned;
                fallingObjectClone.tag = GetObjectTag();
                fallingObjectClone.GetComponent<Image>().sprite = GetObjectSprite(fallingObjectClone.tag);
                gameData.NumberObjectsSpawned++;
            }
        }
        else
        {
          // Debug.Log("Max number of spawned has been reached");
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
        
        switch (gameData.ModeSelected)                      
        {
            //Easy mode chances
            case GameData.GameModes.easy:                            
                if ((rnd < gameData.FallingObjectsSpawnChancesEasy[2])) 
                { //< 15 (Bass)
                    tagName = "Bass";
                }
                else if (rnd >= gameData.FallingObjectsSpawnChancesEasy[0])  
                { //>= 50 (Minnow)
                    tagName = "Minnow";
                }
                else
                { // 15 - 49 (Bream)
                    tagName = "Bream";
                }
                break;

            //Medium mode chances
            case GameData.GameModes.medium:                          

                if ((rnd < gameData.FallingObjectsSpawnChancesMedium[2]))
                { //< 10 (Bass)
                    tagName = "Bass";
                }
                else if ((rnd >= gameData.FallingObjectsSpawnChancesMedium[2]) && 
                    (rnd <= (gameData.FallingObjectsSpawnChancesMedium[3] + gameData.FallingObjectsSpawnChancesMedium[2])))
                { // >+ 10 (Bass) && <= 20 + 10 (Bass + Snake)
                    tagName = "Snake";
                }
                else if ((rnd >= (gameData.FallingObjectsSpawnChancesMedium[3] + gameData.FallingObjectsSpawnChancesMedium[2])) 
                    && (rnd <= (gameData.FallingObjectsSpawnChancesMedium[3] + gameData.FallingObjectsSpawnChancesMedium[2] + gameData.FallingObjectsSpawnChancesMedium[1])))
                { // > 20 + 10 (Bass + Snake) && <= 10 + 20 + 25 (Bass + Snake + Bream)
                    tagName = "Bream";
                }
                else if ((rnd > (gameData.FallingObjectsSpawnChancesMedium[3] + gameData.FallingObjectsSpawnChancesMedium[2] + gameData.FallingObjectsSpawnChancesMedium[1])))
                { //  > (10 + 20 + 25) (Bass + Snake + Bream)
                    tagName = "Minnow";
                }
                else
                { //just for any logic errors or edge cases
                    tagName = "Minnow";
                }
                break;

            //hard mode Chances
            case GameData.GameModes.hard:                            
                if ((rnd < gameData.FallingObjectsSpawnChancesMedium[2]))
                { //< 10 (Bass)
                    tagName = "Bass";
                }
                else if ((rnd >= gameData.FallingObjectsSpawnChancesHard[2]) &&
                    (rnd <= (gameData.FallingObjectsSpawnChancesHard[3] + gameData.FallingObjectsSpawnChancesHard[2])))
                { // >+ 10 (Bass) && <= 15 + 10 (Bass + Snake)
                    tagName = "Snake";
                }
                else if ((rnd >= (gameData.FallingObjectsSpawnChancesHard[3] + gameData.FallingObjectsSpawnChancesHard[2]))
                    && (rnd <= (gameData.FallingObjectsSpawnChancesHard[3] + gameData.FallingObjectsSpawnChancesHard[2] + gameData.FallingObjectsSpawnChancesHard[4])))
                { // > 15 + 10 + 10 && <= 10 + 15 + 20 (Bass + Snake + Hook)
                    tagName = "Hook";
                }
                else if ((rnd >= (gameData.FallingObjectsSpawnChancesHard[3] + gameData.FallingObjectsSpawnChancesHard[2] + gameData.FallingObjectsSpawnChancesHard[1]))
                    && (rnd <= (gameData.FallingObjectsSpawnChancesHard[3] + gameData.FallingObjectsSpawnChancesHard[2] 
                    + gameData.FallingObjectsSpawnChancesHard[4] + gameData.FallingObjectsSpawnChancesHard[1])))
                { // > 15 + 10 + 10 && <= 10 + 15 + 20 + 25 (Bass + Snake + Hook + Bream)
                    tagName = "Bream";
                }
                else if ((rnd > ((gameData.FallingObjectsSpawnChancesHard[3] + gameData.FallingObjectsSpawnChancesHard[2]
                    + gameData.FallingObjectsSpawnChancesHard[1] + gameData.FallingObjectsSpawnChancesHard[4]))))
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
                spriteImage = gameData.FallingObjectsImages[0];
                break;
            case "Bream":
                spriteImage = gameData.FallingObjectsImages[1];
                break;
            case "Bass":
                spriteImage = gameData.FallingObjectsImages[2];
                break;
            case "Snake":
                spriteImage = gameData.FallingObjectsImages[3];
                break;
            case "Hook":
                spriteImage = gameData.FallingObjectsImages[4];
                break;
        }

        return spriteImage;
    }
}
