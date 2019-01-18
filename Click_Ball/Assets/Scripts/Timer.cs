using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс Таймер
/// </summary>
public class Timer : MonoBehaviour
{
    public delegate void GameOver();
    /// <summary>
    /// Событие остановки таймера
    /// </summary>
    public event GameOver StopTimer;
    /// <summary>
    /// Значение таймера
    /// </summary>
    public float timeRemaining = 30f;
    
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            GetComponent<Text>().text = Mathf.Round(timeRemaining).ToString();
        }
        else StopTimer();        
    }
}
