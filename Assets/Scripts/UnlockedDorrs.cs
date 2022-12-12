using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDorrs : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("character_nearby", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("character_nearby", false);
        }
    }
}
