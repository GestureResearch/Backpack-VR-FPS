using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject shootOrigin;

    [SerializeField]
    float damage = 1.0f;
    [SerializeField]
    float speed = 1.0f;

    Animator anim;
    LineRenderer lineRenderer;

    private bool startFire;

    private GameObject target;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        lineRenderer = shootOrigin.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {        
        if(other.name == "Regular_Character")
        {
            startFire = true;
            lineRenderer.enabled = true;
            target = other.gameObject;
            anim.SetBool("isFiring", true);
            anim.SetBool("isIdle", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Regular_Character")
        {
            startFire = false;
            lineRenderer.enabled = false;
            target = null;
            anim.SetBool("isFiring", false);
            anim.SetBool("isIdle", true);
        }
    }

    private void Update()
    {
        if(startFire)
        {
            Fire(target.transform);
        }
        else
        {
            StopMoving();
        }
    }

    void Fire(Transform target)
    {
        lineRenderer.SetPosition(0, shootOrigin.transform.position);
        lineRenderer.SetPosition(1, target.GetChild(0).GetChild(0).GetChild(0).GetChild(0).position);
        ReduceHealth(target.gameObject);
        StartMoving(target);
    }

    void StartMoving(Transform targetTransform)
    {
        transform.LookAt(targetTransform);
        this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
    }

    void StopMoving()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void ReduceHealth(GameObject player)
    {
        player.GetComponent<Health>().currentHealth -= damage;
    }

    // Rotate to face the target
    void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}