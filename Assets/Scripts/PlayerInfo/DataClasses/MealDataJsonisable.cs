using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MealDataJsonisable
{
    public List<string> MealComponents;
    public List<int> MealComponentsNumbers;

    public MealDataJsonisable()
    {
        MealComponents = new List<string>();
        MealComponentsNumbers = new List<int>();
    }

    public MealDataJsonisable(List<string> mealComponents, List<int> mealComponentsNumbers)
    {
        MealComponents = mealComponents;
        MealComponentsNumbers = mealComponentsNumbers;
    }
}
