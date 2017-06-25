using UnityEngine;
using System.Collections;

public class UIBase : MonoBehaviour {



	void Awake(){
		

		OnAwake ();
	}



	void Start () {
		UIButton[] btnArr = GetComponentsInChildren<UIButton> (true);//获取所有子对象的按钮，包括隐藏按钮
		for (int i = 0; i < btnArr.Length; i++) {
			UIEventListener.Get (btnArr[i].gameObject).onClick=BtnClic;
		}
		OnStart ();
	}

	// Update is called once per frame
	//	void Update () {
	//		
	//	}

	protected void BtnClic(GameObject go){
		OnBtnClic (go);
	}
	protected virtual void OnAwake(){
		
	}

	protected virtual void OnStart(){
		
	}

	/// <summary>
	/// 按钮点击事件.
	/// </summary>
	/// <param name="go">点击的对象.</param>
	protected virtual void OnBtnClic(GameObject gob){
		
	}


}
