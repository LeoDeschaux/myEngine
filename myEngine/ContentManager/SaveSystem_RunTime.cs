using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class SaveSystem_RunTime
    {
        //FIELDS
        public static IDictionary<string, string> data;

        public static void Init()
        {
            data = new Dictionary<string, string>();
        }
    }
}
