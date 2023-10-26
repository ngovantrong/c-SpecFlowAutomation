﻿using System;
using System.IO;

namespace FINWebUIAutomation.Support
{
    class FileSupport
    {
        public static string GetCompleteFilePath(string fileInternalPath)
        {
            var enviroment = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            return projectDirectory.Replace("\\bin", $"\\{fileInternalPath}");
        }


    }

}
