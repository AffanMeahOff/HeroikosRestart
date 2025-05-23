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

    [SerializeField] GameObject Group1;
    [SerializeField] GameObject Group2;
    [SerializeField] GameObject Group3;
    [SerializeField] GameObject Group4;
    [SerializeField] GameObject Group5;
    private int tobeat;

    public Enigme3Timer Timer;

    private void Start()
    {
        if (count != null && int.TryParse(count.text, out int check))
        {
            Debug.Log("Nombre d'ennemis vaincus : " + check);
        }
        else
        {
            Debug.LogWarning("Impossible");
        }
    }
    private void Awake()
    {
        Transition();
        UpdateHUD();
        Timer.StartTimer();
        CurrentWave = Wave1;
        CurrentWave.SetActive(true);
        Group1.SetActive(true);
    }

    private void Update()
    {
    
        if (!enigme3won && Timer.isOver)
        {
            enigme3lost = true;
            CurrentWave.SetActive(false);
            TimesUp.SetActive(true);
        }
        else
        {
            if (!wave1Finished && beaten == 5)
            {
                wave1Finished = true;
                CurrentWave.SetActive(false);
                CurrentWave = Wave2;
                Transition();
                CurrentWave.SetActive(true);
                Group2.SetActive(true);
            }
            else if (wave1Finished && !wave2Finished && beaten == 4)
            {
                wave2Finished = true;
                CurrentWave.SetActive(false);
                CurrentWave = Wave3;
                Transition();
                CurrentWave.SetActive(true);
                Group3.SetActive(true);
            }
            else if (wave1Finished && wave2Finished && !wave3Finished && beaten == 3)
            {
                wave3Finished = true;
                CurrentWave.SetActive(false);
                CurrentWave = Wave4;
                Transition();
                CurrentWave.SetActive(true);
                Group4.SetActive(true);
            }
            else if (wave1Finished && wave2Finished && wave3Finished && !wave4Finished && beaten == 2)
            {
                wave4Finished = true;
                CurrentWave.SetActive(false);
                CurrentWave = Wave5;
                Transition();
                CurrentWave.SetActive(true);
                Group5.SetActive(true);
            }
            else if (wave1Finished && wave2Finished && wave3Finished && wave4Finished && beaten == 1)
            {
                CurrentWave.SetActive(false);
                Victory.SetActive(true);
                enigme3won = true;
                Timer.PauseTimer();
            }
        }
        enigme3Finished = enigme3won || enigme3lost;
    }


    public int beaten
    {
        get
        {
            return tobeat - enemies;
        }
        set
        {
            enemies -= value;
            UpdateHUD();
        }
    }

    private void UpdateHUD()
    {
        Debug.Log("Count text = " + count.text);
        Debug.Log("Defeated = " + beaten);
        count.text = beaten.ToString();
        enemynumber.text = "Enemies Defeated:    /" + tobeat;
    }
    public void Transition()
    {
        if (!wave1Finished)
        {
            enemies = 5;
            tobeat = 5;
        }
        else if (!wave2Finished)
        {
            enemies = 4;
            tobeat = 4;
        }
        else if (!wave3Finished)
        {
            enemies = 3;
            tobeat = 3;
        }
        else if (!wave4Finished)
        {
            enemies = 2;
            tobeat = 2;
        }
        else
        {
            enemies = 1;
            tobeat = 1;
        }
        UpdateHUD();      
    }
    
}
