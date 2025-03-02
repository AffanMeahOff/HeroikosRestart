using UnityEngine;

public class Enigme1IO1 : MonoBehaviour
{
    public bool playerinarea;
    public string ItemName;

    [SerializeField] Enigme1Counter enigme1Counter;
 
    public string GetItemName()
    {
        return ItemName;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && playerinarea)
        {
            enigme1Counter.collected += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            playerinarea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            playerinarea = false;
        }    
    }
}
