using UnityEngine;
using System.Collections;

public class UISceneCityCtrl : UISceneBase {

	protected override void OnAwake ()
	{
		base.OnAwake ();

	}

	protected override void OnStart ()
	{
		base.OnStart ();
		StartCoroutine(OpenWindow());
	}
	/// <summary>
	///
	/// </summary>
	/// <returns>The window.</returns>
	IEnumerator OpenWindow(){
		yield return new WaitForSeconds (0.5f);
//		WindowUIMgr.Instance.OpenWindowUI (WindowUIType.Login);
	}

	void Update(){

	}

	protected override void OnBtnClic (GameObject gob)
	{
		base.OnBtnClic (gob);
		Debug.Log (gob.name);
		switch (gob.name) {
		case "headBtn"://头像按钮
			OpenRoleInfoWindow();
			break;
		default:
			break;
		}
	}

	void OpenRoleInfoWindow(){
		WindowUIMgr.Instance.OpenWindowUI (WindowUIType.RoleInfo);
	}

}
