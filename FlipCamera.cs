/************************************************************
参考URL
	[Unity3D] 画面表示を左右反転させる方法
		https://blog.fujiu.jp/2015/09/unity3d.html
		
	Flip/Mirror > Camera?
		https://answers.unity.com/questions/20337/flipmirror-camera.html
************************************************************/
using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class FlipCamera : MonoBehaviour{
	public bool b_FlipHorizontal = false;
	Camera camera;
	private Matrix4x4 mat;

	void Start () {
		// camera = Camera.main;
		camera = GetComponent<Camera>();
		
	}

	void OnPreCull() {
		camera.ResetWorldToCameraMatrix();
		camera.ResetProjectionMatrix();
		mat = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(b_FlipHorizontal ? -1 : 1, 1, 1));
		camera.projectionMatrix = mat;
	}

	void OnPreRender() {
		GL.invertCulling = b_FlipHorizontal;
	}

	void OnPostRender() {
		GL.invertCulling = false;
	}
}
