using UnityEngine;
using System.Collections;
/// <summary>
///攻击状态 Role state attack.
/// </summary>
public class RoleStateAttack : RoleStateAbstract {
	
	public RoleStateAttack(RoleFSMMgr roleFsm):base (roleFsm){
	
	}

	public override void OnEnter ()
	{
		base.OnEnter ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToAttack.ToString(), true);
//		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.ToSkile.ToString(), 1);
		if(CurRoleFsmMgr.CurRoleCtrl.lockEnemy!=null){
			this.CurRoleFsmMgr.CurRoleCtrl.transform.LookAt(new Vector3(CurRoleFsmMgr.CurRoleCtrl.lockEnemy.transform.position.x,CurRoleFsmMgr.CurRoleCtrl.transform.position.y,CurRoleFsmMgr.CurRoleCtrl.lockEnemy.transform.position.z));
		}


	}

	public override void OnLeave ()
	{
		base.OnLeave ();
		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetBool (ToAnimCondition.ToAttack.ToString(), false);
//		this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.ToSkile.ToString(), 0);
	}

	public override void OnUpdate ()
	{
		base.OnUpdate ();
		CurRoleAnimInfo = this.CurRoleFsmMgr.CurRoleCtrl.anim.GetCurrentAnimatorStateInfo (0);
		if(CurRoleAnimInfo.IsName(RoleAnimClipNmme.PhyAttack1.ToString())){
			this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.CurState.ToString(),(int)RoleState.Attack);
			if(CurRoleAnimInfo.normalizedTime >1){//已经执行过一次动画，返回到idle状态
//				CurRoleFsmMgr.ChangeState(RoleState.Idle);
				CurRoleFsmMgr.CurRoleCtrl.ToIdle();
			}
		}else this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.CurState.ToString(),0);//????????????????
	}
}
