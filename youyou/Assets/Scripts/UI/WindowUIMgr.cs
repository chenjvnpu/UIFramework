using UnityEngine;
using System.Collections;

/// <summary>
/// 窗口UI管理器.
/// </summary>
public class WindowUIMgr:Singleton<WindowUIMgr> {

	/// <summary>
	/// 加载窗口UI.
	/// </summary>
	/// <returns>The window U.</returns>
	/// <param name="type">Type.</param>
	/// <param name="containerType">窗口挂点位置.</param>
	public GameObject OpenWindowUI(WindowUIType type){
		GameObject gob=null;
		string prefabName = string.Empty;
		switch (type) {
		case WindowUIType.Login:
			prefabName = "panel_login";
			break;
		case WindowUIType.Register:
			prefabName = "panel_reg";
			break;
		default:
			break;
		}

		gob = ResourceMgr.Instance.LoadAndInstanite (ResouceType.UIWindow, prefabName, putInCache: true);

		UIWindowBase windowBase = gob.GetComponent<UIWindowBase> ();
//		WindowUIContainerType containerType = windowBase.containerType;
//		WindowShowStyle style = windowBase.showStyle;
		Transform transParent=null;
		switch (windowBase.containerType) {
		case WindowUIContainerType.Center:
			transParent =SceneUIMgr.Instance.currentScene.GetCenterTransform();
			break;
		case WindowUIContainerType.TopLeft:
			break;
		case WindowUIContainerType.TopRight:
			break;
		case WindowUIContainerType.BotomoLeft:
			break;
		case WindowUIContainerType.BotomRight:
			break;

		default:
			break;
		}
		if(transParent){
			gob.transform.parent = transParent;
			gob.transform.localPosition = Vector3.zero;
			gob.transform.localScale = Vector3.one;
			NGUITools.SetActive (gob,false);
			StartShowWindow (gob,windowBase.showStyle,true);
		}


		return gob;
	}
	/// <summary>
	/// 更改窗口显示状态.
	/// </summary>
	/// <param name="gob">窗口对象.</param>
	/// <param name="showStyle">打开方式.</param>
	/// <param name="isOpen">true:打开窗口，false：关闭窗口.</param>
	private void StartShowWindow(GameObject gob,WindowShowStyle showStyle,bool isOpen){
		switch (showStyle) {
		case WindowShowStyle.Normal:
			ShowNormalWindow (gob, isOpen);
			break;
		case WindowShowStyle.CenterToBig:
			ShowCenterToBigWindow (gob, isOpen);
			break;
		case WindowShowStyle.FromTop:
			break;
		case WindowShowStyle.FromDown:
			break;
		case WindowShowStyle.FromLeft:
			break;
		case WindowShowStyle.FromRight:
			break;
		default:
			break;
		}
	}
	/// <summary>
	/// Destroies the window.
	/// </summary>
	/// <param name="window">Window.</param>
	void DestroyWindow(GameObject window){
		GameObject.Destroy (window);
	}
	/// <summary>
	/// Shows the normal window.
	/// </summary>
	/// <param name="gob">Gob.</param>
	/// <param name="isOpen">If set to <c>true</c> is open.</param>
	void ShowNormalWindow(GameObject gob,bool isOpen){
		if(isOpen){//打开窗口
			NGUITools.SetActive(gob,true);
		}else{
			DestroyWindow(gob);
		}
	}
	/// <summary>
	/// Shows the center to big window.
	/// </summary>
	void ShowCenterToBigWindow(GameObject gob,bool isOpen){
		TweenScale ts = GameobjectUtil.GetOrCreateComponent<TweenScale> (gob);
	
		ts.from = Vector3.zero;
		ts.to = Vector3.one;
		ts.duration = 3f;
		ts.SetOnFinished (()=>{
			
			if (!isOpen) {
				DestroyWindow(gob);
			} 
		});
		NGUITools.SetActive(gob,true);
		if (isOpen) {
			ts.PlayForward ();
		} else
			ts.PlayReverse ();
	}
}
