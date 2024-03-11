﻿using System.Management.Automation.Runspaces;
using ActiveDirectoryQuerier.PowerShell;

namespace ActiveDirectoryQuerier.Tests;

public class AdCommandParametersTests
{
    [Fact]
    public void AvailableParameters_AvailableParametersNotPopulated_NoValidCommandProvided()
    {
        // Arrange
        ADCommandParameters adCommandParameters = new();

        // Assert
        Assert.Contains("No valid command provided", adCommandParameters.AvailableParameters);
    }

    [Fact]
    public async Task LoadParametersAsync_PopulatesAvailableParameters_IsNotEmpty()
    {
        // Arrange
        ADCommandParameters adCommandParameters = new();
        Command command = new("Get-Process");

        // Act
        await adCommandParameters.LoadAvailableParametersAsync(command);

        // Assert
        Assert.NotEmpty(adCommandParameters.AvailableParameters);
    }

    [Fact]
    public async Task LoadParametersAsync_CheckAvailableParameters_ContainsNameAndId()
    {
        // Arrange
        ADCommandParameters adCommandParameters = new();
        Command command = new("Get-Process");

        // Act
        await adCommandParameters.LoadAvailableParametersAsync(command);

        // Assert
        Assert.Contains("-Name", adCommandParameters.AvailableParameters);
        Assert.Contains("-Id", adCommandParameters.AvailableParameters);
    }
}
