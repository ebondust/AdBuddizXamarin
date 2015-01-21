using System;
using ObjCRuntime;

[assembly: LinkWith ("libAdBuddiz.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
