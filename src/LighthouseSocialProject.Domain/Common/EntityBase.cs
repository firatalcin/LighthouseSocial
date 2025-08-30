﻿namespace LighthouseSocialProject.Domain.Common;

public abstract class EntityBase
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}