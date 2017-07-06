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
	public GameObject LoadPlayer (string name){
		GameObject gob = null;
		if (mRoleDic.ContainsKey (name)) {
			gob = mRoleDic [name];
		} else {
			gob=ResourceMgr.Instance.LoadAndInstanite (ResouceType.Role,string.Format("Player/{0}",name),putInCache:true);
			mRoleDic.Add (name, gob);
		}
		return gob;
	}

	public override void Dispose ()
	{
		base.Dispose ();
		mRoleDic.Clear ();
	}

}
