using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbMonitor
{
    /// <summary>
    /// Specifies a description for a property or event.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        //
        // Summary:
        //     Specifies the default value for the System.ComponentModel.DescriptionAttribute,
        //     which is an empty string (""). This static field is read-only.
        public static readonly DescriptionAttribute Default;

        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DescriptionAttribute
        //     class with no parameters.
        public DescriptionAttribute()
        { }

        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DescriptionAttribute
        //     class with a description.
        //
        // Parameters:
        //   description:
        //     The description text.
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        //
        // Summary:
        //     Gets the description stored in this attribute.
        //
        // Returns:
        //     The description stored in this attribute.
        public virtual string Description { get; }
        //
        // Summary:
        //     Gets or sets the string stored as the description.
        //
        // Returns:
        //     The string stored as the description. The default value is an empty string ("").
        protected string DescriptionValue { get; set; }

        //
        // Summary:
        //     Returns whether the value of the given object is equal to the current System.ComponentModel.DescriptionAttribute.
        //
        // Parameters:
        //   obj:
        //     The object to test the value equality of.
        //
        // Returns:
        //     true if the value of the given object is equal to that of the current; otherwise,
        //     false.
        //public override bool Equals(object obj);
        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     A 32-bit signed integer hash code.
        //public override int GetHashCode();
        //
        // Summary:
        //     Returns a value indicating whether this is the default System.ComponentModel.DescriptionAttribute
        //     instance.
        //
        // Returns:
        //     true, if this is the default System.ComponentModel.DescriptionAttribute instance;
        //     otherwise, false.
        //public override bool IsDefaultAttribute();
    }
}
