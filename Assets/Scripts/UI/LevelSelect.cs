using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] GameObject Cont;
    Button Lvlbtbn;
    [SerializeField] Sprite LockedApart,PassedApart, Lock, Passed, Stop;
    TextMeshProUGUI Levels;
    private void Awake()
    {
        for (int i = 0; i < Cont.transform.childCount; i++)
        {
         
            Cont.transform.GetChild(i).transform.name = (i+1).ToString();
            Levels = Cont.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Levels.text = (i+1).ToString();
            if (PlayerPrefs.GetInt("Lastlevel")>=i)
            {
                //Passed Area
                Cont.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = Passed;

                Cont.transform.GetChild(i).transform.GetComponent<Image>().sprite = PassedApart;
                Cont.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().enabled = false;
            }
            else
            {
                Cont.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = Stop;
                Cont.transform.GetChild(i).transform.GetComponent<Image>().sprite = LockedApart;
                Cont.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().sprite = Lock;
                Cont.transform.GetChild(i).transform.GetComponent<Button>().interactable = false;
            }

          
        }
    }


 
}
