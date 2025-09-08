using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//마우스 회전에 따라 카메라 또한 회전
//필요한 것 : 현재의 각도 및 마우스의 감도

public class CamRotate : MonoBehaviour
{
    Vector3 angle;
    public float sensitivity = 200;
    // Start is called before the first frame update
    void Start()
    {
        angle = Camera.main.transform.eulerAngles;
        angle.x = angle.x * -1;
        //angle.x *= -1 도 동일함

    }

    // Update is called once per frame
    void Update()
    {
        //마우스의 정보를 입력
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        //방향 확인
        angle.x = angle.x + x * sensitivity * Time.deltaTime; //그냥 더하면 잘 안 움직임 민감도를 곱해주기, 시간 정보도 같이
        angle.y = angle.y + y * sensitivity * Time.deltaTime;

        angle.x = Mathf.Clamp(angle.x, -90,90); //최대값, 최소값 제한하기

        //회전
        transform.eulerAngles = new Vector3(-angle.x, angle.y, angle.z);

    }
}
