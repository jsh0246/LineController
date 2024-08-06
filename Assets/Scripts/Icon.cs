using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public Cell curCell;

    bool m_HitDetect;
    RaycastHit m_Hit;
    float m_MaxDistance = 10f;
    Vector3 myVec;

    private void Awake()
    {
        myVec = - transform.forward;
    }

    // ? // 필요할 떄만 Call back 하는 기술? 매번 검사하는게 아닌?
    private void FixedUpdate()
    {
        MoveToCenterPos();
        isInCell();
    }

    // 오브젝트를 curCell의 중간지점으로 옮긴다. curCell은 OnTriggerEnter에서 현재 속해있는 Cell로 설정한다.
    private void MoveToCenterPos()
    {
        if (curCell != null)
        {
            transform.position = Vector3.Lerp(transform.position, curCell.gameObject.transform.position, 0.1f);
        }
    }


    public void isInCell()
    {
        //m_HitDetect = Physics.BoxCast(transform.position, transform.lossyScale * 10f, myVec, out m_Hit, transform.rotation, m_MaxDistance, LayerMask.GetMask("Cell"));
        m_HitDetect = Physics.SphereCast(transform.position, 5f, transform.forward, out m_Hit, 5, LayerMask.GetMask("Cell"));

        if (m_HitDetect)
        {
            print("in");
        }

        //RaycastHit hit;
        //Ray ray = Camera.screenp
        //if(Physics.Raycast(Camera.main.gameObject.transform.position, transform.position, Mathf.Infinity, LayerMask.GetMask("Cell")))
        //{
        //    print("in");
        //}

        //Physics.box
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, myVec * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + myVec * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, myVec * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + myVec * m_MaxDistance, transform.localScale);
        }
    }












    // Cell로 진입하면 해당 Cell을 curCell로 설정하고 해당 Cell의 isOccupied를 true로 설정한다.
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Cell"))
    //    {
    //        curCell = other.gameObject.GetComponent<Cell>();
    //        curCell.icon = this;
    //        //curCell.isOccupied = true;
    //    }
    //}

    // Cell을 빠져나가면 isOccupied를 false로 설정한다.
    // 완전히 전체 Frame을 빠져나가면 curCell을 null로 설정하여 아이콘을 놓았을 때 가운데로 가게 하지 않는다.
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Cell"))
    //    {
    //        Cell cell = other.gameObject.GetComponent<Cell>();
    //        cell.isOccupied = false;
    //        cell.icon = null;
    //    }

    //    if(other.gameObject.CompareTag("Frame"))
    //    {
    //        curCell = null;
    //    }
    //}

    // 최대한 간단하게 구현하려 노력했다.
    // Frame을 설정하기 전에 어떻게 curCell을 null시키는지에 대한 문제(Frame안에서 놀때는 curCell 전환이 잘 되었지만 Frame 밖으로 나가면 curCell이 여전히 남아있는 문제)
    // 가 발생하여 RayCasting, OnTriggerStay, Cell을 감싸는 투명 Frame설정 등 여러 방법을 고민했지만 Cell을 둘러싼 Frame을 설정하는 것이 가장 간편하다고 여겨서 
    // 현재처럼 구현하였다.
}
