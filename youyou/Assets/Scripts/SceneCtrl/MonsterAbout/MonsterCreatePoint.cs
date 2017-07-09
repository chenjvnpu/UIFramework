using UnityEngine;
using System.Collections;
using System;

public class MonsterCreatePoint : MonoBehaviour {
	//刷怪点最大数量
	[SerializeField]
	[Range(1,10)]
	private int maxCount = 5;
	//当前数量
	private int currentCount = 0;
	//上次刷怪时间
	private float preCreateTime=0;

	public string monsterName="enemy1";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(currentCount<maxCount){
			if(Time.time>preCreateTime+UnityEngine.Random.Range(-0.5f,0.5f)){
				preCreateTime = Time.time;

				GameObject item= RoleMgr.Instance.LoadRole (monsterName, RoleType.Monster);

				currentCount++;

				//
				item.transform.parent=this.transform;
				item.transform.position = transform.TransformPoint (UnityEngine.Random.Range (-0.5f,1.5f),0,UnityEngine.Random.Range (-0.5f, 0.5f) );
				RoleCtrl roleCtrl = item.GetComponent<RoleCtrl> ();
				roleCtrl.BornPoint = item.transform.position;
				roleCtrl.RoleDie = RoleDie;
				RoleInfoMonster roleInfo = new RoleInfoMonster ();

				roleInfo.MaxHp = 1000;
				roleInfo.CurHp = roleInfo.MaxHp;
				roleInfo.NickName = "逗你呀";
				roleInfo.RoleId = 1;
				roleInfo.RoleServerId = (int)DateTime.Now.Ticks;

				RoleMonsterAI monsterAI = new RoleMonsterAI (roleCtrl);
				roleCtrl.init (RoleType.Monster,roleInfo,monsterAI);
			}
		}
	}

	/// <summary>
	///怪物死亡 Roles the die.
	/// </summary>
	/// <param name="roleCtrl">Role ctrl.</param>
	void RoleDie(RoleCtrl roleCtrl){
		currentCount--;
		Destroy (roleCtrl.gameObject);
	}
}
