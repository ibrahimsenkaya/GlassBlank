using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    Vector3 point1,pointofTransform;
    GameObject temp,Apartment;
    [SerializeField] GameObject[] Bricks;
    float Xaxis = 3f;
    int randomx,randombrick;
    
    void Start()
    {
        Apartment = GameObject.Find("Bina" + " " + PlayerPrefs.GetInt("Currentlevel") + "(Clone)");

        pointofTransform =Apartment.transform.GetChild(Apartment.transform.childCount-1).position;
        transform.position = new Vector3(0, pointofTransform.y+20f, -15.2f);
        point1 =transform.position;
        InvokeRepeating("Ins", 1f, 1.5f);
 
    }

    void GenerateRandomx()
    {
        randomx = Random.Range(-1, 2);
    }

    void Ins()
    {


        GenerateRandomx();
        point1.x = Xaxis * randomx;
        randombrick = Random.Range(0, 3);
        temp = Instantiate(Bricks[randombrick], point1, Quaternion.identity);
        if (randombrick==2)
        {
            temp.transform.Rotate(270, 0, 0);
        }
    }
}
