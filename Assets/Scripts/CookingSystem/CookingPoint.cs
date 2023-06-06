using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingPoint : MonoBehaviour
{
    [SerializeField] private Controller cookingController;

    public void StartCooking()
    {
        SceneManager.LoadScene("CookingMinigame");
    }
}
