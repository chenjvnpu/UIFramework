using UnityEngine;
using System.Collections;

public class InitSceneCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneMgr.HasLoadInitScene = true;
		StartCoroutine (LoadScene ());
	
	}
	
	IEnumerator LoadScene (){
		yield return new WaitForSeconds (4 );
		SceneMgr.Instance.LoadToLogin ();
		yield return null;
	}
}
