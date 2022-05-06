using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkDisplayManager : MonoBehaviour
{
    public Image perkImage;
    public GameObject player;
    private PlayerController playerController;

    void Awake()
    {
        if (player.GetComponent<PlayerController>() != null)
        {
            playerController = player.GetComponent<PlayerController>();
            {
                playerController.OnPerkSet += OnPerkSet;
                playerController.OnPerkUse += OnPerkUse;
            }
        }
    }

    private void OnPerkSet()
    {
        perkImage.enabled = true;
        string url = playerController.perk.GetComponent<BasePerk>().perkIcon;
        Sprite perkIcon = Resources.Load<Sprite>(url);
        perkImage.sprite = perkIcon;
    }

    private void OnPerkUse()
    {
        perkImage.enabled = false;
    }

}