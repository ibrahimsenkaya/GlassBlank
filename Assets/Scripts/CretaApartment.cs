using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CretaApartment : MonoBehaviour
{
    [SerializeField] GameObject[] Apartments;
    [SerializeField] GameObject Vinc;
    GameObject vinctemp;
    GameObject[] windows;
    GameObject tempapart;
  
    float Flaty=9.6f;
    bool notBroken;
    int level;
    void Awake()
    {
        

        PlayerPrefs.SetInt("BrokenCount", 0);
        level = PlayerPrefs.GetInt("Currentlevel");
      
        tempapart = Instantiate(Apartments[level], new Vector3(0, 24f, 0), Quaternion.identity);
        vinctemp= Instantiate(Vinc,new Vector3(0,68f,-8.2f),Quaternion.identity);
        vinctemp.transform.Rotate(-90f, 0, 180f);
       
        if (PlayerPrefs.GetInt("Currentlevel")==3)
        {
           // tempapart.transform.Rotate(0, 0, 0);
            tempapart.transform.position = new Vector3(0, 24.4f, 6.5f);
         
     
        }
        if (PlayerPrefs.GetInt("Currentlevel") == 10)
        {
            tempapart.transform.Rotate(-90f, 0, 0);
        }
        else
        {
            tempapart.transform.Rotate(-90f, 0, 180f);
        }


        windows = GameObject.FindGameObjectsWithTag("Window");
        for (int i = 0; i < windows.Length; i++)
        {
            if (Random.Range(0, 100) < 40)
            {
                notBroken = true;
            }
            else
            {
                notBroken = false;
                PlayerPrefs.SetInt("BrokenCount", PlayerPrefs.GetInt("BrokenCount") + 1);
            }
            if (notBroken)
            {
                Destroy(windows[i].gameObject);
            }
        }



    }
    void CreateMap()
    {
        //if (level < 3)
        //{
         
        //    map = Instantiate(Maps[0], new Vector3(0, 4, 0), transform.rotation);
        //    map.transform.Rotate(270f, 0, 0);
         
        //}
        //else if (level<6)
        //{
            
        //    map = Instantiate(Maps[1], new Vector3(0, 0, 0), transform.rotation);
        //    map.transform.Rotate(270f, 0, 0);
 
        //}
        //else if (level < 10)
        //{
           
        //    map = Instantiate(Maps[2], new Vector3(0, 4, 0), transform.rotation);
        //    map.transform.Rotate(270f, 0, 0);
   
        //}
    }


    void oldOne()
    {

    //    GameObject tempflat, Apartment;
    //    GameObject map;
    //[SerializeField] GameObject[] Flats;
    //GameObject Flat;
    //level = PlayerPrefs.GetInt("Currentlevel");
    //    Apartment = GameObject.Find("Apartment");
    //    CreateMap();
    //    for (int i = 0; i < level + 2; i++)
    //    {
    //        tempflat = Instantiate(Flats[0], new Vector3(0, Flaty, 0), transform.rotation);
    //        tempflat.transform.Rotate(90f, 0, 0);
    //        for (int j = 0; j < tempflat.transform.childCount; j++)
    //        {
    //            if (Random.Range(0, 100) < 50)
    //            {
    //                notBroken = true;
    //            }
    //            else
    //            {
    //                notBroken = false;
    //                PlayerPrefs.SetInt("BrokenCount", PlayerPrefs.GetInt("BrokenCount") + 1);
    //            }
    //            if (notBroken)
    //            {
    //                Destroy(tempflat.transform.GetChild(j).transform.GetChild(0).gameObject);
    //            }


    //        }
    //        tempflat.transform.SetParent(Apartment.transform);
    //        Flaty += 4.6f;
    //    }
    }
 
}
