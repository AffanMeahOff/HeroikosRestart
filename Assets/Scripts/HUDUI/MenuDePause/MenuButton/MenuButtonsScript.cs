using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsScript : MonoBehaviour
{
    [SerializeField]private Button MultiButton; //good
    [SerializeField]private Button SettingsButton;
    [SerializeField]private Button MapButton; //good
    [SerializeField]private Button SaveButton;
    [SerializeField]private Button ExitButton; //good
    [SerializeField]private Button Resume; //good 
    [SerializeField]private Button Return; //good 



    //les menus

    [SerializeField]private GameObject EnJeu;

    [SerializeField]private GameObject Map;

    [SerializeField]private GameObject MenuPrincipal;

    [SerializeField]private GameObject MultijoueurSettings;

    void Awake()
    {
        Resume.onClick.AddListener(() =>
        {
            EnJeu.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked; //Pour eviter de sorir de l'ecran
            gameObject.SetActive(false);
        });

        MultiButton.onClick.AddListener(() => 
        {
            gameObject.SetActive(false);
            MultijoueurSettings.SetActive(true);
        }); 
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            MenuPrincipal.SetActive(true);
        });
        MapButton.onClick.AddListener(()=>
        {
            Map.SetActive(true);
        });
        Return.onClick.AddListener(() => 
        {
            Map.SetActive(false);
        }
        );
    }    
}
