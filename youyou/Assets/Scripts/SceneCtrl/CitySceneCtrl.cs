using UnityEngine;
using System.Collections;

public class CitySceneCtrl : SceneCtrlBase {
	GameObject gob=null;

	protected override void OnAwake ()
	{
		base.OnAwake ();
		SceneUIMgr.Instance.LoadSceneUI (SceneUIType.MainCity);
	}
	protected override void OnStart ()
	{
		base.OnStart ();
	}
//	void Awake(){
//		SceneUIMgr.Instance.LoadSceneUI (SceneUIType.MainCity);
//	}
	// Use this for initialization
//	void Start () {
//
//	}

	// Update is called once per frame
//	void Update () {
//		if(Input.GetKeyUp(KeyCode.D)){
//			Destroy (gob);
//		}else if(Input.GetKeyUp(KeyCode.L)){
//			gob=ResourceMgr.Instance.LoadAndInstanite(ResouceType.UIScene, "UIRoot_login",putInCache:true);
//		}

//	}
}
