﻿using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public interface ILinkBusiness
    {
        Link CreateLink(string name, string url, DateTime expiryDate, string? description);
    }
}