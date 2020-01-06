using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    GameObject Apartment;
    [SerializeField] GameObject finpanel,InGamePanel,GameOverPanel;
    TextMeshProUGUI Glasses,PauseLevel,Finlevel,InGameLvl;
    [SerializeField] GameObject GlassTxt,LevelTxt;
    [SerializeField] GameObject PauseLeveltxt,FinLevelTxt;
    [SerializeField] FlatController flat;

    void Start()
    {
        Apartment = GameObject.Find("Bina" + " " + PlayerPrefs.GetInt("Currentlevel") + "(Clone)");
        Glasses = GlassTxt.GetComponent<TextMeshProUGUI>();
        PauseLevel= PauseLeveltxt.GetComponent<TextMeshProUGUI>();
        Finlevel= FinLevelTxt.GetComponent<TextMeshProUGUI>();
        InGameLvl = LevelTxt.GetComponent<TextMeshProUGUI>();
        flat.FinEvent += FinishPanel;
        GameObject.Find("Player").GetComponent<WindowCounter>().GameOverEvent += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        Glasses.text = (PlayerPrefs.GetInt("BrokenCount") + 5).ToString();
        PauseLevel.text = PlayerPrefs.GetInt("Currentlevel"+1).ToString();
        Finlevel.text = (PlayerPrefs.GetInt("Currentlevel")+1).ToString();
        InGameLvl.text= "Level"+" "+(PlayerPrefs.GetInt("Currentlevel") + 1).ToString();
    }


    public void PauseBtn()
    {
        Time.timeScale = 0;


    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    void FinishPanel()
    {
        Destroy(Apartment);
        InGamePanel.SetActive(false);
        finpanel.SetActive(true);
        PlayerPrefs.SetInt("Currentlevel", PlayerPrefs.GetInt("Currentlevel")+ 1);
        if (PlayerPrefs.GetInt("Lastlevel") < PlayerPrefs.GetInt("Currentlevel"))
        {
            PlayerPrefs.SetInt("Lastlevel", PlayerPrefs.GetInt("Currentlevel"));
        }
        Time.timeScale = 0;

    }

    public void NextBtn()
    {
   
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    
       
    }

    public void GameOver()
    {
        InGamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;

    }
    
    public void RetryBtn()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }
}
