using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TemporaireBouton : MonoBehaviour
{
    public GameObject itembutton;
   

    public void Instantiator()
    {
        GameObject ItemButton = Instantiate(itembutton);
    }
}