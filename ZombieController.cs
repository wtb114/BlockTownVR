using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	
	public Transform goal;
	public Transform goal2;
	public NavMeshAgent agent;
	float dis;



	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}

	void Update (){
//		agent = GetComponent<NavMeshAgent>();
//		agent.destination = goal.position;
		dis = Vector3.Distance (agent.gameObject.transform.position, agent.destination);
		if (dis < 30.0f) {
			agent.destination = goal2.position;
		} 
		dis = Vector3.Distance (agent.gameObject.transform.position, agent.destination);
		if (dis < 30.0f) {
			agent.destination = goal.position;
		} 
	}
		
}