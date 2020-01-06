using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IskeleFollow : MonoBehaviour
{
    GameObject player;
    float MinY;

    void Start()
    {
        player = GameObject.Find("Player");
        MinY = player.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y - MinY, transform.position.z);
    }
}
