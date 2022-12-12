using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject Tooltip;
    public TextMeshProUGUI tooltipText;
    private RectTransform tpBG;

    public bool empty;
    private bool hovered;

    public GameObject item;
    public Sprite itemIcon;

    private GameObject player;

    private void Awake()
    {
        tpBG = Tooltip.GetComponent<RectTransform>();
        tooltipText = Tooltip.GetComponentInChildren<TextMeshProUGUI>();

    }
    void Start()
    {
        //empty = true;

        player = GameObject.FindWithTag("Player");
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        hovered = false;

    }


    void Update()
    {
        tpBG = Tooltip.GetComponent<RectTransform>();
        tooltipText = Tooltip.GetComponentInChildren<TextMeshProUGUI>();


        if (item)
        {
            empty = false;
            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<Image>().sprite = itemIcon;
            //Debug.Log("updating inventory");
        }
        else
        {
            empty = true;
            
            itemIcon = null;
            this.GetComponent<Image>().sprite = null;
            

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
        //Tooltip.SetActive(true);

        if (item)
        {
            Item thisItem = item.GetComponent<Item>();

            tpBG = Tooltip.GetComponent<RectTransform>();
            tooltipText = Tooltip.GetComponent<TextMeshProUGUI>();


            //check item type

            
            if (thisItem.type == "pistol")
            {
                ShowTooltip("A pistol that belongs to the school secruity guards. \n Hold left click to shoot. \n(Damage: 15)");
            }

            if (thisItem.type == "water")
            {
                ShowTooltip("Pure water, the best it could get. \n(Water +20)");

            }

            if (thisItem.type == "juice")
            {
                ShowTooltip("Juice, tasty but doesn't relieve much thirst. \n(Water +10) \n(Food +5)");

            }

            if (thisItem.type == "heal")
            {
                ShowTooltip("Medical Syringe, mostly found in school nurse office and supply rooms. \n(HP +20)");
            }

            if (thisItem.type == "healPill")
            {
                ShowTooltip("Painkillers. Will kill some pain but does not help so much. \n(HP +10)");
            }


            if (thisItem.type == "rottenBurger")
            {
                ShowTooltip("A rotten burger, looks like someone left it here for a while. \n(HP -20) \n(Food -20)");
            }

            if (thisItem.type == "energyBar")
            {
                ShowTooltip("Energy bar, relieves a bit of hunger. \n(Food +10)");
            }

            if (thisItem.type == "meal")
            {
                ShowTooltip("Frozen meal from the cafeteria, good quality. Relieves a lot of hunger. \n(Food +20)");
            }

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
        Tooltip.SetActive(false);
    }


    public void ShowTooltip(string tooltipString)
    {
        Tooltip.SetActive(true);
        tooltipText.text = tooltipString;
        

    }

    public void HideTooltip()
    {
        Tooltip.SetActive(false);
    }



    //USE INVENTORY
    public void OnPointerClick(PointerEventData eventData)
    {
        //click on slot 
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();

            //check item type

            //LIQUIDS
            if(thisItem.type == "water")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Drink(thisItem.waterUpvalue);
                
                Destroy(item);
            }

            if (thisItem.type == "juice")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Drink(thisItem.waterUpvalue);
                playerStats.Eat(thisItem.foodUpvalue);
                Destroy(item);
            }



            //FOOD
            if (thisItem.type == "food")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Eat(thisItem.foodUpvalue);

                Destroy(item);
            }

            if (thisItem.type == "rottenBurger")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Eat(thisItem.foodUpvalue);
                playerStats.dmg(thisItem.dmgPoints);

                Destroy(item);
            }

            if (thisItem.type == "energyBar")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Eat(thisItem.foodUpvalue);
                

                Destroy(item);
            }



            //WEAPONS
            if (thisItem.type == "pistol")
            {
                Shooting shooting = player.GetComponent<Shooting>();
                shooting.pistolEquipped = true;

                Destroy(item);
            }

            if (thisItem.type == "rifle")
            {
                Shooting shooting = player.GetComponent<Shooting>();
                shooting.rifleEquipped = true;
                Destroy(item);
            }

            //OTHER
            if (thisItem.type == "heal")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Heal(thisItem.HPUpValue);

                Destroy(item);
            }

            if (thisItem.type == "healPill")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Heal(thisItem.HPUpValue);

                Destroy(item);
            }

        }
    }
}
