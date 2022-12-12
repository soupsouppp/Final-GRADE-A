using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    public float health;
    public GameObject player;

    public float Noticedistance;

    private NavMeshAgent navMesh;


    public void TakeDmg(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();

        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < Noticedistance)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            navMesh.SetDestination(newPos);
        }
    }


}
