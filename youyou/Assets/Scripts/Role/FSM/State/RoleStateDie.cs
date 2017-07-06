﻿using UnityEngine;
using System.Collections;
/// <summary>
///死亡状态 Role state die.
/// </summary>
public class RoleStateDie : RoleStateAbstract {


	public RoleStateDie(RoleFSMMgr roleFsm):base (roleFsm){

	}

	public override void OnEnter ()
	{
		base.OnEnter ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToDie.ToString(), true);

	}

	public override void OnLeave ()
	{
		base.OnLeave ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToDie.ToString(), false);
	}

	public override void OnUpdate ()
	{
		base.OnUpdate ();
		CurRoleAnimInfo = this.CurRoleFsmMgr.CurRoleCtrl.anim.GetCurrentAnimatorStateInfo (0);
		if(CurRoleAnimInfo.IsName(RoleAnimClipNmme.Die.ToString())){
			this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.CurState.ToString(),(int)RoleState.Die);
		}
	}
}