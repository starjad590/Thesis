﻿using Domain.Abstractions;

namespace Domain.Entities;

public sealed class GraphicsCard : Entity<Guid>
{
    public string? Make { get; private set; }
    public string? Model { get; private set; }
    public string? Version { get; private set; }

    private GraphicsCard() { }

    private GraphicsCard(string make, string model, string version)
    {
        Id = Guid.NewGuid();
        Make = make;
        Model = model;
        Version = version;
    }

    public static GraphicsCard Create(string make, string model, string version)
        => new GraphicsCard(make, model, version);

    public bool Update(string? make, string? model, string? version)
    {
        bool isChanged = false;

        if (make is not null && make != Make)
        {
            Make = make;
            isChanged = true;
        }

        if (model is not null && model != Model)
        {
            Model = model;
            isChanged = true;
        }

        if (version is not null && version != Version)
        {
            Version = version;
            isChanged = true;
        }

        return isChanged;
    }
}
