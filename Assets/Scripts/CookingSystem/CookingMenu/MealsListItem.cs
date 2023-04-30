using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealsListItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text label;
    private MealComponent _mealComponent;
    private CookingController _cookingController;
    private bool _selected = false;

    public void SetMealComponent(MealComponent mealComponent, CookingController cookingController)
    {
        _mealComponent = mealComponent;
        icon.sprite = _mealComponent.IconSprite;
        label.text = _mealComponent.Label;
        _cookingController = cookingController;
        this.GetComponent<Button>().onClick.AddListener(SelectMealComponent);
    }

    public void SelectMealComponent()
    {
        
        if (!_selected)
        {
            _cookingController.SelectMealComponent(_mealComponent);
            //TODO: selected meal component visualisation
            icon.color = Color.yellow;
        }
        else
        {
            _cookingController.DeselectMealComponent(_mealComponent);
            //TODO: deselected meal component visualisation
            icon.color = Color.white;
        }
    }
}
