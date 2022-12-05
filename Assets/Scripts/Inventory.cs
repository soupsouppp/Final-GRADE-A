using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Animator animator;

    public GameObject inventory;
    public GameObject slotHolder;
    public GameObject player;

    public int slots;
    private Transform[] slot;
    private bool inventoryOpened;

    public GameObject itemPickedUp;
    public bool itemAdded;
    public GameObject itemManager;

    public bool inRange;
    public bool triggerEntered;
    void Start()
    {
        inventoryOpened = false;
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        checkSlots();

    }

    
    public void Update()
    {
        
        //Open Inventory 
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("access inventory");
            inventoryOpened = !inventoryOpened;
            

        }
        if (inventoryOpened)
        {
            //access inventory
            inventory.SetActive(true);
            Cursor.visible = true;
            Debug.Log("curser on in inventory");
        }
        else
        {
            inventory.SetActive(false);
            Cursor.visible = false;
            Debug.Log("curser off not in inventory");
        }

        //ITEM PICK UP
        if (triggerEntered == true && inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //animator.SetTrigger("PickUp");
                AddItem(itemPickedUp);
            }
        }

    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Item")
        {
            if (inRange)
            {
                triggerEntered = true;
                itemPickedUp = other.gameObject;
            }
        }      
    }

    

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            itemAdded = false;
            triggerEntered = false;
        }
    }

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty && itemAdded == false)
            {
                slot[i].GetComponent<Slot>().item = itemPickedUp;
                slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;

                //item.transform.parent = itemManager.transform;
                //item.transform.position = itemManager.transform.position;
                //Destroy(item.GetComponent<Rigidbody>());

                itemAdded = true;

               
                Debug.Log("added item");

                Renderer[] itemRen = item.transform.gameObject.GetComponentsInChildren<MeshRenderer>();
                foreach (var r in itemRen)
                {
                    r.enabled = false;
                }


            }
        }
    }

    public void checkSlots()
    {
        for (int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
            //print(slot[i].name);
        }
    }
}
