using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateCarController : MonoBehaviour
{
    private ECCar player;
    private PlayerController playerController;
    private InputManager inputManager;

    void Awake()
    {
        player = GetComponent<ECCar>();
        inputManager = GetComponent<InputManager>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (inputManager.UsePerk)
        {
            playerController.usePerk();
        }

        player.Rotate(inputManager.Horizontal);
    }

}
