using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FarmView
{
    class EnumBinding : MarkupExtension
    {
        public Type EnumType
        {
            get; set;
        }

        public EnumBinding(Type enumType)
        {
            this.EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == this.EnumType)
                throw new Exception("Must be enum type");

            Array enumValues = Enum.GetValues(EnumType);

            return enumValues;
        }
    }
}
