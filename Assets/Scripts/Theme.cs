using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Theme : MonoBehaviour
{
    public GameObject leftCorner;
    public GameObject rightCorner;
    public GameObject floor;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject leftWall2;
    public GameObject rightWall2;
    public GameObject platforms;

    int themeIdx = 11;
    [SerializeField] string[] themeNames = new string[12];

    void Start()
    {
        // get theme
        StreamReader reader = new StreamReader("theme.dat");
        themeIdx = int.Parse(reader.ReadToEnd());
        reader.Close();

        Debug.Log(themeIdx);

        // get materials based on themeNames & themeIdx
        Material corner = Resources.Load($"Themes/{themeNames[themeIdx]}Corner", typeof(Material)) as Material;
        Material floorMat = Resources.Load($"Themes/{themeNames[themeIdx]}Floor", typeof(Material)) as Material;
        Material platform = Resources.Load($"Themes/{themeNames[themeIdx]}Platform", typeof(Material)) as Material;
        Material wall = Resources.Load($"Themes/{themeNames[themeIdx]}Wall", typeof(Material)) as Material;

        // set platforms theme
        foreach (Transform child in platforms.transform)
        {
            child.gameObject.GetComponent<MeshRenderer>().material = platform;
        }

        leftCorner.GetComponent<MeshRenderer>().material = corner;
        rightCorner.GetComponent<MeshRenderer>().material = corner;
        floor.GetComponent<MeshRenderer>().material = floorMat;
        leftWall.GetComponent<MeshRenderer>().material = wall;
        leftWall2.GetComponent<MeshRenderer>().material = wall;
        rightWall.GetComponent<MeshRenderer>().material = wall;
        rightWall2.GetComponent<MeshRenderer>().material = wall;
    }
}
