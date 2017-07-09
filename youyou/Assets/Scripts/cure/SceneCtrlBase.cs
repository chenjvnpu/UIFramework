using UnityEngine;
using System.Collections;

public class SceneCtrlBase : MonoBehaviour
{
	[SerializeField]
	protected bool isCheckScene = true;

	void Awake ()
	{
		CheckCurrentScene ();
		OnAwake ();
	}
	// Use this for initialization
	void Start ()
	{
		OnStart ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		OnUpdate ();
	}

	protected virtual void OnAwake ()
	{

	}

	protected virtual void OnStart ()
	{
		
	}

	protected virtual void OnUpdate ()
	{

	}

	void CheckCurrentScene ()
	{
		if (isCheckScene)
			SceneMgr.CheckScene ();
	}
}
