using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealsListItem : MonoBehaviour
{
    [SerializeField] private Image selectionImage;
    [SerializeField] private Image icon;
    [SerializeField] private Text label;
    [SerializeField] private Text number;
    private MealComponent _mealComponent;
    private CookingController _cookingController;
    private bool _selected = false;
    public bool Selected
    {
        get { return _selected; }
        set
        {
            _selected = value;
            if(value == true)
            {
                selectionImage.color = Color.green;
            }
            else
            {
                selectionImage.color = Color.white;
            }
        }
    }

    public void SetMealComponent(MealComponent mealComponent, int number, CookingController cookingController)
    {
        _mealComponent = mealComponent;
        icon.sprite = _mealComponent.IconSprite;
        //TODO:label
        //label.text = _mealComponent.Label;
        this.number.text = $"{number}";
        _cookingController = cookingController;
        //this.GetComponent<Button>().onClick.AddListener(SwitchSelection);
    }

    public void SwitchSelection()
    {
        if (_selected) 
        {
            DeselectMealComponent();
        }
        else 
        {
            SelectMealComponent();
        }
    }

    public void SelectMealComponent()
    {
        if(_cookingController.SelectMealComponent(_mealComponent, 1))
        {
            Selected = true;
        }
    }

    public void DeselectMealComponent()
    {
        _cookingController.DeselectMealComponent(_mealComponent, 1);
        Selected = false;
    }
}
