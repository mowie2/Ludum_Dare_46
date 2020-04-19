using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    // Start is called before the first frame update

    Transform part1;
    Transform part2;
    Transform part3;
    Transform light;
    void Start()
    {
        part1 = transform.Find("Part1");
        part2 = transform.Find("Part2");
        part3 = transform.Find("Part3");
        light = transform.Find("Tel Light");

        part1.gameObject.SetActive(false);
        part2.gameObject.SetActive(false);
        part3.gameObject.SetActive(false);
        light.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTeleporter()
    {
        GetComponent<BoxCollider2D>().enabled = true;

        part1.gameObject.SetActive(true);
        part2.gameObject.SetActive(true);
        part3.gameObject.SetActive(true);
        light.gameObject.SetActive(true);
    }
}
