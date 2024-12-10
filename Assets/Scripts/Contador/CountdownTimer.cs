using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timerDuration = 60f; // Duración del contador en segundos
    private float currentTime;
    public Animator animator;

    [Header("UI Settings")]
    public TextMeshProUGUI timerText; // Texto para mostrar el tiempo

    [Header("Gameobjects")]
    public GameObject FinalActiv;
    public GameObject Temporizador;
    public GameObject Lista;

    private bool isRunning = false;

    void Start()
    {
        ResetTimer();
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (FinalActiv != null && !FinalActiv.activeSelf)
            {
                StopTimer();
                Debug.Log("temporizador está desactivado.");                
                
            }

            if (currentTime <= 0f)
            {
                TimerEnded();
            }
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
        TimerStopped();
    }

    public void ResetTimer()
    {
        currentTime = timerDuration;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void TimerEnded()
    {
        isRunning = false;
        Debug.Log("¡El tiempo se ha terminado! Haz algo aquí.");
        // Acción cuando el contador llega a 0
    }

    private void TimerStopped()
    {
        Debug.Log("El contador fue detenido manualmente. Haz algo aquí.");
        Temporizador.SetActive(false);
        Lista.SetActive(false);
        animator.SetBool("End1", true);

    }
}
