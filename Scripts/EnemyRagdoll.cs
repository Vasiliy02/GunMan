using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    public float hitStrength;

    public Transform cam;

    private bool whatHit;

    private Rigidbody rbEnemy;

    private RaycastHit hit;

    private void Awake()
    {
        rbEnemy = GetComponentInChildren<Rigidbody>();
        rbEnemy.tag = "Ragdoll";
        rbEnemy.isKinematic = true;

        GetComponent<Animator>().enabled = true;
    }

    private void FixedUpdate()
    {
        if(whatHit == true)
        { 
            StartRagdoll();
        }
    }

    private void StartRagdoll()
    {
        rbEnemy.isKinematic = false;
        GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            whatHit = true;
        }
    }
}
