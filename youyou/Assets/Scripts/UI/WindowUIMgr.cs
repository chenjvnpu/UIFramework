using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 窗口UI管理器.
/// </summary>
public class WindowUIMgr:Singleton<WindowUIMgr> {
	private Dictionary<WindowUIType,UIWindowBase> windowDic = new Dictionary<WindowUIType, UIWindowBase> ();

	/// <summary>
	/// 打开窗口的数量.
	/// </summary>
	/// <value>The open window count.</value>
	public int OpenWindowCount{
		get{
			return windowDic.Count;
		}
	}

	#region MyRegion打开或者关闭窗口

	/// <summary>
	/// 加载窗口UI.
	/// </summary>
	/// <returns>The window U.</returns>
	/// <param name="type">Type.</param>
	/// <param name="containerType">窗口挂点位置.</param>
	public GameObject OpenWindowUI (WindowUIType type,bool setToTop=true)
	{
		

		if (type == WindowUIType.None)
			return null;
		GameObject gob = null;
		if (windowDic.ContainsKey (type)) {
			gob = windowDic [type].gameObject;	
		} else {
			string prefabName = string.Empty;
			switch (type) {
			case WindowUIType.Login:
				prefabName = "panel_login";
				break;
			case WindowUIType.Register:
				prefabName = "panel_reg";
				break;
			case WindowUIType.RoleInfo:
				prefabName = "panel_RoleInfo";
				break;
			default:
				break;
			}

			gob = ResourceMgr.Instance.LoadAndInstanite (ResouceType.UIWindow, prefabName, putInCache: true);

			UIWindowBase windowBase = gob.GetComponent<UIWindowBase> ();
			if (windowBase == null)
				return null;
			windowBase.currentWindowType = type;
			windowDic.Add (type, windowBase);
			//		WindowUIContainerType containerType = windowBase.containerType;
			//		WindowShowStyle style = windowBase.showStyle;
			Transform transParent = null;
			switch (windowBase.containerType) {
			case WindowUIContainerType.Center:
				transParent = SceneUIMgr.Instance.currentScene.GetCenterTransform ();
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
			if (transParent) {
				gob.transform.parent = transParent;
				gob.transform.localPosition = Vector3.zero;
				gob.transform.localScale = Vector3.one;
				NGUITools.SetActive (gob, false);
				StartShowWindow ( windowBase, true);
			}
		}

		if (setToTop)
			LayerUIMgr.Instance.SetToTopLayer (gob);

		return gob;
	}

	/// <summary>
	/// 关闭窗口.
	/// </summary>
	/// <param name="type">Type.</param>
	public void CloseWindow (WindowUIType type)
	{
		if (windowDic.ContainsKey (type)) {
			StartShowWindow (windowDic [type], false);
		}
	}

	#endregion


	/// <summary>
	/// 更改窗口显示状态.
	/// </summary>
	/// <param name="gob">窗口对象.</param>
	/// <param name="showStyle">打开方式.</param>
	/// <param name="isOpen">true:打开窗口，false：关闭窗口.</param>
	private void StartShowWindow(UIWindowBase window,bool isOpen){
		switch (window.showStyle) {
		case WindowShowStyle.Normal:
			ShowNormalWindow (window, isOpen);
			break;
		case WindowShowStyle.CenterToBig:
			ShowCenterToBigWindow (window, isOpen);
			break;
		case WindowShowStyle.FromTop:
			ShowFromDir (window, isOpen, 0);
			break;
		case WindowShowStyle.FromDown:
			ShowFromDir (window, isOpen, 1);
			break;
		case WindowShowStyle.FromLeft:
			ShowFromDir (window, isOpen, 2);
			break;
		case WindowShowStyle.FromRight:
			ShowFromDir (window, isOpen, 3);
			break;
		default:
			break;
		}
	}
	/// <summary>
	/// Destroies the window.
	/// </summary>
	/// <param name="window">Window.</param>
	void DestroyWindow(UIWindowBase window){
		
		if(windowDic.ContainsKey(window.currentWindowType)){
			windowDic.Remove (window.currentWindowType);
		}
		GameObject.Destroy (window.gameObject);
	}
	/// <summary>
	/// Shows the normal window.
	/// </summary>
	/// <param name="gob">Gob.</param>
	/// <param name="isOpen">If set to <c>true</c> is open.</param>
	void ShowNormalWindow(UIWindowBase window,bool isOpen){
		if(isOpen){//打开窗口
			NGUITools.SetActive(window.gameObject,true);
		}else{
			DestroyWindow(window);
		}
	}
	/// <summary>
	/// Shows the center to big window.
	/// </summary>
	void ShowCenterToBigWindow(UIWindowBase window,bool isOpen){
		GameObject gob = window.gameObject;
		TweenScale ts = GameobjectUtil.GetOrCreateComponent<TweenScale> (gob);
		ts.animationCurve = GlobalInit.Instance.UIAnimationCurve;//设置动画曲线
		ts.from = Vector3.zero;
		ts.to = Vector3.one;
		ts.duration = window.durition;
		ts.SetOnFinished (()=>{
			
			if (!isOpen) {
				DestroyWindow(window);
			} 
		});
		NGUITools.SetActive(gob,true);
		if (isOpen) {
			ts.PlayForward ();
		} else
			ts.PlayReverse ();
	}
	/// <summary>
	/// 从不同的方向加载.
	/// </summary>
	/// <param name="window">Window.</param>
	/// <param name="isOpen">If set to <c>true</c> is open.</param>
	/// <param name="dir">Dir.0：从上，1：从下，2：从左，3：从右</param>
	void ShowFromDir(UIWindowBase window,bool isOpen,int dir){
		GameObject gob = window.gameObject;
		TweenPosition ts = GameobjectUtil.GetOrCreateComponent<TweenPosition> (gob);
		Vector3 from = Vector3.zero;
		switch (dir) {
		case 0:
			from = new Vector3 (0,700,0);
			break;
		case 1:
			from = new Vector3 (0,-700,0);
			break;
		case 2:
			from = new Vector3 (-1200,0,0);
			break;
		case 3:
			from = new Vector3 (1200,0,0);
			break;
		default:
			break;
		}
		ts.animationCurve = GlobalInit.Instance.UIAnimationCurve;//设置动画曲线
		ts.from = from;
		ts.to = Vector3.one;
		ts.duration = window.durition;
		ts.SetOnFinished (()=>{

			if (!isOpen) {
				DestroyWindow(window);
			} 
		});
		NGUITools.SetActive(gob,true);
		if (isOpen) {
			ts.PlayForward ();
		} else
			ts.PlayReverse ();
	}
}
