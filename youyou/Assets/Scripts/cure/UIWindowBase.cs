using UnityEngine;
using System.Collections;

public class UIWindowBase : UIBase {
	
	[SerializeField]
	public WindowUIContainerType containerType=WindowUIContainerType.Center;

	[SerializeField]
	public WindowShowStyle showStyle=WindowShowStyle.Normal;

}
