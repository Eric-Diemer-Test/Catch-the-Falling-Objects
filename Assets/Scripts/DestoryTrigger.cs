using UnityEngine;

public class DestoryTrigger : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;     

    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();      
    }   

    private void OnTriggerEnter(Collider other)
    {       
        gameManager.NumberObjectsSpawned--;
        Destroy(other.gameObject);
    }
}
