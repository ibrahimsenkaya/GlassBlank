using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlatController : MonoBehaviour
{
    GameObject Apartment;
    int CurrentFloor=1;
    bool stage1, stage2=false;
    public event Action NextFloorEvent;
    public event Action FinEvent;

    void Start()
    {
        Apartment = GameObject.Find("Bina"+" "+PlayerPrefs.GetInt("Currentlevel")+"(Clone)");

    }


    void Update()
    {
        
            for (int j = 0; j < Apartment.transform.GetChild(CurrentFloor).transform.childCount; j++)
            {
                if (Apartment.transform.GetChild(CurrentFloor).transform.GetChild(j).transform.childCount == 0)
                {
                    stage1 = true;
                }
                else
                {
                    stage1 = false;
                
                    break;
                }
            }
           
           
        
       
        if (stage1)
        {
            if (CurrentFloor==Apartment.transform.childCount-1)
            {
                FinEvent();
             


            }
            else
            {
                NextFloorEvent();

                CurrentFloor++;
                stage1= false;
            }
   
        }
        stage1 = false;
    }
}
