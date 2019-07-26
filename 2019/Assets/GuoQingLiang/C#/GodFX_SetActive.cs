using UnityEngine;
using System.Collections;

public class GodFX_SetActive : MonoBehaviour {
	Transform FX ;
	bool 显示 = true;
	float _整体延迟; //循环时间.
	float _time   ;
	public static float delay = 9.99f;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if(显示)
		{	
			_time = Time.time;	
		//	SetPlayActive ();
			foreach (Transform t in this.gameObject.transform) {
				FX = t;
			//	FX.gameObject.SetActive (false);
			}
		//	Destroy (this.GetComponent("GodFX_SetActive"));
			显示=false;
		}

	//	Debug.Log (delay);
	 	

		//	FX = t.gameObject;
		if (FX) {
			if (FX.name.Substring (0, 2) == "D_")
				delay = float.Parse (FX.name.Substring (2, 4));
			else if (FX.name.Substring (2, 2) == "D_")
				delay = float.Parse (FX.name.Substring (4, 4));

			else if (FX.name.Substring (0, 2) == "C_"){
				delay = float.Parse (FX.name.Substring (2, 4));

			}
			//	}
//			Debug.Log (FX.name);
		}

		if(Time.time - _time > delay ){
	 		this.gameObject.SetActiveRecursively (true);
		//	_延迟时间 = Time.time  ;
		}
//		Debug.Log( (Time.time - _time) + "   " + delay);
	}
	
	void SetPlayActive () {
		foreach (Transform t in this.gameObject.transform) {
	//		t.gameObject.SetActive (true);
	//		t.gameObject.AddComponent ("GodFX_SetActive");
		}//获取编辑中的特效
		 
	}

}
