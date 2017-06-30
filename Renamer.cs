using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace renamer
{
   
    class Renamer
        {
        string extension = null;
        List<string> files = new List<string>();
        string location = null;

        static void Main(string[] args)
        {
            try
            {
                Renamer rename = new Renamer();
                rename.location = (string)args[0];
                rename.extension = (string)args[1];

                rename.rename();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
                return;
            }
         
        }

        public void rename()
        {
            this.files =  System.IO.Directory.GetFiles(location).ToList();
            Directory.CreateDirectory(this.location + "\\New");

            foreach (string item in files) {
                string filename = Path.GetFileNameWithoutExtension(item);
                string new_location = this.location + "\\New";
                File.Copy(item, new_location + "\\" + filename + this.extension , true);
            }
        
        }
    }
}
