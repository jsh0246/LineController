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

    // ? // �ʿ��� ���� Call back �ϴ� ���? �Ź� �˻��ϴ°� �ƴ�?
    private void FixedUpdate()
    {
        MoveToCenterPos();
        isInCell();
    }

    // ������Ʈ�� curCell�� �߰��������� �ű��. curCell�� OnTriggerEnter���� ���� �����ִ� Cell�� �����Ѵ�.
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












    // Cell�� �����ϸ� �ش� Cell�� curCell�� �����ϰ� �ش� Cell�� isOccupied�� true�� �����Ѵ�.
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Cell"))
    //    {
    //        curCell = other.gameObject.GetComponent<Cell>();
    //        curCell.icon = this;
    //        //curCell.isOccupied = true;
    //    }
    //}

    // Cell�� ���������� isOccupied�� false�� �����Ѵ�.
    // ������ ��ü Frame�� ���������� curCell�� null�� �����Ͽ� �������� ������ �� ����� ���� ���� �ʴ´�.
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

    // �ִ��� �����ϰ� �����Ϸ� ����ߴ�.
    // Frame�� �����ϱ� ���� ��� curCell�� null��Ű������ ���� ����(Frame�ȿ��� ��� curCell ��ȯ�� �� �Ǿ����� Frame ������ ������ curCell�� ������ �����ִ� ����)
    // �� �߻��Ͽ� RayCasting, OnTriggerStay, Cell�� ���δ� ���� Frame���� �� ���� ����� ��������� Cell�� �ѷ��� Frame�� �����ϴ� ���� ���� �����ϴٰ� ���ܼ� 
    // ����ó�� �����Ͽ���.
}
