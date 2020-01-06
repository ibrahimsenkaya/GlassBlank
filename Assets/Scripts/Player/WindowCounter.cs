using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WindowCounter : MonoBehaviour
{

    public event Action GameOverEvent;
    [SerializeField] GameObject Ouch;
    void Update()
    {

        if (PlayerPrefs.GetInt("BrokenCount")==-5)
        {
   
            GameOverEvent();
            PlayerPrefs.SetInt("BrokenCount", -1);

        }
      
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Falling")
        {
            Ouch.SetActive(true);
            PlayerPrefs.SetInt("BrokenCount", PlayerPrefs.GetInt("BrokenCount") - 1);
            Destroy(col.gameObject);

        }
    }
}
