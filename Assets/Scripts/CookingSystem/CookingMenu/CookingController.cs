using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : Controller
{
    [SerializeField] private GameObject mealsListObj;
    [SerializeField] private Transform mealsListContainer;
    private List<MealComponent> _mealComponents;
    private MealType _mealType;

    private void Start()
    {
        OnActivate.AddListener(ShowMealComponents);
    }
    public void ShowMealComponents()
    {
        _mealComponents = new List<MealComponent>();
        foreach(var mealComponent in MealInfo.MealComponents)
        {
            Instantiate(mealsListObj, mealsListContainer).GetComponent<MealsListItem>().SetMealComponent(mealComponent, this);
        }
    }

    public void SelectMealComponent(MealComponent mealComponent)
    {
        _mealComponents.Add(mealComponent);
    }

    public void DeselectMealComponent(MealComponent mealComponent)
    {
        _mealComponents.Remove(mealComponent);
    }

    public void SelectMealType(MealType mealType)
    {
        _mealType = mealType;
    }

    public void StartCooking()
    {
        MealInfo.UseMealComponents(_mealComponents);
        //TODO: cooking game
    }
}
