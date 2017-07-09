using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {
	private Vector3 offset = Vector3.zero;
	private Transform flowTarget;
	public static CameraCtrl Instance;
	 
	void Awake(){
		Instance = this;
	}

	public void Init(Transform target){
		this.flowTarget = target;
		offset = flowTarget.position - transform.position;
	}
	// Use this for initialization
	 void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(flowTarget)
			transform.position = flowTarget.position - offset;	
	}
}
