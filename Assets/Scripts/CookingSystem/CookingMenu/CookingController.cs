using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : Controller
{
    [SerializeField] private GameObject mealsListObj;
    [SerializeField] private Transform mealsListContainer;
    private MealData _mealData;
    private List<MealComponent> _mealComponents;
    private List<int> _mealComponentsNumbers;
    private MealType _mealType;
    private MealCookingType _mealCookingType;

    private void Start()
    {
        OnActivate.AddListener(ShowMealComponents);
    }
    public void ShowMealComponents()
    {
        _mealComponents = new List<MealComponent>();
        _mealComponentsNumbers = new List<int>();
        _mealData = MealInfo.MealData;
        for(int i = 0; i < _mealData.MealComponents.Count; i++)
        {
            Instantiate(mealsListObj, mealsListContainer).GetComponent<MealsListItem>()
                .SetMealComponent(_mealData.MealComponents[i], _mealData.MealComponentNumbers[i], this);
        }
    }

    public bool SelectMealComponent(MealComponent mealComponent, int number)
    {
        if (_mealData.MealComponentNumbers[_mealData.MealComponents.IndexOf(mealComponent)] - number >= 0)
        {
            if (_mealComponents.Contains(mealComponent))
            {
                _mealComponentsNumbers[_mealComponents.IndexOf(mealComponent)] += number;
            }
            else
            {
                _mealComponents.Add(mealComponent);
                _mealComponentsNumbers.Add(number);
            }
            return true;
        }
        return false;
    }

    public void DeselectMealComponent(MealComponent mealComponent, int number)
    {
        if (_mealComponents.Contains(mealComponent))
        {
            int index = _mealComponents.IndexOf(mealComponent);
            if (_mealComponentsNumbers[index] > 1)
            {
                _mealComponentsNumbers[index] -= number;
            }
            else
            {
                _mealComponents.RemoveAt(index);
                _mealComponentsNumbers.RemoveAt(index);
            }
        }
    }

    public void SelectMealType(MealType mealType)
    {
        _mealType = mealType;
    }

    public void SelectCookingType(MealCookingType mealCookingType)
    {
        _mealCookingType = mealCookingType;
    }

    public void StartCooking()
    {
        MealInfo.UseMealComponents(_mealComponents, _mealComponentsNumbers);
        //TODO: cooking game
    }
}
