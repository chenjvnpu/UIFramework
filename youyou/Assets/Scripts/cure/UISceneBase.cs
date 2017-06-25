using UnityEngine;
using System.Collections;

public class UISceneBase: UIBase
{
	public Transform centerContainer;
//中间窗体容器
	public Transform GetCenterTransform ()
	{
		return centerContainer;
	}

	
}
