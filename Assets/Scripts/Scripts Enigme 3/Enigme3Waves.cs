using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enigme3Waves : MonoBehaviour
{
    [SerializeField] TMP_Text count;
    [SerializeField] TMP_Text enemynumber;
    [SerializeField] GameObject Wave1;
    [SerializeField] GameObject Wave2;
    [SerializeField] GameObject Wave3;
    [SerializeField] GameObject Wave4;
    [SerializeField] GameObject Wave5;
    [SerializeField] GameObject TimesUp;
    [SerializeField] GameObject Victory;
    private GameObject CurrentWave;
    private int enemies;
    public bool wave1Finished = false;
    public bool wave2Finished = false;
    public bool wave3Finished = false;
    public bool wave4Finished = false;
    private bool enigme3won = false;
    private bool enigme3lost = false;
    public bool enigme3Finished = false;


    private string amount = "";

    public Enigme3Timer Timer;

    private void Start()
    {
        if (count != null && int.TryParse(count.text, out enemies))
        {
            Debug.Log("Nombre d'ennemis vaincus : " + enemies);
        }
        else
        {
            Debug.LogWarning("Impossible");
            enemies = 0;
        }
    }
    private void Awake()
    {
        Transition();
        UpdateHUD();
        Timer.StartTimer();
        CurrentWave = Wave1;
    }

    private void Update()
    {
        if (count != null && int.TryParse(count.text, out enemies))
        {
        }
        if (!enigme3won && Timer.isOver)
        {
            enigme3lost = true;
            if (CurrentWave == Wave1)
            {
                Wave1.SetActive(false);
            }
            else if (CurrentWave == Wave2)
            {
                Wave2.SetActive(false);
            }
            else if (CurrentWave == Wave3)
            {
                Wave3.SetActive(false);
            }
            else if (CurrentWave == Wave4)
            {
                Wave4.SetActive(false);
            }
            else
            {
                Wave5.SetActive(false);
            }
            TimesUp.SetActive(true);
        }
        else
        {
            if (!wave1Finished && beaten == 5)
            {
                wave1Finished = true;
                enemies = 0;
                Wave1.SetActive(false);
                Wave2.SetActive(true);
                CurrentWave = Wave2;
                Transition();
            }
            else if (wave1Finished && !wave2Finished && beaten == 4)
            {
                wave2Finished = true;
                enemies = 0;
                Wave2.SetActive(false);
                Wave3.SetActive(true);
                CurrentWave = Wave3;
                Transition();
            }
            else if (wave1Finished && wave2Finished && !wave3Finished && beaten == 3)
            {
                wave3Finished = true;
                enemies = 0;
                Wave3.SetActive(false);
                Wave4.SetActive(true);
                CurrentWave = Wave4;
                Transition();
            }
            else if (wave1Finished && wave2Finished && wave3Finished && !wave4Finished && beaten == 2)
            {
                wave2Finished = true;
                enemies = 0;
                Wave4.SetActive(false);
                Wave5.SetActive(true);
                CurrentWave = Wave5;
                Transition();
            }
            else if (wave1Finished && wave2Finished && wave3Finished && wave4Finished && beaten == 1)
            {
                Wave5.SetActive(false);
                Victory.SetActive(true);
                enigme3won = true;
            }
        }
        enigme3Finished = enigme3won || enigme3lost;
    }


    public int beaten
    {
        get
        {
            return enemies;
        }
        set
        {

            enemies = value;

            UpdateHUD();
        }
    }

    private void UpdateHUD()
    {
        Debug.Log("Count text = " + count.text);
        Debug.Log("Defeated = " + beaten);
        count.text = beaten.ToString();
        enemynumber.text = "Enemies Defeated:   /" + amount;
    }
    public void Transition()
    {
        if (!wave1Finished)
        {
            amount = "5";
        }
        else if (!wave2Finished)
        {
            amount = "4";
        }
        else if (!wave3Finished)
        {
            amount = "3";
        }
        else if (!wave4Finished)
        {
            amount = "2";
        }
        else
        {
            amount = "1";
        }
    }
    
}
