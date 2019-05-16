/******************************************************************************
* File         : pLab_Clouds.cs
* Authors      : Toni Westerlund (toni.westerlund@lapinamk.fi),
* Lisence      : MIT Licence
* Copyright    : Lapland University of Applied Sciences
* 
 * MIT License
* 
 * Copyright (c) 2019 Lapland University of Applied Sciences
* 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
 * The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*****************************************************************************/
using UnityEngine;

/// <summary>
/// pLab_Clouds
/// </summary>
public class pLab_Clouds : MonoBehaviour {





    #region // SerializeField
    #endregion

    #region // Private Attributes

    #endregion

    #region // Class Attributes

    #endregion

    #region // Public Attributes

    /// <summary>
    /// How many mesh
    /// </summary>
    public int horizontalStackSize = 20;

    /// <summary>
    /// Height of Cloud planes
    /// </summary>
    public float cloudHeight = 1f;

    /// <summary>
    /// Orginal mesh
    /// </summary>
    public Mesh cloudMesh;

    /// <summary>
    /// Clould Material
    /// </summary>
    public Material cloudMaterial;

    /// <summary>
    /// Different Cloud layers offset
    /// </summary>
    private float offset;

    /// <summary>
    /// Main Camera
    /// </summary>
    public Camera camera;

    /// <summary>
    /// Cloud Matrix
    /// </summary>
    private Matrix4x4 matrix;

    /// <summary>
    /// Shadows Boolean
    /// </summary>
    public bool castShadows = false;

    #endregion

    #region // Protected Attributes

    #endregion

    #region // Set/Get

    #endregion

    #region // Base Class Methods

    /// <summary>
    /// Update()
    /// </summary>
    void Update() {

        cloudMesh = GetComponent<MeshFilter>().mesh;
        cloudMaterial.SetFloat("_midYValue", transform.position.y);
        cloudMaterial.SetFloat("_CloudHeights", cloudHeight);


        offset = cloudHeight / horizontalStackSize / 2f;
        Vector3 startPosition = transform.position + (Vector3.up * (offset * horizontalStackSize / 2f));


        for (int i = 0; i < horizontalStackSize; i++) {
            matrix = Matrix4x4.TRS(startPosition - (Vector3.up * offset * i), transform.rotation, transform.localScale);
            Graphics.DrawMesh(cloudMesh, matrix, cloudMaterial, 0, camera, 0, null, castShadows, false, false);
        }
    }
    #endregion

    #region // Private Methods
    #endregion

    #region // Public Methods


    #endregion




}