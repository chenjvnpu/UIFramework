using UnityEngine;
using System.Collections;
/// <summary>
///休闲状态 Role state idle.
/// </summary>
public class RoleStateIdle : RoleStateAbstract {


	public RoleStateIdle(RoleFSMMgr roleFsm):base (roleFsm){

	}

	public override void OnEnter ()
	{
		base.OnEnter ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToIdleNormal.ToString(), true);

	}

	public override void OnLeave ()
	{
		base.OnLeave ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToIdleNormal.ToString(), false);
	}

	public override void OnUpdate ()
	{
		base.OnUpdate ();
		CurRoleAnimInfo = this.CurRoleFsmMgr.CurRoleCtrl.anim.GetCurrentAnimatorStateInfo (0);
		if(CurRoleAnimInfo.IsName(RoleAnimClipNmme.Idle_Normal.ToString())){
			this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.CurState.ToString(),(int)RoleState.Idle);
		}
	}
}
