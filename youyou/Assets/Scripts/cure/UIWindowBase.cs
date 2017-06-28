using UnityEngine;
using System.Collections;

public class UIWindowBase : UIBase {
	
	[SerializeField]
	public WindowUIContainerType containerType=WindowUIContainerType.Center;

	[SerializeField]
	public WindowShowStyle showStyle=WindowShowStyle.Normal;

	/// <summary>
	/// 动画时间.
	/// </summary>
	public float durition=0.2f;
	[HideInInspector]
	public WindowUIType currentWindowType;
	/// <summary>
	/// 下一个打开的窗口.
	/// </summary>
	protected WindowUIType nextOpenWindowType=WindowUIType.None;

	protected virtual void  Close(){
		WindowUIMgr.Instance.CloseWindow(currentWindowType);
	}

	protected override void BeforeDestroy ()
	{
		base.BeforeDestroy ();
		if (nextOpenWindowType == WindowUIType.None) {
			return;
		} else {
			WindowUIMgr.Instance.OpenWindowUI (nextOpenWindowType);
		}
	}
}
