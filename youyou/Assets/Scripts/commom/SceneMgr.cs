using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneMgr : Singleton<SceneMgr> {
	static bool  hasLoadinitScene=false;

	private SceneType currentSceneType;

	public static bool HasLoadInitScene {
		get {
			return hasLoadinitScene;
		}
		set {
			hasLoadinitScene = value;
		}
	}

	public SceneType CurrentSceneType{
		get{ 
			return currentSceneType;
		}
	}
	/// <summary>
	/// Loads to city.
	/// </summary>
	public void LoadToLogin(){
//		Application.LoadLevel ("login");
		currentSceneType = SceneType.Login;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("loding");
	}

	/// <summary>
	/// Loads to city.
	/// </summary>
	public void LoadToCity(){
//		Application.LoadLevel ("city");

		currentSceneType = SceneType.City;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("loding");
	}

	public static void OpenScene(string name){
		SceneManager.LoadScene (name);
	}

	public static void CheckScene(){
		if(HasLoadInitScene==false && SceneManager.GetActiveScene().name!="init"){
			OpenScene ("init");
		}
	}
}
