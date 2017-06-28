using UnityEngine;
using System.Collections;

public class UILoginCtrl : UIWindowBase {



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
//	void Update () {
//	
//	}

	private void HandelRegEvent(){
		Close ();
		nextOpenWindowType = WindowUIType.Register;

	}



}
