using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;     

    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();      
    }

    /*
    * On trigger event to destroy object
    */
    private void OnTriggerEnter(Collider other)
    {       
        gameManager.NumberObjectsSpawned--;
        Destroy(other.gameObject);
    }
}
