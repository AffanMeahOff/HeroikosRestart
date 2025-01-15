using UnityEngine;

public class ScriptTemporaire : MonoBehaviour
{

    [SerializeField]private GameObject menudepause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            menudepause.SetActive(!menudepause.activeSelf);  
            Cursor.lockState = CursorLockMode.None; //Pour eviter de sorir de l'ecran
          
        }
    }
}
