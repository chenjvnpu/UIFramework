using UnityEngine;
using System.Collections;

public static class GameobjectUtil  {

	public static T GetOrCreateComponent<T>(GameObject gob) where T:MonoBehaviour{
		T t = gob.GetComponent<T> ();
		if(t==null){
			t=gob.AddComponent<T> ();
		}
		return  t;
	}
}
