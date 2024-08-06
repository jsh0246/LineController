using System;
using UnityEngine;

public class Arrangement : MonoBehaviour
{
    private Cell[] Cells;
    private int xLen, yLen;

    private void Awake()
    {
        InitCells();
        //Rearrange();
    }

    private void FixedUpdate()
    {
        //Rearrange();
        //PushOne();
    }

    private void InitCells()
    {
        Cells = FindObjectsOfType<Cell>();
        Array.Sort(Cells, (a, b) =>
        {
            return a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex());
        });
    }

    private void Rearrange()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            print(Cells[i].name);
        }
    }

    private void PushOne()
    {
        if (Cells[2].isOccupied)
        {
            Cells[2].icon.transform.position = Vector3.Lerp(transform.position, Cells[3].gameObject.transform.position, 0.1f);
        }
    }
}
