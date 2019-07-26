using UnityEngine;
using System.Collections;
//[ExecuteInEditMode()]	
public class GodFX_LineAnimition : MonoBehaviour {

	public Transform effectTarget;
	public Transform[] child; 
	Transform nextTarget; 
	public bool auto = false;	
	public float speed = 0.2f;
	int childNum = 0;
	 
	bool playLineEffect= false;
	bool playeffect = true;
	public float delay = 0.0f;
	float temDelayTime;
	public bool loop = false;
	void OnEnable () {
		temDelayTime = 1000000.0f;
		if (child [0]) {
						nextTarget = child [0];
						effectTarget.position = child [0].position;
				}
		playLineEffect = true;
	}
	void Update () {
		if (auto) {
			
			foreach (Transform childx in transform.Find("EffectPlayWithTheLine")) {	
				string name = childx.name;
				int id = int.Parse (name);
				child [id] = childx;  
			} 
			Debug.Log ("Auto JieDian...OK");		
			auto = false;
			nextTarget = child [0];
			effectTarget.position = child [0].position;	
		}

		if(Time.time - temDelayTime >= delay )
			if (child [0]) {
			if(playeffect)
			if(effectTarget != null)
			{
			//	effectTarget.GetComponent<ParticleSystem>().Stop();	
			//	effectTarget.GetComponent<ParticleSystem>().Play();	
				playeffect = false;
			}
				float step = speed*Time.deltaTime; 	
				effectTarget.position = Vector3.MoveTowards (effectTarget.position, nextTarget.position, step); 
						if (Vector3.Distance (nextTarget.position, effectTarget.position) <= 0.01f) {
								if (childNum <= child.Length - 1) {
										childNum += 1;
									 	if (childNum <= child.Length - 1)
										nextTarget = child [childNum];	
				}
						if(loop)
						if (childNum > child.Length - 1) {
							childNum = 0;
							nextTarget = child [childNum];	
						}
						}
				}
		if (playLineEffect) {//reset.
			if (child [0]) {
				childNum = 0;
				nextTarget = child [0];
			 	effectTarget.position = child [0].position;	
				temDelayTime = Time.time;
				if(effectTarget.position == child [0].position)
				{playLineEffect = false;
					playeffect = true;}
			}
		}
		}//end update




}
