using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ProgressBAr : MonoBehaviour
{
    GameObject Apartment,Player;
    Vector3 pointofTransform;
    float maxDistance, currentdistance;
    [SerializeField] Image filled;
    TextMeshProUGUI Filledtext;
    [SerializeField] GameObject FilledText;
    
    private void Start()
    {
        Filledtext = FilledText.GetComponent<TextMeshProUGUI>();
        Player = GameObject.Find("Player");
        Apartment = GameObject.Find("Bina" + " " + PlayerPrefs.GetInt("Currentlevel") + "(Clone)");
        pointofTransform = Apartment.transform.GetChild(Apartment.transform.childCount - 1).position;
        maxDistance =  pointofTransform.y- Player.transform.position.y ;
        
    }

    void Update()
    {

        currentdistance =pointofTransform.y - Player.transform.position.y;
        filled.fillAmount = 1 - ((currentdistance-2.65f) / maxDistance);
        Filledtext.text = "%"+ Convert.ToInt32(filled.fillAmount*100 );
    }
}
