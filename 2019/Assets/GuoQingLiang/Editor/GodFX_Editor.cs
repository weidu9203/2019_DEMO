using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;
  
//using System;
//自定义Tset脚本

 
 
 

public class MyHierarchyMenu :Editor
{ 
	bool 打开折叠三角 = true;
 	static GameObject	selectedObject ;
	static bool Hierarchy显示打开菜单 = true; // 
	public  const  string playeffectBtn = "`";
    public static GameObject  GodFX_word;
    [MenuItem("Window/GuoQingLiang/PlayEffect _" + playeffectBtn, false, 999)]
	static void PlayEffect() {
		GodFX_Editor. KeyPlayFX = true;
		//		Debug.Log (KeyPlayFX);
		//	EditorApplication.ExecuteMenuItem("Window/Layouts/Development");
	}
	[MenuItem ("Window/GuoQingLiang/PlayEffect _`", true)]
	static bool ValidateSelection () {
		return EditorApplication.isPlaying;
	}
	/*
	[MenuItem("Window/GuoQingLiang/OpenEffect _F3", false, 999)]
	static void OpenEffectKey() {
		OpenFxStar (GodFX_Editor.编辑中的特效.gameObject,false);
		GodFX_Editor. _OpenEffectKey = true;
	}
	[MenuItem ("Window/GuoQingLiang/OpenEffect _F3", true)]
	static bool OpenEffectValidateSelection () {
		return EditorApplication.isPlaying;
	}*/

	//	[MenuItem("Window/GuoQingLiang/SelectOnly %#&s", false, 999)]
	[MenuItem("Window/GuoQingLiang/SelectOnly _F1", false, 999)]
	static void selectOnly() {
		GodFX_Editor. SelectOnly = true; 
	}
	[MenuItem ("Window/GuoQingLiang/SelectOnly _F1", true)]
	static bool selectOnlybool () {
		return EditorApplication.isPlaying;
	}

	[MenuItem("Assets/在主视图加载" ,false ,9990)]
	private static void loadInMain()
	{
	//	
		if(GodFX_Editor.编辑中的特效)
		OpenFxStar (GodFX_Editor.编辑中的特效.gameObject,false);
		if(Selection.activeGameObject && PrefabUtility.GetPrefabType(Selection.activeGameObject)  == PrefabType.Prefab)
			GodFX_Editor.FXpath = AssetDatabase.GetAssetPath (Selection.activeGameObject);
		GodFX_Editor.OpenEffect (ref GodFX_Editor.编辑中的特效 ,GodFX_Editor.MAIN.transform);
		GodFX_AssetsSelect.addOne (GodFX_Editor.编辑中的特效);
	}
	[MenuItem("Assets/在A视图加载",false ,9991)]
	private static void loadInA()
	{
		if(GodFX_Editor.编辑中的特效A)
		OpenFxStar (GodFX_Editor.编辑中的特效A.gameObject,false);
		if(Selection.activeGameObject && PrefabUtility.GetPrefabType(Selection.activeGameObject)  == PrefabType.Prefab)
			GodFX_Editor.FXpath = AssetDatabase.GetAssetPath (Selection.activeGameObject);
		GodFX_Editor.OpenEffect (ref GodFX_Editor.编辑中的特效A ,GodFX_Editor.A_EFFECT.transform);
		GodFX_AssetsSelect.addOne (GodFX_Editor.编辑中的特效A);
	//	GodFX_Editor.编辑中的特效A.gameObject.layer
	}
	[MenuItem("Assets/在B视图加载" ,false ,9992)]
	private static void loadInB()
	{
		if(GodFX_Editor.编辑中的特效B)
		OpenFxStar (GodFX_Editor.编辑中的特效B.gameObject,false);
		GodFX_Editor.CreatePoint ();
		if(Selection.activeGameObject && PrefabUtility.GetPrefabType(Selection.activeGameObject)  == PrefabType.Prefab)
			GodFX_Editor.FXpath = AssetDatabase.GetAssetPath (Selection.activeGameObject);
		GodFX_Editor.OpenEffect (ref GodFX_Editor.编辑中的特效B ,GodFX_Editor.B_EFFECT.transform);
		GodFX_AssetsSelect.addOne (GodFX_Editor.编辑中的特效B);
	}
	[MenuItem( "Edit/Test/展开",false)]
	static  void OpenStar()
	{
		OpenFxStar ();
	}
	public static  void OpenFxStar( GameObject 特效 = null, bool 打开折叠三角 = true)
	{
		GameObject effect;
		bool 打开三角;
		if (!特效) {
			effect = Selection.activeTransform.gameObject;
			打开三角 = true;
		} else {
			effect = 特效;
			打开三角 = 打开折叠三角;
		}
		SetExpandedRecursive (effect, 打开三角);
		if (打开三角) 
			foreach (Transform t in effect.transform) {
				Animation animation =	t.gameObject.GetComponent<Animation> ();
				Animator animator = t.gameObject.GetComponent<Animator> ();
				if (animation)
					SetExpandedRecursive (t.gameObject, false);
				if (animator)
					SetExpandedRecursive (t.gameObject, false);
				if (t.name.Length >= 2)
				if (t.name.Substring (0, 2) == "X_")
					SetExpandedRecursive (t.gameObject, false);
			}
	}
	static Transform parentTransform; 
	[MenuItem("Edit/Test/保存 %#&s", false ,3)]
	static void  _save()
	{
	//	_edit ();
		Transform sele = findEffectRoot() ; 
		if (!sele)
			return;

		if (sele.parent.name == "MAIN") {
			GodFX_Editor.编辑中的特效 = sele; 	 
		}
		if (sele.parent.name == "A_EFFECT") {
			GodFX_Editor.编辑中的特效A = sele; 
		}
		if (sele.parent.name == "B_EFFECT") {
			GodFX_Editor.编辑中的特效B = sele;  
		}
			

		parentTransform = Selection.activeTransform;
		if (GodFX_Editor.编辑中的特效)
		if (GodFX_Editor.编辑中的特效.parent.name != "MAIN")
			GodFX_Editor.编辑中的特效 = null;
		if (GodFX_Editor.编辑中的特效A)
		if (GodFX_Editor.编辑中的特效A.parent.name != "A_EFFECT")
			GodFX_Editor.编辑中的特效A = null;
		if (GodFX_Editor.编辑中的特效B)
		if (GodFX_Editor.编辑中的特效B.parent.name != "B_EFFECT")
			GodFX_Editor.编辑中的特效B = null; 
		
		if (Selection.activeTransform)
		if (parentTransform.root.name == "_EffectObject")
		_save2 ();
	}
	static void  _save2(){
		 
		if (parentTransform != GodFX_Editor.编辑中的特效 && parentTransform != GodFX_Editor.编辑中的特效A && parentTransform != GodFX_Editor.编辑中的特效B) {
			
			parentTransform = parentTransform.parent;Debug.Log (parentTransform);
				_save2 ();
			} else {
				if (parentTransform == GodFX_Editor.编辑中的特效)
					GodFX_Editor.saveEffect (GodFX_Editor.编辑中的特效);
				if (parentTransform == GodFX_Editor.编辑中的特效A)
					GodFX_Editor.saveEffect (GodFX_Editor.编辑中的特效A);
				if (parentTransform == GodFX_Editor.编辑中的特效B)
					GodFX_Editor.saveEffect (GodFX_Editor.编辑中的特效B);
			parentTransform = null;
			}
		 
	}
	public static string _Aview = "A";
	public static string _Bview = "B";
	public static string _MAINview = "MAIN";

	[MenuItem("Edit/Test/Edit编辑选择的特效",false, 0)]
	static void  _edit()
	{
		MAINcamera.position = MAINpoint ;
		MAINcamera.rotation = MAINRot ;
		MAINcameraTarget.position =MAINpointTarget  ;


		Acamera.position =Apoint  ;
		Acamera.rotation =ARot ;
		AcameraTarget.position =ApointTarget;
		Bcamera.position =Bpoint  ;
		Bcamera.rotation =BRot  ;
		BcameraTarget.position =BpointTarget  ;


		Transform tem = Selection.activeTransform; 
		Transform sele = findEffectRoot() ; 
		if (!sele)
			return;
			
			if (sele.parent.name == "MAIN") {
			GodFX_Editor.编辑中的特效 = sele; 	  _Aview = "A";   _Bview = "B";   _MAINview = "MAIN";

			//		Selection.activeTransform = MAINview;
		}
			if (sele.parent.name == "A_EFFECT") {
			GodFX_Editor.编辑中的特效A = sele;   _Aview = "MAIN";    _Bview = "B";   _MAINview = "A";
			MAINcamera.position =Apoint;
			MAINcameraTarget.position -= new Vector3(20,0,0)  ;
			Acamera.position = MAINpoint;
			AcameraTarget.position += new Vector3(20,0,0)  ;
			//		Selection.activeTransform = Aview;
		}
			if (sele.parent.name == "B_EFFECT") {
			GodFX_Editor.编辑中的特效B = sele;   _Aview = "A";    _Bview = "MAIN";   _MAINview = "B";
			MAINcamera.position = Bpoint  ;
			MAINcameraTarget.position += new Vector3(20,0,0)  ;
			Bcamera.position = MAINpoint;
			BcameraTarget.position -= new Vector3(20,0,0)  ;
				//	Selection.activeTransform = Bview-

		}
		
	//	EditorApplication.ExecuteMenuItem("GameObject/Align View to Selected");
	//	Selection.activeTransform = tem;
		OpenFxStar ();
		foreach( Transform a in sele.parent. transform){
			if(a != sele){
				OpenFxStar (a.gameObject,false); //关闭其他特效折叠.
			}
		}
		GodFX_Editor.KeyPlayFX = true;
	//	GodFX_MainCamerCtrl.restCamera = true;
	}
  
	[MenuItem("Edit/Test/在A视图加载" ,false, 6)]
	static void  OpenInA()
	{
		if(GodFX_Editor.编辑中的特效A)
		OpenFxStar (GodFX_Editor.编辑中的特效A.gameObject,false);
		
		GameObject	selectedGameObject = Selection.activeTransform.gameObject;
        GodFX_attachEffect attachEffect = selectedGameObject.GetComponent<GodFX_attachEffect>();
        if (selectedGameObject.GetComponent("GodFX_attachEffect"))
        {
            GameObject m_AttachPrefab = attachEffect.AttackEffect;
			Debug.Log ("已打开 " + m_AttachPrefab.name + " 在A视图");
			GodFX_Editor.OpenEffect (ref GodFX_Editor.编辑中的特效A ,GodFX_Editor.A_EFFECT.transform,m_AttachPrefab.transform);
			GodFX_AssetsSelect.addOne (GodFX_Editor.编辑中的特效A);
		}


	}
	 
	[MenuItem("Edit/Test/在A视图加载" , true)]
	static bool a () {
		return Hierarchy显示打开菜单;
	}
 
	[MenuItem("Edit/Test/在B视图加载",false, 7)]
	static void  OpenInB()
	{	
		if(GodFX_Editor.编辑中的特效B)
		OpenFxStar (GodFX_Editor.编辑中的特效B.gameObject,false);
		GameObject	selectedGameObject = Selection.activeTransform.gameObject;
        GodFX_attachEffect attachEffect = selectedGameObject.GetComponent<GodFX_attachEffect>();
        if (selectedGameObject.GetComponent("GodFX_attachEffect"))
        {
            GameObject m_AttachPrefab = attachEffect.AttackEffect;
			Debug.Log ("已打开 " + m_AttachPrefab.name + " 在B视图");
			GodFX_Editor.OpenEffect (ref GodFX_Editor.编辑中的特效B ,GodFX_Editor.B_EFFECT.transform,m_AttachPrefab.transform);
			GodFX_AssetsSelect.addOne (GodFX_Editor.编辑中的特效B);
		}
	}
	[MenuItem("Edit/Test/在B视图加载" , true)]
	static bool b () {
		return Hierarchy显示打开菜单;
	}

   
	[MenuItem("Edit/Test/视图/全显示为所选择的特效"  ,false, 8)]
public	static void  OpenIn3()
	{	
		
		  GodFX_word = GameObject.Find("GodFX_word");
		Transform CameraStand = GodFX_word.transform.Find("Camera stand");
		Transform Camera3same = GodFX_word.transform.Find("Camera 3same"); 

			CameraStand.gameObject.SetActive(false);
			Camera3same.gameObject.SetActive(true);
			Transform sele = findEffectRoot() ;
		Debug.Log ("当前显示" + sele);
		Camera3same.position = new Vector3 ( 0,0,0);

		if (sele == GodFX_Editor.编辑中的特效) {
			if ( _MAINview == "A") 
				Camera3same.position -= new Vector3 (20, 0, 0);
			if ( _MAINview == "B") 
				Camera3same.position += new Vector3 (20, 0, 0);
		}
		if (sele == GodFX_Editor.编辑中的特效A) {
			if ( _MAINview == "MAIN" ||  _MAINview == "B") 
				Camera3same.position -= new Vector3 (20, 0, 0);
		}
		if (sele == GodFX_Editor.编辑中的特效B) {
			if ( _MAINview == "MAIN" || _MAINview == "A") 
				Camera3same.position += new Vector3 (20, 0, 0);
		}
		GodFX_Editor.ScreenXTem = 0;
	
	}
	[MenuItem("Edit/Test/视图/全显示为所选择的特效" , true)]
	static bool _OpenIn3 () {
		Transform sele = Selection.activeTransform;
		if(sele.name == "MAIN" ||  sele.name == "A_EFFECT" || sele.name == "B_EFFECT" || sele.name == "_EffectObject"  )
		return false;
		return true;
	}
	[MenuItem("Edit/Test/视图/分开显示"  ,false, 11)]
	static void  NotOpenIn3()
	{	 
		  GodFX_word = GameObject.Find("GodFX_word");
		Transform CameraStand = GodFX_word.transform.Find("Camera stand");
		Transform Camera3same = GodFX_word.transform.Find("Camera 3same"); 

			CameraStand.gameObject.SetActive(true);
			Camera3same.gameObject.SetActive(false);  
			Camera3same.position = new Vector3 ( 0,0,0);
		GodFX_Editor.ScreenXTem = 0;
		Debug.Log ("切换为分开显示");
	}
	[MenuItem("Edit/Test/视图/分开显示" , true)]
	static bool _NotOpenIn3 () {
		Transform sele = Selection.activeTransform;
		if(sele.name == "MAIN" ||  sele.name == "A_EFFECT" || sele.name == "B_EFFECT" || sele.name == "_EffectObject"  )
			return false;
		return true;
	}

	static Transform eff ;
	public	static Transform  findEffectRoot()
	{
		eff = Selection.activeTransform;
		if (!eff)
			return null;
	//	Debug.Log (eff.parent);

		return	findEffectRoot2 ();
	}

	static Transform  findEffectRoot2()
	{
		if ( GodFX_Editor.MAIN.name == eff.parent.name || GodFX_Editor.A_EFFECT.name == eff.parent.name  ||GodFX_Editor.B_EFFECT.name == eff.parent.name ) {
			return eff;
		}
		if(eff.name == GodFX_Editor.MAIN.name || eff.name == GodFX_Editor.A_EFFECT.name ||eff.name == GodFX_Editor.B_EFFECT.name  || eff.name == "_EffectObject" )
			return null;
		if (eff != GodFX_Editor.编辑中的特效 && eff != GodFX_Editor.编辑中的特效A && eff != GodFX_Editor.编辑中的特效B) {
			
			eff = eff.parent;
			findEffectRoot2 ();
		} else {
			return eff;
		}
		return eff;
	}
	static Transform findEffect; 
	[MenuItem("Edit/Test/Find查找",false, 2)]
	static void  find()
	{
		findEffect = findEffectRoot ();
		Debug.Log (findEffect);
		if (!findEffect)
			return;
	//	Object go = EditorUtility.GetPrefabParent (findEffect.gameObject);
        Object go = PrefabUtility.GetPrefabParent(findEffect.gameObject);
		Selection.activeObject = go;
		EditorGUIUtility.PingObject(go); 
	}
	
	public static void SetExpandedRecursive(GameObject go , bool expand)
	{
		var type = typeof(EditorWindow).Assembly.GetType ("UnityEditor.SceneHierarchyWindow");
		var methodInfo = type.GetMethod ("SetExpandedRecursive");

		EditorApplication.ExecuteMenuItem ("Window/Hierarchy");
		var window = EditorWindow.focusedWindow;
		methodInfo.Invoke (window, new object[]{ go.GetInstanceID (), expand });

	}

	[InitializeOnLoadMethod]
	static void StartInitializeOnLoadMethod()
	{
		EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
	}

	static void OnHierarchyGUI(int instanceID, Rect selectionRect)
	{
		
		if (Event.current != null && selectionRect.Contains(Event.current.mousePosition)
			&& Event.current.button == 1 && Event.current.type == EventType.MouseUp)
		{
			GameObject	selectedGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject; 
			//这里可以判断selectedGameObject的条件
			if (selectedGameObject.transform.root.name == "_EffectObject") 
			{
				Vector2 mousePosition = Event.current.mousePosition;
               if (selectedGameObject.GetComponent("GodFX_attachEffect"))
					Hierarchy显示打开菜单 = true;
				else
					Hierarchy显示打开菜单 = false;
				EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "Edit/Test",null);
			
				Event.current.Use();
			}			
		}
	}

	static Vector3  MAINpoint ;
	static Vector3 MAINpointTarget ;
	static Vector3 Apoint ;
	static Vector3 ApointTarget ;
	static Vector3 Bpoint ;
	static Vector3 BpointTarget ;
	static Quaternion MAINRot ;
	static Quaternion ARot ;
	static Quaternion BRot ;

	static Transform MAINcamera ;
	static Transform Acamera;
	static Transform Bcamera;
	static Transform MAINcameraTarget ;
	static Transform AcameraTarget ;
	static Transform BcameraTarget ;
	//更新.
	public static bool startPlaying () { 
			  GodFX_word = GameObject.Find("GodFX_word");
		if (!GodFX_word)
			return false;
			Transform CameraStand = GodFX_word.transform.Find("Camera stand");
			Transform Camera3same = GodFX_word.transform.Find("Camera 3same");
        MAINcamera = CameraStand.transform.Find("Camera MAIN");
        Acamera = CameraStand.transform.Find("Camera A");
        Bcamera = CameraStand.transform.Find("Camera B");
        MAINcameraTarget = CameraStand.transform.Find("Camera MAIN target");
		AcameraTarget = CameraStand.transform.Find("Camera A target");
		BcameraTarget = CameraStand.transform.Find("Camera B target");
			

		MAINpoint = MAINcamera.transform.position;
		MAINpointTarget = MAINcameraTarget.transform.position;
		Apoint = Acamera.transform.position;
		ApointTarget = AcameraTarget.transform.position;
		Bpoint = Bcamera.transform.position;
		BpointTarget = BcameraTarget.transform.position;
		MAINRot = MAINcamera.transform.rotation;
		ARot =  Acamera.transform.rotation;
		BRot = Bcamera.transform.rotation;


		Debug.Log (MAINpoint +" "+Apoint  +" "+ Bpoint);
		Debug.Log (MAINcamera +" "+Acamera  +" "+ Bcamera);
		return true;
		}
}
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
public class GodFX_Editor : EditorWindow {
	static bool  _运行状态 = false ;
	bool 全局 = true;
	public static string FXpath ;
	bool 新开编辑器 = true;
	public static bool 开始运行 = false;

	Transform 保存对象;
	GameObject _正在保存;
	float 保存 =0.0f;
	static	GameObject _EffectObject;
	GameObject _FXMaker;
	GameObject _FXMakerRoot;
	static	GameObject _InstanceObject;
	static	GameObject 特效备份中心;
	static GameObject _PlayFxRoot;
	static	Transform 编辑中的元素;
	Transform 特效备份;
	bool 自动备份;
    bool autoOpen;
    float 自动备份时间Min = 5.0f;
	public static Transform 编辑中的特效; 
	public static Transform 编辑中的特效A; 
	public static Transform 编辑中的特效B; 
	public static GameObject MAIN;  //节点.
	public static GameObject A_EFFECT;   //节点.
	public static GameObject B_EFFECT;  //节点.
	public static GameObject _MAIN;  //节点.
	public static GameObject _A_EFFECT;   //节点.
	public static GameObject _B_EFFECT;  //节点.

	Object selectPrefab; 
	Transform _clone = null;
	static float 循环时间 = 3.0f;
	//float 删除时间;
	static float _time; //循环时间.
	float _Savetime; //保存时间.
	float 时间轴 = 0.5f;
	float _时间轴 ;
	float 时间缩放 = 1.0f;
	float 时间缩放2 = 1.0f;
	float minValue时间  = 0.0f;
	float maxValue时间  = 1.0f;
	float minLimit时间  = 0.0f;
	float maxLimit时间  = 1.0f;

	string _stopName = "stop";
	string 独显Name = "select";
	string 独显Name_up = "1";
	Transform 独显trmParent;
	int 独显Name_num = 0 ;
	string 独显trmParentName = "NaN";


	bool 记录初始PRS = false;
	Vector3 _UpPos ;
	Vector3 _UpRot ;
	Vector3 _UpSca ;
	static string SeleName;
	string _SeleName;
	static Transform OldSeleTransform;
	Transform	_cloneQuanJu;
	bool 实时更新 = false;
	string 实时更新name= "实时";

	string _隐藏  = "隐藏";
	string _隐藏地面  = "地面";
	string _E_up  = "___";
	float addUP = 0.0f ;

	bool stop = false;
	bool 单独显示 = false;
	bool _break = false;
	bool 编辑路径点 = false;
	Transform select路径; 
	string 编辑路径 = "编辑";
	float 路径刷新时间 = 0.1f;
	float _路径刷新time; //.
	float _整体延迟; //.
	float _延迟时间 = 0.5f ;
	float _延迟; //.
	Color32 pointColor;
	Object parentObject;
//	bool _FXMakerSave = false;
	string Name = "";
	string _Name = "";
	float 缩放比率 = 1.0f;
	float _缩放比率 = 1.0f;
	GameObject 缩放父物体 ;
	bool 缩放 = false;
	int 缩放time = 3;
	Transform[] 缩放跟总数;
	Transform[] 元素总数;
	GameObject 缩放root;
	bool Cant缩放 = false;
	public static bool KeyPlayFX = false;
	public static bool _OpenEffectKey= false;
	public static bool SelectOnly = false;
	GodFX_EffectBone	effectBone;
	public static bool openEffectBool = false;
	//
	//bool OpenFxStarBool = false;

	int lineNum = 0;
	//
	 float 上次时间轴时刻 ;
	static bool 打开后删除其他特效 = true;
	string Clear = "Clear On Open";

	int ScreenX = 0;
	int ScreenY = 0;
	public static int ScreenXTem = 0;
	public static int ScreenYTem = 0;
	[MenuItem ("Window/GuoQingLiang/GodFX_编辑器")]
	static void AddWindow () { 
		GodFX_Editor window = (GodFX_Editor)EditorWindow.GetWindow (typeof (GodFX_Editor)); 
		window.minSize = new Vector2(250, 30);
	}
	public static	void CreatePoint()
	{
		
		_EffectObject = GameObject.Find("_EffectObject");
		if (!GameObject.Find("_EffectObject"))	_EffectObject = new GameObject("_EffectObject");
		//如果没有必要节点，创建出来.

		foreach (Transform t in _EffectObject.transform) {
			if (t.name == "MAIN")		MAIN = t.gameObject;
			if (t.name == "A_EFFECT") 	A_EFFECT = t.gameObject;
			if (t.name == "B_EFFECT")	B_EFFECT = t.gameObject;
		}
		if (MAIN == null) {
			MAIN = new GameObject ("MAIN");
			MAIN.transform.parent = _EffectObject.transform;
			MAIN.SetActive (false);
		}
		if (A_EFFECT == null) {
			A_EFFECT = new GameObject("A_EFFECT");
			A_EFFECT.transform.parent = _EffectObject.transform;
			A_EFFECT.SetActive (false);
		}
		if (B_EFFECT == null) {
			B_EFFECT = new GameObject("B_EFFECT");
			B_EFFECT.transform.parent = _EffectObject.transform;
			B_EFFECT.SetActive (false);
		}

		_PlayFxRoot = GameObject.Find("_PlayFxRoot");
		if (!GameObject.Find("_PlayFxRoot"))	_PlayFxRoot = new GameObject("_PlayFxRoot");

        MyHierarchyMenu.GodFX_word = GameObject.Find("GodFX_word");
		if (!GameObject.Find ("GodFX_word")) {
            MyHierarchyMenu.GodFX_word = AssetDatabase.LoadAssetAtPath<GameObject> ("Assets/GuoQingLiang/Scenes/GodFX_word.prefab");
			GameObject dimian = PrefabUtility.InstantiatePrefab (MyHierarchyMenu.GodFX_word) as GameObject;
		}

		特效备份中心 = GameObject.Find ("特效备份中心");
		if (!GameObject.Find ("特效备份中心"))  	特效备份中心 = new GameObject ("特效备份中心");
	
		if (GameObject.Find ("_InstanceObject")) {
			_InstanceObject = GameObject.Find ("_InstanceObject"); 
			foreach (Transform t in _InstanceObject.transform) {
				Destroy (t.gameObject);
			}
		}

	}

	public static void OpenEffect(ref Transform 特效 , Transform 节点 = null , Transform m_AttachPrefab = null)
	{
		
		CreatePoint ();
		//删除预设.
		//	foreach (Transform t in _EffectObject.transform) {
			GameObject go= (GameObject)Instantiate(_EffectObject.gameObject);//创建预设.
				if (!GameObject.Find ("特效备份中心")) 特效备份中心 = new GameObject ("特效备份中心");
				else 特效备份中心 = GameObject.Find ("特效备份中心");
				go.transform.parent = 特效备份中心.transform;
		System.DateTime now = System.DateTime.Now;
		go.name = "backup at " + now;
		//	}
			foreach (Transform t in _PlayFxRoot.transform) {
				Destroy (t.gameObject);
			}
		if (打开后删除其他特效) {
			if (特效 == 编辑中的特效) { 
				foreach (Transform t in MAIN.transform) {
					Destroy (t.gameObject);
				}
			}
			else	if (特效 == 编辑中的特效A) { 
				foreach (Transform t in A_EFFECT.transform) {
					Destroy (t.gameObject);
				}
			}
			else	if (特效 == 编辑中的特效B) { 
				foreach (Transform t in B_EFFECT.transform) {
					Destroy (t.gameObject);
				}
			}
		}
		if (Selection.activeGameObject && PrefabUtility.GetPrefabType (Selection.activeGameObject) == PrefabType.Prefab) {
		//	FXpath = AssetDatabase.GetAssetPath (Selection.activeGameObject);
		}
		else
			if( m_AttachPrefab)
			FXpath = AssetDatabase.GetAssetPath (m_AttachPrefab);
		else if	(FXpath ==null) 	return; 

	//	Object _特效Prefab = AssetDatabase.LoadAssetAtPath (FXpath, typeof(GameObject));
			GameObject _特效Prefab = AssetDatabase.LoadAssetAtPath<GameObject>(FXpath);
		if (!_特效Prefab)
			return;
	//	_特效Prefab.SetActive (false);
			GameObject 复制特效 = PrefabUtility.InstantiatePrefab (_特效Prefab) as GameObject;
		//	_特效Prefab.SetActive (true);

				//	GameObject go=  PrefabUtility.InstantiatePrefab(_go) as GameObject;  
			特效 = 复制特效.gameObject.transform; 
		//	复制特效.gameObject.SetActiveRecursively (false);
		//	复制特效.gameObject.SetActive (false);
			if(节点)
			复制特效.gameObject.transform.parent = 节点.transform;
			复制特效.transform .position =new Vector3 (0 ,0,0);//重新摆放预设 .
					// go.transform .Rotate (1,2,3 );//预设的旋转角.
		_time = 循环时间;

		MyHierarchyMenu.OpenFxStar (特效.gameObject,true); 
		if(节点.name == "MAIN")
			EditorPrefs.SetString("最近打开", FXpath);
	//	saveEffect( 特效 );
	
	}
		 
	public static void saveEffect( Transform eff = null ){
		if(OldSeleTransform)//如果实时状态.选择物体有“更新”字样，先删除后保存.
		if (OldSeleTransform.name.Length >= 2)
		if (OldSeleTransform.name.Substring (OldSeleTransform.name.Length-2, 2) == "更新")
			OldSeleTransform.name = SeleName;//还原.
		if (eff) {
		// 	eff.gameObject.SetActiveRecursively (true);
         //   eff.gameObject.SetActive(true);
		//	缩放跟总数 = Selection.GetTransforms(SelectionMode.Assets );//跟总数.
			object[] go =	eff.GetComponentsInChildren(typeof(Transform), true);
			foreach (Transform t in go) {
				if (t.name.Length >= 2)
				if (t.name.Substring (0, 2) == "X_")
					t.gameObject.SetActive (false);
			}
			UnityEngine.Object PrefabFXpathObject = PrefabUtility.GetPrefabParent(eff.gameObject);  
			GameObject ret = PrefabUtility.ReplacePrefab (eff.gameObject, PrefabFXpathObject, ReplacePrefabOptions.ConnectToPrefab);
		//	ret.SetActive (true);
		 	EditorUtility.SetDirty (eff);
			AssetDatabase.SaveAssets ();
		}
		object[] _go =	eff.GetComponentsInChildren(typeof(Transform), true);
		/*
		foreach (Transform t in _go) {
			if (t.name.Length >= 2)
			if (t.name.Substring (0, 2) == "D_")
				t.gameObject.SetActive (false);
		}
*/
	}



	public void Awake () 
	{ 
		循环时间 = EditorPrefs.GetFloat("_循环时间", 1);
		Debug.Log("Awake");
	}
 
	
//	[MenuItem( "CONTEXT/Component/_Fold All",false,0 )]
//	public static void FoldAll (){}//Inspector右键菜单.
	/*
	[MenuItem( "GameObject/Fold",false,0 )]
	static void StarInitializeonloadmethodl()
	{
		SetExpandedRecursive (Selection.activeGameObject,false);
	
	}
	*/

	void OnEnable () {
		lineNum =0;
 		Debug.Log("OnEnable");
	//	SceneView.onSceneGUIDelegate = SceneKeyUpdate;  
	}



    bool 显示支持 = false;
    void OnGUI() {
        if (EditorApplication.isPlaying)
            _运行状态 = true;
        if (!EditorApplication.isPlaying)
            _运行状态 = false;
        //	Debug.Log (_运行状态);
        //自动打开
        if (autoOpen)
            if (Selection.activeGameObject)
                if (Selection.activeGameObject.name != lastSelectionGameObject)
                {
                    lastSelectionGameObject = Selection.activeGameObject.name;
                    if (Selection.activeGameObject && PrefabUtility.GetPrefabType(Selection.activeGameObject) == PrefabType.Prefab)
                        GodFX_Editor.FXpath = AssetDatabase.GetAssetPath(Selection.activeGameObject);
                    //	string str = FXpath;
                    if (lastFXpath != FXpath)
                    {
                        GodFX_Editor.OpenEffect(ref GodFX_Editor.编辑中的特效, GodFX_Editor.MAIN.transform);
                        GodFX_AssetsSelect.addOne(GodFX_Editor.编辑中的特效);
                        lastFXpath = FXpath;
                        EditorUtility.FocusProjectWindow();
                    }
                    //	EditorGUIUtility.PingObject (obj);
                    //	Selection.activeObject = obj;
                }

        GUILayout.BeginArea(new Rect(600, 00.0f, position.width, position.height));//运行状态位置.
        _运行状态 = EditorGUILayout.BeginToggleGroup("运行状态", _运行状态);
        GUILayout.EndArea ();// 运行状态位置.

        GUILayout.BeginArea (new Rect (0.0f, 1.0f, 250, 1000));//全局位置.
	
		if (!打开后删除其他特效) {
			Clear = "No       ∑( ° △ °|||)︴     Clear";

		} else {
			Clear = "Clear On Open";
		}
		if (GUILayout.Button (Clear, GUILayout.Width (250), GUILayout.Height (25))) {
			if (Clear == "Clear On Open") {
				打开后删除其他特效 = false;
			} else {
				打开后删除其他特效 = true;
			}
		}
			GUILayout.BeginArea (new Rect (130.0f, 1.0f, 200, 100));//开始位置为 100,100 宽和高都为100
			//	自动备份 = EditorGUILayout.Toggle ("自动备份", 自动备份);
			GUILayout.EndArea ();// 有开始就有结束 GUILaout.EndArea()与GUILayout.BeginArea()搭配使用
	//	GUI.contentColor = new Color(0.1f,.9f,0.1f,1f);//全局设置颜色，设置后后面的控件都变为红色，直到重新设置颜色
	//	GUI.color = Color.green;//全局设置颜色，设置后后面的控件都变为红色，直到重新设置颜色
		if (GUILayout.Button ("保存", GUILayout.Width (120), GUILayout.Height (25))) {
			List<Object> list = new List<Object>();
			if(编辑中的特效)
			list.Add (编辑中的特效);
			if(编辑中的特效A)
				list.Add (编辑中的特效A);
			if(编辑中的特效B)
				list.Add (编辑中的特效B);
			foreach( Transform a in list){

				saveEffect (a);
			}

			}
	//	GUI.contentColor = new Color32(255,255,255,255);//全局设置颜色，设置后后面的控件都变为红色，直到重新设置颜色
			GUILayout.BeginArea (new Rect (130, 30f, 200, 100));//开始位置为 100,100 宽和高都为100
			if (GUILayout.Button ("备份", GUILayout.Width (120), GUILayout.Height (25))) {
				if (编辑中的特效) {
					_正在保存 = new GameObject ("_正在保存...");
					_正在保存.SetActive (false);
					保存对象 = Instantiate (_EffectObject.transform, _EffectObject.transform.position, _EffectObject.transform.rotation)as Transform;
					保存对象.transform.parent = _正在保存.transform;
				//	保存对象.gameObject.SetActiveRecursively (true);
					Destroy (_正在保存.gameObject, 2.0f);
					
					System.DateTime now = System.DateTime.Now;
				string a = now.ToString ().Replace ("/", ".");
				string b = a.ToString ().Replace (":", ".");
				Object emptyPrefab = PrefabUtility.CreateEmptyPrefab ("Assets/GuoQingLiang/Backup/" + "" + "save at " + b + ".prefab");
						emptyPrefab = PrefabUtility.ReplacePrefab (保存对象.gameObject, emptyPrefab); 
					
				}
			}
			GUILayout.EndArea ();// 有开始就有结束 GUILaout.EndArea()与GUILayout.BeginArea()搭配使用
        GUILayout.BeginHorizontal();
        autoOpen = EditorGUILayout.Toggle("auto open", autoOpen);
        GUILayout.EndHorizontal();//
        GUILayout.BeginArea(new Rect(3, 74, 200, 100));
        GUILayout.Label("auto save Min", EditorStyles.boldLabel);
        GUILayout.EndArea();
        GUILayout.BeginHorizontal();
        GUILayout.Space(154);
        GUILayout.BeginArea(new Rect(154, 74, 30, 50));
        自动备份 = EditorGUILayout.Toggle("", 自动备份);
        GUILayout.EndArea();
        GUILayout.Space(44);
        自动备份时间Min = EditorGUILayout.FloatField("", 自动备份时间Min, GUILayout.Width(50.0f), GUILayout.Height(20));
        GUILayout.EndHorizontal();//

        //	 	Debug.Log (Time.time - _Savetime);
        if (自动备份时间Min < 1) {
			自动备份时间Min = 1.0f;
		}
		//
		if (自动备份时间Min >=1)
		if (自动备份)
		if (编辑中的特效) {

			if (Time.time - _Savetime >= 自动备份时间Min * 60.0f) {
				if (编辑中的特效) {
					_正在保存 = new GameObject ("_正在保存...");
					_正在保存.SetActive (false);
					保存对象 = Instantiate (_EffectObject.transform, _EffectObject.transform.position, _EffectObject.transform.rotation)as Transform;
					保存对象.transform.parent = _正在保存.transform;
				//	保存对象.gameObject.SetActiveRecursively (true);
					Destroy (_正在保存.gameObject, 2.0f);

					System.DateTime now = System.DateTime.Now;
					string a = now.ToString ().Replace ("/", ".");
					string b = a.ToString ().Replace (":", ".");
					Object emptyPrefab = PrefabUtility.CreateEmptyPrefab ("Assets/GuoQingLiang/Backup/" + "" + "save at " + b + ".prefab");
					emptyPrefab = PrefabUtility.ReplacePrefab (保存对象.gameObject, emptyPrefab); 
					_Savetime = Time.time;
				}
			}

		}


        GUILayout.Space(-5f);
        GUILayout.Label("Effect", EditorStyles.boldLabel);
        GUILayout.BeginArea(new Rect(50, 95, 200, 300));//开始位置为 100,100 宽和高都为100
        GUILayout.BeginHorizontal();
        string MainButton = "null"; if (!编辑中的特效) MainButton = "null"; else MainButton = "Main";
        if (GUILayout.Button(MainButton, GUILayout.Width(40), GUILayout.Height(17)))
        {
            Object go = PrefabUtility.GetPrefabParent(编辑中的特效.gameObject);
            Selection.activeObject = go;
            //	Selection.activeObject = 编辑中的特效;
            //	EditorGUIUtility.PingObject(编辑中的特效);
        }
        string AButton = "null"; if (!编辑中的特效A) AButton = "null"; else AButton = "A";
        if (GUILayout.Button(AButton, GUILayout.Width(40), GUILayout.Height(17)))
        {
            Object go = PrefabUtility.GetPrefabParent(编辑中的特效A.gameObject);
            Selection.activeObject = go;
            //		Selection.activeObject = 编辑中的特效A;
            //		EditorGUIUtility.PingObject(编辑中的特效A);
        }
        string BButton = "null"; if (!编辑中的特效B) BButton = "null"; else BButton = "B";
        if (GUILayout.Button(BButton, GUILayout.Width(40), GUILayout.Height(17)))
        {
            Object go = PrefabUtility.GetPrefabParent(编辑中的特效B.gameObject);
            Selection.activeObject = go;
            //	Selection.activeObject = 编辑中的特效B;
            //	EditorGUIUtility.PingObject(编辑中的特效B);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();// 有开始就有结束 GUILaout.EndArea()与GUILayout.BeginArea()搭配使用
        GUILayout.Space(-1f);

        循环时间 = EditorGUILayout.FloatField("循环时间", 循环时间, GUILayout.Width(250.0f), GUILayout.Height(20));
        上次时间轴时刻 = 时间轴;
        if (_运行状态 == true)
            _时间轴 = (Time.time - _time) / 循环时间; //更新时间轴百分比.
                                               //	时间轴 = EditorGUILayout.Slider ("", _时间轴*循环时间, 0, 循环时间);
        Color c = GUI.color;
        Color c2 = GUI.contentColor;
        GUI.color = new Color(0, 1, 0, 1);
        EditorGUI.ProgressBar(new Rect(4, 138, position.width - 6, 14), _时间轴 * 循环时间 / 循环时间, "");
        //	GUI.contentColor = Color.white;
        GUI.color = c;
        时间轴 = _时间轴 * 循环时间;
        string _timeLine = (_时间轴 * 循环时间).ToString();
        GUILayout.Label(_timeLine);
        //	Debug.Log (上次时间轴时刻  + "  " + 时间轴);

        EditorGUILayout.MinMaxSlider(ref minValue时间, ref maxValue时间,  minLimit时间, 循环时间,GUILayout.Width (195.0f), GUILayout.Height (20));
			GUILayout.BeginArea (new Rect (200, 155, 200, 100));//开始位置为 100,100 宽和高都为100.18
			EditorGUILayout.FloatField ("", minValue时间, GUILayout.Width (25.0f), GUILayout.Height (16));
			GUILayout.EndArea ();
			GUILayout.BeginArea (new Rect (225, 155, 200, 100));//开始位置为 100,100 宽和高都为100.18
			EditorGUILayout.FloatField ("", maxValue时间, GUILayout.Width (25.0f), GUILayout.Height (16));
			GUILayout.EndArea ();
			GUILayout.Label ("时间缩放", EditorStyles.boldLabel);
			时间缩放 = EditorGUILayout.Slider ("", 时间缩放, 0, 3);
			时间缩放2 = EditorGUILayout.Slider ("", 时间缩放2, 0, 3);


			GUILayout.BeginArea (new Rect (60, 179, 200, 100));//开始位置为 100,100 宽和高都为100.18
			if (GUILayout.Button ("Reset", GUILayout.Width (55), GUILayout.Height (20))) {
				时间缩放 = 1.0f;
			}
			GUILayout.EndArea ();// 有开始就有结束 GUILaout.EndArea()与GUILayout.BeginArea()搭配使用
			GUILayout.BeginArea (new Rect (135, 179, 200, 100));//开始位置为 100,100 宽和高都为100.18
			if (GUILayout.Button ("Reset2", GUILayout.Width (55), GUILayout.Height (20))) {
				时间缩放2 = 1.0f;
			}
			GUILayout.EndArea ();// 有开始就有结束 GUILaout.EndArea()与GUILayout.BeginArea()搭配使用
		//
			if (GUILayout.Button ("Restart", GUILayout.Width (62), GUILayout.Height (25))) {
				if (GameObject.Find ("_PlayFxRoot"))
				foreach (Transform t in _PlayFxRoot.transform) {
					Destroy (t.gameObject);
				}
				PlayFX ();

			}
		//
			//停止播放开关.
			if (GUILayout.Button (_stopName, GUILayout.Width (62), GUILayout.Height (25))) {
				if (!stop) {
					stop = true;
					_stopName = "play";
				} else if (stop) {
					stop = false;
					_stopName = "stop";
				} 
			}
		//单独显示.
		GUILayout.BeginArea (new Rect (63, 237, 200, 100));//开始.
			if (GUILayout.Button (实时更新name, GUILayout.Width (33), GUILayout.Height (33))) {
				if (!实时更新) {
					实时更新 = true;
					实时更新name = ">_<";
					if (Selection.activeTransform) {
						if(实时更新 && 编辑中的特效)
							KeyPlayFX = true;//重播特效.
						if (OldSeleTransform)
							OldSeleTransform.name = SeleName;//还原.
						OldSeleTransform = Selection.activeTransform;
						SeleName = Selection.activeTransform.name;
						if(实时更新 && 编辑中的特效)
						if (Selection.activeTransform.root == 编辑中的特效.root && Selection.activeTransform != 编辑中的特效 && Selection.activeTransform != 编辑中的特效.root) 
							Selection.activeTransform.name = SeleName + "更新";
					}
				}else{
					实时更新 = false;
					实时更新name = "实时";
					if(OldSeleTransform)
					OldSeleTransform.name = SeleName;//还原.
				}
			}
		if (GUI.Button (new Rect (34,0, 50, 33), 独显Name)){
			KeyPlayFX = true;
			if (!单独显示) {
				记录初始PRS = true;
				独显Name_num = 1;
				单独显示 = true;
				独显Name = "返回";
				foreach (Transform t in Selection.transforms) {
					独显trmParent = t;
				}

			} else if (单独显示) {
				单独显示 = false;
				独显Name = "select";
				独显Name_up = "：)";
				独显Name_num = 1;
				foreach (Transform t in Selection.transforms) {
					独显trmParent = t;
				}
			}
			if (GameObject.Find ("_PlayFxRoot"))
				foreach (Transform t in _PlayFxRoot.transform) {
					Destroy (t.gameObject);
				}
		}
		GUILayout.EndArea ();// 独显Name.
		//
		GUILayout.BeginArea (new Rect (148, 237, 200, 100));//开始.50.
	//	if (GUILayout.Button (独显Name_up, GUILayout.Width (33), GUILayout.Height (33))) {
		if (GUILayout.Button ("锁", GUILayout.Width (33), GUILayout.Height (33))) {
			_time =  Time.time;
			单独显示 = true;
			独显Name = "返回";
			独显Name_num = 2;
			独显trmParent = Selection.activeTransform;
			/*
			if (!单独显示) {
				记录初始PRS = true;
				独显Name_num = 1;
				单独显示 = true;
				独显Name_up = "1";
				独显Name = "返回";
				foreach (Transform t in Selection.transforms) {
						独显trmParent = t;
				}
			} else if (单独显示) {
				独显Name_num += 1 ;
				独显Name_up = 独显Name_num.ToString("G");
				foreach (Transform t in Selection.transforms) {
					if(独显Name_num == 1)
						独显trmParent = t;
					if(独显Name_num > 1 && 独显trmParent != t.root)
						独显trmParent = 独显trmParent.parent;
					独显Name = 独显Name = "返回";
				}
	//			独显transformParnt = 
			//	单独显示 = false;

			}
			if (GameObject.Find ("_PlayFxRoot"))
				foreach (Transform t in _PlayFxRoot.transform) {
					Destroy (t.gameObject);
				}
				*/
		}
		GUILayout.EndArea ();// 独显Name_up.

		GUILayout.BeginArea (new Rect (65, 272, 260, 100));//开始.50.
	//	独显trmParent = EditorGUILayout.ObjectField ("", 独显trmParent, typeof(Object), true) as Transform; //获取
		if (独显trmParent && 单独显示 && 独显Name_num == 2)
			独显trmParentName = EditorGUILayout.TextField ("", 独显trmParent.name, GUILayout.Width (115.0f), GUILayout.Height (18));
		else
			独显trmParentName = EditorGUILayout.TextField ("", "(＞﹏＜）", GUILayout.Width (115.0f), GUILayout.Height (18));
		GUILayout.EndArea ();// 编辑中的特效.
			//
			GUILayout.BeginArea (new Rect (183, 237, 200, 200));//开始位置为 100,100 宽和高都为100.50
			if (GUILayout.Button (_隐藏, GUILayout.Width (66), GUILayout.Height (52))) {

				foreach (Transform t in Selection.transforms) {
				
					if (t.root.transform.name == "_EffectObject") {
						if (t.parent.name != "EffectPlayWithTheLine")
					if (t.gameObject.activeSelf) {
							if (t.name.Length >= 2)
							if (t.name.Substring (0, 2) != "X_")
								t.name = "X_" + t.name;
							if (t.name.Length < 2)
								t.name = "X_" + t.name;
							t.gameObject.SetActive(false);
						//	t.gameObject.AddComponent <NcDontActive>();
							_隐藏 = "显示";
						} else {
							if (t.name.Length >= 2)
							if (t.name.Substring (0, 2) == "X_")
								t.name = t.name.Substring (2);
							t.gameObject.SetActive(true);
							//Destroy (t.gameObject.GetComponent ("NcDontActive"));
							_隐藏 = "隐藏";
						}
					}
				}
			}
			GUILayout.EndArea ();// _隐藏.

		GUILayout.BeginArea (new Rect (0, 292, 300, 200));//延迟模块开始 .100
	
		GUILayout.Label ("Name", EditorStyles.boldLabel);
		GUILayout.BeginArea (new Rect (50, 0, 500, 100));//Name开始.

		Name = EditorGUILayout.TextField ("", Name, GUILayout.Width (130.0f), GUILayout.Height (18));
		if (Name != _Name) {
			foreach (Transform t in Selection.transforms) {
				t.name = Name;
				_Name = Name;
			}
		}
		GUILayout.BeginArea (new Rect (133, 0, 300, 200));//_隐藏地面 .100
		GUILayout.BeginHorizontal();
		if (GUILayout.Button (_隐藏地面, GUILayout.Width (33), GUILayout.Height (18))) {
			 MyHierarchyMenu. GodFX_word = GameObject.Find("GodFX_word");
			Transform plane = MyHierarchyMenu.GodFX_word.transform.Find("Plane");
			Transform noPlane = MyHierarchyMenu.GodFX_word.transform.Find("No Plane");
		

			if (_隐藏地面 == "地面") {
				plane.gameObject.SetActive(false);
				noPlane.gameObject.SetActive(true);
				_隐藏地面 = "x_x";
					} else {
				plane.gameObject.SetActive(true);
				noPlane.gameObject.SetActive(false);  
				_隐藏地面 = "地面";
					}
				 
			
		}GUILayout.Space (-3);
		if (GUILayout.Button (_E_up, GUILayout.Width (33), GUILayout.Height (18))) {
			if (_E_up == "_∧_") { 
				addUP = 0;
				_E_up = "___";
			} else { 
				addUP = 1;
				_E_up = "_∧_";
			}


		}
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();// _隐藏地面.


		GUILayout.EndArea ();// Name.

	

		_整体延迟 = EditorGUILayout.FloatField ("整体延迟(虚拟)", _整体延迟, GUILayout.Width (200.0f), GUILayout.Height (20));
		if(_整体延迟>=10.0f){_整体延迟=9.99f;}else if(_整体延迟<=0.0f){_整体延迟 = 0.0f;}
		GUILayout.BeginArea (new Rect (200, 19f, 500, 100));//_整体延迟.
		if (GUILayout.Button ("set", GUILayout.Width (50), GUILayout.Height (22))) {
		//	Selection.activeTransform.gameObject.SetActive (false);
			foreach (Transform t in Selection.transforms) {
				if (t.root.transform.name == "_EffectObject") 
				if (t.parent.name != "EffectPlayWithTheLine"){//
					if (_整体延迟 != 0) {
						if (t.name.Length < 2)
							t.name = "D_" + _整体延迟.ToString ("F2") + "_" + t.name;//
						else if (t.name.Length >= 2) {
							if (t.name.Substring (0, 2) != "X_") {
								if (t.name.Substring (0, 2) != "D_")
									t.name = "D_" + _整体延迟.ToString ("F2") + "_" + t.name;//
								else if (t.name.Substring (0, 2) == "D_")
									t.name = "D_" + _整体延迟.ToString ("F2") + "_" + t.name.Substring (7);//
								
							} else if (t.name.Substring (0, 2) == "X_") {
								if (t.name.Substring (2, 2) != "D_")
									t.name = "X_" + "D_" + _整体延迟.ToString ("F2") + "_" + t.name.Substring (2);//
								else if (t.name.Substring (2, 2) == "D_")
									t.name = "X_" + "D_" + _整体延迟.ToString ("F2") + "_" + t.name.Substring (9);//
							}
						}
					} else {
						if (t.name.Length > 2) {
							if (t.name.Substring (0, 2) == "X_") {
								if (t.name.Substring (2, 2) == "D_")
									t.name = "X_" + t.name.Substring (9);//
							} else if (t.name.Substring (0, 2) == "D_") {
								t.name = t.name.Substring (7);//
							}
						}
					}
				}
			}
		}//
		GUILayout.EndArea ();//_整体延迟.
		//
		GUILayout.BeginArea (new Rect (0, 45, 300, 200));//集体调整延迟的功能模块开始 .
	//	GUILayout.Label ("延迟调整", EditorStyles.boldLabel);
		GUILayout.BeginArea (new Rect (0, 0, 90, 200));//_延迟 .
		_延迟 = EditorGUILayout.FloatField ("延迟调整", _延迟, GUILayout.Width (300.0f), GUILayout.Height (20));
		GUILayout.EndArea ();//_延迟.
			GUILayout.BeginArea (new Rect (150, 0, 300, 200));//集体调整延迟的功能模块开始 .
			_延迟 = EditorGUILayout.FloatField ("", _延迟, GUILayout.Width (50.0f), GUILayout.Height (20));
			GUILayout.EndArea ();//_整体延迟.
					GUILayout.BeginArea (new Rect (100, -1, 300, 200));//增加add .
					if (GUILayout.Button ("+", GUILayout.Width (50), GUILayout.Height (22))) {
						Transform[] selection = Selection.GetTransforms(SelectionMode.Deep );
						foreach (Transform t in selection) {
						ParticleSystem particleSystem =	t.gameObject.GetComponent<ParticleSystem>();
                        var main = particleSystem.main;
                        if (particleSystem) 
                        if (main.startDelay.mode == ParticleSystemCurveMode.Constant)
                        {
                            float cons = main.startDelay.constant + _延迟;
                            if (particleSystem) main.startDelay = cons;
                        }
                        else if (main.startDelay.mode == ParticleSystemCurveMode.TwoConstants)
                        {
                            float min = main.startDelay.constantMin + _延迟;
                            float max = main.startDelay.constantMax + _延迟;
                            main.startDelay = new ParticleSystem.MinMaxCurve(min, max);
                        }
			
			}
					}GUILayout.EndArea ();// 增加add ..
		////
					GUILayout.BeginArea (new Rect (200, -1, 300, 200));//增加add .
					if (GUILayout.Button ("-", GUILayout.Width (50), GUILayout.Height (22))) {
						Transform[] selection = Selection.GetTransforms(SelectionMode.Deep );
						foreach (Transform t in selection) {
                            ParticleSystem particleSystem = t.gameObject.GetComponent<ParticleSystem>();
                        var main = particleSystem.main;
                        if (particleSystem)
                            if (main.startDelay.mode == ParticleSystemCurveMode.Constant)
                            {
                                float cons = main.startDelay.constant - _延迟;
                                if (cons <= 0) cons = 0;
                                if (particleSystem) main.startDelay = cons;
                            }
                            else if (main.startDelay.mode == ParticleSystemCurveMode.TwoConstants)
                            {
                                float min = main.startDelay.constantMin - _延迟;
                                float max = main.startDelay.constantMax - _延迟;
                                if (min <= 0) min = 0; if (max <= 0) max = 0;
                                main.startDelay = new ParticleSystem.MinMaxCurve(min, max);
                            }
			}	
					}
		GUILayout.EndArea ();// 增加add ..
 
		//GUILayout.Label ("____________________________________", EditorStyles.boldLabel);
		GUILayout.EndArea ();// 集体调整延迟的功能模块 ..
		//
		GUILayout.EndArea ();// 
		//
		GUILayout.BeginArea (new Rect (0, 363, 500, 500));//缩放开始 .
			GUILayout.BeginArea (new Rect (0,0, 200, 500));//缩放比率时间轴开始 .
				缩放比率 = EditorGUILayout.Slider ("", 缩放比率, 0, 2);
			GUILayout.EndArea ();// 缩放比率时间轴开始结束.
			GUILayout.BeginArea (new Rect (200, -1, 300, 200));//set .

			if (GUILayout.Button ("缩放", GUILayout.Width (50), GUILayout.Height (18))) {
                float 缩放 = 1;
                if (缩放比率 > 0) 缩放 = 缩放比率;
                Transform select = Selection.activeTransform;
             //   select.localScale = select.localScale * 缩放;
                缩放跟总数 = Selection.GetTransforms(SelectionMode.Assets );//跟总数.
			    元素总数 = Selection.GetTransforms(SelectionMode.Deep );//元素总数.
                 foreach(Transform i in  元素总数){
                     ParticleSystem ps = i.gameObject.GetComponent<ParticleSystem>();
                     var main = ps.main;
                     if (ps)
                     {
                         if (i == select)
                         if (main.scalingMode == ParticleSystemScalingMode.Hierarchy)
                         {
                             i.localScale = i.localScale * 缩放;
                         }
                         if (main.scalingMode == ParticleSystemScalingMode.Local) {
                             i.localScale = i.localScale * 缩放;
                         }
                         if (main.scalingMode == ParticleSystemScalingMode.Shape)
                         {
                             if (!main.startSize3D)
                             {
                                 if (main.startSize.mode == ParticleSystemCurveMode.Constant)
                                 {
                                     float cons = main.startSize.constant * 缩放;
                                     main.startSize = cons;
                                 }
                                 if (main.startSize.mode == ParticleSystemCurveMode.TwoConstants)
                                 {
                                     float min = main.startSize.constantMin * 缩放;
                                     float max = main.startSize.constantMax * 缩放;
                                     main.startSize = new ParticleSystem.MinMaxCurve(min, max);
                                 }
                                 if (main.startSize.mode == ParticleSystemCurveMode.Curve)
                                 {
                                     var a =   main.startSize.curveMax;
                                     var b = main.startSize.curveMultiplier;
                                     main.startSize = new ParticleSystem.MinMaxCurve(b * 缩放, a);
                                 }
                                 if (main.startSize.mode == ParticleSystemCurveMode.TwoCurves)
                                 {
                                     var min = main.startSize.curveMin;
                                     var max = main.startSize.curveMax;
                                     var mul = main.startSize.curveMultiplier;
                                     main.startSize = new ParticleSystem.MinMaxCurve(mul * 缩放, min, max);
                                 }

                             } 
                             else {
                                 if (main.startSize.mode == ParticleSystemCurveMode.Constant)
                                 {
                                     float consX = main.startSizeX.constant * 缩放;
                                     float consY = main.startSizeY.constant * 缩放;
                                     float consZ = main.startSizeZ.constant * 缩放;
                                     main.startSizeX = consX;
                                     main.startSizeY = consY;
                                     main.startSizeZ = consZ;
                                 }
                                 if (main.startSize.mode == ParticleSystemCurveMode.TwoConstants)
                                 {
                                     float minX = main.startSizeX.constantMin * 缩放;
                                     float maxX = main.startSizeX.constantMax * 缩放;
                                     main.startSizeX = new ParticleSystem.MinMaxCurve(minX, maxX);
                                     float minY = main.startSizeY.constantMin * 缩放;
                                     float maxY = main.startSizeY.constantMax * 缩放;
                                     main.startSizeY = new ParticleSystem.MinMaxCurve(minY, maxY);
                                     float minZ = main.startSizeZ.constantMin * 缩放;
                                     float maxZ = main.startSizeZ.constantMax * 缩放;
                                     main.startSizeZ = new ParticleSystem.MinMaxCurve(minZ, maxZ);

                                 }
                                 if (main.startSize.mode == ParticleSystemCurveMode.Curve)
                                 {
                                     var maxX = main.startSizeX.curveMax;
                                     var mul = main.startSizeX.curveMultiplier;
                                     main.startSizeX = new ParticleSystem.MinMaxCurve(mul * 缩放, maxX);
                                     var maxY= main.startSizeY.curveMax;
                                     var mulY = main.startSizeY.curveMultiplier;
                                     main.startSizeY = new ParticleSystem.MinMaxCurve(mulY * 缩放, maxY);
                                     var maxZ = main.startSizeZ.curveMax;
                                     var mulZ = main.startSizeZ.curveMultiplier;
                                     main.startSizeZ = new ParticleSystem.MinMaxCurve(mulZ * 缩放, maxZ);
                                 }
                                 if (main.startSize.mode == ParticleSystemCurveMode.TwoCurves)
                                 {
                                     var minX = main.startSizeX.curveMin;
                                     var maxX = main.startSizeX.curveMax;
                                     var mul = main.startSizeX.curveMultiplier;
                                     main.startSizeX = new ParticleSystem.MinMaxCurve(mul * 缩放, minX, maxX);
                                     var minY = main.startSizeY.curveMin;
                                     var maxY = main.startSizeY.curveMax;
                                     var mulY = main.startSizeY.curveMultiplier;
                                     main.startSizeY = new ParticleSystem.MinMaxCurve(mulY * 缩放, minY, maxY);
                                     var minZ = main.startSizeZ.curveMin;
                                     var maxZ = main.startSizeZ.curveMax;
                                     var mulZ = main.startSizeZ.curveMultiplier;
                                     main.startSizeZ = new ParticleSystem.MinMaxCurve(mulZ * 缩放, minZ, maxZ);

                                 }
                             
                             }
                         }
                       
                            
                     }
            }

			}
			GUILayout.EndArea ();// 增加add ..
		GUILayout.EndArea ();// 缩放结束.

	
		//创建模块.
		GUILayout.BeginArea (new Rect (0, 385, 500, 500));//创建模块开始 .
		//
			if (GUILayout.Button ("创建路径", GUILayout.Width (75), GUILayout.Height (25))) {
				if (编辑中的特效) {
					Object 路径Effect = AssetDatabase.LoadAssetAtPath ("Assets/GuoQingLiang/Prefab/路径_正圆.prefab", typeof(GameObject));
					GameObject 路径Effect_ = (GameObject)Instantiate (路径Effect);
					路径Effect_.name = "路径_正圆";
					路径Effect_.transform.parent = 编辑中的特效.transform;
				}
			} 
		//	GUILayout.BeginArea (new Rect (91, 252, 80, 100));//
		GUILayout.BeginArea (new Rect (80, 0, 80, 100));//
		if (GUILayout.Button (编辑路径, GUILayout.Width (50), GUILayout.Height (25))) {
			if(编辑路径 == "编辑")
			{
				编辑路径点 = true;

				编辑路径 = "隐藏";
			}
			else	if(编辑路径 == "隐藏")
			{

				编辑路径点 = false;
				select路径 = null;
				编辑路径 = "编辑";
			}
		}
		GUILayout.EndArea ();//编辑路径结束
		GUILayout.BeginArea (new Rect (144, 5, 50, 100));//
		select路径 = EditorGUILayout.ObjectField ("", select路径, typeof(Object), true) as Transform; //获取
		GUILayout.EndArea ();//路径obj结束.
		GUILayout.BeginArea (new Rect (204, 5, 50, 100));//
		pointColor =EditorGUILayout.ColorField("", pointColor);
		GUILayout.EndArea ();//颜色结束.

		GUILayout.BeginHorizontal();
		if (GUILayout.Button ("plane", GUILayout.Width (50), GUILayout.Height (25))) {
			CreatNewSameThing ("Assets/GuoQingLiang/Prefab/模型_plane.prefab");

			}
		if (GUILayout.Button ("爆炸", GUILayout.Width (50), GUILayout.Height (25))) {
			CreatNewSameThing ("Assets/GuoQingLiang/Prefab/火星爆炸.prefab");
		
		}
		if (GUILayout.Button ("篝火", GUILayout.Width (50), GUILayout.Height (25))) {
			CreatNewSameThing ("Assets/GuoQingLiang/Prefab/火星篝火.prefab");
		
		}
		if (GUILayout.Button ("刀光01", GUILayout.Width (50), GUILayout.Height (25))) {
			CreatNewSameThing ("Assets/GuoQingLiang/Prefab/刀光01.prefab");

		}
		GUILayout.EndHorizontal ();

		/*
		if (GUILayout.Button ("自动改颜色", GUILayout.Width (250), GUILayout.Height (25))) {
			缩放跟总数 = Selection.GetTransforms(SelectionMode.Assets );//跟总数.
			元素总数 = Selection.GetTransforms(SelectionMode.Deep );//元素总数.
			Debug.Log(元素总数.Length);
			if (缩放跟总数.Length == 1) {
				foreach (Transform t in 元素总数) {
					NcCurveAnimation NcCurveAnimation =t.gameObject.GetComponent<NcCurveAnimation> ();
					ParticleSystem particleSystem =	t.GetComponent<ParticleSystem>();
					if (NcCurveAnimation) {
						for (int i = 0; i < NcCurveAnimation.m_CurveInfoList.Count; i++) {
							if (NcCurveAnimation.m_CurveInfoList [i].m_ApplyType == NcCurveAnimation.NcInfoCurve.APPLY_TYPE.MATERIAL_COLOR) {
								NcCurveAnimation.m_CurveInfoList [i].m_ToColor.x = pointColor.r/255f;
								NcCurveAnimation.m_CurveInfoList [i].m_ToColor.y = pointColor.g/255f;
								NcCurveAnimation.m_CurveInfoList [i].m_ToColor.z = pointColor.b/255f;
								//	NcCurveAnimation.m_CurveInfoList [i].m_ToColor.w = pointColor.a/255f;
								Debug.Log (NcCurveAnimation.m_CurveInfoList [i].m_ToColor.x);
							}
						}

					}
					if (particleSystem) {
						particleSystem.startColor = new Vector4 (pointColor.r/255f,pointColor.g/255f,pointColor.b/255f,pointColor.a/255f) ;
						//		particleSystem.colorOverLifetime.color = ;
					}
				}
			}

		}*/
		GUILayout.EndArea ();// 创建模块ed.
	//	Debug.Log (编辑路径点);
		// 
		GUILayout.EndArea ();//全局位置结束.
		EditorGUILayout.EndToggleGroup ();//运行状态结束位置.
        if (!_运行状态)
        {
           
            GUILayout.BeginArea(new Rect(0, position.height-28, position.width, position.height));//运行状态位置.
            if (GUILayout.Button("请开发者 ~~o(>_<)o ~~ 喝杯咖啡", GUILayout.Width(position.width), GUILayout.Height(27)) )
            {
                if (!显示支持)
                    显示支持 = true;
                else
                    显示支持 = false;
            }

            GUILayout.EndArea();// 显示支持位置.
            GUILayout.BeginArea(new Rect(0, 0, position.width, position.height));//运行状态位置.
            if (显示支持)
            {
                Texture renderTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/GuoQingLiang/Editor/godFX.png");
                if (renderTexture)
                    GUI.DrawTexture(new Rect(5, 5, 240, 240), renderTexture, ScaleMode.ScaleAndCrop, true);
                GUILayout.BeginArea(new Rect(0, position.height - 28, position.width, position.height));//运行状态位置.
                if (GUILayout.Button("感谢(＞﹏＜）支持", GUILayout.Width(position.width), GUILayout.Height(27)))
                {
                    显示支持 = false;
                }
                GUILayout.EndArea();
            }
            else
            {
               
                GUILayout.BeginArea(new Rect(0, 180, position.width, position.height));//位置.
                Texture tex = AssetDatabase.LoadAssetAtPath<Texture>("Assets/GuoQingLiang/Editor/xinxi.png");
                if (tex)
                    GUI.DrawTexture(new Rect(0.0f, 0f, 250, 250), tex, ScaleMode.ScaleAndCrop, true);
                GUILayout.Label("                                                      ", EditorStyles.boldLabel);
                GUILayout.Label("                                                      ", EditorStyles.boldLabel);
                GUILayout.Label("                       GodFX", EditorStyles.boldLabel);
                GUILayout.Label("   神说要有光，于是我们便做起了光影和魔法。  ", EditorStyles.boldLabel);
                GUILayout.Label("                                                      ", EditorStyles.boldLabel);
                GUILayout.Label("                                                      ", EditorStyles.boldLabel);
                GUILayout.Label("                                开发者(微博): 郭青亮", EditorStyles.boldLabel);
                GUILayout.Label("                                         版本: 1.0.27", EditorStyles.boldLabel);
                GUILayout.Label("                 官方下载地址: magesbox.com", EditorStyles.boldLabel);
                GUILayout.Label("                                                      ", EditorStyles.boldLabel);
                GUILayout.Label(" ", EditorStyles.boldLabel);
                GUILayout.EndArea();

            }
            GUILayout.EndArea();// 显示支持位置.
        }


        /*
		if (GUILayout.Button ("对齐到摄像机", GUILayout.Width (75), GUILayout.Height (25))) {
			
			_PlayFxRoot = GameObject.Find ("_PlayFxRoot"); 
			GameObject[] objs = FindObjectsOfType (typeof(GameObject)) as GameObject[];
		//	Transform[] selection = Selection.GetTransforms(_PlayFxRoot );
			if (GameObject.Find ("_PlayFxRoot"))
				foreach (GameObject t in objs) {
				 //	Camera Camera =	t.gameObject.GetComponent<Camera>();
					if (t.gameObject.GetComponent<Camera>()) 
					if (t.transform.root.name == "_PlayFxRoot") {
						Selection.activeTransform.transform.position = t.transform.position;
					}
				}
		}
			if (GUILayout.Button ("OpenInA", GUILayout.Width (75), GUILayout.Height (25))) {
			
			OpenEffect (ref 编辑中的特效A , A_EFFECT.transform);
		}
		if (GUILayout.Button ("OpenInB", GUILayout.Width (75), GUILayout.Height (25))) {

			OpenEffect (ref 编辑中的特效B , B_EFFECT.transform);
		}
		if (GUILayout.Button ("FXpath", GUILayout.Width (75), GUILayout.Height (25))) {

			Debug.Log (FXpath);
		}
*/


        /*
           //	if (编辑中的特效)
               {		
                   GUILayout.BeginArea (new Rect (130, 1.0f, 200, 100));//开始位置为 100,100 宽和高都为100
                   if (GUILayout.Button ("关闭FXMaker", GUILayout.Width (120), GUILayout.Height (25))) {
                       _InstanceObject = GameObject.Find ("_InstanceObject"); 
                       _FXMakerRoot.transform.Find ("_FXMaker").gameObject.SetActive (false);
                       if (GameObject.Find ("_InstanceObject"))
                       foreach (Transform t in _InstanceObject.transform) {
                           Destroy (t.gameObject);
                       }
                       _break = true;
                       stop = false;
                       _stopName = "stop";
                       _Savetime = Time.time;	
                   _time =  Time.time;
                       //记住特效路径.
                       if (编辑中的特效)
                       if (!_FXMaker.activeSelf) {
                           UnityEngine.Object parentObject = EditorUtility.GetPrefabParent (编辑中的特效.gameObject); 
                           FXpath = AssetDatabase.GetAssetPath (parentObject);

                       }
                   _FXMakerSave = true; //有清除instanceObject功能...
                   }
                   GUILayout.EndArea ();// 有开始就有结束 GUILaout.EndArea()与GUILayout.BeginArea()搭配使用
               }*/

        if (lineNum<=35 )
			{
				全局 = false;
				lineNum += 2 ;

			if (lineNum >5 && lineNum <10) {
			//	_FXMakerRoot.transform.Find ("_FXMaker").gameObject.SetActive (false);
				stop = false;
				_stopName = "stop"; 
			}
			if (lineNum >10 && lineNum <15) {//打开最近使用特效.. 

			}
			if (lineNum ==16) {
				CreatePoint ();  
				FXpath = EditorPrefs.GetString ("最近打开"); Debug.Log ("FXpath");
				if (EditorApplication.isPlaying)
					OpenEffect(ref 编辑中的特效,MAIN.transform);  
				PlayFX();
			}
		}
	}
	void CreatNewSameThing( string str){
		
			
		if (Selection.activeTransform) {
			Transform selec = MyHierarchyMenu.findEffectRoot ();

			if (selec != null) {Debug.Log (selec);
				Object clone = AssetDatabase.LoadAssetAtPath (str, typeof(GameObject));
				GameObject Object_clone_ = (GameObject)Instantiate (clone);
				Object_clone_.name = "new" + clone.name;
				if (selec.parent.parent.name != "_EffectObject") {
					Object_clone_.transform.parent = Selection.activeTransform.parent;
					MyHierarchyMenu.OpenFxStar ();
					EditorGUIUtility.PingObject (Object_clone_);
					Selection.activeTransform = Object_clone_.transform;

				} else{
					Object_clone_.transform.parent = Selection.activeTransform;
					MyHierarchyMenu.OpenFxStar ();
					EditorGUIUtility.PingObject (Object_clone_);
					Selection.activeTransform = Object_clone_.transform;

				}
			}
		}

	}

    bool gengxinCamera = false;
    string lastSelectionGameObject;
    string lastFXpath;
    //更新.
    void Update()
	{	
		//根据宽高调整摄像机分布
		if (GameObject.Find ("Complete Camera")) {
			Camera CompleteCamera = GameObject.Find ("Complete Camera").GetComponent<Camera> ();
			if (CompleteCamera) {
				ScreenX = CompleteCamera.pixelWidth;
				ScreenY = CompleteCamera.pixelHeight;
			}
 
		}
		if (!GodFX_CamerUI.isCameraMax && !gengxinCamera) {
			gengxinCamera = true;
		}
		if (ScreenX != ScreenXTem || ScreenY != ScreenYTem || gengxinCamera) {
			 MyHierarchyMenu. GodFX_word = GameObject.Find ("GodFX_word");
		//	if(xy != xyTEM)
			if(!GodFX_CamerUI.isCameraMax)
			if (MyHierarchyMenu.GodFX_word)
                {
				Transform CameraStand = MyHierarchyMenu.GodFX_word.transform.Find ("Camera stand");
				Transform Camera3same = MyHierarchyMenu.GodFX_word.transform.Find ("Camera 3same"); 
				Transform	MAINcamera;
				Transform	Acamera;
				Transform	Bcamera;
				if (CameraStand.gameObject.activeSelf) {
					MAINcamera = CameraStand.transform.Find ("Camera MAIN");
					Acamera = CameraStand.transform.Find ("Camera A");
					Bcamera = CameraStand.transform.Find ("Camera B");

				} else {
					MAINcamera = Camera3same.transform.Find ("Camera MAIN");
					Acamera = Camera3same.transform.Find ("Camera A");
					Bcamera = Camera3same.transform.Find ("Camera B");
				}
				if (ScreenX < ScreenY) {
					MAINcamera.GetComponent<Camera> ().rect = new Rect (0, 0.666666f, 1.0f, 0.333333f);
					Acamera.GetComponent<Camera> ().rect = new Rect (0, 0.333333f, 1.0f, 0.333333f);
					Bcamera.GetComponent<Camera> ().rect = new Rect (0, 0, 1.0f, 0.333333f);
				} else {
					MAINcamera.GetComponent<Camera> ().rect = new Rect (0, 0, 0.333333f, 1);
					Acamera.GetComponent<Camera> ().rect = new Rect (0.333333f, 0, 0.333333f, 1);
					Bcamera.GetComponent<Camera> ().rect = new Rect (0.666666f, 0, 0.333333f, 1);

				}
			}
			ScreenXTem = ScreenX;
			ScreenYTem = ScreenY;
			gengxinCamera = false ;
		//	Debug.Log (ScreenX + "  " +ScreenY);
		}

		///
		if (KeyPlayFX) {
				_PlayFxRoot = GameObject.Find ("_PlayFxRoot");
				if (GameObject.Find ("_PlayFxRoot"))
					foreach (Transform t in _PlayFxRoot.transform) {
						Destroy (t.gameObject);
					}
				PlayFX ();
//				Debug.Log ("play");
			KeyPlayFX = false;
		}
 
		//打开特效快捷键bool.
		if (_OpenEffectKey) {
			OpenEffect (ref 编辑中的特效 ,MAIN.transform);
			_OpenEffectKey = false;
		}

		if (SelectOnly) {
			_time =  Time.time;	
			if (!单独显示) {
				记录初始PRS = true;
				独显Name_num = 1;
				单独显示 = true;
				独显Name = "返回";
				foreach (Transform t in Selection.transforms) {
					独显trmParent = t;
				}

			} else if (单独显示) {
				单独显示 = false;
				独显Name = "select";
				独显Name_up = "：)";
				独显Name_num = 1;
				foreach (Transform t in Selection.transforms) {
					独显trmParent = t;
				}
			}
			if (GameObject.Find ("_PlayFxRoot"))
				foreach (Transform t in _PlayFxRoot.transform) {
					Destroy (t.gameObject);
				}
			SelectOnly = false;
		}


		
		
		//初始化编辑模块.
		if (新开编辑器) {

			_time =  Time.time;
			_Savetime = Time.time;
			CreatePoint (); 

			新开编辑器 =false;
			stop = true;
			_stopName = "play";
		}
		if(!开始运行)
		if (EditorApplication.isPlaying) {
			if(MyHierarchyMenu.startPlaying () )
			开始运行 = true;
		}
		if (!EditorApplication.isPlaying) {
			开始运行 = false;
		}

		if (!stop) 
		if (循环时间>0)
		{
		if (Time.time - _time >= 循环时间) {
			//播放
				PlayFX();
			}
		}
		if (_运行状态) {
	 
				if (时间轴 <= maxValue时间 && 时间轴 >= minValue时间) {
					Time.timeScale = 时间缩放2;
				} else
					Time.timeScale = 时间缩放;
		 
			//		Debug.Log (minValue时间 + "    " + maxValue时间 + "  " + 时间轴);
		}





		if(编辑路径点){
			foreach (Transform t in Selection.transforms) {
				if(t.GetComponent("GodFX_LineAnimition")) 
					select路径 = t;
				else  if(t.parent) 
					if(t.parent.GetComponent("GodFX_LineAnimition")) 
						select路径 = t.parent;
				else if(t.parent.parent) 
					if(t.parent.parent.GetComponent("GodFX_LineAnimition")) 
						select路径 = t.parent.parent;
			}
		}
		if (select路径)
		if (编辑路径点) {
			if ( Time.time - _路径刷新time > 路径刷新时间) {

				GameObject	Cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				MeshFilter meshFilter_ = Cube.gameObject.GetComponent <MeshFilter> ();
				Mesh	mesh = meshFilter_.mesh;
				Material	mat = meshFilter_.GetComponent<Renderer>().material;
				Destroy (Cube);
				foreach (Transform t in select路径.Find("EffectPlayWithTheLine")) {
					Transform clone = Instantiate (t, t.transform.position, t.transform.rotation)as Transform;
					clone.parent = _PlayFxRoot.transform;
					clone.gameObject.AddComponent<MeshRenderer>();
					MeshRenderer meshrender =clone.gameObject.GetComponent<MeshRenderer>();
					meshrender.material = mat;
					mat.color = pointColor;
					clone.gameObject.AddComponent<MeshFilter>();
					MeshFilter meshFilter =clone.gameObject.GetComponent <MeshFilter>();
					meshFilter.mesh = mesh;
				//	clone.gameObject.SetActiveRecursively (true);
					Destroy(clone.gameObject,0.12f);

				}
				_路径刷新time = Time.time;
			}
			
		}
		//记录初始PRS特效显示.
		if(编辑中的特效)
		if(Selection.activeTransform){

				if (记录初始PRS) {	
				_UpPos = Selection.activeTransform.position;	_UpRot = Selection.activeTransform.localEulerAngles;	_UpSca =  Selection.activeTransform.localScale; 
					记录初始PRS = false;	
					}
					if(Selection.activeTransform.position != _UpPos || Selection.activeTransform.localEulerAngles !=  _UpRot  || Selection.activeTransform.localScale != _UpSca){
				if (单独显示)	
				if (_clone) {
							_clone.transform.position += (Selection.activeTransform.position - _UpPos);
							_clone.transform.localEulerAngles += (Selection.activeTransform.localEulerAngles - _UpRot);
							_clone.transform.localScale += (Selection.activeTransform.localScale - _UpSca);
							}//if (_clone)
				if (!单独显示 && 实时更新) {
					
					Transform[] allChildren = _PlayFxRoot.GetComponentsInChildren<Transform>();
					foreach (Transform child in allChildren){
						if (child.name == Selection.activeTransform.name || child.name == Selection.activeTransform.name + "(Clone)") {
							_cloneQuanJu =	child;
//							Debug.Log (child.name);
						}
					}

					if (OldSeleTransform == Selection.activeTransform)//防止切换目标产生的 位移.
					if (_cloneQuanJu ) {
				//		Debug.Log (_cloneQuanJu.name);
						_cloneQuanJu.transform.position += (Selection.activeTransform.position - _UpPos);
						_cloneQuanJu.transform.localEulerAngles += (Selection.activeTransform.localEulerAngles - _UpRot);
						_cloneQuanJu.transform.localScale += (Selection.activeTransform.localScale - _UpSca);
					}//if (_cloneQuanJu)
				}//单独显示.

							_UpPos = Selection.activeTransform.position;
							_UpRot = Selection.activeTransform.localEulerAngles;	
							_UpSca = Selection.activeTransform.localScale; 
					
				}//if(Selection.activeTransform.position != _UpPos ||
	
		}
		//判断切换目标前，是否改变了名字.、、实时显示名字获取.
		if (OldSeleTransform)
		if (OldSeleTransform.name.Length >= 2)
		if (OldSeleTransform.name.Substring (OldSeleTransform.name.Length-2, 2) == "更新")
		if (Selection.activeTransform == OldSeleTransform )
		if (Selection.activeTransform.name.Substring (0,OldSeleTransform.name.Length-2) != _SeleName) { 
		//	SeleName = Selection.activeTransform.name;
		//	_SeleName = SeleName;
//			Debug.Log(Selection.activeTransform.name.Substring (0,OldSeleTransform.name.Length-2)+ "  " +_SeleName);
			SeleName = Selection.activeTransform.name.Substring (0,OldSeleTransform.name.Length-2);
			_SeleName = SeleName;
		}/////////////////////////////

		//如果有EffectBone，就让特效元素跟着EffectBone的骨骼动. 
		_PlayFxRoot = GameObject.Find ("_PlayFxRoot");
		if (GameObject.Find ("_PlayFxRoot")) {
			Transform[] allChildren = _PlayFxRoot.GetComponentsInChildren<Transform> ();
			foreach (Transform t in allChildren) { 
					effectBone = t.GetComponent<GodFX_EffectBone> ();
				if (t.GetComponent ("GodFX_EffectBone")) {
					if(编辑中的特效)
					foreach (Transform a in 编辑中的特效) {
						Animation animation =	a.gameObject.GetComponent<Animation> ();
						Animator animator = a.gameObject.GetComponent<Animator> ();
						if (animation || animator)
							if(t.position == new Vector3(0,0,0) && !单独显示)// Debug.Log ("asdasdasdasd"); 
					 		t.gameObject.SetActive (false);//如果骨骼跟随，先设置隐藏.
						}
					 
					string BoneName = null;
					switch (effectBone.Bone) {
					case Bone.Spine: 		BoneName = "Bip001 Spine"; 	break;  
					case Bone.LThigh: 		BoneName = "Bip001 L Thigh"; break;  
					case Bone.RThigh:		BoneName = "Bip001 R Thigh"; break;  
					case Bone.LCalf: 		BoneName = "Bip001 L Calf"; break;  
					case Bone.RCalf: 		BoneName = "Bip001 R Calf"; break;  	
					case Bone.LFoot: 		BoneName = "Bip001 L Foot"; break;  
					case Bone.RFoot:		BoneName = "Bip001 R Foot"; break;  
					case Bone.Neck: 		BoneName = "Bip001 Neck"; break;  
					case Bone.Head: 		BoneName = "Bip001 Head"; 	break;  
					case Bone.LClavicle: 	BoneName = "Bip001 L Clavicle"; break;  
					case Bone.RClavicle:	BoneName = "Bip001 R Clavicle"; break;  
					case Bone.LUpperArm: 	BoneName = "Bip001 L UpperArm"; break;  
					case Bone.RUpperArm: 	BoneName = "Bip001 R UpperArm"; break;  
					case Bone.LForearm:		BoneName = "Bip001 L Forearm"; break;  
					case Bone.RForearm: 	BoneName = "Bip001 R Forearm"; break;
					case Bone.LHand: 		BoneName = "Bip001 L Hand"; break;  
					case Bone.RHand:		BoneName = "Bip001 R Hand"; break;   
 
					default : 	t.position = new Vector3 (0, 0, 0); break; 
					}//switch
					foreach (Transform b in allChildren)
						if (b.name == BoneName) { 
							t.position = b.transform.position + effectBone.EffectPostion; 
							if(t.position != new Vector3(0,0,0))
								t.gameObject.SetActive (true); 
						}

				}//if (t.GetComponent ("GodFX_EffectBone"))

			}//foreach (Transform t in allChildren)
		}////////////////////////如果有EffectBone，就让特效元素跟着EffectBone的骨骼动. ////////////
	}//Update



	void SaveFX(){


	}

	 void PlayFX(Transform 当前处理的特效 = null )
	{
		CreatePoint ();
		Vector3 偏移位置 = new Vector3 (0,0,0);;


	
		if ( !编辑中的特效A  && ! 编辑中的特效 ) 
			当前处理的特效 = 编辑中的特效B;

		if (编辑中的特效 && 当前处理的特效 == null)
			当前处理的特效 = 编辑中的特效;
		
		if (当前处理的特效 == 编辑中的特效  ) {
			if (MyHierarchyMenu._MAINview == "MAIN") {
				偏移位置 = new Vector3 (0f, addUP, 0f);
			} else if (MyHierarchyMenu._MAINview == "A")
				偏移位置 = new Vector3 (-20f, 0f, 0f);
			else if (MyHierarchyMenu._MAINview == "B")
				偏移位置 = new Vector3 (20f, 0f, 0f);
		} else if (当前处理的特效 == 编辑中的特效A  ) {
			if (MyHierarchyMenu._MAINview == "A") {
				偏移位置 = new Vector3 (0f, addUP, 0f);
			} else
				偏移位置 = new Vector3 (-20f, 0f, 0f);
		} else if (当前处理的特效 == 编辑中的特效B ) {
			偏移位置 = new Vector3 (0f, addUP, 0f);
			if (MyHierarchyMenu._MAINview == "B") {
			} else
				偏移位置 =  new Vector3 (20f, 0f, 0f);
		}
		//复制正在编辑的特效来显示播放.
		if (!单独显示) {
			
			if (当前处理的特效)
				foreach (Transform t in 当前处理的特效) {
		 		
				if (t.name.Length < 2){
					_clone = Instantiate (t, t.transform.position, t.transform.rotation)as Transform;
					_clone.parent = _PlayFxRoot.transform;
						_clone.transform.position += 偏移位置;
				//	_clone.gameObject.SetActiveRecursively (true);
					Destroy (_clone.gameObject, 循环时间 + 0.03f);
				}
				if (t.name.Length >= 2){
					if (t.name.Substring (0, 2) != "D_" && t.name.Substring (0, 2) != "X_"&& t.name.Substring (0, 2) != "C_"){
						_clone = Instantiate (t, t.transform.position, t.transform.rotation)as Transform;
						_clone.parent = _PlayFxRoot.transform;
				//		_clone.gameObject.SetActiveRecursively (true);
							_clone.transform.position += 偏移位置;
						Destroy (_clone.gameObject, 循环时间 + 0.03f);
					}
					if (t.name.Substring (0, 2) == "D_"){
				//		if(t.gameObject.activeSelf == true)
				//			t.gameObject.SetActive (false);
						_clone = Instantiate (t, t.transform.position, t.transform.rotation)as Transform;
						GameObject _DelayRoot = new GameObject ("_DelayRoot");
						_DelayRoot.transform.parent = _PlayFxRoot.transform;
						_clone.parent = _DelayRoot.transform;
							_clone.gameObject.SetActive(false) ;
						_DelayRoot.gameObject.AddComponent<GodFX_SetActive>();
							_clone.transform.position += 偏移位置;
						Destroy (_DelayRoot.gameObject, 循环时间 + 0.03f);
					}
                    /*
					if (t.name.Substring (0, 2) == "C_"){
			//			if(t.gameObject.activeSelf == true)
			//				t.gameObject.SetActive (false);
						GameObject _DelayRoot = new GameObject ("_DelayRoot");
						_DelayRoot.transform.parent = _PlayFxRoot.transform;
						Transform C_abc = Instantiate (t, t.transform.position, t.transform.rotation)as Transform;
						GameObject GodFX_word = GameObject.Find("GodFX_word");
						_DelayRoot.gameObject.AddComponent<GodFX_SetActive>();
						Transform Camera_zhendong = GodFX_word.transform.Find("Camera_zhendong");
						_clone = Instantiate (Camera_zhendong, Camera_zhendong.transform.position, Camera_zhendong.transform.rotation)as Transform;
						NcCurveAnimation NcCurveAnimation =	_clone.GetComponent<NcCurveAnimation>();
						C_abc.parent = _DelayRoot.transform;
						_clone.parent = C_abc.transform;
						if (t.name.Length >= 11)
							NcCurveAnimation.m_fDurationTime = float.Parse (t.name.Substring (7, 4));
						if (t.name.Length >= 16 && t.name.Substring (11, 1)=="_"){
						NcCurveAnimation.m_CurveInfoList[0].m_fValueScale = NcCurveAnimation.m_CurveInfoList[0].m_fValueScale * float.Parse (t.name.Substring (12, 4));
						NcCurveAnimation.m_CurveInfoList[1].m_fValueScale = NcCurveAnimation.m_CurveInfoList[1].m_fValueScale * float.Parse (t.name.Substring (12, 4));
						NcCurveAnimation.m_CurveInfoList[2].m_fValueScale = NcCurveAnimation.m_CurveInfoList[2].m_fValueScale * float.Parse (t.name.Substring (12, 4));
						}
							_clone.transform.position += 偏移位置;
						Destroy (_DelayRoot.gameObject, 循环时间 + 0.03f);
					}**/
				}
				
			}
			_time = Time.time;	

		} else {
			if (!独显trmParent && 独显Name_num ==2) {
				_time =  Time.time;	
				单独显示 = false;
				独显Name = "select";
				独显Name_up = "：)";
				独显Name_num = 1;
			}


				foreach (Transform t in Selection.transforms) {
					if (Selection.activeTransform.root.name == "_EffectObject") {
				
						if (独显Name_num == 1)
							_clone = Instantiate (t, t.transform.position, t.transform.rotation)as Transform;
						else if (独显Name_num >= 2 && 独显trmParent)
							_clone = Instantiate (独显trmParent, 独显trmParent.transform.position, 独显trmParent.transform.rotation)as Transform;
						if(_clone) 	_clone.parent = _PlayFxRoot.transform;
					//	if(_clone) 	_clone.gameObject.SetActiveRecursively (true);
						if(_clone)	_clone.transform.position += 偏移位置;
						if(_clone) 	Destroy (_clone.gameObject, 循环时间 + 0.03f);

				
					}
			}

			_time = Time.time;	
		} 
		if (编辑中的特效 != 编辑中的特效A && 编辑中的特效 != 编辑中的特效B) {//如果没有三个视图全显示.
			if (编辑中的特效A && 当前处理的特效 == 编辑中的特效) {
				当前处理的特效 = 编辑中的特效A;
				PlayFX (编辑中的特效A);
			} else if (编辑中的特效B) { 
				if (当前处理的特效 == 编辑中的特效A || 当前处理的特效 == 编辑中的特效) {
					当前处理的特效 = 编辑中的特效B;
					PlayFX (编辑中的特效B); 
				}

			}

		}
	}
	
	void OnFocus()
	{

	}  
	
	void OnLostFocus()
	{//失去焦点.
		EditorPrefs.SetFloat("_循环时间", 循环时间);

	}
	
	void OnHierarchyChange()
	{
		_break = true;

		_EffectObject =  GameObject.Find("_EffectObject"); 
	 	if(_EffectObject)
		foreach (Transform t in _EffectObject.transform) {
			//	if(t.name == "MAIN")
			//		foreach (Transform a in t) 
			//			编辑中的特效 = a;
				if(t.name == "A_EFFECT")
					if(!编辑中的特效A)
					foreach (Transform a in t) 
						编辑中的特效A = a;
				 
				if(t.name == "B_EFFECT")
				if(!编辑中的特效B)
					foreach (Transform a in t) 
						编辑中的特效B = a; 
		}//获取编辑中的特效.
 
			 
 
	}
	
	void OnProjectChange()
	{ 
	}
	
	void OnInspectorUpdate()
	{
	
		//Debug.Log("窗口面板的更新");
		//这里开启窗口的重绘，不然窗口信息不会刷新
		this.Repaint();
	}
	
	void OnSelectionChange()
	{ 
	//	OldSeleTransform =  Selection.activeTransform.name;
	//	if(OldSeleTransform)
	//		OldSeleTransform.name = SeleName;

			记录初始PRS = true;
		/////////////////////////////////////////////////实时更新.
			if (Selection.activeTransform) {
			if(实时更新 && 编辑中的特效)
		 	KeyPlayFX = true;//重播特效.
			if (OldSeleTransform)
			if (OldSeleTransform.name.Length >= 2)
			if (OldSeleTransform.name.Substring (OldSeleTransform.name.Length-2, 2) == "更新")
				OldSeleTransform.name = SeleName.Substring (0,OldSeleTransform.name.Length-2) ;//还原.
		//		OldSeleTransform.name = SeleName.Substring (0,OldSeleTransform.name.Length-2) ;//还原.
				OldSeleTransform = Selection.activeTransform;
				SeleName = Selection.activeTransform.name;
				_SeleName =	Selection.activeTransform.name; 
			if(实时更新 && 编辑中的特效)
			if (Selection.activeTransform.root == 编辑中的特效.root && Selection.activeTransform != 编辑中的特效 && Selection.activeTransform != 编辑中的特效.root) 
				Selection.activeTransform.name = SeleName + "更新";
		}else  if (!Selection.activeTransform) {
			if(OldSeleTransform)
			if (OldSeleTransform.name.Length >= 2)
			if (OldSeleTransform.name.Substring (OldSeleTransform.name.Length-2, 2) == "更新")
			OldSeleTransform.name = SeleName;//还原.
		}
		////////////////////////////////////////实时更新.ed
		if (单独显示 && EditorApplication.isPlaying) { 
			
			if(GameObject.Find("_PlayFxRoot"))
			foreach (Transform t in _PlayFxRoot.transform) {
				Destroy (t.gameObject);
			}
			PlayFX ();
		}
		//
		foreach (Transform t in Selection.transforms) {
			if(t.gameObject.activeSelf) 
			{
					_隐藏 = "隐藏";
			}else{
					_隐藏 = "显示";
			}
			//改名字，选择时显示选择的物体.
				Name = t.name;
				_Name = Name;
			//

		}
		//
//		Destroy(缩放root);
	}
	
	void OnDestroy()
	{
	//	循环时间 = EditorPrefs.GetFloat("_循环时间", 1);
		EditorPrefs.SetFloat("_循环时间", 循环时间);
		_运行状态 = false;
	//	Debug.Log("当窗口关闭时调用");
	}



	
	
	
}