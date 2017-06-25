using UnityEngine;
using System.Collections;

public class UILoginCtrl : MonoBehaviour {

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
		case "btn_login":
			break;
		case "btn_reg":
			HandelRegEvent ();
			break;

		default:
			break;
		}
		
	}

	private void HandelRegEvent(){
		Destroy (gameObject);
		WindowUIMgr.Instance.LoadWindowUI (WindowUIType.Register,WindowUIContainerType.Center);

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
