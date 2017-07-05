using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///角色有限状态机管理器  Role FSM mgr.
/// </summary>
public class RoleFSMMgr  {
	/// <summary>
	///当前角儿控制器 Gets the current role ctrl.
	/// </summary>
	/// <value>The current role ctrl.</value>
	public RoleCtrl CurRoleCtrl{ get; private set;}

	/// <summary>
	///当前角色的状态枚举 The state of the current role.
	/// </summary>
	private RoleState curRoleStateType = RoleState.None;
	/// <summary>
	///当前角色状态 The state of the current role.
	/// </summary>
	private RoleStateAbstract curRoleState;

	private Dictionary<RoleState,RoleStateAbstract> roleStateDic;
	/// <summary>
	///构造函数中，进行状态初始化 
	/// </summary>
	/// <param name="roleCtrl">Role ctrl.</param>
	public RoleFSMMgr(RoleCtrl roleCtrl){
		this.CurRoleCtrl = roleCtrl;
		roleStateDic=new Dictionary<RoleState, RoleStateAbstract>();
		roleStateDic [RoleState.Idle] = new RoleStateIdle (this);
		roleStateDic [RoleState.Run] = new RoleStateRun (this);
		roleStateDic [RoleState.Attack] = new RoleStateAttack (this);
		roleStateDic [RoleState.Hurt] = new RoleStateHurt (this);
		roleStateDic [RoleState.Die] = new RoleStateDie (this);
		if (roleStateDic.ContainsKey (curRoleStateType)) {
			curRoleState = roleStateDic [curRoleStateType];
		}
	}

	public RoleState CurRoleStateType {
		get {
			return curRoleStateType;
		}
		set {
			curRoleStateType = value;
		}
	}

	public RoleStateAbstract CurRoleState {
		get {
			return curRoleState;
		}
		set {
			curRoleState = value;
		}
	}

	/// <summary>
	///每帧执行 更新状态 Raises the update event.
	/// </summary>
	public void OnUpdate(){
		if(curRoleState!=null){
			curRoleState.OnUpdate ();
		}
	}

	/// <summary>
	///切换状态 Changes the state.
	/// </summary>
	public void ChangeState(RoleState newState){
		if(curRoleStateType==newState){return;}//需要切换的状态和当前状态相同

		if(curRoleState!=null){
			curRoleState.OnLeave ();
		}
		//更改当前状态类型
		curRoleStateType = newState;
		//更改当前状态
		curRoleState=roleStateDic[curRoleStateType];
		curRoleState.OnEnter ();
	}
}
