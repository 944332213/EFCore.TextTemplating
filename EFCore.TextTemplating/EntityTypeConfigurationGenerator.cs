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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using EFCore.TextTemplating.Addition;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class EntityTypeConfigurationGenerator : EFCore.TextTemplating.CodeGeneratorBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("namespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ConfigurationNamespace));
            this.Write("\r\n{\r\n    using Microsoft.EntityFrameworkCore;\r\n    using Microsoft.EntityFramewor" +
                    "kCore.Metadata.Builders;\r\n    using Microsoft.EntityFrameworkCore.Storage.ValueC" +
                    "onversion;\r\n    using ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ModelNamespace));
            this.Write(";\r\n");

        var usingNamespaceEndIndex = GenerationEnvironment.Length;

            this.Write("\r\n");

        var entityTypeComment = EntityType.GetComment();
        var originalEntityTypeComment = entityTypeComment?.ToString();
        var hasEntityClassInfo = EntityClassInfo.TryGetInfo(ref entityTypeComment, out var entityClassInfo);
        if (entityTypeComment != null)
        {

            this.Write("    /// <summary>\r\n    /// ");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityTypeComment));
            this.Write(" Configuration\r\n    /// </summary>\r\n");

        }

            this.Write("    public partial class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityConfigurationName));
            this.Write(" : IEntityTypeConfiguration<");
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityClassName));
            this.Write(">\r\n    {\r\n        /// <summary>\r\n        /// Configure\r\n        /// </summary>\r\n " +
                    "       public void Configure(EntityTypeBuilder<");
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityClassName));
            this.Write("> builder)\r\n        {\r\n");

    var primaryKey = EntityType.FindPrimaryKey();
    if (primaryKey == null)
    {

            this.Write("            builder.HasNoKey();\r\n\r\n");

    }
    else if (!Enumerable.SequenceEqual(
        primaryKey.Properties,
        KeyDiscoveryConvention.DiscoverKeyProperties(
            (IConventionEntityType)primaryKey.DeclaringEntityType,
            primaryKey.DeclaringEntityType.GetProperties().Cast<IConventionProperty>())))
    {

            this.Write("            builder.HasKey(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Lambda(primaryKey.Properties)));
            this.Write(")\r\n                .HasName(\"PRIMARY\");\r\n\r\n");

    }
    if(!UseDataAnnotations)
    {
        var schema = EntityType.GetSchema();
        var scaffoldSchema = schema != null && schema != EntityType.Model.GetDefaultSchema();

        var tableName = EntityType.GetTableName();
        var isView = EntityType.FindAnnotation("Relational:ViewDefinition") != null;
        var scaffoldTable = scaffoldSchema || isView || tableName != (string)EntityType["Scaffolding:DbSetName"];

        if (scaffoldTable)
        {

            this.Write("            builder.");
            this.Write(this.ToStringHelper.ToStringWithCulture(isView ? "ToView" : "ToTable"));
            this.Write("(");
            this.Write(this.ToStringHelper.ToStringWithCulture(scaffoldSchema ? Code.Literal(schema) + ", " : string.Empty));
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(tableName)));
            this.Write(");\r\n\r\n");

        }
    }
    if (originalEntityTypeComment != null)
    {

            this.Write("            builder.HasComment(@\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(originalEntityTypeComment.Replace("\"","\"\"")));
            this.Write("\");\r\n\r\n");

    }

    foreach (var index in EntityType.GetIndexes())
    {

            this.Write("            builder.HasIndex(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Lambda(index.Properties)));
            this.Write(")\r\n");

        if(index.IsUnique)
        {

            this.Write("                .IsUnique()\r\n");

        }

            this.Write("                .HasName(\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(index.GetName()));
            this.Write("\");\r\n\r\n");

    }
    
    var usingNamespaceSet = new HashSet<string>();
    foreach (var property in EntityType.GetProperties())
    {
        var originalGenerationEnvironment = GenerationEnvironment;
        GenerationEnvironment = new StringBuilder();

        var propertyComment = property.GetComment();
        var originalPropertyComment = propertyComment?.ToString();
        var hasEntityPropertyInfo = EntityPropertyInfo.TryGetInfo(ref propertyComment, out var entityPropertyInfo);
        
        var columnName = property.GetColumnName();
    if(!UseDataAnnotations)
    {
        if (columnName != property.Name)
        {

            this.Write("                .HasColumnName(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(columnName)));
            this.Write(")\r\n");

        }

        var columnType = (string)property["Relational:ColumnType"];
        if (columnType != null)
        {

            this.Write("                .HasColumnType(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(columnType)));
            this.Write(")\r\n");

        }

        if (hasEntityPropertyInfo && entityPropertyInfo.Attributes?.Any() == true)
        {
            if (entityPropertyInfo.Attributes.Any(item => item.Code == "DatabaseGenerated(DatabaseGeneratedOption.Identity)"))
            {

            this.Write("                .ValueGeneratedOnAdd()\r\n");
                
            }
            if (entityPropertyInfo.Attributes.Any(item => item.Code == "DatabaseGenerated(DatabaseGeneratedOption.Computed)"))
            {

            this.Write("                .ValueGeneratedOnAddOrUpdate()\r\n");
                
            }
            if (entityPropertyInfo.Attributes.Any(item => item.Code == "DatabaseGenerated(DatabaseGeneratedOption.None)"))
            {

            this.Write("                .ValueGeneratedNever()\r\n");
                
            }
        }
    }

        if (property.IsUnicode() == false)
        {

            this.Write("                .IsUnicode(false)\r\n");

        }

        if (property.IsFixedLength() == true)
        {

            this.Write("                .IsFixedLength()\r\n");

        }
        
        var propertyDefaultValue = property.GetDefaultValue();
        if (propertyDefaultValue != null)
        {

            this.Write("                .HasDefaultValue(");
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyDefaultValue));
            this.Write(")\r\n");

        }

        var propertyDefaultValueSql = property.GetDefaultValueSql();
        if(propertyDefaultValueSql != null)
        {

            this.Write("                .HasDefaultValueSql(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(propertyDefaultValueSql)));
            this.Write(")\r\n");

        }

        var propertyComputedColumnSql = property.GetComputedColumnSql();
        if (propertyComputedColumnSql != null)
        {

            this.Write("                .HasComputedColumnSql(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(propertyComputedColumnSql)));
            this.Write(")\r\n");

        }

        var valueGenerated = property.ValueGenerated;
        var isRowVersion = false;
        if (((IConventionProperty)property).GetValueGeneratedConfigurationSource().HasValue
            && valueGenerated != RelationalValueGenerationConvention.GetValueGenerated(property))
        {
            if (valueGenerated == ValueGenerated.OnAddOrUpdate
                && property.IsConcurrencyToken)
            {
                isRowVersion = true;

            this.Write("                .IsRowVersion()\r\n");

            }
            else
            {

            this.Write("                .ValueGenerated");
            this.Write(this.ToStringHelper.ToStringWithCulture(valueGenerated));
            this.Write("()\r\n");

            }
        }

        if (property.IsConcurrencyToken && !isRowVersion)
        {

            this.Write("                .IsConcurrencyToken()\r\n");

        }

        if(hasEntityPropertyInfo && entityPropertyInfo?.Enum != null)
        {
            usingNamespaceSet.Add(entityPropertyInfo.Enum.UsingNamespace);
            //https://docs.microsoft.com/zh-cn/ef/core/modeling/value-conversions

            var propertyClrType = property.ClrType;
            var isNullableType = propertyClrType.IsGenericType && propertyClrType.GetGenericTypeDefinition() == typeof(Nullable<>);
            var ignoreNullableType = isNullableType ? propertyClrType.GetGenericArguments()[0] : propertyClrType;
            if(ignoreNullableType == typeof(string))
            {

            this.Write("                .HasConversion(new EnumToStringConverter<");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityPropertyInfo.Enum.Name));
            this.Write(">())\r\n");

            }
            else
            {

            this.Write("                .HasConversion(new EnumToNumberConverter<");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityPropertyInfo.Enum.Name));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Reference(ignoreNullableType)));
            this.Write(">())\r\n");

            }
        }

        if (originalPropertyComment != null)
        {

            this.Write("                .HasComment(@\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(originalPropertyComment.Replace("\"","\"\"")));
            this.Write("\")\r\n");

        }

        var propertyConfiguration = GenerationEnvironment.ToString();
        GenerationEnvironment = originalGenerationEnvironment;

        if (propertyConfiguration.Length != 0)
        {

            this.Write("            builder.Property(e => e.");
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            this.Write(")\r\n                ");
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyConfiguration.Trim()));
            this.Write(";\r\n\r\n");

        }
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

    foreach (var foreignKey in EntityType.GetForeignKeys())
    {
        var originalGenerationEnvironment = GenerationEnvironment;
        GenerationEnvironment = new StringBuilder();

        if (!foreignKey.PrincipalKey.IsPrimaryKey())
        {

            this.Write("                .HasPrincipalKey");
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey.IsUnique ? "<" + foreignKey.PrincipalEntityType.Name + ">" : string.Empty));
            this.Write("(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Lambda(foreignKey.PrincipalKey.Properties)));
            this.Write(")\r\n");

        }


            this.Write("                .HasForeignKey");
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey.IsUnique ? "<" + foreignKey.DeclaringEntityType.Name + ">" : string.Empty));
            this.Write("(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Lambda(foreignKey.Properties)));
            this.Write(")\r\n");


        var defaultDeleteBehavior = foreignKey.IsRequired ? DeleteBehavior.Cascade : DeleteBehavior.ClientSetNull;
        if (foreignKey.DeleteBehavior != defaultDeleteBehavior)
        {

            this.Write("                .OnDelete(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(foreignKey.DeleteBehavior)));
            this.Write(")\r\n");

        }

        var relationshipConfiguration = GenerationEnvironment.ToString();
        GenerationEnvironment = originalGenerationEnvironment;


            this.Write("            builder.HasOne(");
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey.DependentToPrincipal != null ? "d => d." + foreignKey.DependentToPrincipal.Name : string.Empty));
            this.Write(").");
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey.IsUnique ? "WithOne" : "WithMany"));
            this.Write("(");
            this.Write(this.ToStringHelper.ToStringWithCulture(foreignKey.PrincipalToDependent != null ? "p => p." + foreignKey.PrincipalToDependent.Name : ""));
            this.Write(")\r\n                ");
            this.Write(this.ToStringHelper.ToStringWithCulture(relationshipConfiguration.Trim()));
            this.Write(";\r\n\r\n");

    }

            this.Write("            ConfigurePartial(builder);\r\n        }\r\n\r\n        partial void Configu" +
                    "rePartial(EntityTypeBuilder<");
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityClassName));
            this.Write("> builder);\r\n    }\r\n}\r\n");
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

private string _ContextNamespaceField;

/// <summary>
/// Access the ContextNamespace parameter of the template.
/// </summary>
private string ContextNamespace
{
    get
    {
        return this._ContextNamespaceField;
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

private global::Microsoft.EntityFrameworkCore.Design.IAnnotationCodeGenerator _AnnotationCodeField;

/// <summary>
/// Access the AnnotationCode parameter of the template.
/// </summary>
private global::Microsoft.EntityFrameworkCore.Design.IAnnotationCodeGenerator AnnotationCode
{
    get
    {
        return this._AnnotationCodeField;
    }
}

private string _ConfigurationNamespaceField;

/// <summary>
/// Access the ConfigurationNamespace parameter of the template.
/// </summary>
private string ConfigurationNamespace
{
    get
    {
        return this._ConfigurationNamespaceField;
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

private string _EntityConfigurationNameField;

/// <summary>
/// Access the EntityConfigurationName parameter of the template.
/// </summary>
private string EntityConfigurationName
{
    get
    {
        return this._EntityConfigurationNameField;
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
bool ContextNamespaceValueAcquired = false;
if (this.Session.ContainsKey("ContextNamespace"))
{
    this._ContextNamespaceField = ((string)(this.Session["ContextNamespace"]));
    ContextNamespaceValueAcquired = true;
}
if ((ContextNamespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ContextNamespace");
    if ((data != null))
    {
        this._ContextNamespaceField = ((string)(data));
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
bool AnnotationCodeValueAcquired = false;
if (this.Session.ContainsKey("AnnotationCode"))
{
    this._AnnotationCodeField = ((global::Microsoft.EntityFrameworkCore.Design.IAnnotationCodeGenerator)(this.Session["AnnotationCode"]));
    AnnotationCodeValueAcquired = true;
}
if ((AnnotationCodeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("AnnotationCode");
    if ((data != null))
    {
        this._AnnotationCodeField = ((global::Microsoft.EntityFrameworkCore.Design.IAnnotationCodeGenerator)(data));
    }
}
bool ConfigurationNamespaceValueAcquired = false;
if (this.Session.ContainsKey("ConfigurationNamespace"))
{
    this._ConfigurationNamespaceField = ((string)(this.Session["ConfigurationNamespace"]));
    ConfigurationNamespaceValueAcquired = true;
}
if ((ConfigurationNamespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ConfigurationNamespace");
    if ((data != null))
    {
        this._ConfigurationNamespaceField = ((string)(data));
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
bool EntityConfigurationNameValueAcquired = false;
if (this.Session.ContainsKey("EntityConfigurationName"))
{
    this._EntityConfigurationNameField = ((string)(this.Session["EntityConfigurationName"]));
    EntityConfigurationNameValueAcquired = true;
}
if ((EntityConfigurationNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("EntityConfigurationName");
    if ((data != null))
    {
        this._EntityConfigurationNameField = ((string)(data));
    }
}


    }
}


    }
}
