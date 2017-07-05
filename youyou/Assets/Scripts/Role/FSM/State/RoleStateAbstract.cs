using UnityEngine;
using System.Collections;
/// <summary>
///角色状态的抽象基类 Role state abstract.
/// </summary>
public abstract class RoleStateAbstract  {
	/// <summary>
	///当前角色动画状态信息 The current role animation info.
	/// </summary>
	public AnimatorStateInfo CurRoleAnimInfo{get;set;}
	/// <summary>
	///当前角色的有限状态机管理器 Sets the current role fsm mgr.
	/// </summary>
	/// <value>The current role fsm mgr.</value>
	public RoleFSMMgr CurRoleFsmMgr{ get;private set;}

//	public RoleStateAbstract (){
//		
//	}
	public RoleStateAbstract(RoleFSMMgr rolefsm){
		CurRoleFsmMgr = rolefsm;
	}
	/// <summary>
	///进入状态 Raises the enter event.
	/// </summary>
	public virtual void OnEnter(){
	}

	/// <summary>
	///执行状态 Raises the update event.
	/// </summary>
	public virtual void OnUpdate(){}
	/// <summary>
	///离开状态 Raises the leave event.
	/// </summary>
	public virtual void OnLeave(){
	}
}
