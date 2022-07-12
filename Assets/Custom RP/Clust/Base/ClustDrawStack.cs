using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CustomRP.Clust
{

    /// <summary>
    /// 自定义渲染管线的绘制栈，用于类似一般CPU的批处理，
    /// 逐个调用传入到执行栈中的Clust进行绘制，也就是所这个类不进行直接的绘制，
    /// 只是调用对应的渲染方法而已
    /// </summary>
    public class ClustDrawStack
    {
        private ClustDrawStack(){ }

        private static ClustDrawStack instance;
        public static ClustDrawStack Instance
        {
            get
            {
                if(instance == null) instance = new ClustDrawStack();
                return instance;
            }
        }

        /// <summary>
        /// 存储用的列表，因为是顺序读取，
        /// 因为经常需要插入和删除，所以使用链表
        /// </summary>
        private LinkedList<ClustBase> clustBases;

        /// <summary>
        /// 插入一个ClustBase对象，插入后就会正常绘制了
        /// </summary>
        /// <param name="clustBase">插入的对象</param>
        public void InsertClustBase(ClustBase clustBase)
        {
            if (clustBases == null)
                clustBases = new LinkedList<ClustBase>();
            if (clustBase == null) return;
            clustBases.AddLast(clustBase);
        }

        public void RemoveClustBase(ClustBase clustBase)
        {
            if (clustBase == null) return;
            clustBases.Remove(clustBase);
        }

        /// <summary>
        /// 调用所有加载中的ClustBase的通过摄像机进行裁剪的函数，使用重载，看见的使用函数只有一个，
        /// 方便记忆，而且之后拓展也方便
        /// </summary>
        public void DrawClustData(ScriptableRenderContext context,
            CommandBuffer buffer, ClustDrawType clustDrawSubPass, Camera camera)
        {
            if (clustBases == null) return;
            foreach(ClustBase index in clustBases)
            {
                index.DrawClustByCamera(context, buffer, clustDrawSubPass, camera);
            }
        }

        /// <summary>
        /// 调用所有加载中的ClustBase的通过矩阵进行裁剪的函数，使用重载，看见的使用函数只有一个，
        /// 方便记忆，而且之后拓展也方便
        /// </summary>
        public void DrawClustData(ScriptableRenderContext context,
            CommandBuffer buffer, ClustDrawType clustDrawSubPass, Matrix4x4 projectMatrix)
        {
            if (clustBases == null) return;
            foreach (ClustBase index in clustBases)
            {
                index.DrawClustByProjectMatrix(context, buffer,
                    clustDrawSubPass, projectMatrix);
            }
        }


    }
}