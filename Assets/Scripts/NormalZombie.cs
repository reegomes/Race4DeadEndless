using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class NormalZombie : MonoBehaviour
{

    [SerializeField]
    private Animator anim;
    Ray ray_verify_forward, ray_verify_back;


    public Transform[] points;
    private int destPoint = 0;
    private int goPoint = 0;
    private NavMeshAgent agent;
    private int anim_Die_Value;
    bool ZombieIsDead;

    void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.autoBraking = false;
        GotoNextPoint();
        ZombieIsDead = false;
        StartCoroutine("Update_Routine");
        StartCoroutine("Update_ModeOn");
    }

    IEnumerator Update_ModeOn()
    {
        if (ZombieIsDead == false)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                anim.SetInteger("AnimValue", 0);
                GotoNextPoint();
                goPoint = Random.Range(0, points.Length);
            }
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("Update_ModeOn");
    }


    IEnumerator Update_Routine()
    {

        ray_verify_forward = new Ray();
        RaycastHit collision_forward = new RaycastHit();

        ray_verify_back = new Ray();
        RaycastHit collision_back = new RaycastHit();

        ray_verify_forward.origin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        ray_verify_forward.direction = transform.forward;

        ray_verify_back.origin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        ray_verify_back.direction = -transform.forward;


        Debug.DrawRay(ray_verify_forward.origin, ray_verify_forward.direction * 1, Color.green);
        Debug.DrawRay(ray_verify_back.origin, ray_verify_back.direction * 1, Color.red);


        if (Physics.Raycast(ray_verify_forward.origin, ray_verify_forward.direction * 1, out collision_forward))
        {
            Debug.Log("Collision");
            if (collision_forward.collider.tag == "Player" && collision_forward.distance < 1)
            {
                Debug.Log("front");
                anim_Die_Value = 2;
                Zombie_Dies();
            }
        }
        if (Physics.Raycast(ray_verify_back.origin, ray_verify_back.direction * 1, out collision_back))
        {
            Debug.Log("Collision_b");
            if (collision_back.collider.tag == "Player" && collision_back.distance < 1)
            {
                Debug.Log("back");
                anim_Die_Value = 3;
                Zombie_Dies();
            }
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("Update_Routine");
    }



    void GotoNextPoint()
    {
        anim.SetInteger("AnimValue", 1);
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + goPoint) % points.Length;
    }

    void Zombie_Dies()
    {
        ZombieIsDead = true;
        anim.SetInteger("AnimValue", anim_Die_Value);
        Destroy(this.gameObject);
    }

}
/*
using UnityEngine;
using UnityEngine.AI;

public class NormalZombie : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    public Transform[] points;
    private int destPoint = 0;
    private int goPoint = 0;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + goPoint) % points.Length;
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        goPoint = Random.Range(0, 24);
    }
}*/