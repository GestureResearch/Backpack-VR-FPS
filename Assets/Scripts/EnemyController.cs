using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;      // Detection range for player

    public float attackRadius = 3f;      // Detection range for player

    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    Animator anim;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Regular_Character").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            if (PresentinLineofSight())
            {
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", true);
                agent.SetDestination(target.position);
                if (distance <= attackRadius)
                {
                    anim.SetBool("isFiring", true);
                    //attack
                }
                else
                {
                    //stop attacking
                }
            }
            else
            {
                FaceTarget();
                anim.SetBool("isWalking", false);
                anim.SetBool("isFiring", false);
                anim.SetBool("isIdle", true);
                // stop attacking
            }
        }
    }

    bool PresentinLineofSight()
    {
        RaycastHit hit;
        Vector3 rayDirection = target.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            if (hit.transform == target)
            {
                return true;
            }
        }
        return false;
    }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}