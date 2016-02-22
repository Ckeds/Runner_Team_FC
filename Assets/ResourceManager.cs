
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    public GameObject map;
    public GameObject rock;
    public GameObject tree;


    List<GameObject> maps;
    List<GameObject> rocks;
    List<GameObject> trees;

    // Use this for initialization
    public void Setup(int m, int r, int t)
    {
        maps = new List<GameObject>();
        rocks = new List<GameObject>();
        trees = new List<GameObject>();

        int i;
        for (i = 0; i < m; i++)
        {
            GameObject obj = (GameObject)Instantiate(map);
            obj.SetActive(false);
            maps.Add(obj);
        }
        for (i = 0; i < r; i++)
        {
            GameObject obj = (GameObject)Instantiate(rock);
            obj.SetActive(false);
            rocks.Add(obj);
        }
        for (i = 0; i < t; i++)
        {
            GameObject obj = (GameObject)Instantiate(tree);
            obj.SetActive(false);
            trees.Add(obj);
        }
    }
    public GameObject GetMap()
    {
        for (int i = 0; i < maps.Count; i++)
        {
            if (!maps[i].activeInHierarchy)
            {
                return maps[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(map);
        maps.Add(obj);
        return obj;
    }
    public GameObject GetRock()
    {
        for (int i = 0; i < rocks.Count; i++)
        {
            if (!rocks[i].activeInHierarchy)
            {
                return rocks[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(rock);
        rocks.Add(obj);
        return obj;
    }
    public GameObject GetTree()
    {
        for (int i = 0; i < trees.Count; i++)
        {
            if (!trees[i].activeInHierarchy)
            {
                return trees[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(tree);
        trees.Add(obj);
        return obj;
    }
}
    