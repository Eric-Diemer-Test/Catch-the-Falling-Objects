using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FallingObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject FallingObjectsPrefab;

    private void OnEnable()
    {
        SpawnFallingObject();
        StartCoroutine(SpawnDelay());
    }

    /*
     * Spawn Delay coroutine
     */
    IEnumerator SpawnDelay()
    {
        int rnd = 0;

        rnd = UnityEngine.Random.Range(Mathf.CeilToInt((int)gameManager.FallingObjectsIntervals[(int)gameManager.ModeSelected] * .5f), Mathf.CeilToInt((int)gameManager.FallingObjectsIntervals[(int)gameManager.ModeSelected] * 1.5f));

        yield return new WaitForSeconds(rnd);
        SpawnFallingObject();
        StartCoroutine(SpawnDelay());
    }

    /*
     * Spawn the object
     * Set all needed paramaters parent, Tag Name, Sprite, Name, Number Objects Spawned
     */
    public void SpawnFallingObject()
    {       
        if (gameManager.NumberObjectsSpawned < gameManager.MaxNumberObjectsSpawned[(int)gameManager.ModeSelected])
        {
            int rnd = 0;

            rnd = UnityEngine.Random.Range(0, 100);

            if (rnd > gameManager.FallingObjectsFallingChance[(int)gameManager.ModeSelected])
            {
                GameObject Clone = Instantiate(FallingObjectsPrefab, this.transform.position, this.transform.rotation) as GameObject;
                Clone.transform.SetParent(GameObject.Find("FallingObjects").transform);
                Clone.name = "Object" + gameManager.NumberObjectsSpawned;
                Clone.tag = GetObjectTag();
                Clone.GetComponent<Image>().sprite = GetObjectSprite(Clone.tag);
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
     * Possible Edge Case if Lowest Chance is not the following:  Bass, Snake, Hook, Bream, Minnow
     */
    public string GetObjectTag()
    {
        string TagName = "";

        int rnd = 0;

        rnd = UnityEngine.Random.Range(0, 100);    
        
        switch (gameManager.ModeSelected)                      
        {
            //Easy mode chances
            case GameManager.GameModes.easy:                            
                if ((rnd < gameManager.FallingObjectsSpawnChancesEasy[2])) 
                { //< 15 (Bass)
                    TagName = "Bass";
                }
                else if (rnd >= gameManager.FallingObjectsSpawnChancesEasy[0])  
                { //>= 50 (Minnow)
                    TagName = "Minnow";
                }
                else
                { // 15 - 49 (Bream)
                    TagName = "Bream";
                }
                break;

            //Medium mode chances
            case GameManager.GameModes.medium:                          

                if ((rnd < gameManager.FallingObjectsSpawnChancesMedium[2]))
                { //< 10 (Bass)
                    TagName = "Bass";
                }
                else if ((rnd >= gameManager.FallingObjectsSpawnChancesMedium[2]) && 
                    (rnd <= (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2])))
                { // >+ 10 (Bass) && <= 20 + 10 (Bass + Snake)
                    TagName = "Snake";
                }
                else if ((rnd >= (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2])) 
                    && (rnd <= (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2] + gameManager.FallingObjectsSpawnChancesMedium[1])))
                { // > 20 + 10 (Bass + Snake) && <= 10 + 20 + 25 (Bass + Snake + Bream)
                    TagName = "Bream";
                }
                else if ((rnd > (gameManager.FallingObjectsSpawnChancesMedium[3] + gameManager.FallingObjectsSpawnChancesMedium[2] + gameManager.FallingObjectsSpawnChancesMedium[1])))
                { //  > (10 + 20 + 25) (Bass + Snake + Bream)
                    TagName = "Minnow";
                }
                else
                { //just for any logic errors or edge cases
                    TagName = "Minnow";
                }
                break;

            //hard mode Chances
            case GameManager.GameModes.hard:                            
                if ((rnd < gameManager.FallingObjectsSpawnChancesMedium[2]))
                { //< 10 (Bass)
                    TagName = "Bass";
                }
                else if ((rnd >= gameManager.FallingObjectsSpawnChancesHard[2]) &&
                    (rnd <= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2])))
                { // >+ 10 (Bass) && <= 15 + 10 (Bass + Snake)
                    TagName = "Snake";
                }
                else if ((rnd >= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2]))
                    && (rnd <= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2] + gameManager.FallingObjectsSpawnChancesHard[4])))
                { // > 15 + 10 + 10 && <= 10 + 15 + 20 (Bass + Snake + Hook)
                    TagName = "Hook";
                }
                else if ((rnd >= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2] + gameManager.FallingObjectsSpawnChancesHard[1]))
                    && (rnd <= (gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2] 
                    + gameManager.FallingObjectsSpawnChancesHard[4] + gameManager.FallingObjectsSpawnChancesHard[1])))
                { // > 15 + 10 + 10 && <= 10 + 15 + 20 + 25 (Bass + Snake + Hook + Bream)
                    TagName = "Bream";
                }
                else if ((rnd > ((gameManager.FallingObjectsSpawnChancesHard[3] + gameManager.FallingObjectsSpawnChancesHard[2]
                    + gameManager.FallingObjectsSpawnChancesHard[1] + gameManager.FallingObjectsSpawnChancesHard[4]))))
                { //  > 10 + 15 + 20 + 25 (Bass + Snake + Bream + Hook)
                    TagName = "Minnow";
                }
                else
                { //just for any logic errors or edge cases
                    TagName = "Minnow";
                }
                break;
        }         

        return TagName;
    }

    /*
     * Get the Sprite based on the Tag Name
     */
    public Sprite GetObjectSprite(String TagName)
    {
        Sprite SpriteImage = null;

        switch (TagName)
        {
            case "Minnow":
                SpriteImage = gameManager.FallingObjectsImages[0];
                break;
            case "Bream":
                SpriteImage = gameManager.FallingObjectsImages[1];
                break;
            case "Bass":
                SpriteImage = gameManager.FallingObjectsImages[2];
                break;
            case "Snake":
                SpriteImage = gameManager.FallingObjectsImages[3];
                break;
            case "Hook":
                SpriteImage = gameManager.FallingObjectsImages[4];
                break;
        }

        return SpriteImage;
    }
}
