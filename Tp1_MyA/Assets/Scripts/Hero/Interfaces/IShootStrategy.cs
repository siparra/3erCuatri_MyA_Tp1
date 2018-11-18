using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IShootStrategy : MonoBehaviour
{
    public  virtual void Shoot() { }
    public virtual void Shoot(float fireRate) { }
}
