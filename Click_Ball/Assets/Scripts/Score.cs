using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс Очки
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// Очки
    /// </summary>
    private float score = 0;
    /// <summary>
    /// Таймер
    /// </summary>
    GameObject timer;
    /// <summary>
    /// Текст окончания игры
    /// </summary>
    GameObject endgame;

    void Start()
    {
        timer = GameObject.Find("Timer");
        timer.GetComponent<Timer>().StopTimer += StopGame;
    }    

    /// <summary>
    /// Метод изменения текста Очки
    /// </summary>
    /// <param name="scale">размер уничтоженного объекта</param>
    public void ChangeText(float scale)
    {
        score += Mathf.Round(10 / scale);
        GetComponent<Text>().text = score.ToString();
    }

    /// <summary>
    /// Вывод надписи об окончании игры
    /// </summary>
    private void StopGame()
    {
        endgame = GameObject.Find("EndGame");
        endgame.GetComponent<Text>().text = "Ваш счет " + score + " очков";
    }
}
