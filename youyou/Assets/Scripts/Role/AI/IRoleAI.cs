using UnityEngine;
using System.Collections;
/// <summary>
///角色AI接口 I role A i1.
/// </summary>
public interface IRoleAI  {
	/// <summary>
	///当前控制的角色 Gets or sets the current role.
	/// </summary>
	/// <value>The current role.</value>
	RoleCtrl currentRole {
		get;
		set;
	}
	/// <summary>
	///执行AI Dos A.
	/// </summary>
	void DoAI ();

}
