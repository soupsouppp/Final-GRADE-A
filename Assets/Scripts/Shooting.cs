using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera playerCam;
    [SerializeField] weaponData gundata;

    public Animator animator;
    private float lastShootTime = 0f;

    public bool pistolEquipped;
    public bool rifleEquipped;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && pistolEquipped)
        {
            ShootWeapon();

        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("shootingPistol", false);
        }
    }

    public void RayShoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, gundata.maxDistance))
        {
            //Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDmg(gundata.damage);
                animator.SetBool("shootingPistol", true);
            }


        }

        
    }

    public void ShootWeapon()
    {
        if(Time.time < lastShootTime + gundata.fireRate)
        {
            Debug.Log("shoot weapon");
            lastShootTime = Time.time;

            RayShoot();
        }
    }
}
