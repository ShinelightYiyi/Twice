using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    private  string name;
    private  string path;
    public  string Name { get => name; }
    public  string Path { get => path; }

    public  UIType(string uiName,string uiPath)
    {
        name = uiName;
        path = uiPath;  
    }
}
