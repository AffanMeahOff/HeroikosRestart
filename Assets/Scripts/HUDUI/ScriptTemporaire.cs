using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptTemporaire : MonoBehaviour
{
    [SerializeField]private GameObject menuinventaire;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            menuinventaire.SetActive(!menuinventaire.activeSelf);  
            if (menuinventaire.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None; //Pour eviter de sorir de l'ecran
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
