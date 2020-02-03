﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace EFCore.TextTemplating
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class MyEntityTypeGenerator : EFCore.TextTemplating.MyCodeGeneratorBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.ComponentModel.Dat" +
                    "aAnnotations;\r\n\r\nnamespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            this.Write("\r\n{\r\n");

    var entityTypeComment = EntityType.GetComment();
    if (entityTypeComment != null)
    {

            this.Write("    /// <summary>\r\n    /// ");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityTypeComment));
            this.Write("\r\n    /// </summary>\r\n");

    }


            this.Write("    public partial class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityType.Name));
            this.Write("\r\n    {\r\n");

    foreach (var property in EntityType.GetProperties().OrderBy(p => p["Scaffolding:ColumnOrdinal"]))
    {
        var propertyComment = property.GetComment();
        if (propertyComment != null)
        {

            this.Write("        /// <summary>\r\n        /// ");
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyComment));
            this.Write("\r\n        /// </summary>\r\n");

        }

        if (!property.IsNullable
            && (!property.ClrType.IsValueType
                || property.ClrType.IsGenericType
                && property.ClrType.GetGenericTypeDefinition() == typeof(Nullable<>))
            && !property.IsPrimaryKey())
        {

            this.Write("        [Required]\r\n");

        }

        var maxLength = property.GetMaxLength();
        if (maxLength.HasValue)
        {
            if (property.ClrType == typeof(string))
            {

            this.Write("        [StringLength(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(maxLength.Value)));
            this.Write(")]\r\n");

            }
            else
            {

            this.Write("        [MaxLength(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(maxLength.Value)));
            this.Write(")]\r\n");

            }
        }

            this.Write("        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Reference(property.ClrType)));
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            this.Write(" { get; set; }\r\n\r\n");

    }

    foreach (var navigation in EntityType.GetNavigations())
    {
        var targetTypeName = navigation.GetTargetType().Name;

        if (navigation.IsCollection())
        {

            this.Write("        public virtual ICollection<");
            this.Write(this.ToStringHelper.ToStringWithCulture(targetTypeName));
            this.Write("> ");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigation.Name));
            this.Write(" { get; } = new HashSet<");
            this.Write(this.ToStringHelper.ToStringWithCulture(targetTypeName));
            this.Write(">();\r\n\r\n");

        }
        else
        {

            this.Write("        public virtual ");
            this.Write(this.ToStringHelper.ToStringWithCulture(targetTypeName));
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigation.Name));
            this.Write(" { get; set; }\r\n\r\n");

        }
    }

            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }

private global::Microsoft.EntityFrameworkCore.Metadata.IEntityType _EntityTypeField;

/// <summary>
/// Access the EntityType parameter of the template.
/// </summary>
private global::Microsoft.EntityFrameworkCore.Metadata.IEntityType EntityType
{
    get
    {
        return this._EntityTypeField;
    }
}

private string _NamespaceField;

/// <summary>
/// Access the Namespace parameter of the template.
/// </summary>
private string Namespace
{
    get
    {
        return this._NamespaceField;
    }
}

private bool _UseDataAnnotationsField;

/// <summary>
/// Access the UseDataAnnotations parameter of the template.
/// </summary>
private bool UseDataAnnotations
{
    get
    {
        return this._UseDataAnnotationsField;
    }
}

private global::Microsoft.EntityFrameworkCore.Design.ICSharpHelper _CodeField;

/// <summary>
/// Access the Code parameter of the template.
/// </summary>
private global::Microsoft.EntityFrameworkCore.Design.ICSharpHelper Code
{
    get
    {
        return this._CodeField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public override void Initialize()
{
    base.Initialize();
    if ((this.Errors.HasErrors == false))
    {
bool EntityTypeValueAcquired = false;
if (this.Session.ContainsKey("EntityType"))
{
    this._EntityTypeField = ((global::Microsoft.EntityFrameworkCore.Metadata.IEntityType)(this.Session["EntityType"]));
    EntityTypeValueAcquired = true;
}
if ((EntityTypeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("EntityType");
    if ((data != null))
    {
        this._EntityTypeField = ((global::Microsoft.EntityFrameworkCore.Metadata.IEntityType)(data));
    }
}
bool NamespaceValueAcquired = false;
if (this.Session.ContainsKey("Namespace"))
{
    this._NamespaceField = ((string)(this.Session["Namespace"]));
    NamespaceValueAcquired = true;
}
if ((NamespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Namespace");
    if ((data != null))
    {
        this._NamespaceField = ((string)(data));
    }
}
bool UseDataAnnotationsValueAcquired = false;
if (this.Session.ContainsKey("UseDataAnnotations"))
{
    this._UseDataAnnotationsField = ((bool)(this.Session["UseDataAnnotations"]));
    UseDataAnnotationsValueAcquired = true;
}
if ((UseDataAnnotationsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("UseDataAnnotations");
    if ((data != null))
    {
        this._UseDataAnnotationsField = ((bool)(data));
    }
}
bool CodeValueAcquired = false;
if (this.Session.ContainsKey("Code"))
{
    this._CodeField = ((global::Microsoft.EntityFrameworkCore.Design.ICSharpHelper)(this.Session["Code"]));
    CodeValueAcquired = true;
}
if ((CodeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Code");
    if ((data != null))
    {
        this._CodeField = ((global::Microsoft.EntityFrameworkCore.Design.ICSharpHelper)(data));
    }
}


    }
}


    }
}
