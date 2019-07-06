using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Registro
    {
        public string subject { get; set; }
        public string credValue { get; set; }
        public short grade { get; set; }

        public Registro(string Subject, string CredValue, short Grade)
        {
            subject = Subject;
            credValue = CredValue;
            grade = Grade;
        }
    }
}
