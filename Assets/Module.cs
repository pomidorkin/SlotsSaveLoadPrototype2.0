using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    ModuleDescriptor moduleDescriptor;

    public void AssignModuleDescriptor(ModuleDescriptor md)
    {
        moduleDescriptor = md;
    }

    void Start()
    {
    }

    void Update()
    {

    }

    public ModuleDescriptor GetModuleDescriptor()
    {
        return moduleDescriptor;
    }
}
