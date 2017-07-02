using UnityEngine;
using System.Collections;

public class UISceneLodingCtrl : UISceneBase {
	[SerializeField]
	private UIProgressBar progressbar;
	[SerializeField]
	private UILabel progressLb;

	public void SetProgressValue(int value){
		progressbar.value = value*0.01f;
		progressLb.text = string.Format ("{0}%",value);
	}

}
