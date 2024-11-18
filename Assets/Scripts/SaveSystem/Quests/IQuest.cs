using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuest 
{
    public string Description { get; }
    bool Complete { get; set; }
}
