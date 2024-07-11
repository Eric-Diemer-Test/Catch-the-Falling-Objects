using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;     

    // Start is called before the first frame update
    void Start()
    {
       gameData = GameObject.Find("GameData").GetComponent<GameData>();      
    }

    /*
    * On trigger event to destroy object
    */
    private void OnTriggerEnter(Collider other)
    {       
        gameData.NumberObjectsSpawned--;
        Destroy(other.gameObject);
    }
}
