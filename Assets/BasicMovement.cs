using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // float vertical = Input.GetAxis("Vertical");
        // if (vertical != 0f)
        // {
        transform.Translate(Vector3.forward * 50f * Time.deltaTime);
        // }

        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            Debug.Log("Horizontal");
            transform.Rotate(Vector3.up, 100f * Time.deltaTime * horizontal);
        }
    }
}
