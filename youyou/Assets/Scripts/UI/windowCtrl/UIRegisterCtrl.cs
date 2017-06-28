using UnityEngine;
using System.Collections;

public class UIRegisterCtrl : UIWindowBase {

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
			//			HandelRegEvent ();
			break;

		default:
			break;
		}
	}

	void HanderBack(){
		Close ();
		nextOpenWindowType = WindowUIType.Login;
	}


//	protected override void BeforeDestroy ()
//	{
//		base.BeforeDestroy ();
//		if(nextOpenWindowType!=WindowUIType.None){
//			WindowUIMgr.Instance.OpenWindowUI (nextOpenWindowType);
//		}
//	}
}
