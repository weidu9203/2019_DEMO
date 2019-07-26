using UnityEngine;
using System.Collections;

public class AniTranPosY : MonoBehaviour 
{
	public float JuLi = 0.5f;
	public float BianShu = 0.1f;
	public float PinLv = 1.0f;

	private Vector3 chuShiPos;
	private float zuiDaPosY;
	private float zuiXiaoPosY;
	private bool IsUp = false;

	void Start () 
	{
		JuLi = JuLi + Random.Range(0.0f, BianShu);
		var shu = Random.value;
		if (shu < 0.5) 
		{
			IsUp = true;
		} else {
			IsUp = false;
		}
		chuShiPos = this.transform.position;
		zuiDaPosY = chuShiPos.y + JuLi;
		zuiXiaoPosY = chuShiPos.y - JuLi;
	}

	void Update () 
	{
		if (!IsUp) 
		{
			this.transform.Translate(Vector3.up * Time.deltaTime * PinLv);
			if (this.transform.position.y >= zuiDaPosY)
			{
				IsUp = true;
			}
		} else {
			this.transform.Translate(-Vector3.up * Time.deltaTime * PinLv);
			if (this.transform.position.y <= zuiXiaoPosY)
			{
				IsUp = false;
			}
		}
	}
		
}
