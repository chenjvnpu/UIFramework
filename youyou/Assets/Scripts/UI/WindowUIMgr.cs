using UnityEngine;
using System.Collections;
/// <summary>
/// 场景类型.
/// </summary>
public enum WindowUIType{
	/// <summary>
	/// 登录窗口.
	/// </summary>
	Login,
	/// <summary>
	/// 注册窗口.
	/// </summary>
	Register,
	SelectServer

}
/// <summary>
/// 窗口挂点位置枚举.
/// </summary>
public enum WindowUIContainerType{
	TopLeft,
	TopRight,
	BotomoLeft,
	BotomRight,
	Center
}
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
	public GameObject LoadWindowUI(WindowUIType type,WindowUIContainerType containerType=WindowUIContainerType.Center){
		GameObject gob=null;
		switch (type) {
		case WindowUIType.Login:
			gob=ResourceMgr.Instance.LoadAndInstanite(ResouceType.UIWindow, "panel_login",true);
			break;
		case WindowUIType.Register:
			gob = ResourceMgr.Instance.LoadAndInstanite (ResouceType.UIWindow, "panel_reg", putInCache: true);
			break;
		default:
			break;
		}
		Transform transParent=null;
		switch (containerType) {
		case WindowUIContainerType.Center:
			transParent = UISceneLoginCtrl.Instance.GetCenterTransform();
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
		}


		return gob;
	}
}
