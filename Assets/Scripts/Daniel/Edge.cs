/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System;
using UnityEngine;

[Serializable]
public class Edge
{
    [SerializeField]
    private Transform first;
    [SerializeField]
    private Transform second;

    public Transform First
    {
        get { return first; }
        set { first = value; }
    }

    public Transform Second
    {
        get { return second; }
        set { second = value; }
    }
}
