using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
	// Use this for initialization
	NavMeshAgent _agent;
	void Start () {
		_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		_agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;

	}
}
