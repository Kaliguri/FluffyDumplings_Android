using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour
{
    float progress = 0;
    public Slider slider;

    private float slider_step = 0.01f;
    private bool slider_edge = false;

    private bool isMoving = true;

    private float[] red_border = { 0.4f, 0.6f };
    private float[] yellow_border = { 0.23f, 0.77f };

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
            progress += 0.01f;
        }
        else
        {
            progress -= 0.01f;
        }
        
        slider.value = progress;
    }

    // 0 - плохо
    // 1 - нормально
    // 2 - отлично
    public void GetScore()
    {
        int result;

        float score = slider.value;
        isMoving = false;

        if ((score >= red_border[0]) && (score <= red_border[1]))
        {
            result = 2;
            Debug.Log("Отлично");
        }
        else if ((score >= yellow_border[0]) && (score <= yellow_border[1]))
        {
            result = 1;
            Debug.Log("Нормально");
        }
        else
        {
            result = 0;
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
