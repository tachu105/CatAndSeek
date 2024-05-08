using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LightMove : MonoBehaviour
{
    public float mouseDistance;
    void Update()
    {
        // カーソル位置を取得
        Vector3 mousePosition = Input.mousePosition;
        // カーソル位置のz座標を10に
        mousePosition.z = mouseDistance;
        // カーソル位置をワールド座標に変換
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        // GameObjectのtransform.positionにカーソル位置(ワールド座標)を代入
        //transform.position = target;
        this.transform.LookAt(target);

    }
}