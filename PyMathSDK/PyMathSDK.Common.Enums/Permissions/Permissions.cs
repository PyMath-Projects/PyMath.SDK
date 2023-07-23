using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace PyMathSDK.Common.Enums.Permissions;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum Permissions
{
    [Description("None")]
    None = 0,

    [Description("Read")]
    Read = 1 << 0,      // 1

    [Description("Write")]
    Write = 1 << 1,     // 2

    [Description("Edit")]
    Edit = 1 << 2,      // 4

    [Description("Delete")]
    Delete = 1 << 3,    // 8

    [Description("Execute")]
    Execute = 1 << 4,   // 16

    [Description("Create")]
    Create = 1 << 5,    // 32

    [Description("Update")]
    Update = 1 << 6,    // 64

    [Description("View")]
    View = 1 << 7,      // 128

    [Description("Upload")]
    Upload = 1 << 8,    // 256

    [Description("Download")]
    Download = 1 << 9,  // 512

    [Description("Share")]
    Share = 1 << 10,    // 1024

    [Description("Approve")]
    Approve = 1 << 11,  // 2048

    [Description("Reject")]
    Reject = 1 << 12,   // 4096

    [Description("Administrate")]
    Administrate = 1 << 13,  // 8192

    [Description("Execute Script")]
    ExecuteScript = 1 << 14, // 16384

    [Description("Export")]
    Export = 1 << 15,   // 32768

    [Description("Import")]
    Import = 1 << 16,   // 65536

    [Description("Manage Users")]
    ManageUsers = 1 << 17,   // 131072

    [Description("View Audit Trail")]
    ViewAuditTrail = 1 << 18,   // 262144

    [Description("Change Settings")]
    ChangeSettings = 1 << 19,   // 524288

    [Description("Override")]
    Override = 1 << 20,   // 1048576

    [Description("Assign Roles")]
    AssignRoles = 1 << 21,   // 2097152

    [Description("Approve Payments")]
    ApprovePayments = 1 << 22,   // 4194304

    [Description("View Reports")]
    ViewReports = 1 << 23,   // 8388608
}