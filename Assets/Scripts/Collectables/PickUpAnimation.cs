using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAnimation : MonoBehaviour
{
    [SerializeField]
    private bool isAnimated = true;

    [SerializeField]
    private bool isRotating = true;
    [SerializeField]
    private bool isFloating = false;
    [SerializeField]
    private bool isScaling = false;

    [SerializeField]
    private Vector3 rotationAngle = new Vector3(0, 10, 0);
    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private float floatSpeed = 0.01f;
    private bool goingUp = true;
    [SerializeField]
    private float floatRate = 0.5f;
    private float floatTimer;

    [SerializeField]
    private Vector3 startScale;
    [SerializeField]
    private Vector3 endScale;

    private bool scalingUp = true;
    [SerializeField]
    private float scaleSpeed;
    [SerializeField]
    private float scaleRate;
    private float scaleTimer;

    // Update is called once per frame
    void Update()
    {
        if (isAnimated)
        {
            if (isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if (isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if (!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if (isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if (scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
    }
}

