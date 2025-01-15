using UnityEngine;

public class ScriptTemporaire : MonoBehaviour
{

    [SerializeField]private GameObject menudepause;
    [SerializeField]private GameObject menuinventaire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            menudepause.SetActive(!menudepause.activeSelf);  
            Cursor.lockState = CursorLockMode.None; //Pour eviter de sorir de l'ecran
          
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            menuinventaire.SetActive(!menuinventaire.activeSelf);  
            Cursor.lockState = CursorLockMode.None; //Pour eviter de sorir de l'ecran
          
        }
    }
}
