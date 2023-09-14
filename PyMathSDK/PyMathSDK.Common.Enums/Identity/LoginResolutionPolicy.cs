using System.ComponentModel;

namespace PyMathSDK.Common.Enums.Identity;

public enum LoginResolutionPolicy
{
    [Description("Username")]
    Username=1,
    
    [Description("Email")]
    Email=2,
}