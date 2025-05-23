using UnityEngine;
using Unity.Netcode;

public class trameManager : NetworkBehaviour
{
    [SerializeField] private GameObject FirstSlide;
    [SerializeField] private GameObject SecondSlide;
    [SerializeField] private GameObject ThirdSlide;

    private void Start()
    {
        if (!IsOwner) return;

        Cursor.lockState = CursorLockMode.None;
        FirstSlide.SetActive(true);
    }

    public void yes()
    {
        if (!IsOwner) return;

        FirstSlide.SetActive(false);
        SecondSlide.SetActive(true);
    }

    public void skip()
    {
        if (!IsOwner) return;

        FirstSlide.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void secondyes()
    {
        if (!IsOwner) return;

        SecondSlide.SetActive(false);
        ThirdSlide.SetActive(true);
    }

    public void lastyes()
    {
        if (!IsOwner) return;

        ThirdSlide.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}