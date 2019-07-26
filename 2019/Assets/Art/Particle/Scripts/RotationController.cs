using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour
{
	public float speed = 40f;
	
	private Transform tr;

    public Transform RotateCenter;

    private GameObject go;

	void Awake()
	{
		tr = GetComponent<Transform>();
	}

	void Update()
	{
        transform.RotateAround(RotateCenter.position,RotateCenter.transform.up, speed * Time.deltaTime);
        transform.rotation=Quaternion.identity;
	}
}
