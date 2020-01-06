using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayerFollow : MonoBehaviour
{

    [SerializeField] GameObject player;

    // Update is called once per frame
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y+14f, transform.position.z);
    }
}
