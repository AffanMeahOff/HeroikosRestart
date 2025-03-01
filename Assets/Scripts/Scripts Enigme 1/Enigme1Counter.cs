using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enigme1Counter : MonoBehaviour
{
    [SerializeField] TMP_Text count;
    int crystals = 0;

    private void Awake()
    {
        UpdateHUD();
    }

    public int collected {
        get {
            return crystals;
        }
        set {
            crystals = value;
            UpdateHUD();
        }
    }
    private void UpdateHUD()
    {
        count.text = crystals.ToString();
    }
}
