using UnityEngine;
using System.Collections;

public class UIRegisterCtrl : UIWindowBase {

	void Awake(){
		UIButton[] btnArr = GetComponentsInChildren<UIButton> (true);//获取所有子对象的按钮，包括隐藏按钮
		for (int i = 0; i < btnArr.Length; i++) {
			UIEventListener.Get (btnArr[i].gameObject).onClick=BtnClic;
		}
	}
	/// <summary>
	/// 按钮点击事件.
	/// </summary>
	/// <param name="go">点击的对象.</param>
	private void BtnClic(GameObject go){
		switch (go.name) {
		case "btn_back":
			break;
		case "btn_reg":
//			HandelRegEvent ();
			break;

		default:
			break;
		}

	}
//	private void HandelRegEvent(){
//		Destroy (gameObject);
//		WindowUIMgr.Instance.OpenWindowUI (WindowUIType.Register);
//
//	}
//
//	private void HandelBackEvent(){
//		Destroy (gameObject);
//		WindowUIMgr.Instance.OpenWindowUI (WindowUIType.Register);
//
//	}


}
