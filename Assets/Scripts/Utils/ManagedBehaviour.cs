using System.Collections.Generic;

public class ManagedBehaviour : ManagedBehaviourBase
{
    private bool initialized;

    public virtual bool UpdateWhenPaused => false;

    public void Initialize()
    {
        if (!initialized)
        {
            initialized = true;
            ManagedInitialize();
        }
    }

    public virtual void ManagedUpdate()
    {
    }

    public virtual void ManagedFixedUpdate()
    {
    }

    public virtual void ManagedLateUpdate()
    {
    }

    protected virtual void ManagedInitialize()
    {
    }

    public sealed override void Update()
    {
        if (CanUpdate())
        {
            ManagedUpdate();
        }
    }

    public sealed override void FixedUpdate()
    {
        if (CanUpdate())
        {
            ManagedFixedUpdate();
        }
    }

    public sealed override void LateUpdate()
    {
        if (CanUpdate())
        {
            ManagedLateUpdate();
        }
    }

    protected sealed override void Awake()
    {
        if (!initialized)
        {
            initialized = true;
            ManagedInitialize();
        }
    }

    private bool CanUpdate()
    {
        if (!UpdateWhenPaused)
        {
            //logic for pausing
        }
        return true;
    }
}

