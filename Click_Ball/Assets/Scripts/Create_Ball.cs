using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс создатель объектов
/// </summary>
public class Create_Ball : MonoBehaviour
{
    /// <summary>
    /// Объект
    /// </summary>
    public GameObject Ball;
    /// <summary>
    /// время создания объекта
    /// </summary> 
    float start_create = 1;
    /// <summary>
    /// Интервал создания объектов
    /// </summary>
    float interval = 0.5f;
    /// <summary>
    /// Размер объекта
    /// </summary>
    float scale_Ball;
    /// <summary>
    /// Цвет объекта
    /// </summary>
    Color color_Ball;
    /// <summary>
    /// Позиция объекта
    /// </summary>
    Vector3 pos_Ball;
    /// <summary>
    /// Случайное число для позиции по оси X
    /// </summary>
    float random_x;
    /// <summary>
    /// Случайное число для позиции по оси Y
    /// </summary>
    float random_y;
    /// <summary>
    /// Вспомогательный вектор для пересчета координат из экранных в мировые
    /// </summary>
    Vector3 ScrToWP;
    /// <summary>
    /// Таймер
    /// </summary>
    GameObject timer;
    /// <summary>
    /// Начальное значение таймера
    /// </summary>
    float istime;
    /// <summary>
    /// Начальная скорость объекта
    /// </summary>
    float speed = 0.5f;
    /// <summary>
    /// Добавление к скорости объекта, зависит от значения таймера
    /// </summary>
    float plusspeed = 1;

    void Start()
    {
        ScrToWP = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        InvokeRepeating("CreateBall", start_create, interval);

        timer = GameObject.Find("Timer");
        istime = timer.GetComponent<Timer>().timeRemaining;

        timer.GetComponent<Timer>().StopTimer += StopCreate;
    }
    
    /// <summary>
    /// Создание объектов
    /// </summary>
    public void CreateBall()
    {
        //размер объекта
        scale_Ball = UnityEngine.Random.Range(0.5f, 1.5f);
        Ball.transform.localScale = new Vector3(scale_Ball, scale_Ball, scale_Ball);

        //координаты объекта, с учетом размера объекта
        random_x = UnityEngine.Random.Range(-ScrToWP.x + Ball.transform.localScale.x / 2, 
                                              ScrToWP.x - Ball.transform.localScale.x / 2);
        random_y = -ScrToWP.y + Ball.transform.localScale.y / 2;
        pos_Ball = new Vector3(random_x, random_y, Ball.transform.position.z);

        //создание объекта
        GameObject ball = Instantiate(Ball, pos_Ball, Quaternion.identity);

        //цвет объекта
        color_Ball = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f),
                                                              UnityEngine.Random.Range(0f, 1f), 1f);
        ball.GetComponent<MeshRenderer>().material.color = color_Ball;

        //увеличение скорости объекта в зависимости от значений таймера
        //Начальное значение таймера istime делится на десять равных частей, каждую десятую часть времени скорость увеличивается на plusspeed/10 
        if (Mathf.Round(timer.GetComponent<Timer>().timeRemaining) <= istime - istime * plusspeed / 10)
        {
            plusspeed++;
        }

        //Задание скорости объекта
        ball.GetComponent<Life_Ball>().speed_ball = speed + (plusspeed/10);
    }

    /// <summary>
    /// Остановка создания объектов
    /// </summary>
    private void StopCreate()
    {
        CancelInvoke();
    }

}
