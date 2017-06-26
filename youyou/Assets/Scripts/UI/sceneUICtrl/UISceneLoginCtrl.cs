using UnityEngine;
using System.Collections;

public class UISceneLoginCtrl : UISceneBase {


	protected override void OnAwake ()
	{
		base.OnAwake ();

	}

	protected override void OnStart ()
	{
		base.OnStart ();
		GameObject gob= WindowUIMgr.Instance.OpenWindowUI (WindowUIType.Login);
	}
	

}
