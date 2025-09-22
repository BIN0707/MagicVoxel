using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//사용자가 마우스를 클릭한 지점에 복셀 1개를 생성
//필요한 속성 : 복셀 공장
public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;

    public int voxelPoolSize = 20;
    public static List<GameObject> voxelPool = new List<GameObject>();
    //static = 정적 변수, 유일하다

    void Start()
    {
        for(int i =0; i < voxelPoolSize; i++)
        {
            //복셀 생성
             GameObject voxel = Instantiate(voxelFactory);
             //생성 시 컬러 변경, 마지막 pdf 타이핑 (과제)
             //voxel.Rander = 
//             voxel.GetComponet


             //복셀 비활성화
             voxel.SetActive(false);

             //폴에 담기
             voxelPool.Add(voxel);

        }

    }

//Ray : 무형의 시선 , Raycast : 시선을 던지는 것, RaycastHit : 특정 물체에 시선이 닿은 것
public float createTime = 0.1f;
float currentTime = 0;

public Transform crosshair;

    void Update()
    {
        ARAVRInput.DrawCrosshair(crosshair);

        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            currentTime += Time.deltaTime;
            if (currentTime > createTime)
            {
                Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);

                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo = new RaycastHit();

                if(Physics.Raycast(ray, out hitInfo))
                {
                    if(voxelPool.Count > 0) //오브젝트 폴 안에 복셀이 있는지 확인인
                    {
                        GameObject voxel = voxelPool[0]; //폴에서 값을 가져옴
                        voxel.SetActive(true); //복셀 활성화
                        voxel.transform.position = hitInfo.point;
                        //Racast를 통해 얻은 충돌 지점의 위치로 객체를 옮김
                        voxelPool.RemoveAt(0);
                        currentTime = 0;
                    }
                }
                
            }

        }         
    }

}