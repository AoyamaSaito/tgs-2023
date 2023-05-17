using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generartor : MonoBehaviour
{
    //[SerializeField]
    //private float _generateTime = 2;
    [SerializeField]
    private GameObject _bulletSet;


    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Instantiate(_bulletSet, this.transform);
        }
    }

    //IEnumerator Generate()
    //{


    //    yield return new WaitForSeconds(_generateTime);
    //}
}
