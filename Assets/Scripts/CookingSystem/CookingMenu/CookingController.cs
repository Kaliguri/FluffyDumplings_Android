using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CookingController : Controller
{
    [SerializeField] private Meal testMeal;
    [Space]
    [SerializeField] private CookingResultNotificator cookingResultNotificator;
    [Space]
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
    private Meal _currentMeal;

    private void Start()
    {
        //TODO:Show when activates
        //OnActivate.AddListener(ShowMealComponents);
        MealDataJsonisable jsonisable = new MealDataJsonisable();
        jsonisable.MealComponents = new List<string>() { "meat_beef", "flour", "salt", "pepper", "sourCream"};
        jsonisable.MealComponentsNumbers = new List<int>() { 20, 20, 20, 20, 20 };
        File.WriteAllText($"{Application.persistentDataPath}/Info/MealDataJsonisable.json", JsonUtility.ToJson(jsonisable));
        Debug.Log(Application.persistentDataPath);

        ShowMealComponents();
    }
    public void ShowMealComponents()
    {
        _mealComponents = new List<MealComponent>();
        _mealComponentsNumbers = new List<int>();
        _mealData = MealInfo.MealData;
        for(int i = 0; i < _mealData.MealComponents.Count; i++)
        {
            /*switch (_mealComponents[i].MealComponentType)
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
            }*/
            Instantiate(mealsListObj, fillingsListContainer).GetComponent<MealsListItem>()
                        .SetMealComponent(_mealData.MealComponents[i], _mealData.MealComponentsNumbers[i], this);
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
        //TODO:calculate difficulty and define meal
        _currentMeal = testMeal;
        sliderMove.StartGame(new float[]{ 0.4f, 0.6f }, new float[]{ 0.23f, 0.77f }, EndGame);
    }

    public void EndGame(CookingResult cookingResult)
    {
        cookingResultNotificator.ShowResult(_currentMeal, cookingResult);
    }
}
