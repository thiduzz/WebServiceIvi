using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WebServiceIvi
{
    [Serializable]
    public class OptEmailWeb 
    {
        List<OptEmail> _optemails;

        public OptEmailWeb(List<OptEmail> optemails)
        {
            _optemails = optemails;
        }

        public OptEmailWeb()
        {
           List<OptEmail> _optemails = new List<OptEmail>();
        }

        public List<OptEmail> UserOptEmail
        {
            set { _optemails = value; }
            get { return _optemails;  }
        }
    }
}
