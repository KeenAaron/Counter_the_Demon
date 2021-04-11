using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float moveSpeed = 7f;
	Rigidbody2D myRigidbody;
	Transform target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		target = GameObject.FindWithTag("Player").transform;
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		myRigidbody.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player")) {
			StartCoroutine(DestroyCo());
		}
	}
	public IEnumerator DestroyCo()
	{
		yield return new WaitForSeconds(0.2f);
		Destroy(this.gameObject);
	}
}
