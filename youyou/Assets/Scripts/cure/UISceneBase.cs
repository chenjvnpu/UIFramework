using UnityEngine;
using System.Collections;

public class UISceneBase <T>: MonoBehaviour where T : MonoBehaviour {
	public static T Instance;
	public Transform centerContainer;//中间窗体容器
	void Awake(){
		Instance = this as T;
		OnAwake ();
	}

	protected virtual void OnAwake(){
		Debug.Log ("---------------onawake");
	}

	public Transform GetCenterTransform(){
		return centerContainer;
	}
}
