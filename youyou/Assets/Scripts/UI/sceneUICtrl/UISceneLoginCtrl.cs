using UnityEngine;
using System.Collections;

public class UISceneLoginCtrl : UISceneBase {


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
	/// 当初始化结束后，显示登录窗口，需要延时加载.
	/// </summary>
	/// <returns>The window.</returns>
	IEnumerator OpenWindow(){
		yield return new WaitForSeconds (0.5f);
		WindowUIMgr.Instance.OpenWindowUI (WindowUIType.Login);
	}

	void Update(){
//		if(Input.GetKeyUp(KeyCode.O)){
//			WindowUIMgr.Instance.OpenWindowUI (WindowUIType.Login);
//		}else if(Input.GetKeyUp(KeyCode.D)){
//			WindowUIMgr.Instance.CloseWindow (WindowUIType.Login);
//		}
	}
	

}
