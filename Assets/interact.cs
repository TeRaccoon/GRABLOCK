using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class interact : MonoBehaviour
{
    Material[] materials = new Material[56];
    public Texture m_MainTexture, m_Normal, m_Metal;
    Vector3 target;
    int globalCount = 0;

    void Start()
    {
        for (int i = 0; i < 54; i++)
        {
            materials[i] = new Material(Shader.Find("Standard"));
            StartCoroutine(GetTexture(i));
        }
        GenerateCube();
    }
    IEnumerator GetTexture(int pictureCounter)
    {
        UnityWebRequest www = new("http://localhost/Res/" + pictureCounter + ".jpg");
        DownloadHandlerTexture textureDownload = new();
        www.downloadHandler = new DownloadHandlerTexture();
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            materials[pictureCounter].mainTexture = textureDownload.texture;
        }
    }
    private GameObject[] GenerateSide(GameObject[] cubeSides, float x, float y, float z, float scaleX, float scaleY, float scaleZ)
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.SetParent(cube.transform);
            cube1.transform.position = new Vector3(x, y, z);
            cube1.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            cube1.GetComponent<Renderer>().material = materials[globalCount];
            cube1.GetComponent<BoxCollider>().enabled = true;
            cube1.GetComponent<BoxCollider>().isTrigger = true;

            if (x == 7.5f || x == -7.5f)
            {
                y += 5;
                if (y == 10)
                {
                    y = -5;
                    z += 5;
                }
            }
            if (y == 7.5f || y == -7.5f)
            {
                z += 5;
                if (z == 10)
                {
                    z = -5;
                    x += 5;
                }
            }
            if (z == 7.5f || z == -7.5f)
            {
                x += 5;
                if (x == 10)
                {
                    x = -5;
                    y += 5;
                }
            }
            cubeSides[globalCount] = cube1;
            globalCount++;
        }
        return cubeSides;
    }
    private void GenerateCube()
    {
        GameObject[] cubeSides = new GameObject[56];
        GameObject cube = GameObject.Find("Cube");

        cubeSides = GenerateSide(cubeSides, 7.5f, -5, -5, 0.1f, 5, 5);
        cubeSides = GenerateSide(cubeSides, -7.5f, -5, -5, 0.1f, 5, 5);
        cubeSides = GenerateSide(cubeSides, -5, 7.5f, -5, 5, 0.1f, 5);
        cubeSides = GenerateSide(cubeSides, -5, -7.5f, -5, 5, 0.1f, 5);
        cubeSides = GenerateSide(cubeSides, -5, -5, 7.5f, 5, 5, 0.1f);
        cubeSides = GenerateSide(cubeSides, -5, -5, -7.5f, 5, 5, 0.1f);
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            target = new Vector3(-180, 180, 180);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            target = new Vector3(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            target = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            target = new Vector3(0, 270, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            target = new Vector3(135, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            target = new Vector3(-45, 0, 0);
        }
        cube.transform.rotation = Quaternion.Slerp(cube.transform.rotation, Quaternion.Euler(target.x, target.y, target.z), .01f);       
    }

}
