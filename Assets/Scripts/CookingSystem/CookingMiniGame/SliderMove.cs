using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour
{
    public Slider slider;

    private float slider_step = 1;
    private bool slider_edge = false;

    private bool isMoving = false;

    private float[] red_border = { 0.4f, 0.6f };
    private float[] yellow_border = { 0.23f, 0.77f };

    public Action<CookingResult> resultEvent;

    public void StartGame(float[] red_border, float[] yellow_border, Action<CookingResult> resultEvent)
    {
        this.red_border = red_border;
        this.yellow_border = yellow_border;
        this.resultEvent = resultEvent;
    }

    private void UpdateProgress()
    {
        if (slider.value == 1)
        {
            slider_edge = true;
        }
        else if (slider.value == 0)
        {
            slider_edge = false;
        }

        if (slider_edge == false)
        {
            slider.value += slider_step * Time.deltaTime;
        }
        else
        {
            slider.value -= slider_step * Time.deltaTime;
        }
    }

    // 0 - плохо
    // 1 - нормально
    // 2 - отлично
    public void CompleteGame()
    {
        float score = slider.value;
        isMoving = false;

        if ((score >= red_border[0]) && (score <= red_border[1]))
        {
            resultEvent?.Invoke(CookingResult.Perfect);
            Debug.Log("Отлично");
        }
        else if ((score >= yellow_border[0]) && (score <= yellow_border[1]))
        {
            resultEvent?.Invoke(CookingResult.Good);
            Debug.Log("Нормально");
        }
        else
        {
            resultEvent?.Invoke(CookingResult.Bad);
            Debug.Log("Плохо :(");
        }
    }

    private void Update()
    {
        if (isMoving == true)
        {
            UpdateProgress();
        }
    }
}