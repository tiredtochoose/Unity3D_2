﻿using UnityEngine;
using System;


namespace My3DProject
{
    [Serializable]
    public struct SerializableGameObject
    {
        public string Name;
        public SerializableVector3 Pos;
        public SerializableQuaternion Rot;
        public SerializableVector3 Scale;
    }

    [Serializable]
    public struct SerializableVector3
    {
        public float X;
        public float Y;
        public float Z;

        public SerializableVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3(SerializableVector3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator SerializableVector3(Vector3 value)
        {
            return new SerializableVector3(value.x, value.y, value.z);
        }

    }

     [Serializable]
    public struct SerializableQuaternion
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public SerializableQuaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        public static implicit operator Quaternion(SerializableQuaternion value)
        {
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }
        public static implicit operator SerializableQuaternion(Quaternion value)
        {
            return new SerializableQuaternion(value.x, value.y, value.z, value.w);
        }
    }

}
