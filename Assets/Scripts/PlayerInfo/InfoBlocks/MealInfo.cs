using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class MealInfo
{
    public static List<MealComponent> MealComponents
    {
        get
        {
            return GetMealComponents(MealDataJsonisable.MealComponents);
        }
    }

    public static MealData MealData
    {
        get
        {
            MealDataJsonisable mealDataJsonisable = MealDataJsonisable;
            return new MealData(GetMealComponents(mealDataJsonisable.MealComponents), mealDataJsonisable.MealComponentsNumbers);
        }
    }

    public static void UseMealComponents(List<MealComponent> usedMealComponents)
    {
        MealData mealData = MealData;
        for (int i = 0; i < mealData.MealComponents.Count; i++)
        {
            if (usedMealComponents.Contains(mealData.MealComponents[i]))
            {
                //TODO: perhaps it`s better to use ListHelper
                if (mealData.MealComponentNumbers[i] > 1)
                {
                    mealData.MealComponentNumbers[i]--;
                }
                else
                {
                    mealData.MealComponents.RemoveAt(i);
                    mealData.MealComponentNumbers.RemoveAt(i);
                }
            }
        }
        MealDataJsonisable = new MealDataJsonisable(GetMealComponentsJsonisable(mealData.MealComponents), mealData.MealComponentNumbers);
    }

    public static void AddMealComponent(List<MealComponent> mealComponents, List<int> numbers)
    {

    }

    private static void CheckFile()
    {
        FoldersCreater.CheckFolders();
        if (!File.Exists($"{Application.persistentDataPath}/Info/MealDataJsonisable.json"))
        {
            File.WriteAllText($"{Application.persistentDataPath}/Info/MealDataJsonisable.json", JsonUtility.ToJson(new MealDataJsonisable()));
        }
    }

    private static List<MealComponent> GetMealComponents(List<string> mealComponents)
    {
        //TODO: types of meal components (fillings, dough etc)
        List<MealComponent> result = new List<MealComponent>();
        result.AddRange(MealComponents.Select(m => { return Resources.Load<MealComponent>($"/MealComponents/{m}"); }).ToList());
        return result;
    }

    private static List<string> GetMealComponentsJsonisable(List<MealComponent> mealComponents)
    {
        return mealComponents.Select(m => { return m.Label; }).ToList();
    }

    private static MealDataJsonisable MealDataJsonisable
    {
        get
        {
            CheckFile();
            return JsonUtility.FromJson<MealDataJsonisable>(File.ReadAllText($"{Application.persistentDataPath}/Info/MealDataJsonisable.json"));
        }
        set
        {
            File.WriteAllText($"{Application.persistentDataPath}/Info/MealDataJsonisable.json", JsonUtility.ToJson(value));
        }
    }
}
