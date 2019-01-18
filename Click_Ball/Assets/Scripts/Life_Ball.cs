using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Созданный объект
/// </summary>
public class Life_Ball : MonoBehaviour
{
    /// <summary>
    /// Скорость объекта
    /// </summary>
    public float speed_ball;
    /// <summary>
    /// очки
    /// </summary>
    GameObject score;
    /// <summary>
    /// Таймер
    /// </summary>
    GameObject timer;

    void Start()
    {
        timer = GameObject.Find("Timer");
        timer.GetComponent<Timer>().StopTimer += StopBall;
    }

    void Update()
    {
        //Изменение позиции объекта
        transform.Translate(Vector3.up * Time.deltaTime * speed_ball / (transform.localScale.y * transform.localScale.y));
    }

    /// <summary>
    /// Выход за пределы видимости камеры
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(gameObject, 1);
    }

    /// <summary>
    /// Собитие по нажатию кнопки мыши
    /// </summary>
    private void OnMouseDown()
    {
        if (speed_ball > 0)
        {
            Destroy(gameObject);

            score = GameObject.Find("Score");
            score.GetComponent<Score>().ChangeText(transform.localScale.y);
        }
    }

    /// <summary>
    /// Остановка движения объектов
    /// </summary>
    private void StopBall()
    {
        speed_ball = 0;
    }
}
