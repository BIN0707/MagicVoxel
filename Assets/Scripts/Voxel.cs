using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public float destoryTime = 3.0f;
    float currentTime = 0;
    
    void OnEnable()
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere; //크기가 1이고 방향만 존재
        Rigidbody rb= gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if (currentTime > destoryTime)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);//자기 자신을 비활성화 함
            VoxelMaker.voxelPool.Add(gameObject); //오브젝트 폴에 다시 넣어줌
        }
    }
}
