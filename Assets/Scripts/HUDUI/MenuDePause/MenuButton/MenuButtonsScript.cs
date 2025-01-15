using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsScript : MonoBehaviour
{
    [SerializeField]private Button MultiButton;
    [SerializeField]private Button SettingsButton;
    [SerializeField]private Button MapButton;
    [SerializeField]private Button SaveButton;
    [SerializeField]private Button ExitButton;
    [SerializeField]private GameObject MultijoueurSettings;

    void Awake()
    {
        if (MultiButton != null)
        {
            MultiButton.onClick.AddListener(MultiButtonPressed);
        }   
        
    }
    void MultiButtonPressed()
    {
        gameObject.SetActive(false);
        MultijoueurSettings.SetActive(true);
    }
}
