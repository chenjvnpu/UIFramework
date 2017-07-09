using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoleMgr : Singleton<RoleMgr> {
	/// <summary>
	///角色镜像字典 The m role.
	/// </summary>
	private Dictionary<string,GameObject> mRoleDic = new Dictionary<string, GameObject> ();

	/// <summary>
	///通过角色预设名称，克隆加载角色 Loads the player.
	/// </summary>
	/// <returns>The player.</returns>
	/// <param name="name">Name.</param>
	public GameObject LoadRole (string name,RoleType type){
		GameObject gob = null;
//		if (mRoleDic.ContainsKey (name)) {//不可以从字典中去，需要实例化一个新的对象
//			gob = mRoleDic [name];
//		} else {
			string path = "";
			switch (type) {
			case RoleType.MainPlayer:
				path = string.Format ("Player/{0}", name);
				break;
			case RoleType.Monster:
				path = string.Format ("Enemy/{0}", name);
				break;
			default:
				break;
			}

			gob=ResourceMgr.Instance.LoadAndInstanite (ResouceType.Role,path,putInCache:true);
//			mRoleDic.Add (name, gob);
//		}
		return gob;
	}



	public override void Dispose ()
	{
		base.Dispose ();
		mRoleDic.Clear ();
	}

}
