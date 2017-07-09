using UnityEngine;
using System.Collections;
/// <summary>
/// 角色控制器.
/// </summary>
public class RoleCtrl : MonoBehaviour {
	[SerializeField]
	private Transform headBarPos;//头顶血条挂点
	private GameObject toBarUI;
	[SerializeField]
	public Animator anim;
	/// <summary>
	/// 当前角色类型  The type of the current role.
	/// </summary>
	public RoleType curRoleType=RoleType.None;
	/// <summary>
	///当前角色信息 The current role info.
	/// </summary>
	public RoleInfoBase currentRoleInfo=null;
	/// <summary>
	///当前角色AI The current role A.
	/// </summary>
	public IRoleAI currentRoleAI = null;
	/// <summary>
	///当前角色的有限状态机管理 The current role fsm mgr.
	/// </summary>
	public RoleFSMMgr currentRoleFsmMgr=null;
	[HideInInspector]
	public Vector3 TargetPos;
	[HideInInspector]
	public CharacterController characterControl;
	public float moveSpeed=10f;
	[HideInInspector]
	public RoleHeadBarCtrl headBarCtrl;
	/// <summary>
	/// 出生点The born point.
	/// </summary>
	[HideInInspector]
	public Vector3 BornPoint;

	/// <summary>
	/// 视野范围The view range.
	/// </summary>
	public float viewRange;

	/// <summary>
	/// 巡逻范围The patrol range.
	/// </summary>
	public float patrolRange;

	/// <summary>
	/// 攻击范围The attack range.
	/// </summary>
	public float attackRange;
	/// <summary>
	///攻击的对象 The lock enemy.
	/// </summary>
	public RoleCtrl lockEnemy;

	/// <summary>
	/// 角色受伤委托The role hurt.
	/// </summary>
	public System.Action RoleHurt;
	public System.Action<RoleCtrl> RoleDie;


	/// <summary>
	/// Init the specified roleType, roleInfo and roleAI.
	/// </summary>
	/// <param name="roleType">Role type.</param>
	/// <param name="roleInfo">Role info.</param>
	/// <param name="roleAI">Role A.</param>
	public void init(RoleType roleType,RoleInfoBase roleInfo,IRoleAI roleAI){
		this.curRoleType = roleType;
		this.currentRoleInfo = roleInfo;
		this.currentRoleAI = roleAI;
	}

	#region 控制角色方法

	public void ToIdle ()
	{
		currentRoleFsmMgr.ChangeState (RoleState.Idle);
	}
	public void MoveTo (Vector3 targetPos)
	{
		if (targetPos == Vector3.zero)
			return;
		TargetPos = targetPos;
		currentRoleFsmMgr.ChangeState (RoleState.Run);
	}
	public void ToAttack ()
	{
		if(lockEnemy==null){return;}
		currentRoleFsmMgr.ChangeState (RoleState.Attack);
		lockEnemy.ToHurt (100,0.5f);
	}
	/// <summary>
	/// Tos the hurt.
	/// </summary>
	/// <param name="attackValue">攻击力.</param>
	/// <param name="delayTime">掉血延迟时间.</param>
	public void ToHurt (int attackValue,float delayTime)
	{
		StartCoroutine (DelayHurt (attackValue,delayTime));

	}
	private IEnumerator DelayHurt(int attackValue,float delayTime){
		yield return new WaitForSeconds (delayTime);
		//计算得到伤害值
		int demageValue=(int)(attackValue*Random.Range(0.5f,1f));
		if(RoleHurt!=null){
			RoleHurt ();
		}
		currentRoleInfo.CurHp -= demageValue;
		if (currentRoleInfo.CurHp <= 0) {
			currentRoleFsmMgr.ChangeState (RoleState.Die);
		} else {
			currentRoleFsmMgr.ChangeState (RoleState.Hurt);
			headBarCtrl.GetHurt ("-" + demageValue.ToString(),currentRoleInfo.CurHp/(float)currentRoleInfo.MaxHp);
		}


	}

	public void ToDie ()
	{
		currentRoleFsmMgr.ChangeState (RoleState.Die);
	}


	#endregion


	// Use this for initialization
	void Start () {
		characterControl = this.GetComponent<CharacterController> ();
		currentRoleFsmMgr = new RoleFSMMgr (this);
		ToIdle ();
		InidRoleHeadBar ();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentRoleAI==null){
			return;
		}
		currentRoleAI.DoAI ();

		if(currentRoleFsmMgr!=null)
		currentRoleFsmMgr.OnUpdate ();

		if(Input.GetKeyDown(KeyCode.I)){
			ToIdle ();
		}

		if(Input.GetKeyDown(KeyCode.R)){
//			MoveTo ();
		}

		if(Input.GetKeyDown(KeyCode.A)){
			ToAttack ();
		}

		if(Input.GetKeyDown(KeyCode.H)){
			ToHurt (100,.5f);
		}

		if(Input.GetKeyDown(KeyCode.D)){
			ToDie ();
		}


	}

	/// <summary>
	///初始化头顶条 Inids the role head bar.
	/// </summary>
	void InidRoleHeadBar(){
		if (RoleHeadBarRoot.Instance == null || currentRoleInfo==null || headBarPos==null)
			return;
		//
		toBarUI=ResourceMgr.Instance.LoadAndInstanite(ResouceType.UIOther,"roleHeadBar");
		toBarUI.transform.parent = RoleHeadBarRoot.Instance.gameObject.transform;
		toBarUI.transform.localScale = Vector3.one;
		toBarUI.transform.position = Vector3.zero;
		headBarCtrl = toBarUI.GetComponent<RoleHeadBarCtrl> ();
		headBarCtrl.Init (headBarPos,currentRoleInfo.NickName,isShowHpBar:(curRoleType==RoleType.MainPlayer?false:true));

	}

	void OnDestroy(){
		if(toBarUI.gameObject){
			Destroy (toBarUI.gameObject);
		}
	}
}
