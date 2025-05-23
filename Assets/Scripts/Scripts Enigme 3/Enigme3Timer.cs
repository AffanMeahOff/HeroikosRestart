using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enigme3Timer : MonoBehaviour
{
    public TMP_Text timerText; // UI Text to display the countdown
    public float totalTime = 900f; // 15 minutes in seconds
    private float remainingTime;
    private bool isRunning = false;
    public bool isOver = false;

    void Start()
    {
        remainingTime = totalTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isRunning && remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0f)
            {
                remainingTime = 0f;
                isRunning = false;
                // Optional: Call a method here when the timer ends
                OnTimerEnd();
            }

            UpdateTimerDisplay();
        }
    }

    // Start the countdown
    public void StartTimer()
    {
        isRunning = true;
    }

    // Pause the countdown
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Reset the countdown to 15 minutes
    public void ResetTimer()
    {
        isRunning = false;
        remainingTime = totalTime;
        UpdateTimerDisplay();
    }

    // Update the UI text
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60F);
        int seconds = Mathf.FloorToInt(remainingTime % 60F);
        timerText.text = "Time Left : " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Optional: What to do when the timer hits 0
    void OnTimerEnd()
    {
        Debug.Log("Timer ended!");
        isOver = true;
    }
}

