using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //player viriable 
    public float maxHP, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;

    public float health, water, food;

    public bool dead;

    public GameObject ChoiceScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DormDoor")
        {
            Door door = other.GetComponent<Door>();
            Choice choice = ChoiceScript.GetComponent<Choice>();

            if(choice.signedIn == true)
            {
                door.canBeOpen = true;
            }
        }
    }


    public void Start()
    {

        health = maxHP;
        

    }



    public void Update()
    {
        
        










        //survival 
        if (!dead)
        {
            water -= thirstIncreaseRate * Time.deltaTime;
            food -= hungerIncreaseRate * Time.deltaTime;
        }


        //player death 
        if (water <= 0)
        {
            Die();
        }
        if (food <= 0)
        {
            Die();
        }
        if (health <= 0)
        {
            Die();
        }


        
    }

    //death function
    public void Die()
    {
        Debug.Log("player death");
        dead = true;
    }


    public void Drink(float waterUpvalue)
    {
        water += waterUpvalue;
    }

    public void Eat(float foodUpvalue)
    {
        food += foodUpvalue;
    }


    //taking dmg
    public void dmg(float dmgpoints)
    {
        if (!dead)
        {
            health -= dmgpoints;
        }
    }

    //healing 
    public void Heal(float HPUpValue)
    {
        if (health < maxHP)
        {
            health += HPUpValue;
        }
    }









    //testing

}