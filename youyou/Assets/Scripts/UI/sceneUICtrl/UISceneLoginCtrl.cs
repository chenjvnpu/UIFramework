using UnityEngine;
using System.Collections;

public class UISceneLoginCtrl : UISceneBase<UISceneLoginCtrl> {


	protected override void OnAwake ()
	{
		base.OnAwake ();
		GameObject gob= WindowUIMgr.Instance.LoadWindowUI (WindowUIType.Login);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
