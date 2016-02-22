
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
        if (!maps[0].activeInHierarchy)
        {
            GameObject g = maps[0];
            maps.RemoveAt(0);
            maps.Add(g);
            return g;
        }

        GameObject obj = (GameObject)Instantiate(map);
        maps.Add(obj);
        return obj;
    }
    public GameObject GetRock()
    {
        if (!rocks[0].activeInHierarchy)
        {
            GameObject g = rocks[0];
            rocks.RemoveAt(0);
            rocks.Add(g);
            return g;
        }

        GameObject obj = (GameObject)Instantiate(rock);
        rocks.Add(obj);
        return obj;
    }
    public GameObject GetTree()
    {
        if (!trees[0].activeInHierarchy)
        {
            GameObject g = trees[0];
            trees.RemoveAt(0);
            trees.Add(g);
            return g;
        }
        GameObject obj = (GameObject)Instantiate(tree);
        trees.Add(obj);
        return obj;
    }
    public void SortDeactivated(List<GameObject> deactivated)
    {
        foreach(GameObject g in deactivated)
        {
            if (rocks.Contains(g))
            {
                rocks.Remove(g);
                g.SetActive(false);
                rocks.Insert(0, g);
            }
            else if (trees.Contains(g))
            {
                trees.Remove(g);
                g.SetActive(false);
                trees.Insert(0, g);
            }
        }
    }
}
    