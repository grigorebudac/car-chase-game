using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkDisplayManager : MonoBehaviour
{
    public RawImage perkImage;

    void Start()
    {
        if (GetComponent<PlayerController>() != null)
        {
            GetComponent<PlayerController>().OnPerkUse += OnPerkUse;
        }
    }

    private void OnPerkUse()
    {
        perkImage.enabled = false;
    }

}
