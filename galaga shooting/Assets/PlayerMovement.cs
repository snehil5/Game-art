using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	float maxSpeed = 5f;
    float shipBoundary = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


		Vector3 pos = transform.position;

		pos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;

		transform.position = pos;

		pos.x += Input.GetAxis ("Horizontal") * maxSpeed * Time.deltaTime;

        if(pos.y+shipBoundary > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundary;
        }
        if (pos.y-shipBoundary <  -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundary;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundary > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundary;
        }
        if (pos.x - shipBoundary < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundary;
        }

        transform.position = pos;
	}
}
