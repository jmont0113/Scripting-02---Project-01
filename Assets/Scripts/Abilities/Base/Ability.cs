﻿using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour
{
    public abstract void Use(Transform origin, Transform target);
}