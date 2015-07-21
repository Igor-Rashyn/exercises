using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    abstract class iDS
    {
        public iDS Next;

        //public void SetNext(iDS ds)
        //{
        //    this.Next = ds;
        //}


        //iDS Next  { get; set; }
        /// <summary>
        /// Save to File
        /// </summary>
        /// <param name="b">Bitmap Picture</param>
        /// <param name="fileName">Filename</param>
      public abstract  void Save(Bitmap b, string fileName); // в файл
       /// <summary>
       /// Load from file
       /// </summary>
       /// <param name="fileName"> File name</param>
       /// <returns>Bitmap Picture</returns>
      public abstract Bitmap Load(string fileName);
       /// <summary>
        /// Implementing Factory Method
       /// </summary>
       /// <param name="fileName">File name</param>
       /// <returns>Interface iDS</returns>
      public abstract iDS Get(string fileName); 
        /// <summary>
        /// Implementing Chain-of-responsibility pattern
        /// </summary>
        /// <param name="extension">File name</param>
        /// <returns>Interface iDS</returns>
      public abstract iDS IsReady(string extension); 
    }
}
