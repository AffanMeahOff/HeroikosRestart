using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TemporaireBouton : MonoBehaviour
{
    public GameObject itembutton;
    public Transform ItemContent; // Conteneur des items dans l'inventaire UI


    public void Instantiator()
    {
        GameObject ItemButton = Instantiate(itembutton, ItemContent);
    }
}