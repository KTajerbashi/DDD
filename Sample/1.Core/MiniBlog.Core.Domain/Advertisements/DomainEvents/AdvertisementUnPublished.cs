﻿using DDD.Core.Domain.Library.Events;

namespace MiniBlog.Core.Domain.Advertisements.DomainEvents;

public sealed record AdvertisementUnPublished(Guid BusinessId, long Id) : IDomainEvent;
