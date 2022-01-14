using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CatchScript : MonoBehaviour
{
    private GameObject gameobj;
    private bool CubeFlag = false;
    private bool SphereFlag = false;
    private bool CapsuleFlag = false;
    public Texture2D texture;
    void Start()
    {
 
    }
    void Update()
    {
        //鼠标监听 是否点击
        if (Input.GetMouseButtonDown(0))
        {
            //set ray Camera.main 只是代表tag标签为main camera 的摄像机 其可以替换为任何摄像机
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //创建碰撞体对象
            RaycastHit hit;
            //判断是否碰撞
            if (Physics.Raycast(ray,out hit))
            {
                //打印拾取物体的名称
                Debug.Log(hit.transform.name);
                SetObj(hit.transform.name);        
            }
            else
            {
                CubeFlag = false;
                CapsuleFlag = false;
                SphereFlag = false;
            }
        }
 
        if (CubeFlag)
        {
            gameobj.GetComponent<Renderer>().material.mainTexture = texture;
            gameobj.transform.Rotate(0, 10, 0);
        }
 
        if (SphereFlag)
        {
            gameobj.transform.Translate(0, 0.02f, 0);
        }
        if (CapsuleFlag)
        {
            gameobj.transform.Rotate(0, 10, 0);
        }
 
    }
    void SetObj(string hitname)
    {
        switch(hitname)
        {
            case "Cube":
 
                gameobj = GameObject.Find("Cube");
                CubeFlag = true;
                CapsuleFlag = false;
                SphereFlag = false;
                break;
            case "Sphere":
                gameobj = GameObject.Find("Sphere");
                SphereFlag = true;
                CubeFlag = false;
                CapsuleFlag = false;
                break;
            case "Capsule":
                gameobj = GameObject.Find("Capsule");
                CapsuleFlag = true;
                CubeFlag = false;
                SphereFlag = false;
                break;
            default:
                CubeFlag = false;
                CapsuleFlag = false;
                SphereFlag = false;
                break;
        }
    }
}