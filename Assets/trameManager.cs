using NUnit.Framework.Constraints;
using UnityEngine;

public class trameManager : MonoBehaviour
{
    [SerializeField] private GameObject FirstSlide;
    // [SerializeField] private GameObject FirstYesButton;
    // [SerializeField] private GameObject NoButton;
    [SerializeField] private GameObject SecondSlide;
    [SerializeField] private GameObject ThirdSlide;


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        FirstSlide.SetActive(true);
    }
    public void yes()
    {
        FirstSlide.SetActive(false);
        SecondSlide.SetActive(true);
    }
    public void skip()
    {
        FirstSlide.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void secondyes()
    {
        SecondSlide.SetActive(false);
        ThirdSlide.SetActive(true);
    }
    public void lastyes()
    {
        ThirdSlide.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
