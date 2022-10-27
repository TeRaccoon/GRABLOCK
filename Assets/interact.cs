using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class interact : MonoBehaviour
{
    GameObject cube;
    Material[] materials = new Material[56];
    public Texture m_MainTexture, m_Normal, m_Metal;
    Vector3 target;

    void Start()
    {
        cube = GameObject.Find("Cube");

        materials[0] = new Material(Shader.Find("Standard"));
        for (int i = 0; i < 54; i++)
        {
            materials[i] = new Material(Shader.Find("Standard"));
            StartCoroutine(GetTexture(i));
        }
        GenerateCube();
    }
    IEnumerator GetTexture(int pictureCounter)
    {
        UnityWebRequest www = new UnityWebRequest("http://localhost/Res/" + pictureCounter + ".jpg");
        DownloadHandlerTexture textD = new DownloadHandlerTexture();
        www.downloadHandler = textD;
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            materials[pictureCounter].mainTexture = textD.texture;
        }
    }
    private void GenerateCube()
    {
        GameObject[] cubeSides = new GameObject[56];
        GameObject cube = GameObject.Find("Cube");
        int globalCount = 0;

        int y = -5;
        int z = -5;
        int counter = 0;
        for (int i = 0; i < 9; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.SetParent(cube.transform);
            cube1.transform.position = new Vector3(7.5f, y, z);
            cube1.transform.localScale = new Vector3(0.1f, 5, 5);
            cube1.GetComponent<Renderer>().material = materials[globalCount];
            cube1.GetComponent<BoxCollider>().enabled = true;
            cube1.GetComponent<BoxCollider>().isTrigger = true;
            cube1.AddComponent<events>();
            globalCount++;
            y += 5;
            if (y == 10)
            {
                y = -5;
                z += 5;
            }
            cubeSides[counter] = cube1;
            counter++;
        }
        y = -5;
        z = -5;
        for (int i = 0; i < 9; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.SetParent(cube.transform);
            cube1.transform.position = new Vector3(-7.5f, y, z);
            cube1.transform.localScale = new Vector3(0.1f, 5, 5);
            cube1.GetComponent<Renderer>().material = materials[globalCount];
            cube1.GetComponent<BoxCollider>().enabled = true;
            cube1.GetComponent<BoxCollider>().isTrigger = true;
            cube1.AddComponent<events>();
            globalCount++;
            y += 5;
            if (y == 10)
            {
                y = -5;
                z += 5;
            }
            cubeSides[counter] = cube1;
            counter++;
        }
        int x = -5;
        z = -5;
        for (int i = 0; i < 9; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.SetParent(cube.transform);
            cube1.transform.position = new Vector3(x, 7.5f, z);
            cube1.transform.localScale = new Vector3(5, 0.1f, 5);
            cube1.GetComponent<Renderer>().material = materials[globalCount];
            cube1.GetComponent<BoxCollider>().enabled = true;
            cube1.GetComponent<BoxCollider>().isTrigger = true;
            cube1.AddComponent<events>();
            globalCount++;
            z += 5;
            if (z == 10)
            {
                z = -5;
                x += 5;
            }
            cubeSides[counter] = cube1;
            counter++;
        }
        x = -5;
        z = -5;
        for (int i = 0; i < 9; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.SetParent(cube.transform);
            cube1.transform.position = new Vector3(x, -7.5f, z);
            cube1.transform.localScale = new Vector3(5, 0.1f, 5);
            cube1.GetComponent<Renderer>().material = materials[globalCount];
            cube1.GetComponent<BoxCollider>().enabled = true;
            cube1.GetComponent<BoxCollider>().isTrigger = true;
            cube1.AddComponent<events>();
            globalCount++;
            z += 5;
            if (z == 10)
            {
                z = -5;
                x += 5;
            }
            cubeSides[counter] = cube1;
            counter++;
        }
        x = -5;
        y = -5;
        for (int i = 0; i < 9; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.SetParent(cube.transform);
            cube1.transform.position = new Vector3(x, y, 7.5f);
            cube1.transform.localScale = new Vector3(5, 5, 0.1f);
            cube1.GetComponent<Renderer>().material = materials[globalCount];
            cube1.GetComponent<BoxCollider>().enabled = true;
            cube1.GetComponent<BoxCollider>().isTrigger = true;
            cube1.AddComponent<events>();
            globalCount++;
            y += 5;
            if (y == 10)
            {
                y = -5;
                x += 5;
            }
            cubeSides[counter] = cube1;
            counter++;
        }
        x = -5;
        y = -5;
        for (int i = 0; i < 9; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.SetParent(cube.transform);
            cube1.transform.position = new Vector3(x, y, -7.5f);
            cube1.transform.localScale = new Vector3(5, 5, 0.1f);
            cube1.GetComponent<Renderer>().material = materials[globalCount];
            cube1.GetComponent<BoxCollider>().enabled = true;
            cube1.GetComponent<BoxCollider>().isTrigger = true;
            cube1.AddComponent<events>();
            globalCount++;
            x += 5;
            if (x == 10)
            {
                x = -5;
                y += 5;
            }
            cubeSides[counter] = cube1;
            counter++;
        }
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
