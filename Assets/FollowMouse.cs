using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowMouse : MonoBehaviour {
	public bool isMoving;
	static Animator anim;
	NavMeshAgent agent;

	void Start () {
		isMoving = false;
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (!isMoving) 
			anim.SetTrigger ("isIdle");
		if (isMoving)
			anim.SetTrigger ("isJogging");*/
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				agent.destination = hit.point;
				anim.SetBool ("isJogging", true);
			}
		}
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					anim.SetBool ("isJogging", false);
					//anim.SetTrigger ("isIdle");
				}
			}
		}
	}
}
