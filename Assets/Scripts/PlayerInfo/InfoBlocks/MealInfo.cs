using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class MealInfo: MonoBehaviour
{
    [SerializeField] private List<MealComponent> mealComponents;
    private static List<MealComponent> s_mealComponents;

    private void Start()
    {
        s_mealComponents = mealComponents;
    }

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

    public static void UseMealComponents(List<MealComponent> usedMealComponents, List<int> usedMealComponentsNumbers)
    {
        MealData mealData = MealData;
        for (int i = 0; i < mealData.MealComponents.Count; i++)
        {
            if (usedMealComponents.Contains(mealData.MealComponents[i]))
            {
                //TODO: perhaps it`s better to use ListHelper
                if (mealData.MealComponentsNumbers[i] > 1)
                {
                    mealData.MealComponentsNumbers[i]--;
                }
                else
                {
                    mealData.MealComponents.RemoveAt(i);
                    mealData.MealComponentsNumbers.RemoveAt(i);
                }
            }
        }
        MealDataJsonisable = new MealDataJsonisable(GetMealComponentsJsonisable(mealData.MealComponents), mealData.MealComponentsNumbers);
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
        foreach (var mealComponent in mealComponents)
        {
            MealComponent newComponent = Resources.Load<MealComponent>($"MealComponents/{mealComponent}");
            result.Add(newComponent);
        }
        return result;
        /*List<MealComponent> result = new List<MealComponent>();
        foreach(var mealComponent in mealComponents)
        {
            result.Add(s_mealComponents.Where(m => m.Label == mealComponent).Single());
        }
        return result;*/
    }

    private static List<string> GetMealComponentsJsonisable(List<MealComponent> mealComponents)
    {
        Debug.Log("get jsonisable");
        List<string> result = new List<string>();
        foreach(var m in mealComponents)
        {
            Debug.Log(m);
            result.Add(m.name);
        }
        return result;
        //return mealComponents.Select(m => { return m.Label; }).ToList();
    }

    private static MealDataJsonisable MealDataJsonisable
    {
        get
        {
            CheckFile();
            string json = File.ReadAllText($"{Application.persistentDataPath}/Info/MealDataJsonisable.json");

            Debug.Log(json);
            return JsonUtility.FromJson<MealDataJsonisable>(json);
        }
        set
        {
            File.WriteAllText($"{Application.persistentDataPath}/Info/MealDataJsonisable.json", JsonUtility.ToJson(value));
        }
    }
}
