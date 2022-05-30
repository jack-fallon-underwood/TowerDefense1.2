using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Debuff
{
    protected Monster target;

    private float duration;

    private float elapsed;

    public Debuff(Monster target, float duration)
    {
        this.target = target;
        this.duration = duration;
    }

    public virtual void Update()
    {
        elapsed += Time.deltaTime;
 
        if (elapsed >= duration)
        {
            Remove();
        }
    }

    public virtual void Remove()
    {
        if(target != null)
        {
            Debug.Log("forcryingoutloud");
        }
    }
}
