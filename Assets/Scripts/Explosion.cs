using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject,1); // animasyon oynadıktan 2 saniye sonra destroy
    }

    
}
