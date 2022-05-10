using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkDisplayManager : MonoBehaviour
{
    [SerializeField]
    private Image perkImage;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text scoreText;
    private PlayerController playerController;

    void Awake()
    {
        if (player.GetComponent<PlayerController>() != null)
        {
            playerController = player.GetComponent<PlayerController>();
            {
                playerController.OnPerkSet += OnPerkSet;
                playerController.OnPerkUse += OnPerkUse;
                playerController.OnScoreChange += OnScoreChange;
            }
        }
    }

    private void OnScoreChange()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + playerController.score.ToString();
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