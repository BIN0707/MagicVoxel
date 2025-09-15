using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//사용자가 마우스를 클릭한 지점에 복셀 1개를 생성
//필요한 속성 : 복셀 공장
public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;

    void Start()
    {
        
    }

//Ray : 무형의 시선 , Raycast : 시선을 던지는 것, RaycastHit : 특정 물체에 시선이 닿은 것
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo))
            {
                GameObject voxel = Instantiate(voxelFactory);

                voxel.transform.position = hitInfo.point;
                //포지션의 정보를 바꿈
            }
        }
    }
}
