using UnityEngine;
using System.Collections;

public class RoleHeadBarCtrl : MonoBehaviour {
	[SerializeField]
	private UILabel nickNameLb;
	[SerializeField]
	private HUDText hudtext;
	[SerializeField]
	private UIProgressBar hpProgressBar;
	Transform targetTrans;
	string nickName;
//	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main==null ||  UICamera.mainCamera==null)return;
		Vector3 viewPos= Camera.main.WorldToViewportPoint (targetTrans.position);
		Vector3 pos= UICamera.mainCamera.ViewportToWorldPoint (viewPos);//转换为UI相机的世界坐标
		transform.position=pos;

	}
	public void Init(Transform target,string name,bool isShowHpBar=false){
		this.targetTrans = target;
		this.nickName = name;
		nickNameLb.text = name;
		NGUITools.SetActive (hpProgressBar.gameObject, isShowHpBar);

	}

	/// <summary>
	///天假头顶飘血上弹文字 Sets the hud text.
	/// </summary>
	/// <param name="hurtValue">Hurt value.</param>
	public void GetHurt(string hurtValue,float hpValuePercent){
		hudtext.Add (hurtValue,Color.red,0.1f);
		hpProgressBar.value = hpValuePercent;
	}

	/// <summary>
	///设置血条进度 Sets the hp progress.
	/// </summary>
	/// <param name="progress">Progress.</param>
	public void SetHpProgress(float progress){
		hpProgressBar.value = progress;
	}
}
