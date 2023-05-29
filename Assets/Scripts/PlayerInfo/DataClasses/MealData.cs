using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealData
{
    public List<MealComponent> MealComponents;
    public List<int> MealComponentsNumbers;

    public MealData()
    {
        MealComponents = new List<MealComponent>();
        MealComponentsNumbers = new List<int>();
    }

    public MealData(List<MealComponent> mealComponents, List<int> mealComponentNumbers)
    {
        MealComponents = mealComponents;
        MealComponentsNumbers = mealComponentNumbers;
    }
}
