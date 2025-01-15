using UnityEngine;

public class PlayerButtonScripts : MonoBehaviour
{
    [SerializeField]private GameObject MenuPanneRov;
    [SerializeField]private GameObject epee;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            MenuPanneRov.SetActive(!MenuPanneRov.activeSelf);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            epee.SetActive(!epee.activeSelf);
        }
    }
}
