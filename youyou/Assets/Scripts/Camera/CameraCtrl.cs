using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {
	private Vector3 offset = Vector3.zero;
	public Transform flowTarget;
	 
	// Use this for initialization
	void Start () {
		offset = flowTarget.position - transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = flowTarget.position - transform.position;	
	}
}
