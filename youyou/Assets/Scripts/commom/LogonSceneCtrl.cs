using UnityEngine;
using System.Collections;

public class LogonSceneCtrl : MonoBehaviour {
	GameObject gob=null;
	void Awake(){
		SceneUIMgr.Instance.LoadSceneUI (SceneUIType.Login);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.D)){
			Destroy (gob);
		}else if(Input.GetKeyUp(KeyCode.L)){
			gob=ResourceMgr.Instance.LoadAndInstanite(ResouceType.UIScene, "UIRoot_login",putInCache:true);
		}
	
	}
}
