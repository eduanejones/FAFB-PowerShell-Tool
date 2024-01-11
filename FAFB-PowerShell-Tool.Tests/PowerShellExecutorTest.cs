﻿using FAFB_PowerShell_Tool.PowerShell.Commands;

namespace FAFB_PowerShell_Tool.Tests;

public class PowerShellExecutorTest
{
    [Fact]
    public void CommandNameIsCorrect()
    {
        InternalCommand command = new("Get-ADUser");
        Assert.Equal("Get-ADUser",  command.CommandName);
    }

    [Fact]
    public void CommandNameThrowsArgumentExceptionWhenNull()
    {
        Assert.Throws<ArgumentException>(() => new InternalCommand(null!));
    }

    [Fact]
    public void CommandNameThrowsArgumentExceptionWhenWhitespace()
    {
        Assert.Throws<ArgumentException>(() => new InternalCommand(""));
        Assert.Throws<ArgumentException>(() => new InternalCommand(" "));
        Assert.Throws<ArgumentException>(() => new InternalCommand(string.Empty));
    }
}
