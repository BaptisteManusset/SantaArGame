using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;


public class OBJExporter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void ExportToOBJ(GameObject meshToExport)
	{
        string filepath = Application.persistentDataPath + "/" + meshToExport.name + ".obj";

        AndroidHelper.ShowAndroidToastMessage("Exporting mesh...");
        StringBuilder sb = new StringBuilder();
        int startVertex = 0;

        
            Mesh mesh = meshToExport.GetComponent<MeshFilter>().mesh;
            int meshVertices = 0;
            sb.Append(string.Format("g {0}\n", meshToExport.name));

            // Vertices.
            for (int i = 0; i < mesh.vertices.Length; i++)
            {
                meshVertices++;
                Vector3 v = meshToExport.transform.TransformPoint(mesh.vertices[i]);

                // Include vertex colors as part of vertex point for applications that support it.
                if (mesh.colors32.Length > 0)
                {
                    float r = mesh.colors32[i].r / 255.0f;
                    float g = mesh.colors32[i].g / 255.0f;
                    float b = mesh.colors32[i].b / 255.0f;
                    sb.Append(string.Format("v {0} {1} {2} {3} {4} {5} 1.0\n", v.x, v.y, v.z, r, g, b));
                }
                else
                {
                    sb.Append(string.Format("v {0} {1} {2} 1.0\n", v.x, v.y, v.z));
                }
            }

            sb.Append("\n");

            // Normals.
            if (mesh.normals.Length > 0)
            {
                foreach (Vector3 n in mesh.normals)
                {
                    sb.Append(string.Format("vn {0} {1} {2}\n", n.x, n.y, n.z));
                }

                sb.Append("\n");
            }

            // Texture coordinates.
            if (mesh.uv.Length > 0)
            {
                foreach (Vector3 uv in mesh.uv)
                {
                    sb.Append(string.Format("vt {0} {1}\n", uv.x, uv.y));
                }

                sb.Append("\n");
            }

            // Faces.
            int[] triangles = mesh.triangles;
            for (int j = 0; j < triangles.Length; j += 3)
            {
                int v1 = triangles[j + 2] + 1 + startVertex;
                int v2 = triangles[j + 1] + 1 + startVertex;
                int v3 = triangles[j] + 1 + startVertex;

                // Filter out single vertex index triangles which cause Maya to not be able to
                // import the mesh.
                if (v1 != v2 || v2 != v3)
                {
                    sb.Append(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n", v1, v2, v3));
                }
            }

            sb.Append("\n");
            startVertex += meshVertices;
        

        StreamWriter sw = new StreamWriter(filepath);
        sw.AutoFlush = true;
        sw.Write(sb.ToString());
        AndroidHelper.ShowAndroidToastMessage(string.Format("Exported: {0}", filepath));

    }
}
