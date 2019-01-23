﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core_SpecFlow.Uteis
{
    class SeleniumPath
    {

        public static String getPathSeleniumDriver()
        {
            // Função para definir o path do diretório
            String strAppDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            //Função para reduzir em duas camadas a arvore do path
            var gparent = Directory.GetParent(Directory.GetParent(strAppDir).ToString());
            //Conversão var -> String
            String aux = gparent.ToString();

            //Concatenar Path diretorio + Path Drivers
            String strAppFolderData = ("C:\\chromedriver");


            return strAppFolderData; //+ strAppFolderData;
        }

    }
}
