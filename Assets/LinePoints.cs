using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoints : MonoBehaviour
{
    Vector2 Direction;
    public float force;
    public GameObject pointPrefab;

    public Transform ShootPoint;
    public GameObject[] Points;
    public int numberOfPoints;
    // Start is called before the first frame update
    void Start()
    {
        Points = new GameObject[numberOfPoints];
        for(int i = 0; i < numberOfPoints; i++ )
        {
            Points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 canonPos = ShootPoint.transform.position;
        Direction = mousePos - canonPos;
        faceMouse();
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
        }
    }
    void faceMouse()
    {
        ShootPoint.transform.right = Direction;
    }
    Vector2 PointPosition(float t)
    {
        Vector2 currentPos = (Vector2)ShootPoint.transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPos;
    }
}
