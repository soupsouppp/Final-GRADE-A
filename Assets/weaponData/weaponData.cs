using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Guns", menuName = "Weapon")]
public class weaponData : ScriptableObject
{
    public new string name;
    public float damage;
    public float maxDistance;

    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloading;


}
