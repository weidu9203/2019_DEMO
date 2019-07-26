using UnityEngine;
using System.Collections;

/*created by Jason 20160824
 * 浮生若梦出品
 * 作者公众号“特效基地”
 * 作者QQ:541211225
 * Mobile:15821684699
 * v1.3
*/
public class JasonTransform : MonoBehaviour {
	
	[UnityEngine.Header("v1.3")]
	public float delay = 0f;
	public float life  = 0f;


	public enum transType{Transform,sinTransform,randomTransform}
	public transType transformType;

	[UnityEngine.Header("Transform")]
	public Vector3 moveSpeed = new Vector3(0,0,0);
	public Vector3 rotateSpeed = new Vector3(0,0,0);
	public Vector3 scaleSpeed = new Vector3(0,0,0);

	[UnityEngine.Header("Sin Transform")]
	public Vector3 sinRange = new Vector3 (0,0,0);
	public float sinFrequency = 5.0f;

	[UnityEngine.Header("Random Transform")]
	public Vector3 randomRange = new Vector3 (0,0,0);
	public float randomFrequency = 1.0f;

	private Transform myTransform;
	private float tempTimer;
	// Use this for initialization
	void Start () {
		
		myTransform = this.transform;
		tempTimer = 1/randomFrequency;

		if(delay > 0){
			this.gameObject.SetActive (false);
			Invoke ("JasonCreate",delay);
		}

		if(life > 0){
			Invoke ("JasonDelete",life);
		}

	}

	// Update is called once per frame
	void Update () {

		if (transformType == transType.Transform) {
			if (moveSpeed != Vector3.zero) {
				//sinRange = Vector3.zero;
				//randomRange = Vector3.zero;

				myTransform.Translate (moveSpeed * Time.deltaTime, Space.Self);
				return;
			} 
			if (rotateSpeed != Vector3.zero)
				myTransform.Rotate (rotateSpeed * Time.deltaTime, Space.Self);
			if (scaleSpeed != Vector3.zero)
				myTransform.localScale += scaleSpeed; 

			return;



		} else if (transformType == transType.sinTransform) {
			float xSin = Mathf.Sin (Time.time * sinFrequency) * sinRange.x;
			float ySin = Mathf.Sin (Time.time * sinFrequency) * sinRange.y;
			float zSin = Mathf.Sin (Time.time * sinFrequency) * sinRange.z;

			if (sinRange != Vector3.zero) {
				//randomRange = Vector3.zero;
				//moveSpeed = Vector3.zero;

				myTransform.localPosition = new Vector3 (xSin, ySin, zSin);
				return;
			}
			return;


		} else if (transformType == transType.randomTransform) {
		
			float myRangex = Random.Range (-randomRange.x, randomRange.x);
			float myRangey = Random.Range (-randomRange.y, randomRange.y);
			float myRangez = Random.Range (-randomRange.z, randomRange.z);

			tempTimer -= Time.deltaTime;
			if(randomRange != Vector3.zero){
				if(tempTimer <= 0){
					//sinRange = Vector3.zero;
					//moveSpeed = Vector3.zero;

					myTransform.localPosition = new Vector3(myRangex,myRangey,myRangez);
					tempTimer = 1/randomFrequency;
					return;
				}
				return;
			} 
			return;
		}
			
	}

	void JasonCreate (){
		this.gameObject.SetActive (true);
	}
	void JasonDelete (){
		Destroy (this.gameObject);
	}

}