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
		GameObject roleObj=RoleMgr.Instance.LoadPlayer(GlobalInit.Instance.curRoleNickName);

		roleObj.transform.parent = transform.FindChild ("Role");
		roleObj.transform.localPosition = Vector3.zero;

		GlobalInit.Instance.curRoleCtrl = roleObj.GetComponent<RoleCtrl> ();
		GlobalInit.Instance.curRoleCtrl.init (RoleType.MainPlayer,new RoleInfoBase(){NickName=GlobalInit.Instance.curRoleNickName},new RoleMainPlayerCityAI());
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
			if(Physics.Raycast(ray,out myHit)){
				//			if(myHit.collider.gameObject.name.Equals("Ground",System.StringComparison.CurrentCultureIgnoreCase)){//忽略大小写
				if(myHit.collider.gameObject.name.Contains("Plane")){//忽略大小写
					if(GlobalInit.Instance.curRoleCtrl!=null){
						GlobalInit.Instance.curRoleCtrl.MoveTo (myHit.point);
					}
				}
			}
		}

	}

}
