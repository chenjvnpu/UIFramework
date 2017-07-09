using UnityEngine;
using System.Collections;
/// <summary>
///怪物AI Role monster A.
/// </summary>
public class RoleMonsterAI : IRoleAI {
	/// <summary>
	///下次巡逻时间 The nex patrol time.
	/// </summary>
	private float nexPatrolTime=1;
	/// <summary>
	/// The next attack time.
	/// </summary>
	private float nextAttackTime = 0;
	#region IRoleAI1 implementation

	public RoleCtrl currentRole {
		get ;
		set ;
	}


	public void DoAI ()
	{
		if (currentRole.currentRoleFsmMgr.CurRoleStateType == RoleState.Die)
			return;
		if (currentRole.lockEnemy == null) {
			
			//若果是待机状态，进行巡逻
			if(currentRole.currentRoleFsmMgr.CurRoleStateType==RoleState.Idle){
				//设置巡逻范围
				if(Time.time>nexPatrolTime){
					nexPatrolTime = Time.time + Random.Range(3,6);
					currentRole.MoveTo (new Vector3(currentRole.BornPoint.x+Random.Range(currentRole.patrolRange*-1,currentRole.patrolRange),currentRole.BornPoint.y,currentRole.BornPoint.z+Random.Range(currentRole.patrolRange*-1,currentRole.patrolRange)));

				}
			}
			//搜索附近是否存在锁定对象
//			Collider[] colliders=Physics.OverlapSphere(currentRole.transform.position,currentRole.viewRange,1);
			if(Vector3.Distance(currentRole.transform.position,GlobalInit.Instance.curRoleCtrl.transform.position)<currentRole.viewRange){
				currentRole.lockEnemy = GlobalInit.Instance.curRoleCtrl;
			}
		} else {
			if(currentRole.lockEnemy.currentRoleInfo.CurHp<=0){
				currentRole.lockEnemy = null;
			}
			//have lock enemy
			//1判读当前对象与锁定对象的距离大于锁定范围，取消锁定  

			if(Vector3.Distance(currentRole.transform.position,GlobalInit.Instance.curRoleCtrl.transform.position)>currentRole.viewRange){
				currentRole.lockEnemy =null;
				return;
			} 
			//2如果在攻击范围之内，进行攻击
			if (Vector3.Distance (currentRole.transform.position, GlobalInit.Instance.curRoleCtrl.transform.position) < currentRole.attackRange) {
				if (Time.time > nextAttackTime && currentRole.currentRoleFsmMgr.CurRoleStateType!=RoleState.Attack) {
					currentRole.ToAttack ();
					nextAttackTime = Time.time + Random.Range (3, 5);
				}
			} else {
				//3如果在锁定范围之内，进行追击
				//			currentRole.MoveTo (GlobalInit.Instance.curRoleCtrl.transform.position);
				if( currentRole.currentRoleFsmMgr.CurRoleStateType==RoleState.Idle){
					Vector3 targetPos=GlobalInit.Instance.curRoleCtrl.transform.position;
					currentRole.MoveTo (new Vector3(targetPos.x+Random.Range(-0.5f,0.5f),targetPos.y,targetPos.z+Random.Range(-0.5f,0.5f)));
				}

						
			}

		}

	}
	#endregion

	public RoleMonsterAI (RoleCtrl roleCtrl){
		currentRole = roleCtrl;
	}
}
