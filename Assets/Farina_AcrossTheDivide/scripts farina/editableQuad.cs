using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class editableQuad : MonoBehaviour
{

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;
    Mesh mesh;
    public int xSize = 4;
    public int ySize = 4;


    public GameObject corner1;
    public GameObject corner2;
    public GameObject corner3;
    public GameObject corner4;
   
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }


    void CreateShape()
    {
        /*
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        
        for (int i = 0,y = 0; y <= ySize; y++)
        {
            for( int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, y, 0);
                i++;
            }
        }
        */

        
        vertices = new Vector3[]
            {
                //new Vector3(corner1.transform.worldToLocalMatrix.
               // new Vector3(corner1.transform.position),
                new Vector3(corner1.transform.position.x,corner1.transform.position.y,corner1.transform.position.z),
                new Vector3(corner2.transform.position.x,corner2.transform.position.y,corner2.transform.position.z),
                new Vector3(corner3.transform.position.x,corner3.transform.position.y,corner3.transform.position.z),
                new Vector3(corner4.transform.position.x,corner4.transform.position.y,corner4.transform.position.z)




                /*
                new Vector3(0,0,0),
                new Vector3(0,1,0),
                new Vector3(1,0,0),
                new Vector3(1,1,0)
                */
            };
        
        triangles = new int[]
            {
                0,1,2,
                1,3,2
            };

        uvs = new Vector2[]
            {

                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };
        

    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }


    // Update is called once per frame
    void Update()
    {
        CreateShape();
        UpdateMesh();
    }
}
