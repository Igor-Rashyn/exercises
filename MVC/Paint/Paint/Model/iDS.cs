using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
   public interface iDS
    {
        iDS Next  { get; set; }
        /// <summary>
        /// Save to File
        /// </summary>
        /// <param name="b">Bitmap Picture</param>
        /// <param name="fileName">Filename</param>
        void Save(Bitmap b, string fileName); // в файл
       /// <summary>
       /// Load from file
       /// </summary>
       /// <param name="fileName"> File name</param>
       /// <returns>Bitmap Picture</returns>
        Bitmap Load(string fileName);
       /// <summary>
        /// Implementing Factory Method
       /// </summary>
       /// <param name="fileName">File name</param>
       /// <returns>Interface iDS</returns>
        iDS Get(string fileName); 
        /// <summary>
        /// Implementing Chain-of-responsibility pattern
        /// </summary>
        /// <param name="extension">File name</param>
        /// <returns>Interface iDS</returns>
        iDS IsReady(string extension); 
    }
}
