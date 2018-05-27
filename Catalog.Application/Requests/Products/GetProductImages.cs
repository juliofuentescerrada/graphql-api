﻿using System.Collections.Generic;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProductComments : IRequest<IEnumerable<Comment>>
    {
        public int ProductId { get; set; }
    }
}