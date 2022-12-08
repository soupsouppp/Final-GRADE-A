using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using JetBrains.Annotations;

public class Raycast : MonoBehaviour
{
    public GameObject ChatCanvas;
    public GameObject player;

    private bool ChatOpened;
    public bool inChatRange;

    public TextMeshProUGUI highlightText;
    public GameObject Textbox;


    void Start()
    {
        ChatOpened = false;
        highlightText = Textbox.GetComponent<TextMeshProUGUI>();

    }


    public void Update()
    {
        Textbox.SetActive(false);

        //freeze player movement and inventory while chatting
        PlayerController playerController = player.GetComponent<PlayerController>();
        Inventory inventory = player.GetComponent<Inventory>();

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 8))
        {
            //Inventory inventory = gameObject.GetComponentInParent<Inventory>();

            if (hit.transform.tag == "Item")
            {
                Textbox.SetActive(true);
                highlightText.text = "E to pick up";
                inventory.inRange = true;
                //Debug.Log("Raycast in range");

            }
            else
            {
                inventory.inRange = false;
                Textbox.SetActive(false);
            }


            if (hit.transform.tag == "NPC")
            {
                inChatRange = true;
                Textbox.SetActive(true);
                highlightText.text = "F to chat";


            }
            else
            {
                inChatRange = false;
                //Textbox.SetActive(false);
            }


        }

        if (Input.GetKeyDown(KeyCode.F) && inChatRange)
        {
            ChatOpened = !ChatOpened;


        }

        if (ChatOpened)
        {
            //access inventory
            ChatCanvas.SetActive(true);
            Cursor.visible = true;
            Debug.Log("curser on in chat");
            playerController.enabled = false;
            inventory.enabled = false;
        }
        else
        {
            ChatCanvas.SetActive(false);
            Cursor.visible = false;
            Debug.Log("curser off not in chat");
            playerController.enabled = true;
            inventory.enabled = true;
        }


    }


}


