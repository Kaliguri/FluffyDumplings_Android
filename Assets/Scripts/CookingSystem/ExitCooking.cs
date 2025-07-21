using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCooking : MonoBehaviour
{
    [SerializeField] private string mainSceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitMinigame();
        }
    }

    public void ExitMinigame()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
