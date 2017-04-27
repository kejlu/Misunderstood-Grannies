using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrannyControl : MonoBehaviour {
	public bool isMoving;
	public GameObject granny;
	static Animator anim;
	NavMeshAgent agent;
	GameObject elvis;

	float granny_count = 0f;
	// Use this for initialization
	void Start () {
		isMoving = false;
		anim = GetComponent<Animator> ();
		/*agent = GetComponent<NavMeshAgent> ();
		elvis = GameObject.FindWithTag ("Player");*/
	}
	
	// Update is called once per frame
	void Update () {
		if (granny_count == 0) {
			if (!isMoving)
				anim.SetBool ("isChasing", false);
			StartCoroutine(waitThreeSeconds());
			Instantiate(granny, new Vector3(-3f, -2f, 5f), Quaternion.identity);
			granny_count = granny_count + 1f;
		}
		else if (granny_count < 3) {
			StartCoroutine(waitFiveSeconds());
			Instantiate(granny, new Vector3((granny_count + 1) * -3f, -2f, 5f), Quaternion.identity);
			granny_count = granny_count + 1f;
		}

	}

	IEnumerator waitThreeSeconds() {
		yield return new WaitForSecondsRealtime(3);
	}

	IEnumerator waitFiveSeconds() {
		yield return new WaitForSecondsRealtime(5);
	}

}
