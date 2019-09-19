﻿/****************************************************************************
 * Copyright (c) 2018.3 布鞋 827922094@qq.com
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

using UnityEngine;
using QFramework;

public class PoolTest :IPoolable
{
    public static int Index=0;
    private int CurrentIndex;


    private ResLoader mResLoader = ResLoader.Allocate();

    private void Start()
    {
        ResMgr.Init();

       

        //mResLoader.LoadSync<GameObject>("AssetObj")
        //    .Instantiate()
        //    .Name("这是使用通过 AssetName 加载的对象");

        //mResLoader.LoadSync<GameObject>("assetobj_prefab", "AssetObj")
        //    .Instantiate()
        //    .Name("这是使用通过 AssetName  和 AssetBundle 加载的对象");
    }


    public PoolTest()
    {
        Index++;
        CurrentIndex = Index;
        Debug.Log("创建");
        mResLoader.LoadSync<GameObject>("Resources/TestPool")
              .Instantiate()
              .Name("这是使用ResKit加载的对象");
     

    }

    public void DebugIndex()
    {
        Debug.Log("当前"+ CurrentIndex);
    }

    public void OnRecycled()
    {
        CurrentIndex = 0;
    }

    private bool isrecyscled;
    public bool IsRecycled { get { return isrecyscled; } set { isrecyscled = value; } }

}
