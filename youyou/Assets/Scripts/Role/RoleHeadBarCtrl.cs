using UnityEngine;
using System.Collections;

public class RoleHeadBarCtrl : MonoBehaviour {
	[SerializeField]
	private UILabel nickNameLb;
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
	public void Init(Transform target,string name){
		this.targetTrans = target;
		this.nickName = name;
		nickNameLb.text = name;
	}
}
