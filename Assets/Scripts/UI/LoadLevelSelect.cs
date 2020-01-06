
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadLevelSelect : MonoBehaviour
{
    public void LoadLevel()
    {
        print(transform.name);
        PlayerPrefs.SetInt("Currentlevel", Int32.Parse(transform.name)-1);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
