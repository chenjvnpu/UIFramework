using UnityEngine;
using System.Collections;
using UnityEditor;

public class GetObjPath : Editor {

	[MenuItem("Assets/GetItemPath")]
	static void getItemPath(){
		//		Object[] seletionObjs	= Selection.GetFiltered (typeof(object),SelectionMode.DeepAssets);
		Object activeObj = Selection.activeObject;
		string path = AssetDatabase.GetAssetPath(activeObj);
		Debug.Log (path);

	}

}