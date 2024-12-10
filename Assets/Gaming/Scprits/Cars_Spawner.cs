using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars_Spawner : MonoBehaviour
{
    public GameObject vehicle1;
    public GameObject vehicle2;
    public GameObject vehicle3;
    public GameObject vehicle4;
    public GameObject vehicle5;
    public GameObject vehicle6;
    public GameObject vehicle7;
    public GameObject vehicle8;
    public GameObject vehicle9;
    public GameObject vehicle10;
    public GameObject vehicle11;
    public Transform swanpoint1;
    public Transform swanpoint2;
    public Transform swanpoint3;
    public Transform swanpoint4;
    public Transform swanpoint5;
    public Transform swanpoint6;
    public Transform swanpoint7;
    public Transform swanpoint8;
    public Transform swanpoint9;
    public Transform swanpoint10;
    public Transform swanpoint11;
    public Transform swanpoint12;
    public Transform swanpoint13;
    public Transform swanpoint14;
    public Transform swanpoint15;
    public Transform swanpoint16;
    public Transform swanpoint17;
    public Transform swanpoint18;
    public Transform swanpoint19;
    public Transform swanpoint20;
    public GameManager gameManager;
    Transform[] spawnpoints1;
    Transform[] spawnpoints2 = new Transform[0];
    int cars_numbered;
    int max;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.level == GameManager.Level.one)
        {
            cars_numbered = 2;
            max = 3;
        }
        else if (gameManager.level == GameManager.Level.two)
        {
            cars_numbered = 4;
            max = 4;
        }
        else if (gameManager.level == GameManager.Level.three)
        {
            cars_numbered = 6;
            max = 5;
        }
        else if (gameManager.level == GameManager.Level.four)
        {
            cars_numbered = 8;
            max = 6;
        }
        else if (gameManager.level == GameManager.Level.five)
        {
            cars_numbered = 10;
            max = 7;
        }
        else if (gameManager.level == GameManager.Level.six)
        {
            cars_numbered = 12;
            max = 8;
        }
        else if (gameManager.level == GameManager.Level.seven)
        {
            cars_numbered = 14;
            max = 9;
        }
        else if (gameManager.level == GameManager.Level.eight)
        {
            cars_numbered = 16;
            max = 10;
        }
        else if (gameManager.level == GameManager.Level.nine)
        {
            cars_numbered = 18;
            max = 11;
        }
        else if (gameManager.level == GameManager.Level.ten)
        {
            cars_numbered = 20;
            max = 12;
        }
        spawnpoints1 = new Transform[20] { swanpoint1, swanpoint2, swanpoint3, swanpoint4, swanpoint5, swanpoint6, swanpoint7, swanpoint8, swanpoint9, swanpoint10, swanpoint11, swanpoint12, swanpoint13, swanpoint14, swanpoint15, swanpoint16, swanpoint17, swanpoint18, swanpoint19, swanpoint20 };
        for (int i = 0; i < cars_numbered; i++)
        {
            Add_plane(spawnpoints1[i]);
        }

        for (int i = 0; i < spawnpoints2.Length; i++)
        {
            int random = UnityEngine.Random.Range(1, max);
            if (random == 1)
            {
                Instantiate(vehicle1, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 2)
            {
                Instantiate(vehicle2, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 3)
            {
                Instantiate(vehicle3, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 4)
            {
                Instantiate(vehicle4, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 5)
            {
                Instantiate(vehicle5, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 6)
            {
                Instantiate(vehicle6, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 7)
            {
                Instantiate(vehicle7, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 8)
            {
                Instantiate(vehicle8, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 9)
            {
                Instantiate(vehicle9, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 10)
            {
                Instantiate(vehicle10, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
            else if (random == 11)
            {
                Instantiate(vehicle11, spawnpoints2[i].position + new Vector3(UnityEngine.Random.Range(-4, 5), 0, UnityEngine.Random.Range(-10, 11)), Quaternion.AngleAxis(UnityEngine.Random.Range(0, 359), Vector3.up));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Add_plane(Transform xyz)
    {
        Array.Resize(ref spawnpoints2, spawnpoints2.Length + 1);
        spawnpoints2[spawnpoints2.Length - 1] = xyz;
    }
}
