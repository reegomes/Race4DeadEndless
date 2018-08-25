using UnityEngine;
using UnityEngine.AI;
public class GameManager : MonoBehaviour
{

    private static GameManager instancia;
    public static GameManager Instancia { get { return instancia; } }

    private void Start()
    {
        instancia = this;
    }

}
public enum NomeDoEnumQueEuAindaNaoDecidiOQueFazer
{
    velocity, gas, angle, mass, nitro, points
}
public class Patrol : MonoBehaviour
{
    //public Transform[] points;
	//Usado no site da unity
	public GameObject[] points;
    private int destPoint = 0;
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
		
		//agent.destination = points[destPoint].position;
		//Usado no site da Unity
		agent.destination = points[destPoint].transform.position;
		destPoint = (destPoint + 1) % points.Length;
    }
	void Update() {
		if(!agent.pathPending && agent.remainingDistance < 0.5f){
			GotoNextPoint();
		}	
	}
}