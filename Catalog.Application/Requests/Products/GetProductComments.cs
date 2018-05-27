﻿using System.Collections.Generic;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProductImages : IRequest<IEnumerable<Image>>
    {
        public int ProductId { get; set; }
    }
}