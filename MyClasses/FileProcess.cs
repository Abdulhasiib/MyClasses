using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyClasses
{
    public class FileProcess
    {
        public bool FileExists(string FileName)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                throw new ArgumentNullException("{0} file Name Invalid", FileName);
            }

            return File.Exists(FileName);
        }
    }
}
