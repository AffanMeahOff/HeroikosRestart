using UnityEngine;

public class PlayerButtonScripts : MonoBehaviour
{
    [SerializeField]private GameObject MenuPanneRov;
    [SerializeField]private GameObject epee;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            MenuPanneRov.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            epee.SetActive(!epee.activeSelf);
        }
    }
}
