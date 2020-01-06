using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMove : MonoBehaviour
{
    Vector3 temppos;
    FlatController flatcontroller;
    bool Ismoving=false;
    GameObject tempGlass;
    [SerializeField] GameObject Tutpanel;
    float currentpos;
    SwipeControl swp;

    Animator anim;
    void Start()
    {

        if (PlayerPrefs.GetInt("Currentlevel") != 0)
        {
            Tutpanel.SetActive(false);
        }
        swp = transform.GetComponent<SwipeControl>();
        currentpos = transform.position.y;
        anim = transform.GetComponent<Animator>();
        flatcontroller = GameObject.Find("FlatControl").GetComponent<FlatController>();
        flatcontroller.NextFloorEvent += MoveNextFloor;
  
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !Ismoving)
        {
            RaycastHit hit;
            temppos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15f);
            Ray ray = Camera.main.ScreenPointToRay(temppos);

            if (Physics.Raycast(ray, out hit))
            {
                tempGlass = hit.transform.gameObject;
                if (hit.transform.tag == "Window" && hit.transform.position.y - transform.position.y < 7f)
                {
                    if (PlayerPrefs.GetInt("Currentlevel") == 0)
                    {
                        Tutpanel.SetActive(false);
                    }
                    anim.SetBool("Put", true);
             
                    transform.DOMoveX(hit.point.x, 1f).OnComplete(() =>
                    {

                    });
                    if (hit.transform.position.x - transform.position.x < 0)
                    {
                        transform.DORotate(new Vector3(0, 270, 0), .7f).OnComplete(() =>
                        {
                            transform.DORotate(new Vector3(0, 0, 0), .1f);
                        });
                    }
                    else
                    {
                        transform.DORotate(new Vector3(0, 90, 0), .7f).OnComplete(() =>
                        {
                            transform.DORotate(new Vector3(0, 0, 0), .1f);
                        }
                   );
                    }

                    Ismoving = true;

                }

            }


        }
        if (swp.SwipeLeft && transform.position.x > -10)
        {
            if (PlayerPrefs.GetInt("Currentlevel") ==0)
            {
                Tutpanel.transform.GetChild(0).GetComponent<Animator>().SetBool("Tap", true);
            }
          
            anim.SetBool("Right", true);
            transform.DOMoveX(transform.position.x - 10f, 1.3f);
       
        }
        if (swp.SwipeRight && transform.position.x < 10)
        {
            if (PlayerPrefs.GetInt("Currentlevel") == 0)
            {
                Tutpanel.transform.GetChild(0).GetComponent<Animator>().SetBool("Tap", true);
            }
            anim.SetBool("Left", true);
            transform.DOMoveX(transform.position.x + 10f, 1.3f);
        }



    }
    

    void MoveNextFloor()
    {
        currentpos += 7.2f;
        transform.DOMoveY(currentpos, 1f);
  
    }

    public void PuttheGalss()
    {
        PlayerPrefs.SetInt("BrokenCount", PlayerPrefs.GetInt("BrokenCount") - 1);
        anim.SetBool("Put", false);
        Destroy(tempGlass.transform.gameObject);
        Ismoving = false;
    }
}
