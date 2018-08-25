using UnityEngine;
using UnityEngine.AI;

public class NormalZombie : MonoBehaviour {

    [SerializeField]
    private Animator anim;

	public Transform[] points;
        private int destPoint = 0;
        private int goPoint = 0;
        private NavMeshAgent agent;
        void Start () {

            agent = GetComponent<NavMeshAgent>();
            agent.autoBraking = false;
            GotoNextPoint();
        }
        void GotoNextPoint() {
        anim.SetBool("IsRunning", true);
        if (points.Length == 0)
                return;
            agent.destination = points[destPoint].position;
            destPoint = (destPoint + goPoint) % points.Length;
        }
        void Update () {


            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
                goPoint = Random.Range(0, 24);
        }
    }