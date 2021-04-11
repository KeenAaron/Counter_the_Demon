using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public GameObject bullet;
	public float attackRadius;
	Transform target;
	float fireRate;
	float nextFire;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform;
		fireRate = 1f;
		nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfTimeToFire ();
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire && Vector3.Distance(target.position, transform.position) < attackRadius) {
			Instantiate (bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
	}

}
