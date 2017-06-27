using UnityEngine;
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

public enum WindowShowStyle{
	Normal,
	CenterToBig,
	/// <summary>
	///从上向下.
	/// </summary>
	FromTop,
	FromDown,
	/// <summary>
	///从左向右.
	/// </summary>
	FromLeft,
	FromRight
}