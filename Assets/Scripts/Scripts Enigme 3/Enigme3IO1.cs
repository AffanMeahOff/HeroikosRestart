using UnityEngine;

public class Enigme3IO1 : MonoBehaviour
{
    public bool playerinarea;
    public string ItemName;

    [SerializeField] Enigme3Waves enigme3Waves;
 
    public string GetItemName()
    {
        return ItemName;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && playerinarea)
        {
            enigme3Waves.beaten += 1;
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
