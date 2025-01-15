using UnityEngine;

public class PlayerButtonScripts : MonoBehaviour
{
    [SerializeField]private GameObject MenuPannel;
    [SerializeField]private GameObject epee;


    // Update is called once per frame
    void Awake()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            MenuPannel.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            epee.SetActive(true);
        }
    }
}
