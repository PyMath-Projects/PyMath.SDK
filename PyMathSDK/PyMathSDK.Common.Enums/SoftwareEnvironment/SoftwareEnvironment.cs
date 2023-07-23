using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace PyMathSDK.Common.Enums.SoftwareEnvironment;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum SoftwareEnvironment
{
    [Description("Development")]
    Dev = 1,

    [Description("Staging")]
    Staging = 2,

    [Description("Production")]
    Prod = 3,
    
    [Description("Quality Assurance")]
    QA = 4,
    
    [Description("Integration")]
    Integration = 5,
    
    [Description("User Acceptance Testing")]
    UAT = 6,
    
    [Description("Pre-Production")]
    PreProd = 7,
    
    [Description("Disaster Recovery")]
    DR = 8,
    
    [Description("Sandbox")]
    Sandbox = 9,
    
    [Description("Continuous Integration")]
    CI = 10,
    
    [Description("Continuous Deployment")]
    CD = 11,
}