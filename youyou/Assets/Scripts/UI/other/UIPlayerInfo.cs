using UnityEngine;
using System.Collections;

public class UIPlayerInfo : MonoBehaviour {
	[SerializeField]
	private UIProgressBar hpProgressbar;
	[SerializeField]
	private UIProgressBar expProgressbar;
	[SerializeField]
	private UILabel playerNameLable;

	private RoleInfoMainPlayer roleInfo;
	// Use this for initialization
	void Start () {
		if(GlobalInit.Instance.curRoleCtrl !=null){
			GlobalInit.Instance.curRoleCtrl.RoleHurt = MainPlayerHurt;
			SetInfo ();
		}
	}

	void SetInfo(){
		roleInfo = GlobalInit.Instance.curRoleCtrl.currentRoleInfo as RoleInfoMainPlayer;
		playerNameLable.text =roleInfo.NickName;
	}

	void MainPlayerHurt(){
		hpProgressbar.value = roleInfo.CurHp / (float)roleInfo.MaxHp;
	}

}
