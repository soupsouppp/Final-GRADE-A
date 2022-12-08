using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthbar : MonoBehaviour
{
    public Image healthBar;
    public Image waterBar;
    public Image foodBar;

    public GameObject player;

    float lerpSpeed;
    Color hpMax = new Color(0.302f, 1f, 0.651f);
    Color hpMin = new Color(0.902f, 0.122f, 1f);

    Color foodMin = new Color(1, 0.914f, 0.463f);
    

    void Start()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;

        fillHP();
        fillWater();
        fillFood();

        colorChange();

        

        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        //healthbar
        if (playerStat.health > playerStat.maxHP)
        {
            playerStat.health = playerStat.maxHP;
        }

        if (playerStat.water > playerStat.maxThirst)
        {
            playerStat.water = playerStat.maxThirst;
        }

        if (playerStat.food > playerStat.maxHunger)
        {
            playerStat.food = playerStat.maxHunger;
        }


    }

    private void fillHP()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerStat.health / playerStat.maxHP, lerpSpeed);
        //Debug.Log("filled hp bar");
    }

    private void fillWater()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        waterBar.fillAmount = Mathf.Lerp(waterBar.fillAmount, playerStat.water / playerStat.maxThirst, lerpSpeed);
        //Debug.Log("filled water bar");

    }

    private void fillFood()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        foodBar.fillAmount = Mathf.Lerp(foodBar.fillAmount, playerStat.food / playerStat.maxHunger, lerpSpeed);
        //Debug.Log("filled food bar");

    }



    void colorChange()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        Color hpBarColor = Color.Lerp(Color.red, hpMax, (playerStat.health / playerStat.maxHP));
        healthBar.color = hpBarColor;

        Color foodBarColor = Color.Lerp(Color.red, foodMin, (playerStat.food / playerStat.maxHunger));
        foodBar.color = foodBarColor;

        Color waterBarColor = Color.Lerp(Color.red, Color.green, (playerStat.water / playerStat.maxThirst));
        waterBar.color = waterBarColor;

    }
}

