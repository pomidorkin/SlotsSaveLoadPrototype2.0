using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class VehicleDecriptor
{

    public List<ModuleDescriptor> Modules = new List<ModuleDescriptor>();

    public void AddModule(ModuleDescriptor moduleDescriptor)
    {
        Modules.Add(moduleDescriptor);
    }

    public List<ModuleDescriptor> GetModules()
    {
        return Modules;
    }
}
