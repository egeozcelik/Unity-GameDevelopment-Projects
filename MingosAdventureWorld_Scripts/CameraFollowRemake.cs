using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRemake : MonoBehaviour
{
	//public float speed = 15f;
	//public float minDistance;
	//public GameObject target;
	//public Vector3 offset;

	//private Vector3 targetPos;

	//// Use this for initialization
	//void Start()
	//{
	//    targetPos = transform.position;
	//}

	//// Update is called once per frame
	//void Update()
	//{
	//    if (target)
	//    {
	//        Vector3 posNoZ = transform.position + offset;
	//        Vector3 targetDirection = (target.transform.position - posNoZ);
	//        float interpVelocity = targetDirection.magnitude * speed;
	//        targetPos = (transform.position) + (targetDirection.normalized * interpVelocity * Time.deltaTime);
	//        transform.position = Vector3.Lerp(transform.position, targetPos, 0.25f);

	//    }
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start()
	{
		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 15f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

		}
	}
}
    /*public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

		}
	}
	 *
	 **/

