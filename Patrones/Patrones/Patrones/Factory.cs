using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones
{
    abstract class Factory
    {
        public Factory()
        {

        }

        public FactoryObject getNewObject()
        {
            return new FactoryObject();
        }

        public class FactoryObject
        {

        }
    }
}
