﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject inventoryMenu;
    //public GameObject player;
    public string inventoryKey;
    public bool isInventoryMenuActive;

    private GameObject player;
    private Behaviour playerMotor;
    private GameObject mainCamera;
    private Behaviour mouseVerticalLook;



    // Start is called before the first frame update
    void Start()
    {
        isInventoryMenuActive = false;

        //Don't need this. Use "public GameObject player" above then define player in Unity Inspector
        player = GameObject.Find("Player");
        playerMotor = player.GetComponent<PlayerMotor>();

        mainCamera = GameObject.Find("Main Camera");
        mouseVerticalLook = mainCamera.GetComponent<MouseVerticalLook>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(inventoryKey))
        {
            if (isInventoryMenuActive == false)
            {
                inventoryMenu.SetActive(true);
                isInventoryMenuActive = true;
                Cursor.lockState = CursorLockMode.None;
                playerMotor.enabled = false;
                mouseVerticalLook.enabled = false;

            }
            else
            {
                inventoryMenu.SetActive(false);
                isInventoryMenuActive = false;
                Cursor.lockState = CursorLockMode.Locked;
                playerMotor.enabled = true;
                mouseVerticalLook.enabled = true;
            }
        }
    }
}
