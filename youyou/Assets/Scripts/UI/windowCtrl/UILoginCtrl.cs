using UnityEngine;
using System.Collections;

public class UILoginCtrl : UIWindowBase {

	 

	private void BtnClic(GameObject go){
		
		
	}

	private void HandelRegEvent(){
		Destroy (gameObject);
		WindowUIMgr.Instance.LoadWindowUI (WindowUIType.Register,WindowUIContainerType.Center);

	}

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
			break;
		case "btn_reg":
			HandelRegEvent ();
			break;

		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
