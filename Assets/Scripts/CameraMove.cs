using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    int Boundary = 10;
    float speed = 4f;

    private void LateUpdate()
    {
        //if (Input.mousePosition.x > Screen.width - Boundary)
        //{
        //    transform.position += Vector3.right * speed * Time.deltaTime;
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        //}
        //if (Input.mousePosition.x < 0 + Boundary)
        //{
        //    transform.position += Vector3.left * speed * Time.deltaTime;
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        //}

        //if (Input.mousePosition.y > Screen.height - Boundary)
        //{
        //    transform.position += Vector3.up * speed * Time.deltaTime;
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        //}

        //if (Input.mousePosition.y < 0 + Boundary)
        //{
        //    transform.position += Vector3.down * speed * Time.deltaTime;
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        //}
    }

}
