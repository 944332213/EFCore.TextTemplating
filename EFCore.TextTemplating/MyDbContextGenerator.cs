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
    using Microsoft.EntityFrameworkCore.Scaffolding;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class MyDbContextGenerator : EFCore.TextTemplating.MyCodeGeneratorBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using Microsoft.EntityFrameworkCore;\r\nusing ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ModelNamespace));
            this.Write(";\r\n\r\nnamespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            this.Write("\r\n{\r\n    public partial class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ContextName));
            this.Write(" : DbContext\r\n    {\r\n");

    foreach (var entityType in Model.GetEntityTypes())
    {

            this.Write("        public virtual DbSet<");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityType.Name));
            this.Write("> ");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityType["Scaffolding:DbSetName"]));
            this.Write(" { get; set; }\r\n");

    }


            this.Write("\r\n        protected override void OnConfiguring(DbContextOptionsBuilder options)\r" +
                    "\n            => options");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Fragment(ProviderCode.GenerateUseProvider(ConnectionString))));
            this.Write(";\r\n\r\n        protected override void OnModelCreating(ModelBuilder modelBuilder)\r\n" +
                    "        {\r\n");

    foreach (var entityType in Model.GetEntityTypes())
    {

            this.Write("            modelBuilder.ApplyConfiguration(new ");
            this.Write(this.ToStringHelper.ToStringWithCulture(entityType.Name));
            this.Write("Configuration());\r\n");

    }

            this.Write("        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }

private global::Microsoft.EntityFrameworkCore.Metadata.IModel _ModelField;

/// <summary>
/// Access the Model parameter of the template.
/// </summary>
private global::Microsoft.EntityFrameworkCore.Metadata.IModel Model
{
    get
    {
        return this._ModelField;
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

private string _ContextNameField;

/// <summary>
/// Access the ContextName parameter of the template.
/// </summary>
private string ContextName
{
    get
    {
        return this._ContextNameField;
    }
}

private string _ConnectionStringField;

/// <summary>
/// Access the ConnectionString parameter of the template.
/// </summary>
private string ConnectionString
{
    get
    {
        return this._ConnectionStringField;
    }
}

private bool _SuppressConnectionStringWarningField;

/// <summary>
/// Access the SuppressConnectionStringWarning parameter of the template.
/// </summary>
private bool SuppressConnectionStringWarning
{
    get
    {
        return this._SuppressConnectionStringWarningField;
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

private global::Microsoft.EntityFrameworkCore.Scaffolding.IProviderConfigurationCodeGenerator _ProviderCodeField;

/// <summary>
/// Access the ProviderCode parameter of the template.
/// </summary>
private global::Microsoft.EntityFrameworkCore.Scaffolding.IProviderConfigurationCodeGenerator ProviderCode
{
    get
    {
        return this._ProviderCodeField;
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


/// <summary>
/// Initialize the template
/// </summary>
public override void Initialize()
{
    base.Initialize();
    if ((this.Errors.HasErrors == false))
    {
bool ModelValueAcquired = false;
if (this.Session.ContainsKey("Model"))
{
    this._ModelField = ((global::Microsoft.EntityFrameworkCore.Metadata.IModel)(this.Session["Model"]));
    ModelValueAcquired = true;
}
if ((ModelValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Model");
    if ((data != null))
    {
        this._ModelField = ((global::Microsoft.EntityFrameworkCore.Metadata.IModel)(data));
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
bool ContextNameValueAcquired = false;
if (this.Session.ContainsKey("ContextName"))
{
    this._ContextNameField = ((string)(this.Session["ContextName"]));
    ContextNameValueAcquired = true;
}
if ((ContextNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ContextName");
    if ((data != null))
    {
        this._ContextNameField = ((string)(data));
    }
}
bool ConnectionStringValueAcquired = false;
if (this.Session.ContainsKey("ConnectionString"))
{
    this._ConnectionStringField = ((string)(this.Session["ConnectionString"]));
    ConnectionStringValueAcquired = true;
}
if ((ConnectionStringValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ConnectionString");
    if ((data != null))
    {
        this._ConnectionStringField = ((string)(data));
    }
}
bool SuppressConnectionStringWarningValueAcquired = false;
if (this.Session.ContainsKey("SuppressConnectionStringWarning"))
{
    this._SuppressConnectionStringWarningField = ((bool)(this.Session["SuppressConnectionStringWarning"]));
    SuppressConnectionStringWarningValueAcquired = true;
}
if ((SuppressConnectionStringWarningValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("SuppressConnectionStringWarning");
    if ((data != null))
    {
        this._SuppressConnectionStringWarningField = ((bool)(data));
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
bool ProviderCodeValueAcquired = false;
if (this.Session.ContainsKey("ProviderCode"))
{
    this._ProviderCodeField = ((global::Microsoft.EntityFrameworkCore.Scaffolding.IProviderConfigurationCodeGenerator)(this.Session["ProviderCode"]));
    ProviderCodeValueAcquired = true;
}
if ((ProviderCodeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ProviderCode");
    if ((data != null))
    {
        this._ProviderCodeField = ((global::Microsoft.EntityFrameworkCore.Scaffolding.IProviderConfigurationCodeGenerator)(data));
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


    }
}


    }
}
