using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class skeleton : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    public Transform[] points;
    private bool skeletonDead = false;

    void Start()
    {
        int rand = Random.Range(0, points.Length-1);
        agent.SetDestination(points[rand].position);
        anim.SetTrigger("walk");
    }
    void Update()
    {

        if (!skeletonDead && agent.remainingDistance <= agent.stoppingDistance){ 
            int rand = Random.Range(0, points.Length-1);
            agent.SetDestination(points[rand].position);
            anim.SetTrigger("dead");
        }
        if (skeletonDead && !agent.isStopped)
        {
            Debug.Log("skeleton dead");
            agent.isStopped = true;
            anim.SetTrigger("dead");
            anim.ResetTrigger("walk");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Object collision_object = collision.collider.gameObject;
        if (collision_object.name == "Bear_4") {

            if (collision_object.GetComponent<Animator>().GetBool("Attack1"))
            {
                skeletonDead = true;
            }
        }
    }
}
