using UnityEngine;
using System.Collections;
/// <summary>
///跑步状态 Role state run.
/// </summary>
public class RoleStateRun : RoleStateAbstract {


	public RoleStateRun(RoleFSMMgr roleFsm):base (roleFsm){

	}

	public override void OnEnter ()
	{
		base.OnEnter ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToRun.ToString(), true);

	}

	public override void OnLeave ()
	{
		base.OnLeave ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToRun.ToString(), false);
	}

	public override void OnUpdate ()
	{
		base.OnUpdate ();
		CurRoleAnimInfo = this.CurRoleFsmMgr.CurRoleCtrl.anim.GetCurrentAnimatorStateInfo (0);
		if(CurRoleAnimInfo.IsName(RoleAnimClipNmme.Run.ToString())){
			this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.CurState.ToString(),(int)RoleState.Run);
		}
	}
}
