using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;  

public class GodFX_AssetsSelect : EditorWindow {
	public static Transform 编辑中的特效 = null; 
	string 上一个编辑的特效; 
	Transform[] 最近打开的特效;
	GameObject _EffectObject;
	int 最近打开的特效Num;
	static bool addOneFX = false;
	 private List<Object> list = new List<Object>();
	 private List<Object> listTop = new List<Object>();
	private Vector2 _position = new Vector2();
	string listSave ;
	[MenuItem ("Window/GuoQingLiang/GodFX_打开历史")]
	static void AddWindow () { 
		GodFX_AssetsSelect window = (GodFX_AssetsSelect)EditorWindow.GetWindow (typeof (GodFX_AssetsSelect)); 
	}

	public void Awake () 
	{ 
	//	listSave  = EditorPrefs.GetString("保存List", 1); ;
	}
	void  Start()
	{

	}
	void OnEnable () { 
 
	} 
	void Update () {
		if (addOneFX) {

			addFX ();
			addOneFX = false;
		}
	}

	static Object addlist编辑中的特效;
	public static void addOne ( Transform 特效 ) {
		 addlist编辑中的特效 = EditorUtility.GetPrefabParent (特效.gameObject); 
		addOneFX = true;
	}

	void addFX ( ) {
		//	if (编辑中的特效.name != 上一个编辑的特效){
		if (Isnew (addlist编辑中的特效) == -1) {
			list.Add (addlist编辑中的特效);
		} else {
			list.RemoveAt (Isnew (addlist编辑中的特效) ); //删除存在的.
			list.Add (addlist编辑中的特效);
		}
	}

	 int  Isnew ( Object _object) {
		int sameObject = -1;
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
			//	Object addlist编辑中的特效 = EditorUtility.GetPrefabParent (编辑中的特效.gameObject); 
				string	FXpath = AssetDatabase.GetAssetPath (_object);
				string	i_FXpath = AssetDatabase.GetAssetPath (list [i]);
				if (FXpath == i_FXpath)
					sameObject = i;
			}
		}

		return sameObject; //-1是已有的.其他是新打开的特效.
		
	}
	void OnGUI () {
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("add", GUILayout.Width (60), GUILayout.Height (25))) {
 
			list.Add (Selection.activeGameObject);
		}
		if (GUILayout.Button ("清除", GUILayout.Width (60), GUILayout.Height (25))) {

			list = new List<Object>();
		}
		GUILayout.EndHorizontal ();

		if (list != null)
		{
		 	_position = EditorGUILayout.BeginScrollView(_position, false, false);

			if (listTop != null) //固定组.
			{
			//	_position = EditorGUILayout.BeginScrollView(_position, false, false);
				for (int i = 0; i < listTop.Count; i++)
				{
					int a = listTop.Count - i - 1;
					GUILayout.BeginHorizontal ();
					EditorGUILayout.LabelField ("T",GUILayout.Width(16));	GUILayout.Space(-3);
					if (listTop [a]) {
						if (GUILayout.Button (listTop [a].name, GUILayout.Width (160), GUILayout.Height (16))) {
							Selection.activeObject = listTop [a];
							GodFX_Editor._OpenEffectKey = true;
						}
						GUILayout.Space (-3);
						if (GUILayout.Button ("Find", GUILayout.Width (36), GUILayout.Height (16))) {
							Selection.activeObject = listTop [a];
							EditorGUIUtility.PingObject (listTop [a]);
						}
						GUILayout.Space (-3);
						if (GUILayout.Button ("X", GUILayout.Width (20), GUILayout.Height (16))) {
							listTop.RemoveAt (a);
						}
					}
					GUILayout.EndHorizontal (); 
				}
			//	EditorGUILayout.EndScrollView();
			}

			for (int i = 0; i < list.Count; i++)
			{
				int a = list.Count - i - 1;
				GUILayout.BeginHorizontal (); 
			//	EditorGUILayout.ObjectField(list[a], typeof(Object), false);
				if(list[a]){
					if (GUILayout.Button ("t", GUILayout.Width (16), GUILayout.Height (16))) {
					//	Selection.activeObject = list [a];
					//	EditorGUIUtility.PingObject(list [a]);
						listTop.Add (list [a]);
					}GUILayout.Space(-3);
					if (GUILayout.Button (list[a].name, GUILayout.Width (160), GUILayout.Height (16))) {
						Selection.activeObject = list [a];
						GodFX_Editor._OpenEffectKey = true;
					//	EditorGUIUtility.PingObject(list [a]);
					}GUILayout.Space(-3);
					if (GUILayout.Button ("Find", GUILayout.Width (36), GUILayout.Height (16))) {
						Selection.activeObject = list [a];
						EditorGUIUtility.PingObject(list [a]);
					}GUILayout.Space(-3);
				
					if (GUILayout.Button ("X", GUILayout.Width (20), GUILayout.Height (16))) {
						list.RemoveAt (a);
					}
				}//if(list[a])
				GUILayout.EndHorizontal (); 
			}
			EditorGUILayout.EndScrollView();
		}
	}

	void OnHierarchyChange()
	{ 
	//	listSave  = EditorPrefs.SetString("保存List", listTop.ToString); ;
//	  	Debug.Log(listSave);
	}
	void OnInspectorUpdate()
	{ 
		//Debug.Log("窗口面板的更新");
		//这里开启窗口的重绘，不然窗口信息不会刷新
		this.Repaint();
	}

}
