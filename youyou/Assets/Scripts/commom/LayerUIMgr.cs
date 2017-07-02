using UnityEngine;
using System.Collections;

public class LayerUIMgr :Singleton<LayerUIMgr> {
	private int  mPanelDepth=50;
	/// <summary>
	/// UI置顶方法1：没打开一个panel 层级加1.
	/// 方法2：先查找root目录下层级最高的panel，然后将最大值加一，赋给新打开的panel
	/// 这里采用方法1实现
	/// </summary>
	/// <param name="panelGob">Panel gob.</param>
	public void SetToTopLayer(GameObject panelGob){
		UIPanel[] panels = panelGob.GetComponentsInChildren<UIPanel> ();
		mPanelDepth += 1;
		for (int i = 0; i < panels.Length; i++) {
			panels [i].depth += mPanelDepth;
		}

	}

	public void Reset(){
		mPanelDepth=50;
	}

	/// <summary>
	/// 打开窗口为0的时候，重置初始化层级.
	/// </summary>
	public void ChenckOpenWindow(){
		if(WindowUIMgr.Instance.OpenWindowCount==0){
			Reset ();
		}
	}
}
