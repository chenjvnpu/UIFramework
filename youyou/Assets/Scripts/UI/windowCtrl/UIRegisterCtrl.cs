using UnityEngine;
using System.Collections;

public class UIRegisterCtrl : UIWindowBase {
	public UIInput nameInput;
	public UIInput passwordInput;
	public UIInput prePasswordInput;
	public UILabel tipsLabel;
	protected override void OnAwake ()
	{
		base.OnAwake ();
	}

	protected override void OnStart ()
	{
		base.OnStart ();
	}
//	void Awake(){
//		UIButton[] btnArr = GetComponentsInChildren<UIButton> (true);//获取所有子对象的按钮，包括隐藏按钮
//		for (int i = 0; i < btnArr.Length; i++) {
//			UIEventListener.Get (btnArr[i].gameObject).onClick=BtnClic;
//		}
//	}
	/// <summary>
	/// 按钮点击事件.
	/// </summary>
	/// <param name="go">点击的对象.</param>
	protected override void OnBtnClic (GameObject gob)
	{
		base.OnBtnClic (gob);
		switch (gob.name) {
		case "btn_back":
			HanderBack ();
			break;
		case "btn_reg":
			HanderRegister ();
			break;

		default:
			break;
		}
	}

	void HanderBack(){
		Close ();
		nextOpenWindowType = WindowUIType.Login;
	}

	void HanderRegister(){
		string nickName = nameInput.value;
		string psd = passwordInput.value;
		string rePsd = prePasswordInput.value;
		if(string.IsNullOrEmpty(nickName)){
			tipsLabel.text = "请输入昵称";
			return;
		}

		else if(string.IsNullOrEmpty(psd)){
			tipsLabel.text = "请输入密码";
			return;
		}
		else if(string.IsNullOrEmpty(rePsd)){
			tipsLabel.text = "请输入确认密码";
			return;
		}else if(psd!=rePsd){
			tipsLabel.text = "两次密码不一致";
			return;
		}

		PlayerPrefs.SetString (GlobalInit.NICKNAME, nickName);
		PlayerPrefs.SetString (GlobalInit.PASSWORD,psd);
	
	}

//	protected override void BeforeDestroy ()
//	{
//		base.BeforeDestroy ();
//		if(nextOpenWindowType!=WindowUIType.None){
//			WindowUIMgr.Instance.OpenWindowUI (nextOpenWindowType);
//		}
//	}
}
