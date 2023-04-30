using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealData
{
    public List<MealComponent> MealComponents;
    public List<int> MealComponentNumbers;

    public MealData()
    {
        MealComponents = new List<MealComponent>();
        MealComponentNumbers = new List<int>();
    }

    public MealData(List<MealComponent> mealComponents, List<int> mealComponentNumbers)
    {
        MealComponents = mealComponents;
        MealComponentNumbers = mealComponentNumbers;
    }
}
