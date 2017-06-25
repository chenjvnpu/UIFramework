using UnityEngine;
using System.Collections;
using System.Text;
/// <summary>
/// 资源类型
/// </summary>
public enum ResouceType
{
	/// <summary>
	/// 场景UI
	/// </summary>
	UIScene,
	/// <summary>
	/// 窗口UI
	/// </summary>
	UIWindow,
	/// <summary>
	/// 角色
	/// </summary>
	Role,
	/// <summary>
	/// 特效
	/// </summary>
	Effect
}
public class ResourceMgr :Singleton<ResourceMgr>
{
	/// <summary>
	/// T保存缓存对象
	/// </summary>
	Hashtable mPrefabsTable;
	public ResourceMgr(){
		mPrefabsTable = new Hashtable ();
	}
	/// <summary>
	/// 加载资源.
	/// </summary>
	/// <param name="type">Type.</param>
	/// <param name="path">Path.</param>
	/// <param name="putInCache">是否放入缓存区.</param>
	public GameObject Load (ResouceType type, string path,bool putInCache=false)
	{
		

		GameObject gob = null;
		if (mPrefabsTable.ContainsKey (path)) {//从缓存中加载
			gob = mPrefabsTable [path] as GameObject;
			Debug.Log ("load from cache");
		} else {
			StringBuilder myPathSb = new StringBuilder ();

			switch (type) {
			case ResouceType.UIScene:
				myPathSb.Append ("UIPrefabs/ScenePrefabs/");
				break;
			case ResouceType.UIWindow:
				myPathSb.Append ("UIPrefabs/WindowPrefabs/");
				break;
			case ResouceType.Role:
				myPathSb.Append ("RolePrefabs/");
				break;
			case ResouceType.Effect:
				myPathSb.Append ("EffectPrefabs/");
				break;

			default:
				break;
			}	
			myPathSb.Append (path);
			Debug.Log (myPathSb.ToString());

			if (path != null) {
				gob= Resources.Load (myPathSb.ToString()) as GameObject;
				if (gob && putInCache)
					mPrefabsTable.Add (path, gob);
			}
		}


		return gob;

	}
	/// <summary>
	/// 加载资源并实例化对象
	/// </summary>
	/// <returns>The and instanite.</returns>
	/// <param name="type">Type.</param>
	/// <param name="path">Path.</param>
	public GameObject LoadAndInstanite (ResouceType type, string path,bool putInCache=false)
	{
		GameObject prefab = Load (type, path,putInCache);
		if (prefab != null)
			return GameObject.Instantiate (prefab);
		return null;
	}

	/// <summary>
	/// 释放资源
	/// </summary>
	/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="ResourceMgr"/>. The <see cref="Dispose"/>
	/// method leaves the <see cref="ResourceMgr"/> in an unusable state. After calling <see cref="Dispose"/>, you must
	/// release all references to the <see cref="ResourceMgr"/> so the garbage collector can reclaim the memory that the
	/// <see cref="ResourceMgr"/> was occupying.</remarks>
	public override void Dispose ()
	{
		base.Dispose ();
		Resources.UnloadUnusedAssets ();
	}


}
