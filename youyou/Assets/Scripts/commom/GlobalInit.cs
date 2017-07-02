using UnityEngine;
using System.Collections;

public class GlobalInit : MonoBehaviour {
	public static GlobalInit Instance;
	/// <summary>
	/// UI 动画曲线.
	/// </summary>
	public AnimationCurve UIAnimationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
	void Awake(){
		Instance = this;
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region 常量
	/// <summary>
	/// 昵称key.
	/// </summary>
	public static string NICKNAME = "nickName";
	/// <summary>
	/// 密码key.
	/// </summary>
	public static string PASSWORD = "password";

	#endregion
}
