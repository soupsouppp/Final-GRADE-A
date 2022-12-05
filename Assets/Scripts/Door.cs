using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool canBeOpen;
    public Animator animator;
    public GameObject door;
    
    // Start is called before the first frame update
    void Start()
    {
        canBeOpen = false;
        animator = door.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canBeOpen)
        {
            animator.SetBool("character_nearby", true);
        }
    }
}
