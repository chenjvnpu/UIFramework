using UnityEngine;
using System.Collections;
/// <summary>
///角色信息窗口控制器.
/// </summary>
public class UIRoleInfoCtrl :UIWindowBase {
	protected override void OnBtnClic (GameObject gob)
	{
		base.OnBtnClic (gob);
		switch (gob.name) {
		case "closeBtn":
			OnCloseBtnClick ();
			break;
		default:
			break;
		}
	}

	void OnCloseBtnClick(){
		WindowUIMgr.Instance.CloseWindow (WindowUIType.RoleInfo);
	}

}
