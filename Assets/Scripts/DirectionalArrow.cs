using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject arrowPointer;

    private const float SHOW_ARROW_DISTANCE = 30f;
    private const float HIDE_ARROW_DISTANCE = 5f;

    private void Awake()
    {
        hideArrow();
    }

    private void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, target.transform.position);
      
        if (distance > SHOW_ARROW_DISTANCE)
        {
            showArrow();
        }

        if(distance < HIDE_ARROW_DISTANCE)
        {
            hideArrow();
        }


        transform.LookAt(targetPosition);
    }

    private void showArrow() {
        arrowPointer.SetActive(true);
    }

    private void hideArrow()
    {
        arrowPointer.SetActive(false);
    }
}
