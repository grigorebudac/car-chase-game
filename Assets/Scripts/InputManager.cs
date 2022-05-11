using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool UsePerk { get; private set; }
    public bool Break { get; private set; }
    public bool BreakUp { get; private set; }
    [SerializeField]
    private string horizontalAxis = "Horizontal";
    [SerializeField]
    private string verticalAxis = "Vertical";
    [SerializeField]
    private string usePerkButton = "UsePerk";
    [SerializeField]
    private string breakButton = "Break1";

    public event Action onUsePerk = delegate { };

    void Update()
    {
        Horizontal = Input.GetAxis(horizontalAxis);
        Vertical = Input.GetAxis(verticalAxis);
        UsePerk = Input.GetButtonDown(usePerkButton);
        Break = Input.GetButton(breakButton);
        BreakUp = Input.GetButtonUp(breakButton);

        if (UsePerk)
        {
            onUsePerk();
        }
    }
}
