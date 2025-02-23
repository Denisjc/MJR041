﻿using System.Net;
using System.Net.Http;
using Microsoft.Azure.Cosmos;

namespace Data.CosmosDb.Helpers
{
    internal static class ItemResponseResultExtensions
    {
        internal static void EnsureSuccessStatusCode<TEntity>(
            this ItemResponse<TEntity> itemResponse)
        {
            switch (itemResponse.StatusCode)
            {
                case HttpStatusCode.Created:
                case HttpStatusCode.OK:
                case HttpStatusCode.NoContent:
                    break;
                default:
                    throw new HttpRequestException(
                        $"Something went wrong in Cosmos operation, a {itemResponse.StatusCode} status code was returned.");
            }
        }
    }
}
