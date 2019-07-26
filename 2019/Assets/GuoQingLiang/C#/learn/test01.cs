using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
using System.Reflection;
public class test01 : MonoBehaviour {
	//用于存储绘制三角形的顶点坐标
	private Vector3[] vertices;
	//用于记录绘制三角形所需要的顶点ID顺序
	private int[] triangles;
	//记录顶点数
	private int count=0;
	//定义Mesh
	private Mesh mesh;


	public Transform asd;

	Plane plane;
	public GameObject _mesh ;
	private Vector3[] _vertices;
	//定义一个链表用于记录所有点的坐标
	private List<Vector3> list;
	// Use this for initialization
	void Start () {
		GameObject go = new GameObject ("Triangle");
		MeshFilter filter = go.AddComponent<MeshFilter> ();

		// 构建三角形的三个顶点，并赋值给Mesh.vertices
		  mesh = new Mesh ();
		filter.sharedMesh = mesh;
		 
		mesh.vertices = new Vector3[] {
			new Vector3 (0, 0, 0),
			new Vector3 (0, 1, 0),
			new Vector3 (1, 0, 0),
		};

		// 构建三角形的顶点顺序，因为这里只有一个三角形，
		// 所以只能是(0, 1, 2)这个顺序。
		mesh.triangles = new int[3] {0, 1, 2};
	  
		mesh.RecalculateNormals ();
		mesh.RecalculateBounds ();

		// 使用Shader构建一个材质，并设置材质的颜色。
		Material material = new Material (Shader.Find ("Diffuse"));
		material.SetColor ("_Color", Color.yellow);

		// 构建一个MeshRender并把上面创建的材质赋值给它，
		// 然后使其把上面构造的Mesh渲染到屏幕上。
		MeshRenderer renderer = go.AddComponent<MeshRenderer> ();
		renderer.sharedMaterial = material;
	}
	
	// Update is called once per frame
	void Update () {
	//	if (Input.GetMouseButtonUp(1))
	//		this.GetTriangle ();
		plane.Set3Points(new Vector3(0,0,0),new Vector3(0,1,0),new Vector3(1,0,0));
	 
	
		_vertices = _mesh.gameObject.GetComponent<MeshFilter>().mesh.vertices ;
		if (Input.GetMouseButtonUp(1))
		for (int i = 0; i < _mesh.gameObject.GetComponent<MeshFilter>().mesh.vertexCount; i++) {
 
				if (plane.GetSide(_mesh.transform.localToWorldMatrix.MultiplyPoint (_vertices [i]))) {
					Debug.Log (_vertices [i]);
		  	}

		}
	}
	 
}
