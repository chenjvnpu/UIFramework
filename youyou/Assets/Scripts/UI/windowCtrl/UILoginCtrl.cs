using UnityEngine;
using System.Collections;

public class UILoginCtrl : UIWindowBase {

	public UIInput nameText;
	public UIInput passwordText;
	public UILabel tipsLabel;
	protected override void OnAwake ()
	{
		base.OnAwake ();

	}

	protected override void OnStart ()
	{
		base.OnStart ();
	}

	protected override void OnBtnClic (GameObject go)
	{
		base.OnBtnClic (go);
		switch (go.name) {
		case "btn_login":
			HanderLoginEvent ();
			break;
		case "btn_reg":
			HandelRegEvent ();
			break;

		default:
			break;
		}
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	private void HandelRegEvent(){
		Close ();
		nextOpenWindowType = WindowUIType.Register;

	}

	private void HanderLoginEvent(){
		string name = nameText.value;
		string password = passwordText.value;
		if(string.IsNullOrEmpty(name)){
			tipsLabel.text = "请输入昵称";
			return;
		}else if(string.IsNullOrEmpty(password)){
			tipsLabel.text = "请输入密码";
			return;
		}
		string oldName=PlayerPrefs.GetString(GlobalInit.NICKNAME);
		string oldpsd=PlayerPrefs.GetString(GlobalInit.PASSWORD);
		if (name == oldName && password == oldpsd) {
			SceneMgr.Instance.LoadToCity ();
		} else {
			tipsLabel.text="账号或者密码有误";
		}

	}



}
