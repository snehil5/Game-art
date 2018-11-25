using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    public GameObject cube;

    // Use this for initialization
    void Start()
    {
        cube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            cube.SetActive(true);
        }
    }
}
