using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiZiFly : MonoBehaviour
{

    public Vector3 SpeedVector3;

    public float DetroyTime = 5f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject,DetroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(SpeedVector3*Time.deltaTime);
	}
}
