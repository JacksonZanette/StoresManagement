﻿using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Models.ValueObjects;

namespace StoresManagement.Application.Stores.GetStore;
public sealed record GetStoreResponse(Guid Id, string Name, Address Address)
{
    public static GetStoreResponse FromEntity(Store store)
        => new(store.Id, store.Name, store.Address);
}