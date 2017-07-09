using UnityEngine;
using System.Collections;

public class CitySceneCtrl : SceneCtrlBase {
	GameObject gob=null;
	[SerializeField]
	private Transform roleSpwan;
	protected override void OnAwake ()
	{
		base.OnAwake ();
		SceneUIMgr.Instance.LoadSceneUI (SceneUIType.MainCity);
	}
	protected override void OnStart ()
	{
		base.OnStart ();
		//加载玩家
		GameObject roleObj=RoleMgr.Instance.LoadRole(GlobalInit.Instance.curRoleNickName,RoleType.MainPlayer);

		roleObj.transform.parent = transform.FindChild ("Role");
		roleObj.transform.localPosition = Vector3.zero;

		GlobalInit.Instance.curRoleCtrl = roleObj.GetComponent<RoleCtrl> ();
		RoleInfoMainPlayer roleInfo = new RoleInfoMainPlayer ();
		roleInfo.MaxHp = 10000;
		roleInfo.CurHp = roleInfo.MaxHp;
		roleInfo.NickName = GlobalInit.Instance.curRoleNickName;
		roleInfo.RoleId = 11;

		GlobalInit.Instance.curRoleCtrl.init (RoleType.MainPlayer,roleInfo,new RoleMainPlayerCityAI(roleObj.GetComponent<RoleCtrl> ()));
		CameraCtrl.Instance.Init (roleObj.transform);
	}

	protected override void OnUpdate ()
	{
		base.OnUpdate ();
		Camera cam = Camera.main;
		if (cam == null)
			return;
		if(Input.GetMouseButtonDown(0)){
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit myHit;
			//获取Role层所有的射线碰撞
			RaycastHit[] hitAll = Physics.RaycastAll (ray,Mathf.Infinity, 1<<LayerMask.NameToLayer("Role"));
			if(hitAll.Length>0){
				RoleCtrl rc = hitAll [0].collider.gameObject.GetComponent<RoleCtrl> ();
				if(rc && rc.curRoleType==RoleType.Monster){
					GlobalInit.Instance.curRoleCtrl.lockEnemy = rc;

				}
			}else

				if(Physics.Raycast(ray,out myHit)){
				if (myHit.collider.gameObject.layer == LayerMask.NameToLayer ("UI"))
					return;
				//			if(myHit.collider.gameObject.name.Equals("Ground",System.StringComparison.CurrentCultureIgnoreCase)){//忽略大小写
				if(myHit.collider.gameObject.name.Contains("Plane")){//忽略大小写
					if(GlobalInit.Instance.curRoleCtrl!=null){
							GlobalInit.Instance.curRoleCtrl.lockEnemy = null;
							GlobalInit.Instance.curRoleCtrl.MoveTo (myHit.point);
						
					}
				} 
			}
		}

	}

}
