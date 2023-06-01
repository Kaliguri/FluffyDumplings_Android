using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingResultNotificator : MonoBehaviour
{
    [SerializeField] private Image mealImage;
    [SerializeField] private Text mealName;
    [SerializeField] private Text resultStatus;

    public void ShowResult(Meal resultMeal, CookingResult result)
    {
        mealImage.sprite = resultMeal.IconSprite;
        mealName.text = resultMeal.Label;

        switch (result)
        {
            case CookingResult.Bad:
                resultStatus.color = Color.red;
                resultStatus.text = "Bad";
                break;
            case CookingResult.Good:
                resultStatus.color = Color.yellow;
                resultStatus.text = "Good";
                break;
            case CookingResult.Perfect:
                resultStatus.color = Color.green;
                resultStatus.text = "Perfect";
                break;
        }

        gameObject.SetActive(true);
    }

    public void CloseNotif()
    {
        gameObject.SetActive(false);
    }
}
