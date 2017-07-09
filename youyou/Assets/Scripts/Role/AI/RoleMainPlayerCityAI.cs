using UnityEngine;
using System.Collections;
/// <summary>
///主角主城AI Role main player city A.
/// </summary>
public class RoleMainPlayerCityAI : IRoleAI {



	#region IRoleAI1 implementation

	public RoleCtrl currentRole {
		get;
		set;
	}

	public void DoAI ()
	{
		//如果存在攻击敌人 就进行攻击
		if(currentRole.lockEnemy!=null ){
			if(currentRole.lockEnemy.currentRoleInfo.CurHp<=0){
				currentRole.lockEnemy = null;
			}
			if( currentRole.currentRoleFsmMgr.CurRoleStateType!=RoleState.Attack){
				currentRole.ToAttack ();
			}

		}
	}

	#endregion

	public RoleMainPlayerCityAI (RoleCtrl roleCtrl){
		currentRole = roleCtrl;
	}
	

}
