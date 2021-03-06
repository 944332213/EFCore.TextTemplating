﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 16.0.0.0
//  
//     对此文件的更改可能导致不正确的行为，如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace EFCore.TextTemplating
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using EFCore.TextTemplating.Addition;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class EntityTypeGenerator : EFCore.TextTemplating.CodeGeneratorBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("namespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ModelNamespace));
            this.Write("\r\n{\r\n    using System;\r\n    using System.Collections.Generic;\r\n    using System.C" +
                    "omponentModel;\r\n    using System.ComponentModel.DataAnnotations;\r\n    using Syst" +
                    "em.ComponentModel.DataAnnotations.Schema;\r\n");

        var usingNamespaceEndIndex = GenerationEnvironment.Length;

            this.Write("\r\n");

        var entityTypeComment = EntityType.GetComment();
        var hasEntityClassInfo = EntityClassInfo.TryGetInfo(ref entityTypeComment, out var entityClassInfo);
        if (entityTypeComment != null)
        {

            this.Write("    /// <summary>\r\n    /// ");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityTypeComment));
            this.Write("\r\n    /// </summary>\r\n    [Serializable]\r\n    [Description(@\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityTypeComment.Replace("\"","\"\"")));
            this.Write("\")]\r\n");

        }
    if(UseDataAnnotations)
    {
        var schema = EntityType.GetSchema();
        var scaffoldSchema = schema != null && schema != EntityType.Model.GetDefaultSchema();

        var tableName = EntityType.GetTableName();
        var isView = EntityType.FindAnnotation("Relational:ViewDefinition") != null;
        var scaffoldTable = scaffoldSchema || isView || tableName != (string)EntityType["Scaffolding:DbSetName"];
        if(!isView)
        {

            this.Write("    [Table(");
            this.Write(this.ToStringHelper.ToStringWithCulture(scaffoldSchema ? Code.Literal(schema) + ", " : string.Empty));
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(tableName)));
            this.Write(")]\r\n");

        }
    }

            this.Write("    public partial class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityClassName));
            this.Write("\r\n    {\r\n");

    var usingNamespaceSet = new HashSet<string>();
    if(hasEntityClassInfo && entityClassInfo.UsingNamespaces?.Any() == true)
    {
        foreach (var usingNamespace in entityClassInfo.UsingNamespaces)
        {
            usingNamespaceSet.Add(usingNamespace);
        }
    }

    foreach (var property in EntityType.GetProperties().OrderBy(p => p["Scaffolding:ColumnOrdinal"]))
    {
        var propertyComment = property.GetComment();
        var hasEntityPropertyInfo = EntityPropertyInfo.TryGetInfo(ref propertyComment, out var entityPropertyInfo);
        usingNamespaceSet.Add(entityPropertyInfo?.Enum?.UsingNamespace);
        if (propertyComment != null)
        {

            this.Write("        /// <summary>\r\n        /// ");
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyComment));
            this.Write("\r\n        /// </summary>\r\n        [Description(@\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyComment.Replace("\"","\"\"")));
            this.Write("\")]\r\n");

        }
    if(UseDataAnnotations)
    {
        if(property.IsPrimaryKey())
        {

            this.Write("        [Key]\r\n");

        }
        var columnProperties = new List<string>();
        var columnName = property.GetColumnName();
        if (columnName != property.Name)
        {
            columnProperties.Add($"{Code.Literal(columnName)}");
        }
        var columnType = (string)property["Relational:ColumnType"];
        if (columnType != null)
        {
            columnProperties.Add($"TypeName = {Code.Literal(columnType)}");
        }
        if(columnProperties.Any())
        {

            this.Write("        [Column(");
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(", ", columnProperties)));
            this.Write(")]\r\n");

        }
    }
        var propertyClrType = property.ClrType;
        var isNullableType = propertyClrType.IsGenericType && propertyClrType.GetGenericTypeDefinition() == typeof(Nullable<>);
        if (!property.IsNullable
            && (!property.ClrType.IsValueType || isNullableType)
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

        if (hasEntityPropertyInfo && entityPropertyInfo?.Attributes?.Any() == true)
        {
            foreach (var attribute in entityPropertyInfo.Attributes)
            {
                usingNamespaceSet.Add(attribute.UsingNamespace);

            this.Write("        [");
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Code));
            this.Write("]\r\n");

            }
        }

        var ignoreNullableType = isNullableType ? propertyClrType.GetGenericArguments()[0] : propertyClrType;
        if(ignoreNullableType == typeof(DateTime))
        {
            ignoreNullableType = typeof(DateTimeOffset);
            propertyClrType = isNullableType ? typeof(DateTimeOffset?) : typeof(DateTimeOffset);
        }
        var propertyClrTypeName = hasEntityPropertyInfo && entityPropertyInfo?.Enum != null
            ? isNullableType
                ? string.Concat(entityPropertyInfo.Enum.Name, "?")
                : entityPropertyInfo.Enum.Name
            : Code.Reference(propertyClrType);

            this.Write("        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyClrTypeName));
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            this.Write(" { get; set; }\r\n\r\n");

    }

    if(usingNamespaceSet.Any())
    {
        foreach (var usingNamespace in usingNamespaceSet)
        {
            if(string.IsNullOrWhiteSpace(usingNamespace))
            {
                continue;
            }
            var value = usingNamespace;
            var prefix = "using ";
            var thus = "    ";
            if (!value.Trim().StartsWith(prefix))
            {
                value = string.Concat(thus, prefix, value);
            }

            var suffix = ";";
            if (!value.Trim().EndsWith(suffix))
            {
                value = string.Concat(value, suffix);
            }
            value += "\r\n";

            GenerationEnvironment.Insert(usingNamespaceEndIndex, value);
            usingNamespaceEndIndex += value.Length;
        }
    }

    foreach (var navigation in EntityType.GetNavigations())
    {
        var targetType = navigation.GetTargetType();
        var targetTypeName = GetEntityClassName(targetType);

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

private string _ModelNamespaceField;

/// <summary>
/// Access the ModelNamespace parameter of the template.
/// </summary>
private string ModelNamespace
{
    get
    {
        return this._ModelNamespaceField;
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

private string _EntityNameField;

/// <summary>
/// Access the EntityName parameter of the template.
/// </summary>
private string EntityName
{
    get
    {
        return this._EntityNameField;
    }
}

private string _EntityClassNameField;

/// <summary>
/// Access the EntityClassName parameter of the template.
/// </summary>
private string EntityClassName
{
    get
    {
        return this._EntityClassNameField;
    }
}

private global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String> _GetEntityNameField;

/// <summary>
/// Access the GetEntityName parameter of the template.
/// </summary>
private global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String> GetEntityName
{
    get
    {
        return this._GetEntityNameField;
    }
}

private global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String> _GetEntityClassNameField;

/// <summary>
/// Access the GetEntityClassName parameter of the template.
/// </summary>
private global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String> GetEntityClassName
{
    get
    {
        return this._GetEntityClassNameField;
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
bool ModelNamespaceValueAcquired = false;
if (this.Session.ContainsKey("ModelNamespace"))
{
    this._ModelNamespaceField = ((string)(this.Session["ModelNamespace"]));
    ModelNamespaceValueAcquired = true;
}
if ((ModelNamespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ModelNamespace");
    if ((data != null))
    {
        this._ModelNamespaceField = ((string)(data));
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
bool EntityNameValueAcquired = false;
if (this.Session.ContainsKey("EntityName"))
{
    this._EntityNameField = ((string)(this.Session["EntityName"]));
    EntityNameValueAcquired = true;
}
if ((EntityNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("EntityName");
    if ((data != null))
    {
        this._EntityNameField = ((string)(data));
    }
}
bool EntityClassNameValueAcquired = false;
if (this.Session.ContainsKey("EntityClassName"))
{
    this._EntityClassNameField = ((string)(this.Session["EntityClassName"]));
    EntityClassNameValueAcquired = true;
}
if ((EntityClassNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("EntityClassName");
    if ((data != null))
    {
        this._EntityClassNameField = ((string)(data));
    }
}
bool GetEntityNameValueAcquired = false;
if (this.Session.ContainsKey("GetEntityName"))
{
    this._GetEntityNameField = ((global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String>)(this.Session["GetEntityName"]));
    GetEntityNameValueAcquired = true;
}
if ((GetEntityNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("GetEntityName");
    if ((data != null))
    {
        this._GetEntityNameField = ((global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String>)(data));
    }
}
bool GetEntityClassNameValueAcquired = false;
if (this.Session.ContainsKey("GetEntityClassName"))
{
    this._GetEntityClassNameField = ((global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String>)(this.Session["GetEntityClassName"]));
    GetEntityClassNameValueAcquired = true;
}
if ((GetEntityClassNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("GetEntityClassName");
    if ((data != null))
    {
        this._GetEntityClassNameField = ((global::System.Func<Microsoft.EntityFrameworkCore.Metadata.IEntityType, System.String>)(data));
    }
}


    }
}


    }
}
