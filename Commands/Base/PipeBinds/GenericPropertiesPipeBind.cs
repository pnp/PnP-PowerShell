using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Pages;
using SharePointPnP.PowerShell.Commands.ModernPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class GenericPropertiesPipeBind
    {
        private readonly Hashtable _hashtable;
        private string _jsonObject;

        public GenericPropertiesPipeBind(Hashtable hashtable)
        {
            _hashtable = hashtable;
            _jsonObject = null;
        }

        public GenericPropertiesPipeBind(string json)
        {
            _hashtable = null;
            _jsonObject = json;
        }

        public string Json => _jsonObject;

        public Hashtable Properties => _hashtable;

        public override string ToString() => Json ?? new JObject(_hashtable).ToString();
        
    }
}
