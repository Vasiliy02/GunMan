using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Rigidbody bullet;

    public float sensetive;
    public float shootForce;
    public float speedShot;

    private float shootTime;

    public LayerMask clikOn;

    private NavMeshAgent agent;

    private Animator animHero;

    private bool whatAct;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animHero = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(whatAct == false)
            {
                Move();
            }
        } 

        if(whatAct == true)
        {
            Shoot();
        }
    }

    private void Move()
    {
        Ray clikRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(clikRay, out hit, 120, clikOn))
        {
            agent.SetDestination(hit.point);
        }
    }

    private void Shoot()
    {
        transform.Rotate(0f, Input.GetAxis("Mouse X") * sensetive, 0f);
        animHero.SetTrigger("Shoot");

        if (Input.GetMouseButton(0) & shootTime <= 0)
        {
            Rigidbody BulletInstance;
            BulletInstance = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
            BulletInstance.AddForce(spawnPoint.forward * shootForce);

            shootTime = speedShot;
        }

        if (shootTime > 0)
        {
            shootTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ShootingRange")
        {
            whatAct = true;
        }
    }
}
