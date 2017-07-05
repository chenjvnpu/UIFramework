using UnityEngine;
using System.Collections;
/// <summary>
///受伤状态 Role state hurt.
/// </summary>
public class RoleStateHurt : RoleStateAbstract {

	public RoleStateHurt(RoleFSMMgr roleFsm):base (roleFsm){

	}
	public override void OnEnter ()
	{
		base.OnEnter ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToHurt.ToString(), true);

	}

	public override void OnLeave ()
	{
		base.OnLeave ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToHurt.ToString(), false);
	}

	public override void OnUpdate ()
	{
		base.OnUpdate ();
		CurRoleAnimInfo = this.CurRoleFsmMgr.CurRoleCtrl.anim.GetCurrentAnimatorStateInfo (0);
		if(CurRoleAnimInfo.IsName(RoleAnimClipNmme.Hurt.ToString())){
			this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.CurState.ToString(),(int)RoleState.Hurt);
			if(CurRoleAnimInfo.normalizedTime >1){//已经执行过一次动画，返回到idle状态
				//				CurRoleFsmMgr.ChangeState(RoleState.Idle);
				CurRoleFsmMgr.CurRoleCtrl.ToIdle();
			}
		}
	}
}
