using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{
	[SerializeField]
	private Transform cameraRotate;
	[SerializeField]
	private Transform cameraUpdown;
	[SerializeField]
	private Transform cameraZoom;

	private Transform flowTarget;
	public static CameraCtrl Instance;

	void Awake ()
	{
		Instance = this;
	}

	public void Init (Transform target)
	{
		this.flowTarget = target;
		cameraRotate.position = new Vector3 (target.position.x, cameraRotate.position.y, target.position.z);
	}
	// Use this for initialization
	void Start ()
	{
		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flowTarget)
			cameraRotate.position = new Vector3 (flowTarget.position.x, cameraRotate.position.y, flowTarget.position.z);
		if (Input.GetKey (KeyCode.L)) {
			RotateLeftCamera ();
		} else if (Input.GetKey (KeyCode.R)) {
			RotateRigntCamera ();
		} else if (Input.GetKey (KeyCode.U)) {
			UpCamera ();
		} else if (Input.GetKey (KeyCode.D)) {
			DownCamera ();
		}else if (Input.GetKey (KeyCode.I)) {
			ZoomIn ();
		}else if (Input.GetKey (KeyCode.O)) {
			ZoomOn ();
		}
	}

	public void RotateLeftCamera ()
	{
		cameraRotate.Rotate (new Vector3 (0, 1, 0));
	}

	public void RotateRigntCamera ()
	{
		cameraRotate.Rotate (new Vector3 (0, -1, 0));
	}

	public void UpCamera(){
		cameraUpdown.Rotate (new Vector3(1,0,0));
	}
	public void DownCamera(){
		cameraUpdown.Rotate (new Vector3(-1,0,0));
	}

	public void ZoomIn(){
		cameraZoom.localPosition += new Vector3(0,0,0.1f);
	}
	public void ZoomOn(){
		cameraZoom.localPosition -= new Vector3(0,0,0.1f);
	}
}
