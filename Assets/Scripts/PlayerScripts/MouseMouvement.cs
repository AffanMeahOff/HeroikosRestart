using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MouseMovement : NetworkBehaviour //Voir la doc que j'ai faite
{

    public float mouseSensitivity = 1500f; //Reglage de la Sensi (en variable public)
 
    float xRotation = 0f; //Initialisation de la souris ur l'axe x
    float YRotation = 0f; //Initialisation de la souris ur l'axe y
 
    void Start() //Ne sera lancé qu'une seule et unique fois avant l'update du premier frame
    {
      Cursor.lockState = CursorLockMode.Locked; //Pour eviter de sorir de l'ecran
    }
 
    void Update() //A chaque update ou par frame plutot
    {
        if(!IsOwner)
        {
          return;
        }
        
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Intensité
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //Optimisationn et fluidité
 
       //controle la rotation auour de l'axe x (en haut et/ou en bas)
       xRotation -= mouseY;
 
       //Cette ligne empeche la rotation excessive, voir doc (c'est surtout pour eviter de faire un backflip)
       xRotation = Mathf.Clamp(xRotation, -90f, 90f);
 
       //controle la rotation auour de l'axe y (gauceh et/ou drotie)
       YRotation += mouseX;
 
       //crée une rotation 3D à partir de ces angles exprimés en degrés.
       transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);

    }
}
