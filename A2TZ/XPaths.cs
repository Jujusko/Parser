using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2TZ
{
    internal class XPaths
    {
        /// <summary>
        /// XPath 
        /// </summary>
        public const string NextPage = "//span[contains(@class,'x-btn-icon-el x-btn-icon-el-plain-toolbar-small x-tbar-page-next')]";
        public const string Pagination = "//span[@class='react-table-cell x-toolbar-text x-toolbar-item x-toolbar-text-default']";
        
        /// <summary>
        /// css selectors
        /// </summary>
        public const string Data = ".ag-body-container";
    }
}
