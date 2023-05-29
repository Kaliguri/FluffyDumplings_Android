using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : Controller
{
    [SerializeField] private GameObject mealsListObj;
    [SerializeField] private Transform fillingsListContainer;
    [SerializeField] private Transform spicesListContainer;
    [SerializeField] private Transform saucesListContainer;
    [Space]
    [SerializeField] private SliderMove sliderMove;
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
            switch (_mealComponents[i].MealComponentType)
            {
                case MealComponentTypes.Flare:
                    Instantiate(mealsListObj, fillingsListContainer).GetComponent<MealsListItem>()
                        .SetMealComponent(_mealData.MealComponents[i], _mealData.MealComponentsNumbers[i], this);
                    break;
                case MealComponentTypes.Filling:
                    Instantiate(mealsListObj, fillingsListContainer).GetComponent<MealsListItem>()
                        .SetMealComponent(_mealData.MealComponents[i], _mealData.MealComponentsNumbers[i], this);
                    break;
                case MealComponentTypes.Spice:
                    Instantiate(mealsListObj, spicesListContainer).GetComponent<MealsListItem>()
                        .SetMealComponent(_mealData.MealComponents[i], _mealData.MealComponentsNumbers[i], this);
                    break;
                case MealComponentTypes.Sauce:
                    Instantiate(mealsListObj, saucesListContainer).GetComponent<MealsListItem>()
                        .SetMealComponent(_mealData.MealComponents[i], _mealData.MealComponentsNumbers[i], this);
                    break;
            }
            
        }
    }

    public bool SelectMealComponent(MealComponent mealComponent, int number)
    {
        if (_mealData.MealComponentsNumbers[_mealData.MealComponents.IndexOf(mealComponent)] - number >= 0)
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
        //TODO:calculate difficulty
        sliderMove.StartGame(new float[]{ 0.4f, 0.6f }, new float[]{ 0.23f, 0.77f }, EndGame);
    }

    public void EndGame(CookingResult cookingResult)
    {
        //TODO: define product
    }
}
