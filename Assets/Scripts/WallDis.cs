using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDis : MonoBehaviour
{
    [SerializeField] private GameObject chuchelo;
    [SerializeField] private GameObject wall;

    private void Update()
    {
        if (!chuchelo)
        {
            wall.SetActive(false);
        }
    }


}
