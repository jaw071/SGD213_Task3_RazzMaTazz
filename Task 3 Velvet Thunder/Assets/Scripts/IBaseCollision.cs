using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IBaseCollision
{ 
    public abstract void OnTriggerEnter2D(Collider2D col);

    public abstract void OnCollisionEnter2D(Collision2D col);
}
