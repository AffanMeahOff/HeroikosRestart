using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptTemporaire : MonoBehaviour
{
    [SerializeField]private GameObject menuinventaire;
    [SerializeField]private GameObject pausemenu;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None; //Pour eviter de sortir de l'ecran
            pausemenu.SetActive(!pausemenu.activeSelf);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            menuinventaire.SetActive(!menuinventaire.activeSelf);  
            //InventaireManager.Instance.ListItems();
            if (menuinventaire.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None; //Pour eviter de sortir de l'ecran
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
