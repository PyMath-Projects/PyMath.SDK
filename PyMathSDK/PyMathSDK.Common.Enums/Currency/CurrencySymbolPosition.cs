using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace PyMathSDK.Common.Enums.Currency;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum CurrencySymbolPosition
{
    [Description("Before Amount")]
    BeforeAmount,

    [Description("After Amount")]
    AfterAmount
}