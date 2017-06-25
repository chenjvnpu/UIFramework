﻿using UnityEngine;
using System.Collections;
/// <summary>
/// 场景类型.
/// </summary>
public enum SceneUIType{
	/// <summary>
	/// 登录场景.
	/// </summary>
	Login,
	Loading,
	MainCity
}
/// <summary>
/// 场景UI管理器.
/// </summary>
public class SceneUIMgr : Singleton<SceneUIMgr> {

	public GameObject LoadSceneUI(SceneUIType type){
		GameObject gob=null;
		switch (type) {
		case SceneUIType.Login:
			gob=ResourceMgr.Instance.LoadAndInstanite(ResouceType.UIScene, "UIRoot_login");
			break;
		case SceneUIType.Loading:
			break;
		case SceneUIType.MainCity:
			break;
		default:
			break;
		}
		return gob;
	}
}