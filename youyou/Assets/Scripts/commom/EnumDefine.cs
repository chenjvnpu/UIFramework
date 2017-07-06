using UnityEngine;
using System.Collections;
public enum SceneType{
	Loding,
	Login,
	City
}

/// <summary>
/// 场景类型.
/// </summary>
public enum SceneUIType{
	/// <summary>
	/// 空的.
	/// </summary>
	None,
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
	/// 空.
	/// </summary>
	None,
	/// <summary>
	/// 登录窗口.
	/// </summary>
	Login,
	/// <summary>
	/// 注册窗口.
	/// </summary>
	Register,
	SelectServer,
	/// <summary>
	/// 角色信息窗口.
	/// </summary>
	RoleInfo

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

/// <summary>
/// 资源类型
/// </summary>
public enum ResouceType
{
	/// <summary>
	/// 场景UI
	/// </summary>
	UIScene,
	/// <summary>
	/// 窗口UI
	/// </summary>
	UIWindow,
	/// <summary>
	/// 角色
	/// </summary>
	Role,
	/// <summary>
	/// 特效
	/// </summary>
	Effect,

	UIOther
}

/// <summary>
/// 角色类型 Role type.
/// </summary>
public enum RoleType{
	None=0,//未设置
	MainPlayer=1,
	Monster=2,


}
/// <summary>
///角色状态 Role state.
/// </summary>
public enum RoleState{
	None=0,//未设置
	Idle=1,
	Run=2,
	Attack=3,
	Hurt=4,
	Die=5

}

/// <summary>
///动画状态机 动画片段名称 Role animation clip nmme.
/// </summary>
public enum RoleAnimClipNmme{
	Idle_Normal,
	Idle_Fight,
	Run,
	Hurt,
	Die,
	PhyAttack1,
	Skill4,
	Skill5,
	Skill6,



}
/// <summary>
///动画跳转的条件，参数名称 To animation condition.
/// </summary>
public enum ToAnimCondition{
	ToIdleNormal,
	ToIdleFight,
	ToRun,
	ToHurt,
	ToDie,
	ToAttack,
	ToSkile,
	CurState
}