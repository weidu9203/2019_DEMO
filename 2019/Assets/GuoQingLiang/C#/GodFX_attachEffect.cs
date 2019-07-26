using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GodFX_attachEffect : MonoBehaviour {
    public GameObject AttackEffect;
    Transform InstantiatePrefab;
    public float DelayTime = 0;
    public float LifeTime = 0;
     float timePoint = -1;
     float lifePoint = -1;

	void Start () {
        timePoint = Time.time;
	}
	void Update () {
        if (!AttackEffect) return;
        if (lifePoint == -1)
        if (DelayTime < Time.time - timePoint)
        {
            InstantiatePrefab = Instantiate(AttackEffect.transform, transform.position, transform.rotation) as Transform;
            if (InstantiatePrefab)
            {
            //    InstantiatePrefab = PrefabUtility.InstantiatePrefab(Prefab) as GameObject;
                InstantiatePrefab.transform.position = transform.position;
                InstantiatePrefab.transform.rotation = transform.rotation;
                InstantiatePrefab.transform.localScale = transform.localScale;
                GameObject _PlayFxRoot = GameObject.Find("_PlayFxRoot");
                if (!GameObject.Find("_PlayFxRoot")) _PlayFxRoot = new GameObject("_PlayFxRoot");
                InstantiatePrefab.transform.parent = transform;
            }
            lifePoint = Time.time;
        }
        if (lifePoint > 0)
            if (LifeTime < Time.time - lifePoint) 
            {
                Destroy(gameObject);
                lifePoint = -1;
            }

	}
}
