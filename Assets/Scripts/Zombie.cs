using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    [SerializeField]
    private Animator animZombieMaster;

    private float velocity;
    //0 - idle // 1 - walking //2- attack // 3- heavy attack << ANIMATOR CONTROLLER VALUE
    private int animControllerValue, damage, life, points;
    
    
    //CREATE A NAVMESH AGENT TO ZOMBIES
    private NavMeshAgent ZombieAgent;
    //
    private Ray rayToDetect;
    private RaycastHit toCarDetect;
    //
    //Acessos
    public int AnimControllerValue
    {

        get
        {
            return animControllerValue;
        }

        set
        {
            animControllerValue = value;
        }
    }
    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
        }
    }
    public int Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
        }
    }

    
    //construtor do zombie
    public Zombie(int life, Animator anim)
    {
        //metod to create
        Debug.Log("A hero has been borned");

        //when the hero is born, it receive a damage and a armor value
        this.Life = life;
        this.animZombieMaster = anim;
    }


    private void Start()
    {
        //não necessariamente precisa desses valores
        velocity = 5;
        Damage = 2;
    }


    // Update is called once per frame
    void Update () {
    }

    //Lembrar de dar um Override
    public void AttackModeOn(int controller = 2, int damage = 1)
    {
        //when this metod is activate, Zombie attack
        Debug.Log("AttackModeOn");
        animZombieMaster.SetInteger("MoveController",controller);
        this.AnimControllerValue = controller;
        this.Damage = damage;
    }


    public void HeavyAttackModeOn(int controller = 3, int damage = 2)
    {
        //when this metod is activate, Zombie attack more strong
        Debug.Log("HeavyAttackModeOn");
        animZombieMaster.SetInteger("MoveController", controller);
        this.AnimControllerValue = controller;
        this.Damage = damage;
    }

    public void WalkingModeOn(int controller = 1)
    {
        //when this metod is activate, Zombie Move
        Debug.Log("WalkingkModeOn");
        animZombieMaster.SetInteger("MoveController", controller);
        this.AnimControllerValue = controller;
        //ATIVAR O NAVMESH 
    }

    public void DeadModeOn(int pointsPerDeath = 1, int timetodestroy = 2)
    {
        //when this metod is activate, Zombie Dies
        Debug.Log("DeadModeOn");
        this.Points = pointsPerDeath;
        //RagDoll MODE ON
        Destroy(gameObject, timetodestroy);
    }

    public void AgentPatrolMode(Transform PatrolPoints, int controller = 1)
    {
        //when this metod is activate, Zombie PatrolMode is activate
        animZombieMaster.SetInteger("MoveController", controller);
        Debug.Log("PatrolModeOn");
 
    }

    public virtual void RaycastColliderToCar(Ray rayDetect, RaycastHit carDetect)
    {

        this.rayToDetect = rayDetect;
        this.toCarDetect = carDetect;
        Debug.DrawRay(rayDetect.origin, rayDetect.direction * 25, Color.red, 1.0f);

        if (Physics.Raycast(rayDetect.origin, rayDetect.direction, out carDetect))
        {
            if(carDetect.distance < 0.5)
            {
                //RAGDOLL MODE ON
                DeadModeOn();
            }
            else if(carDetect.distance > 0)
            {
                WalkingModeOn();
            }
            else{

                //AGENT PATROL MODE Navhmesh
            }
        }
    }
}
