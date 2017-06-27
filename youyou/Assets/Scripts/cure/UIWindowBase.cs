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

}
