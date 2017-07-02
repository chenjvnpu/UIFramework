using UnityEngine;
using System.Collections;

/// <summary>
/// 场景UI管理器.
/// </summary>
public class SceneUIMgr : Singleton<SceneUIMgr> {
	public UISceneBase currentScene;
	public GameObject LoadSceneUI(SceneUIType type){
		GameObject gob=null;
		switch (type) {
		case SceneUIType.Login:
			gob = ResourceMgr.Instance.LoadAndInstanite (ResouceType.UIScene, "UIRoot_login");
			currentScene = gob.GetComponent<UISceneLoginCtrl> ();
			break;
		case SceneUIType.Loading:
			break;
		case SceneUIType.MainCity:
			gob = ResourceMgr.Instance.LoadAndInstanite (ResouceType.UIScene, "UI Root_city");
			currentScene = gob.GetComponent<UISceneCityCtrl> ();
			break;
		default:
			break;
		}
		return gob;
	}
}
