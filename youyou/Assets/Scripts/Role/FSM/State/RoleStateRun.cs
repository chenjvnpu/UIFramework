using UnityEngine;
using System.Collections;
/// <summary>
///跑步状态 Role state run.
/// </summary>
public class RoleStateRun : RoleStateAbstract {
	/// <summary>
	///转身的速度 The m rotation speed.
	/// </summary>
	private float mRotationSpeed=0.2f;
	/// <summary>
	/// 转身的目标方向The m target quaternion.
	/// </summary>
	private Quaternion mTargetQuaternion;

	public RoleStateRun(RoleFSMMgr roleFsm):base (roleFsm){

	}

	public override void OnEnter ()
	{
		base.OnEnter ();
		mRotationSpeed = 0;
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
		}else this.CurRoleFsmMgr.CurRoleCtrl.anim.SetInteger (ToAnimCondition.CurState.ToString(),0);

		//移动

		if (Vector3.Distance (CurRoleFsmMgr.CurRoleCtrl.TargetPos, CurRoleFsmMgr.CurRoleCtrl.transform.position) >1f) {
			Vector3 direction = CurRoleFsmMgr.CurRoleCtrl.TargetPos - CurRoleFsmMgr.CurRoleCtrl.transform.position;
			direction = direction.normalized;//角色移动方向归一化
			direction = direction * Time.deltaTime * CurRoleFsmMgr.CurRoleCtrl.moveSpeed;//控制角色移动速度
			direction.y = 0;
			//控制角色缓慢转身
			if (mRotationSpeed < 1) {
				mRotationSpeed += 10f * Time.deltaTime;
				mTargetQuaternion = Quaternion.LookRotation (direction);
				CurRoleFsmMgr.CurRoleCtrl.transform.rotation = Quaternion.Slerp (CurRoleFsmMgr.CurRoleCtrl.transform.rotation, mTargetQuaternion, mRotationSpeed);
				if(Quaternion.Angle(CurRoleFsmMgr.CurRoleCtrl.transform.rotation, mTargetQuaternion)<1){//点击点在主角的后面
					mRotationSpeed = 0;
				}
			}

			CurRoleFsmMgr.CurRoleCtrl.characterControl.Move (direction);
		} else {
			CurRoleFsmMgr.ChangeState (RoleState.Idle);
		}
	}
}
